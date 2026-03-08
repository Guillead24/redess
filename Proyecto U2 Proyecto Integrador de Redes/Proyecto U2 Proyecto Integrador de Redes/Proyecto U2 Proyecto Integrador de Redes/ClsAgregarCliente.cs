using System;
using System.Collections.Generic;

namespace Proyecto_U2_Proyecto_Integrador_de_Redes
{
    internal class ClsAgregarCliente
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string MAC { get; set; }
        public string IP { get; set; }
        public string Hostname { get; set; }
        public bool Activo { get; set; }
        public string UltimaIP { get; set; }

        // NUEVA: Máscara de subred
        public string MascaraSubred { get; set; }

        // NUEVA: IP de broadcast (calculada)
        public string Broadcast { get; set; }

        // --- PARA SIMULACIÓN ---
        public double ConsumoActual { get; set; }
        public int MbpsMaximos { get; set; }

        // Agregar al final de las propiedades (después de Broadcast):
        public List<ClsBitacoraDNS> BitacoraDNS { get; set; } = new List<ClsBitacoraDNS>();

        public ClsAgregarCliente(string nombre, string tipo)
        {
            Nombre = nombre;
            Tipo = tipo;
            UltimaIP = null;
            MascaraSubred = "255.255.255.0"; // Valor por defecto

            // Límites de Mbps según tipo
            switch (tipo)
            {
                case "Tv":
                case "Consola":
                    MbpsMaximos = 45;
                    break;
                case "PC":
                case "Laptop":
                    MbpsMaximos = 25;
                    break;
                default:
                    MbpsMaximos = 10;
                    break;
            }
        }

        public override string ToString() => $"{Nombre} - {IP}";
    }
}