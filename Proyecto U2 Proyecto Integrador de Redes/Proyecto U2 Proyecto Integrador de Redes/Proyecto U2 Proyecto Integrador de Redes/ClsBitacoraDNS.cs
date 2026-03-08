using System;

namespace Proyecto_U2_Proyecto_Integrador_de_Redes
{
    internal class ClsBitacoraDNS
    {
        public string Dominio { get; set; }
        public string IPResuelta { get; set; }
        public DateTime Fecha { get; set; }
        public string Organizacion { get; set; }
        public string Pais { get; set; }
        public bool Exitoso { get; set; }  // ⭐ NUEVO: Indica si se encontró

        public ClsBitacoraDNS(string dominio, string ip, string organizacion, string pais, bool exitoso)
        {
            Dominio = dominio;
            IPResuelta = ip;
            Fecha = DateTime.Now;
            Organizacion = organizacion;
            Pais = pais;
            Exitoso = exitoso;
        }

        public override string ToString()
        {
            string estado = Exitoso ? "✅" : "❌";
            string resultado = Exitoso ? IPResuelta : "No se encontró";
            return $"{estado} [{Fecha:HH:mm:ss}] {Dominio} → {resultado} ({Organizacion})";
        }
    }
}