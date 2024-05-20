using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Modelo
{
    public static class SesionUsuario_Modelo
    {
       
        public static int id_usuario {get;set;}
       
        public static string nombre { get;set;}
       
        public static string password {  get;set;}
       
        public static string token {  get;set;}
       
        public static int id_tipoUser { get;set;}
       
        public static string fecha {  get;set;}
    }
    public class TipoUsuario_Modelo
    {
       
        public int id_tipoUsuario { get;set;}
       
        public string nombre { get;set;}
        
    }

}
