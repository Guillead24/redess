using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_U2_Proyecto_Integrador_de_Redes.ClsConfiguracionDNS;

namespace Proyecto_U2_Proyecto_Integrador_de_Redes
{
    internal class ClsGestorClientes
    {
        private List<ClsAgregarCliente> _listaClientes = new List<ClsAgregarCliente>();
        private readonly object _lock = new object();
        private Random _random = new Random();

        // NUEVA: Propiedades de red
        public string RedActual { get; private set; }
        public string MascaraActual { get; private set; }
        public string BroadcastActual { get; private set; }

        public List<ClsAgregarCliente> ListaClientes
        {
            get { lock (_lock) { return _listaClientes.ToList(); } }
        }

        // ==========================================================
        // NUEVO: MÉTODO PARA GENERAR 20 CLIENTES AUTOMÁTICAMENTE
        // ==========================================================
        public async Task GenerarClientesAutomaticosAsync(string ipInicio, string ipFin, string mascara)
        {
            // Listas de datos para aleatoriedad
            string[] nombresBase = { "PC-Admin", "Laptop-Soporte", "SmartTV-Comedor", "Consola-Gaming", "Celular-Visita", "Tablet-RRHH", "Servidor-App", "Workstation-UX" };
            string[] tiposBase = { "PC", "Laptop", "Tv", "Consola", "Celular" };

            // Pool de dominios para simular diferentes pertenencias en cada reinicio
            string[] dominiosSimulados = {
                "google.com", "microsoft.com", "github.com", "uabc.mx", "amazon.com",
                "netflix.com", "facebook.com", "wikipedia.org", "apple.com", "cisco.com",
                "unison.mx", "tecmilenio.edu", "nasa.gov", "openai.com", "arduino.cc"
            };

            for (int i = 1; i <= 20; i++)
            {
                // Seleccionar nombre y tipo al azar
                string nombreAleatorio = $"{nombresBase[_random.Next(nombresBase.Length)]}_{i}";
                string tipoAleatorio = tiposBase[_random.Next(tiposBase.Length)];

                // 1. Agregar el cliente a la red
                var clienteNuevo = await AgregarClienteAsync(nombreAleatorio, tipoAleatorio, ipInicio, ipFin, mascara);

                // 2. Si se agregó correctamente y tenemos DNS configurados, vincularlo a un dominio aleatorio
                if (clienteNuevo != null && _listaDNS.Count > 0)
                {
                    // Elegir un servidor DNS de los que ya existen en el sistema al azar
                    var dnsServidorAzar = _listaDNS[_random.Next(_listaDNS.Count)];

                    // Elegir un dominio al azar del pool
                    string dominioAzar = dominiosSimulados[_random.Next(dominiosSimulados.Length)];

                    // Resolvemos el DNS para este cliente (esto llena la bitácora y el TreeView)
                    int ultimoIndice = _listaClientes.Count - 1;
                    ResolverDNSConVerificacion(dominioAzar, ultimoIndice, dnsServidorAzar.Nombre);
                }
            }
        }

        // --- NUEVO: Cálculos de máscara de subred ---
        private uint ObtenerMascaraBits(string mascara)
        {
            try
            {
                IPAddress address = IPAddress.Parse(mascara);
                byte[] bytes = address.GetAddressBytes();
                uint mascaraUint = (uint)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);

                // Contar bits en 1 (CIDR)
                int bits = 0;
                uint temp = mascaraUint;
                while (temp != 0)
                {
                    bits += (int)(temp & 1);
                    temp >>= 1;
                }
                return mascaraUint;
            }
            catch
            {
                return 0xFFFFFF00; // 255.255.255.0 por defecto
            }
        }

        private string CalcularBroadcast(string ip, string mascara)
        {
            uint ipUint = IpToUint(ip);
            uint mascaraUint = IpToUint(mascara);
            uint broadcastUint = ipUint | ~mascaraUint;
            return UintToIp(broadcastUint);
        }

        private bool ValidarIPenRed(string ip, string red, string mascara)
        {
            uint ipUint = IpToUint(ip);
            uint redUint = IpToUint(red);
            uint mascaraUint = IpToUint(mascara);

            // Aplicar máscara a la IP y comparar con la red
            return (ipUint & mascaraUint) == redUint;
        }

        // --- MOTOR DE SIMULACIÓN ---
        public void SimularConsumo()
        {
            lock (_lock)
            {
                foreach (var c in _listaClientes)
                {
                    c.ConsumoActual = c.Activo ? Math.Round(_random.NextDouble() * c.MbpsMaximos, 2) : 0;
                }
            }
        }

        // --- CÁLCULOS DE IP ---
        private uint IpToUint(string ip)
        {
            try
            {
                IPAddress address = IPAddress.Parse(ip);
                byte[] bytes = address.GetAddressBytes();
                return (uint)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);
            }
            catch
            {
                return 0;
            }
        }

        private string UintToIp(uint value)
        {
            return $"{((value >> 24) & 0xFF)}.{((value >> 16) & 0xFF)}.{((value >> 8) & 0xFF)}.{((value) & 0xFF)}";
        }

        // NUEVO: Método para configurar la red
        public void ConfigurarRed(string red, string mascara)
        {
            if (!IPAddress.TryParse(red, out _))
                MessageBox.Show("Dirección de red inválida.");

            if (!IPAddress.TryParse(mascara, out _))
                MessageBox.Show("Máscara de subred inválida.");

            RedActual = red;
            MascaraActual = mascara;
            BroadcastActual = CalcularBroadcast(red, mascara);
        }

        public async Task<ClsAgregarCliente> AgregarClienteAsync(string nombre, string tipo, string ipInicio, string ipFin, string mascara = null)
        {
            uint inicio = IpToUint(ipInicio);
            uint fin = IpToUint(ipFin);

            if (inicio == 0 || fin == 0)
                MessageBox.Show("Dirección IP inválida.");

            if (inicio > fin)
                MessageBox.Show("La IP de inicio debe ser menor o igual a la IP final.");

            // Validar que las IPs estén en la misma red si hay máscara
            if (!string.IsNullOrEmpty(mascara) && !string.IsNullOrEmpty(RedActual))
            {
                if (!ValidarIPenRed(ipInicio, RedActual, mascara) || !ValidarIPenRed(ipFin, RedActual, mascara))
                    MessageBox.Show($"Las IPs deben estar en la red {RedActual} con máscara {mascara}");
            }

            var cliente = new ClsAgregarCliente(nombre, tipo);

            // Asignar máscara al cliente
            if (!string.IsNullOrEmpty(mascara))
                cliente.MascaraSubred = mascara;
            else if (!string.IsNullOrEmpty(MascaraActual))
                cliente.MascaraSubred = MascaraActual;

            lock (_lock)
            {
                // Obtener todas las IPs ocupadas por clientes ACTIVOS
                HashSet<uint> ipsOcupadas = new HashSet<uint>(
                    _listaClientes
                        .Where(c => c.Activo && !string.IsNullOrEmpty(c.IP))
                        .Select(c => IpToUint(c.IP))
                );

                // Buscar primera IP libre
                uint ipAsignada = 0;
                for (uint i = inicio; i <= fin; i++)
                {
                    if (!ipsOcupadas.Contains(i))
                    {
                        ipAsignada = i;
                        break;
                    }
                }

                if (ipAsignada == 0)
                {
                    MessageBox.Show($"No hay IPs libres en el rango {ipInicio} - {ipFin}. ");
                    return null;  // ⭐ AGREGAR ESTO - No agregar el cliente
                }

                cliente.IP = UintToIp(ipAsignada);


                // Calcular broadcast para este cliente
                if (!string.IsNullOrEmpty(cliente.MascaraSubred))
                {
                    cliente.Broadcast = CalcularBroadcast(cliente.IP, cliente.MascaraSubred);
                }

                cliente.MAC = GenerarMACAleatorio();
                cliente.Hostname = nombre;
                cliente.Activo = true;
                cliente.UltimaIP = cliente.IP;

                _listaClientes.Add(cliente);
            }

            await Task.Delay(50);
            return cliente;
        }

        private string GenerarMACAleatorio()
        {
            byte[] macBytes = new byte[6];
            _random.NextBytes(macBytes);
            macBytes[0] = (byte)(macBytes[0] & 0xFE | 0x02);
            return string.Join(":", macBytes.Select(b => b.ToString("X2")));
        }

        public (int usadas, int libres) ObtenerEstadisticas(string ipInicio, string ipFin)
        {
            try
            {
                uint inicio = IpToUint(ipInicio);
                uint fin = IpToUint(ipFin);

                if (inicio == 0 || fin == 0 || inicio > fin)
                    return (0, 0);

                long totalRango = (long)fin - (long)inicio + 1;

                int usadas = 0;
                lock (_lock)
                {
                    usadas = _listaClientes.Count(c =>
                        c.Activo &&
                        !string.IsNullOrEmpty(c.IP) &&
                        IpToUint(c.IP) >= inicio &&
                        IpToUint(c.IP) <= fin
                    );
                }

                int libres = (int)totalRango - usadas;

                return (usadas, libres);
            }
            catch
            {
                return (0, 0);
            }
        }

        public void EliminarCliente(int index)
        {
            lock (_lock)
            {
                if (index >= 0 && index < _listaClientes.Count)
                {
                    _listaClientes.RemoveAt(index);
                }
            }
        }

        public void ActualizarCliente(int index, string mac, string ip, string host, bool activo, string mascara = null, string ipInicio = null, string ipFin = null)
        {
            lock (_lock)
            {
                if (index < 0 || index >= _listaClientes.Count)
                    MessageBox.Show("Índice de cliente inválido.");

                var clienteAModificar = _listaClientes[index];
                string ipAnterior = clienteAModificar.IP;

                // Validar máscara si se proporciona
                if (!string.IsNullOrEmpty(mascara) && !IPAddress.TryParse(mascara, out _))
                    MessageBox.Show("Máscara de subred inválida.");

                // CASO ESPECIAL: Activando un cliente inactivo
                if (activo && !clienteAModificar.Activo)
                {
                    string ipIntentar = !string.IsNullOrEmpty(ip) ? ip : clienteAModificar.UltimaIP;

                    if (!string.IsNullOrEmpty(ipIntentar))
                    {
                        // Verificar si la IP está dentro del rango
                        if (!string.IsNullOrEmpty(ipInicio) && !string.IsNullOrEmpty(ipFin))
                        {
                            uint ipNum = IpToUint(ipIntentar);
                            uint inicioNum = IpToUint(ipInicio);
                            uint finNum = IpToUint(ipFin);

                            if (ipNum >= inicioNum && ipNum <= finNum)
                            {
                                // Verificar que nadie más tenga esta IP ACTIVA
                                bool ipOcupada = _listaClientes
                                    .Where((c, i) => i != index && c.Activo && c.IP == ipIntentar)
                                    .Any();

                                if (!ipOcupada)
                                {
                                    // ¡La IP está libre! Asignarla
                                    clienteAModificar.IP = ipIntentar;
                                    clienteAModificar.MAC = mac;
                                    clienteAModificar.Hostname = string.IsNullOrEmpty(host) ? clienteAModificar.Nombre : host;
                                    clienteAModificar.Activo = true;
                                    clienteAModificar.UltimaIP = ipIntentar;

                                    // Actualizar máscara si se proporciona
                                    if (!string.IsNullOrEmpty(mascara))
                                        clienteAModificar.MascaraSubred = mascara;

                                    // Recalcular broadcast
                                    clienteAModificar.Broadcast = CalcularBroadcast(clienteAModificar.IP, clienteAModificar.MascaraSubred);

                                    return;
                                }
                            }
                        }
                    }

                    // Si no pudo recuperar su IP, asignar una nueva
                    AsignarNuevaIPAlActivar(clienteAModificar, index, mac, host, mascara, ipInicio, ipFin);
                    return;
                }

                // CASO NORMAL
                if (!string.IsNullOrEmpty(ip) && ip != ipAnterior)
                {
                    // Validar que la nueva IP esté dentro del rango
                    if (!string.IsNullOrEmpty(ipInicio) && !string.IsNullOrEmpty(ipFin))
                    {
                        uint ipNum = IpToUint(ip);
                        uint inicioNum = IpToUint(ipInicio);
                        uint finNum = IpToUint(ipFin);

                        if (ipNum < inicioNum || ipNum > finNum)
                            MessageBox.Show($"La IP {ip} está fuera del rango permitido ({ipInicio} - {ipFin}).");
                    }

                    // Validar que la nueva IP no esté ocupada
                    bool ipOcupada = _listaClientes
                        .Where((c, i) => i != index && c.Activo && c.IP == ip)
                        .Any();

                    if (ipOcupada)
                        MessageBox.Show($"La IP {ip} ya está siendo utilizada por otro cliente activo.");
                }

                // Actualizar el cliente
                clienteAModificar.MAC = mac;
                clienteAModificar.IP = ip;
                clienteAModificar.Hostname = string.IsNullOrEmpty(host) ? clienteAModificar.Nombre : host;
                clienteAModificar.Activo = activo;

                if (!string.IsNullOrEmpty(mascara))
                    clienteAModificar.MascaraSubred = mascara;

                // Recalcular broadcast
                if (!string.IsNullOrEmpty(clienteAModificar.IP) && !string.IsNullOrEmpty(clienteAModificar.MascaraSubred))
                {
                    clienteAModificar.Broadcast = CalcularBroadcast(clienteAModificar.IP, clienteAModificar.MascaraSubred);
                }

                if (activo && !string.IsNullOrEmpty(ip))
                {
                    clienteAModificar.UltimaIP = ip;
                }
            }
        }

        private void AsignarNuevaIPAlActivar(ClsAgregarCliente cliente, int index, string mac, string host, string mascara, string ipInicio, string ipFin)
        {
            if (string.IsNullOrEmpty(ipInicio) || string.IsNullOrEmpty(ipFin))
                MessageBox.Show("Se necesita el rango de IPs para asignar una nueva dirección.");

            uint inicio = IpToUint(ipInicio);
            uint fin = IpToUint(ipFin);

            HashSet<uint> ipsOcupadas = new HashSet<uint>(
                _listaClientes
                    .Where((c, i) => i != index && c.Activo && !string.IsNullOrEmpty(c.IP))
                    .Select(c => IpToUint(c.IP))
            );

            uint nuevaIP = 0;
            for (uint i = inicio; i <= fin; i++)
            {
                if (!ipsOcupadas.Contains(i))
                {
                    nuevaIP = i;
                    break;
                }
            }

            if (nuevaIP == 0)
            {
                MessageBox.Show($"No hay IPs libres disponibles en el rango {ipInicio} - {ipFin} para activar el cliente. ");
                return;  // ⭐ AGREGAR ESTO - No modificar el cliente
            }

            string nuevaIPStr = UintToIp(nuevaIP);


            cliente.MAC = mac;
            cliente.IP = nuevaIPStr;
            cliente.Hostname = string.IsNullOrEmpty(host) ? cliente.Nombre : host;
            cliente.Activo = true;
            cliente.UltimaIP = nuevaIPStr;

            if (!string.IsNullOrEmpty(mascara))
                cliente.MascaraSubred = mascara;

            cliente.Broadcast = CalcularBroadcast(cliente.IP, cliente.MascaraSubred);
        }

        // === MÉTODOS DNS  ===


        //Resuelve un dominio a IP y guarda en la bitácora del cliente

        // Busca el método ResolverDNS y ACTUALÍZALO a esto:

        public string ResolverDNS(string dominio, int indiceCliente)
        {
            bool exito = false;
            string ipResuelta = "";
            string organizacion = "Desconocido";
            string pais = "No identificado";

            try
            {
                dominio = dominio.Replace("http://", "").Replace("https://", "")
                                .Replace("www.", "").Trim();

                if (string.IsNullOrEmpty(dominio))
                    throw new ArgumentException("Dominio vacío");

                IPHostEntry host = Dns.GetHostEntry(dominio);
                ipResuelta = host.AddressList
                    .FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                    .ToString() ?? host.AddressList[0].ToString();

                // Detectar organización
                var infoDominio = ClsDetectarDominio.Analizar(dominio);
                organizacion = infoDominio.Tipo;
                pais = infoDominio.Pais;

                exito = true;
            }
            catch (Exception ex)
            {
                ipResuelta = $"Error: {ex.Message}";
                exito = false;
            }

            // Guardar en bitácora del cliente
            if (indiceCliente >= 0 && indiceCliente < _listaClientes.Count)
            {
                var cliente = _listaClientes[indiceCliente];

                // Guardar en bitácora del cliente
                var entradaBitacora = new ClsBitacoraDNS(dominio, ipResuelta, organizacion, pais, exito);
                cliente.BitacoraDNS.Add(entradaBitacora);

                // ⭐ Guardar en el DNS seleccionado (con nombre del cliente)
                AgregarConsultaADNS(dominio, ipResuelta, cliente.Nombre, exito);
            }

            return ipResuelta;
        }

        public ClsDetectarDominio ObtenerInfoDominio(string dominio)
        {
            return ClsDetectarDominio.Analizar(dominio);
        }

        public List<ClsBitacoraDNS> ObtenerBitacoraDNS(int indiceCliente)
        {
            if (indiceCliente >= 0 && indiceCliente < _listaClientes.Count)
            {
                return _listaClientes[indiceCliente].BitacoraDNS
                       .OrderByDescending(b => b.Fecha)
                       .ToList();
            }
            return new List<ClsBitacoraDNS>();
        }


        // === NUEVO: Lista de configuraciones DNS ===
        private List<ClsConfiguracionDNS> _listaDNS = new List<ClsConfiguracionDNS>();
        private ClsConfiguracionDNS _dnsSeleccionado = null;

        public List<ClsConfiguracionDNS> ListaDNS
        {
            get { lock (_lock) { return _listaDNS.ToList(); } }
        }

        public ClsConfiguracionDNS DNSSeleccionado
        {
            get { return _dnsSeleccionado; }
        }

        // === MÉTODOS PARA GESTIONAR DNS ===

        public void AgregarDNS(string nombre, string primario, string secundario)
        {
            lock (_lock)
            {
                if (!System.Net.IPAddress.TryParse(primario, out _))
                {
                    MessageBox.Show("DNS Primario inválido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!System.Net.IPAddress.TryParse(secundario, out _))
                {
                    MessageBox.Show("DNS Secundario inválido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_listaDNS.Any(d => d.Nombre.ToLower() == nombre.ToLower()))
                {
                    MessageBox.Show("Ya existe un DNS con ese nombre", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dns = new ClsConfiguracionDNS(nombre, primario, secundario);
                _listaDNS.Add(dns);
            }
        }

        public void EliminarDNS(int indice)
        {
            lock (_lock)
            {
                if (indice >= 0 && indice < _listaDNS.Count)
                {
                    _listaDNS.RemoveAt(indice);

                    if (_dnsSeleccionado == _listaDNS.ElementAtOrDefault(indice))
                    {
                        _dnsSeleccionado = null;
                    }
                }
            }
        }

        public void SeleccionarDNS(int indice)
        {
            lock (_lock)
            {
                if (indice >= 0 && indice < _listaDNS.Count)
                {
                    foreach (var dns in _listaDNS)
                    {
                        dns.Activo = false;
                    }

                    _dnsSeleccionado = _listaDNS[indice];
                    _dnsSeleccionado.Activo = true;
                }
            }
        }



        // Agregar consulta al DNS seleccionado (con nombre de cliente)
        public void AgregarConsultaADNS(string dominio, string ip, string clienteNombre, bool exitoso)
        {
            lock (_lock)
            {
                if (_dnsSeleccionado != null)
                {
                    var consulta = new ClsConsultaDNS(dominio, ip, clienteNombre, exitoso);
                    _dnsSeleccionado.ConsultasRealizadas.Add(consulta);
                }
            }
        }

        public List<ClsConsultaDNS> ObtenerConsultasDNS(int indice)
        {
            lock (_lock)
            {
                if (indice >= 0 && indice < _listaDNS.Count)
                {
                    return _listaDNS[indice].ConsultasRealizadas
                           .OrderByDescending(c => c.Fecha)
                           .ToList();
                }
                return new List<ClsConsultaDNS>();
            }
        }

        public void LimpiarConsultasDNS(int indice)
        {
            lock (_lock)
            {
                if (indice >= 0 && indice < _listaDNS.Count)
                {
                    _listaDNS[indice].ConsultasRealizadas.Clear();
                }
            }
        }

        // ⭐ NUEVO: Resolver DNS verificando duplicados
        public string ResolverDNSConVerificacion(string dominio, int indiceCliente, string nombreDNSServer)
        {
            bool exito = false;
            string ipResuelta = "";
            string organizacion = "Desconocido";
            string pais = "No identificado";

            try
            {
                dominio = dominio.Replace("http://", "").Replace("https://", "")
                                .Replace("www.", "").Trim();

                if (string.IsNullOrEmpty(dominio))
                    throw new ArgumentException("Dominio vacío");

                IPHostEntry host = Dns.GetHostEntry(dominio);
                ipResuelta = host.AddressList
                    .FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?
                    .ToString() ?? host.AddressList[0].ToString();

                // Detectar organización
                var infoDominio = ClsDetectarDominio.Analizar(dominio);
                organizacion = infoDominio.Tipo;
                pais = infoDominio.Pais;

                exito = true;
            }
            catch (Exception ex)
            {
                ipResuelta = $"Error: {ex.Message}";
                exito = false;
            }

            // Guardar en bitácora del cliente
            if (indiceCliente >= 0 && indiceCliente < _listaClientes.Count)
            {
                var cliente = _listaClientes[indiceCliente];

                // Guardar en bitácora del cliente (siempre se guarda)
                var entradaBitacora = new ClsBitacoraDNS(dominio, ipResuelta, organizacion, pais, exito);
                cliente.BitacoraDNS.Add(entradaBitacora);

                // ⭐ Buscar el DNS por nombre
                var dnsServer = BuscarDNSPorNombre(nombreDNSServer);
                if (dnsServer != null)
                {
                    // ⭐ VERIFICAR DUPLICADOS: No agregar si ya existe para este cliente+dominio
                    bool yaExiste = dnsServer.ConsultasRealizadas.Any(c =>
                        c.ClienteNombre == cliente.Nombre &&
                        c.Dominio.ToLower() == dominio.ToLower());

                    if (!yaExiste)
                    {
                        var consulta = new ClsConsultaDNS(dominio, ipResuelta, cliente.Nombre, exito);
                        dnsServer.ConsultasRealizadas.Add(consulta);
                    }
                }
            }

            return ipResuelta;
        }

        // ⭐ AUXILIAR: Buscar DNS por nombre
        public ClsConfiguracionDNS BuscarDNSPorNombre(string nombreDNS)
        {
            lock (_lock)
            {
                if (string.IsNullOrEmpty(nombreDNS))
                    return null;

                return _listaDNS.FirstOrDefault(d =>
                    d.Nombre.ToLower() == nombreDNS.ToLower().Trim());
            }
        }

        // Agregar al final de la clase, antes del cierre }
        public void EliminarConsultaDNS(int indiceDNS, int indiceConsulta)
        {
            lock (_lock)
            {
                if (indiceDNS >= 0 && indiceDNS < _listaDNS.Count)
                {
                    var dns = _listaDNS[indiceDNS];
                    if (indiceConsulta >= 0 && indiceConsulta < dns.ConsultasRealizadas.Count)
                    {
                        dns.ConsultasRealizadas.RemoveAt(indiceConsulta);
                    }
                }
            }
        }
        // Agregar al final de la clase ClsGestorClientes, antes del cierre }
        // Agregar al final de la clase ClsGestorClientes, antes del cierre }
        public void EliminarConsultaEspecifica(int indiceDNS, string clienteNombre, string ipResuelta)
        {
            lock (_lock)
            {
                if (indiceDNS >= 0 && indiceDNS < _listaDNS.Count)
                {
                    var dns = _listaDNS[indiceDNS];

                    // Buscar la consulta específica por cliente e IP
                    var consultaAEliminar = dns.ConsultasRealizadas
                        .FirstOrDefault(c => c.ClienteNombre == clienteNombre && c.IPResuelta == ipResuelta);

                    if (consultaAEliminar != null)
                    {
                        dns.ConsultasRealizadas.Remove(consultaAEliminar);
                    }
                }
            }
        }
    }
}