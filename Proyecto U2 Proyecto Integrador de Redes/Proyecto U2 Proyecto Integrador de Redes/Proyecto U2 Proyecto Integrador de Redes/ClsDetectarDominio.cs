using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_U2_Proyecto_Integrador_de_Redes
{
    internal class ClsDetectarDominio
    {
        public string Extension { get; set; }
        public string Tipo { get; set; }
        public string Pais { get; set; }
        public string Descripcion { get; set; }

        public static ClsDetectarDominio Analizar(string dominio)
        {
            var resultado = new ClsDetectarDominio();

            // Limpiar dominio
            dominio = dominio.ToLower().Trim();

            // Obtener extensión (última parte después del punto)
            string[] partes = dominio.Split('.');
            string extension = partes.Length > 1 ? partes[partes.Length - 1] : "desconocido";

            resultado.Extension = "." + extension;

            // Detectar tipo y país
            switch (extension)
            {
                case "com":
                    resultado.Tipo = "Comercial";
                    resultado.Pais = "Internacional";
                    resultado.Descripcion = "Compañía comercial";
                    break;
                case "mx":
                    resultado.Tipo = "País";
                    resultado.Pais = "México 🇲🇽";
                    resultado.Descripcion = "Dominio mexicano";
                    break;
                case "org":
                    resultado.Tipo = "Organización";
                    resultado.Pais = "Internacional";
                    resultado.Descripcion = "Organización sin fines de lucro";
                    break;
                case "edu":
                    resultado.Tipo = "Educativo";
                    resultado.Pais = "Internacional";
                    resultado.Descripcion = "Institución educativa";
                    break;
                case "gob":
                case "gov":
                    resultado.Tipo = "Gobierno";
                    resultado.Pais = "Internacional";
                    resultado.Descripcion = "Entidad gubernamental";
                    break;
                case "net":
                    resultado.Tipo = "Red";
                    resultado.Pais = "Internacional";
                    resultado.Descripcion = "Proveedor de red/internet";
                    break;
                case "io":
                    resultado.Tipo = "Tecnología";
                    resultado.Pais = "Internacional";
                    resultado.Descripcion = "Input/Output - Tech startups";
                    break;
                case "co":
                    resultado.Tipo = "Comercial";
                    resultado.Pais = "Colombia 🇨🇴";
                    resultado.Descripcion = "Compañía colombiana";
                    break;
                case "us":
                    resultado.Tipo = "País";
                    resultado.Pais = "Estados Unidos 🇺🇸";
                    resultado.Descripcion = "Dominio estadounidense";
                    break;
                case "uk":
                    resultado.Tipo = "País";
                    resultado.Pais = "Reino Unido 🇬🇧";
                    resultado.Descripcion = "Dominio británico";
                    break;
                case "de":
                    resultado.Tipo = "País";
                    resultado.Pais = "Alemania 🇩🇪";
                    resultado.Descripcion = "Dominio alemán";
                    break;
                case "jp":
                    resultado.Tipo = "País";
                    resultado.Pais = "Japón 🇯🇵";
                    resultado.Descripcion = "Dominio japonés";
                    break;
                case "cn":
                    resultado.Tipo = "País";
                    resultado.Pais = "China 🇨🇳";
                    resultado.Descripcion = "Dominio chino";
                    break;
                default:
                    resultado.Tipo = "Desconocido";
                    resultado.Pais = "No identificado";
                    resultado.Descripcion = "Extensión no reconocida";
                    break;
            }

            return resultado;
        }
    }
}