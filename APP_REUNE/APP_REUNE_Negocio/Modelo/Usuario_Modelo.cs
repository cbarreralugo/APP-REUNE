using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Modelo
{
    public class Usuario_Modelo
    {
        public string id_usuario { get; set; }

        public string nombre { get; set; }

        public string password { get; set; }

        public string token { get; set; }

        public string id_tipoUser { get; set; }

        public string fecha { get; set; }
        public string diasRestantes { get; set; }
        public string perfil { get; set; }
        public string esta_activo { get; set; }
        public string userid_api { get; set; }
        public string username_api { get; set; }
        public string password_api { get; set; }
        public string institucionid_api { get; set; }
        public string is_active_api { get; set; }
        public string profileid_api { get; set; }
        public string system_api { get; set; }
        public string date_api { get; set; }
    }
    // Definición de los modelos de respuesta para deserializar JSON
    public class ResponseModel
    {
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string institucionid { get; set; }
        public bool is_active { get; set; }
        public string profileid { get; set; }
        public string date { get; set; }
        public string system { get; set; }
        public string token_access { get; set; }
    }
}
