using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Modelo
{
    public class Sesion_Modelo
    {
        public int id_usuario { get; set; }

        public string nombre { get; set; }

        public string password { get; set; }

        public string token { get; set; }

        public int id_tipoUser { get; set; }

        public string fecha { get; set; }
        public int diasRestantes {  get; set; } 
    }
}
