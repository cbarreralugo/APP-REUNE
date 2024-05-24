using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Modelo
{
    public class Configuraciones_Modelo
    {
        internal string key;

        public int id_configuracion { get; set; }

        public int valida_login { get; set; }

        public int escribir_log { get; set; }

        public string ruta_log { get; set; }
        public string api_reune { get; set; }

        public string configuracion { get; set; }
        public string valor { get; set; }
        public string ruta_sesion_temporal { get; set; }
        public int mostrar_alerts { get; set; }
        public int auto_regenerar_token_user { get; set; }
        public  string pre_info { get; set; }
    }

    public static class Configuracion_Modelo
    {

        public static int id_configuracion { get; set; }

        public static int valida_login { get; set; }

        public static int escribir_log { get; set; }

        public static string ruta_log { get; set; }
        public static int auto_regenerar_token_user { get; set; }

        public static string configuracion { get; set; }
        public static string valor { get; set; }
        public static string ruta_sesion_temporal { get; set; }
        public static string key { get; set; }
        public static int mostrar_alerts { get; set; }
        public static string api_reune { get; set; }
        public static string pre_info {  get; set; }
    }
}
