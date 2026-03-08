using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_U2_Proyecto_Integrador_de_Redes
{
    internal class ClsConfiguracionDNS
    {
        public string Nombre { get; set; }
        public string Primario { get; set; }
        public string Secundario { get; set; }
        public bool Activo { get; set; }

        public List<ClsConsultaDNS> ConsultasRealizadas { get; set; }

        public int Contador { get; set; }
        public ClsConfiguracionDNS(string nombre, string primario, string secundario)
        {
            Nombre = nombre;
            Primario = primario;
            Secundario = secundario;
            Activo = false;
            ConsultasRealizadas = new List<ClsConsultaDNS>();
            Contador = 1; 
        }

        public override string ToString()
        {
            return $"{Nombre} ({Primario})";
        }
        internal class ClsConsultaDNS
        {
            public string Dominio { get; set; }
            public string IPResuelta { get; set; }
            public string ClienteNombre { get; set; }
            public DateTime Fecha { get; set; }
            public bool Exitoso { get; set; }

            public ClsConsultaDNS(string dominio, string ip, string cliente, bool exitoso)
            {
                Dominio = dominio;
                IPResuelta = ip;
                ClienteNombre = cliente;
                Fecha = DateTime.Now;
                Exitoso = exitoso;
            }

            public override string ToString()
            {
                string icono = Exitoso ? "✅" : "❌";
                return $"{icono} [{Fecha:HH:mm:ss}] {Dominio} → {IPResuelta}";
            }
        }
    }
}