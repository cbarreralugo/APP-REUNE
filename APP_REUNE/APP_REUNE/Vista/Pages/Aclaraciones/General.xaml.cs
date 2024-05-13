using APP_REUNE.Service;
using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APP_REUNE.Vista.Pages.Aclaraciones
{
    /// <summary>
    /// Lógica de interacción para General.xaml
    /// </summary>7
    public partial class General : Page
    {
        private Aclaraciones_Service _aclaracionesService;
        public General()
        {
            InitializeComponent();
            CargarPreInformacio();
            _aclaracionesService = new Aclaraciones_Service();
        }

        private void CargarPreInformacio()
        {
            Utilidad.Util.CargarComboTrimestre(cb_AclaracionTrimestre);
            Utilidad.Util.CargarComboNumero(cb_AclaracionNumero);
            Utilidad.Util.CargarComboEstadoConPend(cb_AclaracionEstadoConPend);
            Utilidad.Util.CargarComboMonetario(cb_AclaracionMonetario);
            Utilidad.Util.CargarComboPORI(cb_AclaracionPori);
            Utilidad.Util.CargarComboTipoPersona(cb_AclaracionTipoPersona);
            Utilidad.Util.CargarComboSexo(cb_AclaracionSexo);
            Utilidad.Util.CargarComboEdad(cb_AclaracionEdad);
            Utilidad.Util.CargarComboNivelAtencion(cb_AclaracionNivelAtencion);
            Utilidad.Util.CargarComboReversa(cb_AclaracionReversa);
            Utilidad.Util.CargarComboOperacionExtranjero(cb_AclaracionOperacionExtranjero);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            Aclaracion_Model aclaracion = new Aclaracion_Model
            {
                AclaracionDenominacion = txt_AclaracionDenominacion.Text,
                AclaracionSector = txt_AclaracionSector.Text,
                AclaracionTrimestre = (int) cb_AclaracionTrimestre.SelectedValue,
                AclaracionNumero = (int) cb_AclaracionNumero.SelectedValue,
                AclaracionFolioAtencion = txt_AclaracionFolioAtencion.Text,
                AclaracionEstadoConPend = (int) cb_AclaracionEstadoConPend.SelectedValue,
                AclaracionFechaReclamacion = dp_AclaracionFechaAclaracionReclmacion.SelectedDate.Value.ToString("dd/MM/yyyy"),
                AclaracionFechaAtencion = dp_AclaracionFechaAtencion.SelectedDate.Value.ToString("dd/MM/yyyy"),
                AclaracionMedioRecepcionCanal = int.Parse(txt_AclaracionMedioAclaracionepcionCanal.Text),
                AclaracionProductoServicio = txt_AclaracionProductoServicio.Text,
                AclaracionCausaMotivo = txt_AclaracionCausaMotivo.Text,
                AclaracionFechaResolucion = dp_AclaracionFechaResolucion.SelectedDate.Value.ToString("dd/MM/yyyy"),
                AclaracionFechaNotifiUsuario = dp_AclaracionFechaNotifiUsuario.SelectedDate.Value.ToString("dd/MM/yyyy"),
                AclaracionEntidadFederativa = int.Parse(txt_AclaracionEntidadFederativa.Text),
                AclaracionCodigoPostal = int.Parse(txt_AclaracionCodigoPostal.Text),
                AclaracionMunicipioAlcaldia = int.Parse(txt_AclaracionMunicipioAlcaldia.Text),
                AclaracionLocalidad = int.Parse(txt_AclaracionLocalidad.Text),
                AclaracionColonia = txt_AclaracionColonia.Text,
                AclaracionMonetario = (string)cb_AclaracionMonetario.SelectedValue,
                AclaracionMontoReclamado = int.Parse(txt_AclaracionMontoReclamado.Text),
                AclaracionPori = (string)cb_AclaracionPori.SelectedValue,
                AclaracionTipoPersona = (int)cb_AclaracionTipoPersona.SelectedValue,
                AclaracionSexo = (string) cb_AclaracionSexo.SelectedValue,
                AclaracionEdad = (int) cb_AclaracionEdad.SelectedValue,
                AclaracionNivelAtencion = (int) cb_AclaracionNivelAtencion.SelectedValue,
                AclaracionFolioCondusef = txt_AclaracionFolioCondusef.Text,
                AclaracionReversa = (string) cb_AclaracionReversa.SelectedValue,
                AclaracionOperacionExtranjero = (string) cb_AclaracionOperacionExtranjero.SelectedValue
            };
            ResponseAPI aPI = new ResponseAPI();
            string response = await _aclaracionesService.SendAclaracion(aclaracion); // Nota el cambio aquí
            if (response != null)
            {
                aPI.txtApiResponse.Text = response; // Muestra la respuesta en el TextBox
                aPI.Show();
            }
            else
            {
                aPI.txtApiResponse.Text = "Error al enviar la aclaración.";
                aPI.Show();
            }
        }

        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
