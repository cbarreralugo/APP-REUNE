using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Modelo
{
    public class Aclaracion_Model
    {
        public string AclaracionDenominacion { get; set; }
        public string AclaracionSector { get; set; }
        public string AclaracionTrimestre { get; set; }
        public string AclaracionNumero { get; set; }
        public string AclaracionFolioAtencion { get; set; }
        public string AclaracionEstadoConPend { get; set; }
        public string AclaracionFechaReclamacion { get; set; }
        public string AclaracionFechaAclaracion { get; set; }
        public string AclaracionFechaAtencion { get; set; }
        public string AclaracionMedioRecepcionCanal { get; set; }
        public string AclaracionProductoServicio { get; set; }
        public string AclaracionCausaMotivo { get; set; }
        public string AclaracionFechaResolucion { get; set; }
        public string AclaracionFechaNotifiUsuario { get; set; }
        public string AclaracionEntidadFederativa { get; set; }
        public string AclaracionCodigoPostal { get; set; }
        public string AclaracionMunicipioAlcaldia { get; set; }
        public string AclaracionLocalidad { get; set; }
        public string AclaracionColonia { get; set; }
        public string AclaracionMonetario { get; set; }
        public string AclaracionMontoReclamado { get; set; }
        public string AclaracionPori { get; set; }
        public string AclaracionTipoPersona { get; set; }
        public string AclaracionSexo { get; set; }
        public string AclaracionEdad { get; set; }
        public string AclaracionNivelAtencion { get; set; }
        public string AclaracionFolioCondusef { get; set; }
        public string AclaracionReversa { get; set; }
        public string AclaracionOperacionExtranjero { get; set; }
    }
    public class AclaracionDetalle
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string FechaAclaracion { get; set; }
        public string Estado { get; set; } 
    }
}
