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
        public int AclaracionTrimestre { get; set; }
        public int AclaracionNumero { get; set; }
        public string AclaracionFolioAtencion { get; set; }
        public int AclaracionEstadoConPend { get; set; }
        public string AclaracionFechaAclaracion { get; set; }
        public string AclaracionFechaAtencion { get; set; }
        public int AclaracionMedioRecepcionCanal { get; set; }
        public string AclaracionProductoServicio { get; set; }
        public string AclaracionCausaMotivo { get; set; }
        public string AclaracionFechaResolucion { get; set; }
        public string AclaracionFechaNotifiUsuario { get; set; }
        public int AclaracionEntidadFederativa { get; set; }
        public int AclaracionCodigoPostal { get; set; }
        public int AclaracionMunicipioAlcaldia { get; set; }
        public int AclaracionLocalidad { get; set; }
        public int AclaracionColonia { get; set; }
        public string AclaracionMonetario { get; set; }
        public string AclaracionMontoReclamado { get; set; }
        public string AclaracionPori { get; set; }
        public int AclaracionTipoPersona { get; set; }
        public string AclaracionSexo { get; set; }
        public int AclaracionEdad { get; set; }
        public int AclaracionNivelAtencion { get; set; }
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
