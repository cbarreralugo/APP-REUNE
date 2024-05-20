using APP_REUNE.Service;
using APP_REUNE_Negocio.Modelo;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Design;
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
            txt_AclaracionDenominacion.Text = "SAM Asset Management S.A. de C.V., Sociedad Operadora de Fondos de Inversión.";
            txt_AclaracionSector.Text = "Sociedad Operadora de Fondos de Inversión";
            txt_AclaracionEntidadFederativa.Text = "09";
            txt_AclaracionCodigoPostal.Text = "5120";
            txt_AclaracionMunicipioAlcaldia.Text = "004";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Seleccionar archivo JSON"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string jsonContent = File.ReadAllText(filePath);

                var aclaracion = JsonConvert.DeserializeObject<Aclaracion_Model>(jsonContent);

                if (aclaracion != null)
                {
                    var apiService = new Aclaraciones_Service();
                    bool success = await apiService.SendAclaracion(aclaracion);

                    if (success)
                    {
                      
                        Toast.Correcto("Archivo enviado correctamente.");
                    }
                    else
                    {
                        Toast.Error("Error al enviar el archivo.");
                    }
                }
                else
                {
                    Toast.Error("El archivo JSON no es válido.");
                }
            }
        }


        private async void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            Toast.Denegado("Acción fuera de servicio");
            //var apiService = new Aclaraciones_Service();

            //var aclaracion = new Aclaracion_Model
            //{
            //    AclaracionDenominacion = txt_AclaracionDenominacion.Text,
            //    AclaracionSector = txt_AclaracionSector.Text,
            //    AclaracionTrimestre = int.Parse(cb_AclaracionTrimestre.SelectedValue.ToString()),
            //    AclaracionNumero = int.Parse(cb_AclaracionNumero.SelectedValue.ToString()),
            //    AclaracionFolioAtencion = txt_AclaracionFolioAtencion.Text,
            //    AclaracionEstadoConPend = int.Parse(cb_AclaracionEstadoConPend.SelectedValue.ToString()),
            //    AclaracionFechaAclaracion = dp_AclaracionFechaAclaracionReclmacion.SelectedDate.Value.ToString("dd/MM/yyyy"),
            //    AclaracionFechaAtencion = dp_AclaracionFechaAtencion.SelectedDate.Value.ToString("dd/MM/yyyy"),
            //    AclaracionMedioRecepcionCanal = int.Parse(txt_AclaracionMedioAclaracionepcionCanal.Text),
            //    AclaracionProductoServicio = txt_AclaracionProductoServicio.Text,
            //    AclaracionCausaMotivo = txt_AclaracionCausaMotivo.Text,
            //    AclaracionFechaResolucion = dp_AclaracionFechaResolucion.SelectedDate.Value.ToString("dd/MM/yyyy"),
            //    AclaracionFechaNotifiUsuario = dp_AclaracionFechaNotifiUsuario.SelectedDate.Value.ToString("dd/MM/yyyy"),
            //    AclaracionEntidadFederativa = int.Parse(txt_AclaracionEntidadFederativa.Text),
            //    AclaracionCodigoPostal = int.Parse(txt_AclaracionCodigoPostal.Text),
            //    AclaracionMunicipioAlcaldia = int.Parse(txt_AclaracionMunicipioAlcaldia.Text),
            //    AclaracionLocalidad = int.Parse(txt_AclaracionLocalidad.Text),
            //    AclaracionColonia = txt_AclaracionColonia.Text,
            //    AclaracionMonetario = cb_AclaracionMonetario.SelectedValue.ToString(),
            //    AclaracionMontoReclamado = txt_AclaracionMontoReclamado.Text,
            //    AclaracionPori = cb_AclaracionPori.SelectedValue.ToString(),
            //    AclaracionTipoPersona = int.Parse(cb_AclaracionTipoPersona.SelectedValue.ToString()),
            //    AclaracionSexo = cb_AclaracionSexo.SelectedValue.ToString(),
            //    AclaracionEdad = int.Parse(cb_AclaracionEdad.SelectedValue.ToString()),
            //    AclaracionNivelAtencion = int.Parse(cb_AclaracionNivelAtencion.SelectedValue.ToString()),
            //    AclaracionFolioCondusef = txt_AclaracionFolioCondusef.Text,
            //    AclaracionReversa = cb_AclaracionReversa.SelectedValue.ToString(),
            //    AclaracionOperacionExtranjero = cb_AclaracionOperacionExtranjero.SelectedValue.ToString()
            //};

            //string response = await apiService.SendAclaracion(aclaracion);
            //if (response != null)
            //{
            //    // Procesa la respuesta si es necesario
            //}
        }


        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
