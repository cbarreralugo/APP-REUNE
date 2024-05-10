using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Modelo
{
    public class Configuraciones_Modelo
    {
       
        public int id_configuracion {  get; set; }
       
        public int valida_login {  get; set; }
       
        public int escribir_log {  get; set; }
       
        public string ruta_log {  get; set; }
        public string api_reune { get; set; }

    }

    public static class Configuracion_Modelo
    {

        public static int id_configuracion { get; set; }

        public static int valida_login { get; set; }

        public static int escribir_log { get; set; }

        public static string ruta_log { get; set; }
        public static string api_reune { get; set; }

    }
}
