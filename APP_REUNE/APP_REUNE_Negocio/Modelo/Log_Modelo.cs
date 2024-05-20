using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Modelo
{
    public class Log_Modelo
    {
        public int id_log {  get; set; }
        public int id_usuario { get; set; }
        public string titulo { get; set; }
        public string mensaje { get; set; }
        public string equipo {  get; set; }
        public string fecha { get; set; }
        public string nombreUsuario { get;  set; }
    }
}
