using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Modelo
{
    public class Configuraciones_Modelo
    {
        [Required]
        public int id_configuracion {  get; set; }
        [Required]
        public int valida_login {  get; set; }
        [Required]
        public int escribir_log {  get; set; }
        [Required]
        public string ruta_log {  get; set; }

    }
}
