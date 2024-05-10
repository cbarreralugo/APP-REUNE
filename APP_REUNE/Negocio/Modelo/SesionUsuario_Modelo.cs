using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Modelo
{
    public  class SesionUsuario_Modelo
    {
        [Required]
        public int id_usuario {get;set;}
        [Required]
        public string nombre { get;set;}
        [Required]
        public string password {  get;set;}
        [Required]
        public string token {  get;set;}
        [Required]
        public int id_tipoUser { get;set;}
        [Required]
        public string fecha {  get;set;}
    }
    public class TipoUsuario_Modelo
    {
        [Required]
        public int id_tipoUsuario { get;set;}
        [Required]
        public string nombre { get;set;}
        
    }

}
