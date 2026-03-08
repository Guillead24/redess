using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_U2_Proyecto_Integrador_de_Redes
{
    public partial class frmServ : Form
    {
        ClsGestorClientes gestorClientes = new ClsGestorClientes();
        int indiceSeleccionado = -1;
        private TreeNode _nodoDNSSeleccionado = null;

        public frmServ()
        {
            InitializeComponent();
            txtRed.Text = "192.168.0.1";
            txtTotalIP.Text = "192.168.0.254";
            txtsubred.Text = "255.255.255.0";
            gestorClientes.ConfigurarRed(txtRed.Text, txtsubred.Text);

            // Eventos de IP
            txtRed.TextChanged += (s, e) => ActualizarEstadisticasIP();
            txtTotalIP.TextChanged += (s, e) => ActualizarEstadisticasIP();
            txtsubred.TextChanged += (s, e) => {
                try
                {
                    gestorClientes.ConfigurarRed(txtRed.Text, txtsubred.Text);
                }
                catch { }
            };

            // Configuración inicial de simulación
            timerSimulacion.Interval = 1000;
            timerSimulacion.Tick += TimerSimulacion_Tick;
            btnDetener.Visible = false; // Oculto al inicio

            // Valores de red por defecto
            ActualizarEstadisticasIP();
            ActualizarDataGridView();

            // 1. Cargamos los DNS primero
            CargarDNSPorDefecto();

            // 2. LLAMADA NUEVA: Generar los 20 clientes automáticamente al iniciar
            InicializarEntornoAutomatico();

            // Configuración del menú contextual de DNS
            ContextMenuStrip menuDNS = new ContextMenuStrip();
            ToolStripMenuItem itemLimpiar = new ToolStripMenuItem("🗑️ Limpiar Consultas de este DNS");
            itemLimpiar.Click += (s, e) => {
                if (tVDNS.SelectedNode != null && tVDNS.SelectedNode.Level > 0)
                {
                    int indice = tVDNS.SelectedNode.Index;
                    gestorClientes.LimpiarConsultasDNS(indice);
                    ActualizarTreeViewDNS();
                }
            };
            menuDNS.Items.Add(itemLimpiar);
            tVDNS.ContextMenuStrip = menuDNS;
        }

        // ==========================================================
        // NUEVO: FUNCIÓN DE INICIALIZACIÓN AUTOMÁTICA
        // ==========================================================
        private async void InicializarEntornoAutomatico()
        {
            // Genera 20 clientes y los reparte en los dominios de forma aleatoria
            // Usamos los valores actuales de los TextBox de red
            await gestorClientes.GenerarClientesAutomaticosAsync(txtRed.Text, txtTotalIP.Text, txtsubred.Text);

            // Refrescamos toda la interfaz para mostrar los 20 clientes y sus DNS
            ActualizarListBox();
            ActualizarDataGridView();
            ActualizarEstadisticasIP();
            ActualizarTreeViewDNS();
        }

        // --- LÓGICA DE SIMULACIÓN ---

        private void btnSimular_Click(object sender, EventArgs e)
        {
            if (timerSimulacion.Enabled) // Acción: PAUSAR
            {
                timerSimulacion.Stop();
                btnSimular.Text = "Reanudar Simulación";
                btnSimular.BackColor = Color.Orange;
                btnDetener.Visible = true; // Aparece al pausar
            }
            else // Acción: INICIAR / REANUDAR
            {
                timerSimulacion.Start();
                btnSimular.Text = "Pausar Simulación";
                btnSimular.BackColor = Color.Yellow;
                btnDetener.Visible = false; // Desaparece al reanudar
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            timerSimulacion.Stop();
            btnDetener.Visible = false;
            btnSimular.Text = "Iniciar Simulación";
            btnSimular.BackColor = Color.LightGreen;

            lblTotalRed.Text = "Tráfico Total Red: 0 Mbps";
            lblConsumo.Text = "Consumo Actual: 0 Mbps";
            MessageBox.Show("Simulación terminada.");
        }

        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            try
            {
                gestorClientes.SimularConsumo();

                if (indiceSeleccionado >= 0)
                {
                    var c = gestorClientes.ListaClientes[indiceSeleccionado];
                    lblConsumo.Text = $"Consumo Actual: {c.ConsumoActual} Mbps";
                }

                double totalMbps = gestorClientes.ListaClientes.Sum(c => c.ConsumoActual);
                lblTotalRed.Text = $"Tráfico Total Red: {Math.Round(totalMbps, 2)} Mbps";

                ActualizarEstadisticasIP();
                ActualizarColumnaActivoEnGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Error durante la simulación. Verifique la configuración de red y los clientes.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- LÓGICA DE INTERFAZ Y CRUD ---

        private void ActualizarEstadisticasIP()
        {
            string ini = txtRed.Text.Trim();
            string fin = txtTotalIP.Text.Trim();

            if (System.Net.IPAddress.TryParse(ini, out _) && System.Net.IPAddress.TryParse(fin, out _))
            {
                var stats = gestorClientes.ObtenerEstadisticas(ini, fin);
                lblIpsUs.Text = $"IP Usadas: {stats.usadas}";
                lblIpLibres.Text = $"IP Libres: {stats.libres}";
                lblIpLibres.ForeColor = stats.libres <= 0 ? Color.Red : Color.Green;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            gbCrearC.Visible = true;
            gBDHCP.Visible = false;
            txtNombre.Clear();
            cBoxTipo.SelectedIndex = -1;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text) && cBoxTipo.SelectedIndex != -1)
            {
                btnGuardar.Enabled = false;
                try
                {
                    var cliente = await gestorClientes.AgregarClienteAsync(txtNombre.Text, cBoxTipo.Text, txtRed.Text, txtTotalIP.Text, txtsubred.Text);

                    if (cliente != null)
                    {
                        ActualizarListBox();
                        ActualizarDataGridView();
                        ActualizarEstadisticasIP();
                        gbCrearC.Visible = false;
                    }
                    ActualizarListBox();
                    ActualizarEstadisticasIP();

                    gbCrearC.Visible = false;
                    txtNombre.Clear();
                    cBoxTipo.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { btnGuardar.Enabled = true; }
            }
        }

        private void listCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCliente.SelectedIndex >= 0)
            {
                indiceSeleccionado = listCliente.SelectedIndex;
                var c = gestorClientes.ListaClientes[indiceSeleccionado];

                txtMac.Text = c.MAC;
                txtIP.Text = c.IP;
                txtHostName.Text = c.Hostname;
                txtMascaraCliente.Text = c.MascaraSubred;
                txtBroadcast.Text = $"{c.Broadcast ?? "N/A"}";
                CBAct.Checked = c.Activo;
                CBInac.Checked = !c.Activo;

                gBDHCP.Visible = true;
                gbCrearC.Visible = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (indiceSeleccionado >= 0)
                {
                    gestorClientes.ActualizarCliente(
                        indiceSeleccionado,
                        txtMac.Text,
                        txtIP.Text,
                        txtHostName.Text,
                        CBAct.Checked,
                        txtMascaraCliente.Text,
                        txtRed.Text,
                        txtTotalIP.Text
                    );
                }
                ActualizarListBox();
                ActualizarEstadisticasIP();

                txtMac.Clear();
                txtIP.Clear();
                txtHostName.Clear();
                CBAct.Checked = false;
                CBInac.Checked = false;
                gBDHCP.Visible = false;
                indiceSeleccionado = -1;

                MessageBox.Show("Cliente actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                CBInac.Checked = true;
                CBAct.Checked = false;
                MessageBox.Show($"Error al modificar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listCliente.SelectedIndex >= 0)
            {
                gestorClientes.EliminarCliente(listCliente.SelectedIndex);
                ActualizarListBox();
                ActualizarDataGridView();
                ActualizarEstadisticasIP();
                gBDHCP.Visible = false;
                indiceSeleccionado = -1;
            }
        }

        private void ActualizarListBox()
        {
            listCliente.Items.Clear();
            foreach (var c in gestorClientes.ListaClientes) listCliente.Items.Add(c.Nombre);
        }

        private void CBAct_CheckedChanged(object sender, EventArgs e)
        {
            if (CBAct.Checked) CBInac.Checked = false;
        }
        private void CBInac_CheckedChanged(object sender, EventArgs e)
        {
            if (CBInac.Checked) CBAct.Checked = false;
        }
        private void ActualizarDataGridView()
        {
            dgvClientes.Rows.Clear();

            foreach (var cliente in gestorClientes.ListaClientes)
            {
                int rowIndex = dgvClientes.Rows.Add();
                DataGridViewRow row = dgvClientes.Rows[rowIndex];

                row.Cells["colNombre"].Value = cliente.Nombre;
                row.Cells["colHostname"].Value = cliente.Hostname;
                row.Cells["colTipo"].Value = cliente.Tipo;
                row.Cells["colIP"].Value = cliente.IP ?? "Sin IP";
                row.Cells["colActivo"].Value = cliente.Activo;
                row.Tag = cliente;
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indiceSeleccionado = e.RowIndex;
                CargarDatosCliente(indiceSeleccionado);
                ActualizarBitacoraVisual();
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow?.Index >= 0)
            {
                indiceSeleccionado = dgvClientes.CurrentRow.Index;
                CargarDatosCliente(indiceSeleccionado);
                ActualizarBitacoraVisual();
            }
        }

        private void ActualizarColumnaActivoEnGrid()
        {
            var clientes = gestorClientes.ListaClientes;
            for (int i = 0; i < Math.Min(clientes.Count, dgvClientes.Rows.Count); i++)
            {
                dgvClientes.Rows[i].Cells["colActivo"].Value = clientes[i].Activo;
            }
        }

        private void CargarDatosCliente(int index)
        {
            if (index >= 0 && index < gestorClientes.ListaClientes.Count)
            {
                var c = gestorClientes.ListaClientes[index];
                txtMac.Text = c.MAC;
                txtIP.Text = c.IP;
                txtHostName.Text = c.Hostname;
                txtMascaraCliente.Text = c.MascaraSubred;
                txtBroadcast.Text = c.Broadcast ?? "N/A";
                CBAct.Checked = c.Activo;
                CBInac.Checked = !c.Activo;
                gBDHCP.Visible = true;
                gbCrearC.Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (indiceSeleccionado < 0)
            {
                MessageBox.Show("⚠️ Selecciona un cliente en la tabla primero", "Advertencia",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var clienteSeleccionado = gestorClientes.ListaClientes[indiceSeleccionado];

            if (!clienteSeleccionado.Activo)
            {
                MessageBox.Show(
                    $"❌ El cliente '{clienteSeleccionado.Nombre}' NO está activo.\n\n" +
                    "Un cliente inactivo no tiene conexión a la red,\n" +
                    "por lo tanto no puede realizar consultas DNS.",
                    "Cliente Inactivo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);

                txtBusacar.Clear();
                rtbDNS.Clear();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBusacar.Text))
            {
                MessageBox.Show("⚠️ Ingresa un dominio (ej: google.com)", "Advertencia",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dominio = txtBusacar.Text.Trim();
            ClsConfiguracionDNS dnsAUsar = null;
            var listaDNS = gestorClientes.ListaDNS;

            foreach (var dns in listaDNS)
            {
                if (dns.Nombre.ToLower() == dominio.ToLower() ||
                    dominio.ToLower().Contains(dns.Nombre.ToLower()))
                {
                    dnsAUsar = dns;
                    int indice = listaDNS.IndexOf(dns);
                    if (indice >= 0) gestorClientes.SeleccionarDNS(indice);
                    break;
                }
            }

            if (dnsAUsar == null) dnsAUsar = gestorClientes.DNSSeleccionado;
            if (dnsAUsar == null && listaDNS.Count > 0)
            {
                dnsAUsar = listaDNS[0];
                gestorClientes.SeleccionarDNS(0);
            }

            if (dnsAUsar == null)
            {
                MessageBox.Show("⚠️ No hay ningún DNS configurado.", "Sin DNS Configurados",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var infoDominio = gestorClientes.ObtenerInfoDominio(dominio);
            string ipResuelta = gestorClientes.ResolverDNSConVerificacion(dominio, indiceSeleccionado, dnsAUsar.Nombre);
            bool exito = !ipResuelta.StartsWith("Error");

            rtbDNS.Clear();
            rtbDNS.SelectionColor = exito ? Color.Green : Color.Red;
            rtbDNS.SelectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
            rtbDNS.AppendText(exito ? "✅ DNS ENCONTRADO\n\n" : "❌ DNS NO ENCONTRADO\n\n");

            rtbDNS.SelectionColor = Color.SteelBlue;
            rtbDNS.SelectionFont = new Font("Segoe UI", 10, FontStyle.Regular);
            rtbDNS.AppendText($"🌐 Dominio: {dominio}\n");

            rtbDNS.SelectionColor = exito ? Color.Green : Color.Red;
            rtbDNS.SelectionFont = new Font("Consolas", 9, FontStyle.Regular);
            rtbDNS.AppendText($"📍 IP: {ipResuelta}\n");

            rtbDNS.SelectionColor = Color.DarkOrange;
            rtbDNS.AppendText($"🏢 Organización: {infoDominio.Tipo}\n");

            rtbDNS.SelectionColor = Color.Purple;
            rtbDNS.AppendText($"🌎 País: {infoDominio.Pais}\n");

            rtbDNS.SelectionColor = Color.Gray;
            rtbDNS.SelectionFont = new Font("Segoe UI", 8, FontStyle.Italic);
            rtbDNS.AppendText($"ℹ️ {infoDominio.Descripcion}\n");

            rtbDNS.SelectionColor = Color.SlateGray;
            rtbDNS.AppendText($"🕐 Fecha: {DateTime.Now:HH:mm:ss}\n");
            rtbDNS.AppendText("\n─────────────────────────\n");

            rtbDNS.SelectionColor = exito ? Color.DarkGreen : Color.DarkRed;
            rtbDNS.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
            rtbDNS.AppendText(exito ? "✓ La consulta DNS se realizó correctamente." : "✗ No se pudo resolver el dominio.");

            ActualizarBitacoraVisual();
            ActualizarTreeViewDNS();
            txtBusacar.Clear();
        }

        private void ActualizarBitacoraVisual()
        {
            rtbbitacora.Clear();

            if (indiceSeleccionado < 0)
            {
                rtbbitacora.SelectionColor = Color.Gray;
                rtbbitacora.AppendText("Seleccione un cliente para ver su bitácora");
                return;
            }

            var bitacora = gestorClientes.ObtenerBitacoraDNS(indiceSeleccionado);

            if (bitacora.Count == 0)
            {
                rtbbitacora.SelectionColor = Color.Gray;
                rtbbitacora.AppendText("Sin consultas DNS registradas");
            }
            else
            {
                int exitos = bitacora.Count(b => b.Exitoso);
                int errores = bitacora.Count(b => !b.Exitoso);

                rtbbitacora.SelectionColor = Color.SteelBlue;
                rtbbitacora.SelectionFont = new Font("Segoe UI", 9, FontStyle.Bold);
                rtbbitacora.AppendText($"📋 Bitácora DNS - {bitacora.Count} consultas\n");

                rtbbitacora.SelectionColor = Color.Green;
                rtbbitacora.SelectionFont = new Font("Segoe UI", 8, FontStyle.Regular);
                rtbbitacora.AppendText($"✅ Exitosas: {exitos}  ");

                rtbbitacora.SelectionColor = Color.Red;
                rtbbitacora.AppendText($"❌ Fallidas: {errores}\n\n");

                rtbbitacora.SelectionFont = new Font("Consolas", 8.5f, FontStyle.Regular);

                foreach (var entrada in bitacora)
                {
                    rtbbitacora.SelectionColor = entrada.Exitoso ? Color.Black : Color.DarkRed;
                    string icono = entrada.Exitoso ? "✅" : "❌";
                    rtbbitacora.AppendText($"{icono} [{entrada.Fecha:HH:mm:ss}] {entrada.Dominio}");

                    if (entrada.Exitoso)
                    {
                        rtbbitacora.SelectionColor = Color.Green;
                        rtbbitacora.AppendText($" → {entrada.IPResuelta}");
                    }
                    else
                    {
                        rtbbitacora.SelectionColor = Color.Red;
                        rtbbitacora.AppendText(" → No se encontró");
                    }
                    rtbbitacora.SelectionColor = Color.Gray;
                    rtbbitacora.AppendText($" ({entrada.Organizacion})\n");
                }
            }
        }

        private void CargarDNSPorDefecto()
        {
            txtDnsPrimario.Text = "8.8.8.8";
            txtDnsSecundario.Text = "8.8.8.4";
            gestorClientes.AgregarDNS("Google.com", "8.8.8.8", "8.8.4.4");
            gestorClientes.AgregarDNS("Cloudflare.com", "1.1.1.1", "1.0.0.1");
            gestorClientes.AgregarDNS("OpenDNS.com", "208.67.222.222", "208.67.220.220");
            ActualizarTreeViewDNS();
        }

        private void ActualizarTreeViewDNS()
        {
            tVDNS.Nodes.Clear();

            TreeNode nodoRaiz = new TreeNode("🌐 Servidores DNS Configurados")
            {
                ForeColor = Color.SteelBlue,
                NodeFont = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            var listaDNS = gestorClientes.ListaDNS;

            for (int i = 0; i < listaDNS.Count; i++)
            {
                var dns = listaDNS[i];
                string icono = dns.Activo ? "✅" : "☐";
                string textoPadre = $"{icono} {dns.Nombre} - {dns.Primario}";

                TreeNode nodoDNS = new TreeNode(textoPadre)
                {
                    Tag = dns,
                    ForeColor = dns.Activo ? Color.Green : Color.Black,
                    NodeFont = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                if (dns.ConsultasRealizadas.Count > 0)
                {
                    TreeNode nodoConsultas = new TreeNode($"📋 Consultas ({dns.ConsultasRealizadas.Count})")
                    {
                        ForeColor = Color.DarkOrange,
                        NodeFont = new Font("Segoe UI", 8, FontStyle.Italic)
                    };

                    foreach (var consulta in dns.ConsultasRealizadas.OrderByDescending(c => c.Fecha))
                    {
                        string iconoConsulta = consulta.Exitoso ? "✅" : "❌";
                        string textoConsulta = $"{iconoConsulta} {consulta.ClienteNombre} → {consulta.IPResuelta}";

                        TreeNode nodoConsulta = new TreeNode(textoConsulta)
                        {
                            ForeColor = consulta.Exitoso ? Color.Green : Color.Red,
                            NodeFont = new Font("Consolas", 8, FontStyle.Regular),
                            ToolTipText = $"Dominio: {consulta.Dominio}\nCliente: {consulta.ClienteNombre}\nFecha: {consulta.Fecha:dd/MM/yyyy HH:mm:ss}"
                        };

                        nodoConsultas.Nodes.Add(nodoConsulta);
                    }
                    nodoDNS.Nodes.Add(nodoConsultas);
                }
                nodoRaiz.Nodes.Add(nodoDNS);
            }

            tVDNS.Nodes.Add(nodoRaiz);
            nodoRaiz.ExpandAll();

            var seleccionado = gestorClientes.DNSSeleccionado;
            if (seleccionado != null)
            {
                lblselecionado.Text = $"📡 DNS Activo: {seleccionado.Nombre} ({seleccionado.Primario}) - {seleccionado.ConsultasRealizadas.Count} consultas";
                lblselecionado.ForeColor = Color.Green;
            }
            else
            {
                lblselecionado.Text = "📡 DNS: Ninguno seleccionado";
                lblselecionado.ForeColor = Color.DarkOrange;
            }
        }

        private void btnAgregarDNS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreDNS.Text))
            {
                MessageBox.Show("⚠️ Ingresa un nombre para el DNS", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDnsPrimario.Text))
            {
                MessageBox.Show("⚠️ Ingresa DNS Primario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDnsSecundario.Text))
            {
                MessageBox.Show("⚠️ Ingresa DNS Secundario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            gestorClientes.AgregarDNS(txtNombreDNS.Text.Trim(), txtDnsPrimario.Text.Trim(), txtDnsSecundario.Text.Trim());
            ActualizarTreeViewDNS();

            txtNombreDNS.Clear();
            txtDnsPrimario.Clear();
            txtDnsSecundario.Clear();
            txtNombreDNS.Focus();
        }

        private void btnEliminarDNs_Click(object sender, EventArgs e)
        {
            if (_nodoDNSSeleccionado == null)
            {
                MessageBox.Show("⚠️ Selecciona un DNS de la lista para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_nodoDNSSeleccionado.Level == 0)
            {
                MessageBox.Show("⚠️ No puedes eliminar el nodo raíz.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dnsSeleccionado = _nodoDNSSeleccionado.Tag as ClsConfiguracionDNS;
            if (dnsSeleccionado == null) return;

            var listaDNS = gestorClientes.ListaDNS;
            int indice = -1;

            for (int i = 0; i < listaDNS.Count; i++)
            {
                if (listaDNS[i].Nombre == dnsSeleccionado.Nombre && listaDNS[i].Primario == dnsSeleccionado.Primario)
                {
                    indice = i;
                    break;
                }
            }

            if (indice == -1) return;

            var confirm = MessageBox.Show($"¿Eliminar el DNS '{dnsSeleccionado.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                gestorClientes.EliminarDNS(indice);
                _nodoDNSSeleccionado = null;
                ActualizarTreeViewDNS();
            }
        }

        private void tVDNS_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level > 0)
            {
                _nodoDNSSeleccionado = e.Node;
                int indice = e.Node.Index;
                gestorClientes.SeleccionarDNS(indice);
                ActualizarTreeViewDNS();
            }
            else
            {
                _nodoDNSSeleccionado = null;
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            if (_nodoDNSSeleccionado == null)
            {
                MessageBox.Show("⚠️ Selecciona una consulta específica", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_nodoDNSSeleccionado.Level != 3)
            {
                MessageBox.Show("⚠️ Debes seleccionar una consulta específica", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string textoNodo = _nodoDNSSeleccionado.Text;
            string nombreCliente = "";
            string ipResuelta = "";

            int inicioNombre = textoNodo.IndexOf("✅") + 2;
            int finNombre = textoNodo.IndexOf("→");
            if (inicioNombre > 0 && finNombre > inicioNombre)
            {
                nombreCliente = textoNodo.Substring(inicioNombre, finNombre - inicioNombre).Trim();
                ipResuelta = textoNodo.Substring(finNombre + 1).Trim();
            }

            if (string.IsNullOrEmpty(nombreCliente) || string.IsNullOrEmpty(ipResuelta)) return;

            TreeNode nodoConsultas = _nodoDNSSeleccionado.Parent;
            TreeNode nodoDNS = nodoConsultas.Parent;
            int indiceDNS = nodoDNS.Index;

            var confirm = MessageBox.Show($"¿Eliminar esta consulta?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                gestorClientes.EliminarConsultaEspecifica(indiceDNS, nombreCliente, ipResuelta);
                ActualizarTreeViewDNS();
                _nodoDNSSeleccionado = null;
            }
        }
    }
}