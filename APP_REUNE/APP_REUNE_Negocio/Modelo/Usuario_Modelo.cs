using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Modelo
{
    public class Usuario_Modelo
    {
        public int id_usuario { get; set; }

        public string nombre { get; set; }

        public string password { get; set; }

        public string token { get; set; }

        public int id_tipoUser { get; set; }

        public string fecha { get; set; }
        public int diasRestantes { get; set; }
        public string perfil { get; set; }
        public bool esta_activo { get; set; }
    }
    // Definición de los modelos de respuesta para deserializar JSON
    public class ResponseModel
    {
        public string message { get; set; }
        public UserData data { get; set; }
    }

    public class UserData
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string institucionid { get; set; }
        public string is_active { get; set; }
        public int profileid { get; set; }
        public string token_access { get; set; }
    }
}
