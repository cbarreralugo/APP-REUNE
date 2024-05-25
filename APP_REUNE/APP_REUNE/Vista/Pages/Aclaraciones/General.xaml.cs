using APP_REUNE.Service;
using APP_REUNE.Utilidad;
using APP_REUNE.Vista.PreInfo;
using APP_REUNE_Negocio.Modelo;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APP_REUNE.Vista.Pages.Aclaraciones
{
    /// <summary>
    /// Lógica de interacción para General.xaml
    /// </summary>
    public partial class General : Page
    {
        private Aclaraciones_Service _aclaracionesService;
        private string fileName = "AclaracionesGeneral.txt";

        public General()
        {
            InitializeComponent();
            CargarPreInformacio();
            _aclaracionesService = new Aclaraciones_Service();
        }

        private void CargarPreInformacio()
        {
            // Limpiar todos los campos
            txt_AclaracionDenominacion.Clear();
            txt_AclaracionSector.Clear();
            cb_AclaracionTrimestre.SelectedIndex = 0;
            cb_AclaracionNumero.SelectedIndex = 0;
            txt_AclaracionFolioAtencion.Clear();
            cb_AclaracionEstadoConPend.SelectedIndex = 0;
            dp_AclaracionFechaAclaracionReclmacion.SelectedDate = DateTime.Now;
            dp_AclaracionFechaAtencion.SelectedDate = DateTime.Now;
            txt_AclaracionMedioAclaracionepcionCanal.Clear();
            txt_AclaracionProductoServicio.Clear();
            txt_AclaracionCausaMotivo.Clear();
            dp_AclaracionFechaResolucion.SelectedDate = DateTime.Now;
            dp_AclaracionFechaNotifiUsuario.SelectedDate = DateTime.Now;
            txt_AclaracionEntidadFederativa.Clear();
            txt_AclaracionCodigoPostal.Clear();
            txt_AclaracionMunicipioAlcaldia.Clear();
            txt_AclaracionLocalidad.Clear();
            txt_AclaracionColonia.Clear();
            cb_AclaracionMonetario.SelectedIndex = 0;
            txt_AclaracionMontoReclamado.Clear();
            cb_AclaracionPori.SelectedIndex = 0;
            cb_AclaracionTipoPersona.SelectedIndex = 0;
            cb_AclaracionSexo.SelectedIndex = 0;
            cb_AclaracionEdad.SelectedIndex = 0;
            cb_AclaracionNivelAtencion.SelectedIndex = 0;
            txt_AclaracionFolioCondusef.Clear();
            cb_AclaracionReversa.SelectedIndex = 0;
            cb_AclaracionOperacionExtranjero.SelectedIndex = 0;
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
            txt_AclaracionDenominacion.Text = CamposPreCargados.Denominacion;
            txt_AclaracionSector.Text = CamposPreCargados.Sector;
            txt_AclaracionEntidadFederativa.Text = CamposPreCargados.EntidadFederativa;
            txt_AclaracionCodigoPostal.Text = CamposPreCargados.CodigoPostal;
            txt_AclaracionMunicipioAlcaldia.Text = CamposPreCargados.DelegacionMunicipio;
            txt_AclaracionLocalidad.Text = CamposPreCargados.Localidad;
            txt_AclaracionColonia.Text = CamposPreCargados.Colonia;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
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

                    var aclaraciones = JsonConvert.DeserializeObject<List<Aclaracion_Model>>(jsonContent);

                    if (aclaraciones != null)
                    {
                        var apiService = new Aclaraciones_Service();
                        bool success = await apiService.SendAclaraciones(aclaraciones);

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
            catch (Exception ex)
            {
                Toast.Sistema("Error al leer archivo json", ex);
            }
        }

        private async void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var aclaracion = new Aclaracion_Model
                {
                    AclaracionDenominacion = txt_AclaracionDenominacion.Text,
                    AclaracionSector = txt_AclaracionSector.Text,
                    AclaracionTrimestre = cb_AclaracionTrimestre.SelectedValue != null ? int.Parse(cb_AclaracionTrimestre.SelectedValue.ToString()) : (int?)null,
                    AclaracionNumero = cb_AclaracionNumero.SelectedValue != null ? int.Parse(cb_AclaracionNumero.SelectedValue.ToString()) : (int?)null,
                    AclaracionFolioAtencion = txt_AclaracionFolioAtencion.Text,
                    AclaracionEstadoConPend = cb_AclaracionEstadoConPend.SelectedValue != null ? int.Parse(cb_AclaracionEstadoConPend.SelectedValue.ToString()) : (int?)null,
                    AclaracionFechaAclaracion = dp_AclaracionFechaAclaracionReclmacion.SelectedDate.HasValue ? dp_AclaracionFechaAclaracionReclmacion.SelectedDate.Value.ToString("dd/MM/yyyy") : null,
                    AclaracionFechaAtencion = dp_AclaracionFechaAtencion.SelectedDate.HasValue ? dp_AclaracionFechaAtencion.SelectedDate.Value.ToString("dd/MM/yyyy") : null,
                    AclaracionMedioRecepcionCanal = !string.IsNullOrEmpty(txt_AclaracionMedioAclaracionepcionCanal.Text) ? int.Parse(txt_AclaracionMedioAclaracionepcionCanal.Text) : (int?)null,
                    AclaracionProductoServicio = txt_AclaracionProductoServicio.Text,
                    AclaracionCausaMotivo = txt_AclaracionCausaMotivo.Text,
                    AclaracionFechaResolucion = dp_AclaracionFechaResolucion.SelectedDate.HasValue ? dp_AclaracionFechaResolucion.SelectedDate.Value.ToString("dd/MM/yyyy") : null,
                    AclaracionFechaNotifiUsuario = dp_AclaracionFechaNotifiUsuario.SelectedDate.HasValue ? dp_AclaracionFechaNotifiUsuario.SelectedDate.Value.ToString("dd/MM/yyyy") : null,
                    AclaracionEntidadFederativa = !string.IsNullOrEmpty(txt_AclaracionEntidadFederativa.Text) ? int.Parse(txt_AclaracionEntidadFederativa.Text) : (int?)null,
                    AclaracionCodigoPostal = !string.IsNullOrEmpty(txt_AclaracionCodigoPostal.Text) ? int.Parse(txt_AclaracionCodigoPostal.Text) : (int?)null,
                    AclaracionMunicipioAlcaldia = !string.IsNullOrEmpty(txt_AclaracionMunicipioAlcaldia.Text) ? int.Parse(txt_AclaracionMunicipioAlcaldia.Text) : (int?)null,
                    AclaracionLocalidad = !string.IsNullOrEmpty(txt_AclaracionLocalidad.Text) ? int.Parse(txt_AclaracionLocalidad.Text) : (int?)null,
                    AclaracionColonia = !string.IsNullOrEmpty(txt_AclaracionColonia.Text) ? int.Parse(txt_AclaracionColonia.Text) : (int?)null,
                    AclaracionMonetario = cb_AclaracionMonetario.SelectedValue != null ? cb_AclaracionMonetario.SelectedValue.ToString() : null,
                    AclaracionMontoReclamado = !string.IsNullOrEmpty(txt_AclaracionMontoReclamado.Text) ? decimal.Parse(txt_AclaracionMontoReclamado.Text) : (decimal?)null,
                    AclaracionPori = cb_AclaracionPori.SelectedValue != null ? cb_AclaracionPori.SelectedValue.ToString() : null,
                    AclaracionTipoPersona = cb_AclaracionTipoPersona.SelectedValue != null ? int.Parse(cb_AclaracionTipoPersona.SelectedValue.ToString()) : (int?)null,
                    AclaracionSexo = cb_AclaracionSexo.SelectedValue != null ? cb_AclaracionSexo.SelectedValue.ToString() : null,
                    AclaracionEdad = cb_AclaracionEdad.SelectedValue != null ? int.Parse(cb_AclaracionEdad.SelectedValue.ToString()) : (int?)null,
                    AclaracionNivelAtencion = cb_AclaracionNivelAtencion.SelectedValue != null ? int.Parse(cb_AclaracionNivelAtencion.SelectedValue.ToString()) : (int?)null,
                    AclaracionFolioCondusef = txt_AclaracionFolioCondusef.Text,
                    AclaracionReversa = cb_AclaracionReversa.SelectedValue != null ? cb_AclaracionReversa.SelectedValue.ToString() : null,
                    AclaracionOperacionExtranjero = cb_AclaracionOperacionExtranjero.SelectedValue != null ? cb_AclaracionOperacionExtranjero.SelectedValue.ToString() : null
                };

                var aclaraciones = new List<Aclaracion_Model> { aclaracion };

                bool success = await _aclaracionesService.SendAclaraciones(aclaraciones);

                if (success)
                {
                    Toast.Correcto("Aclaración enviada correctamente.");
                }
                else
                {
                    Toast.Error("Error al enviar la aclaración.");
                }
            }
            catch (Exception ex)
            {
                Toast.Error("Error: " + ex.Message);
            }
        }
        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            string campos = string.Empty;

            try
            {
                campos = $"{txt_AclaracionDenominacion.Text}|{txt_AclaracionSector.Text}|{cb_AclaracionTrimestre.SelectedValue}|{cb_AclaracionNumero.SelectedValue}|{txt_AclaracionFolioAtencion.Text}|{cb_AclaracionEstadoConPend.SelectedValue}|{dp_AclaracionFechaAclaracionReclmacion.SelectedDate?.ToString("dd/MM/yyyy")}|{dp_AclaracionFechaAtencion.SelectedDate?.ToString("dd/MM/yyyy")}|{txt_AclaracionMedioAclaracionepcionCanal.Text}|{txt_AclaracionProductoServicio.Text}|{txt_AclaracionCausaMotivo.Text}|{dp_AclaracionFechaResolucion.SelectedDate?.ToString("dd/MM/yyyy")}|{dp_AclaracionFechaNotifiUsuario.SelectedDate?.ToString("dd/MM/yyyy")}|{txt_AclaracionEntidadFederativa.Text}|{txt_AclaracionCodigoPostal.Text}|{txt_AclaracionMunicipioAlcaldia.Text}|{txt_AclaracionLocalidad.Text}|{txt_AclaracionColonia.Text}|{cb_AclaracionMonetario.SelectedValue}|{txt_AclaracionMontoReclamado.Text}|{cb_AclaracionPori.SelectedValue}|{cb_AclaracionTipoPersona.SelectedValue}|{cb_AclaracionSexo.SelectedValue}|{cb_AclaracionEdad.SelectedValue}|{cb_AclaracionNivelAtencion.SelectedValue}|{txt_AclaracionFolioCondusef.Text}|{cb_AclaracionReversa.SelectedValue}|{cb_AclaracionOperacionExtranjero.SelectedValue}";

                if (SesionTemporal.GuardarPreInfo(campos, fileName))
                {
                    Toast.CreateLog("Aclaraciones", "Datos guardados correctamente.");
                }
                else
                {
                    Toast.CreateLog("Aclaraciones", "Error al guardar información previa");
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al guardar los datos ", ex);
            }
            finally { campos = string.Empty; }
        }

        private void btn_Cargar_Click(object sender, RoutedEventArgs e)
        {
            string campos = string.Empty;

            try
            {
                campos = SesionTemporal.ObtenerPreInfo(fileName);
                if (campos != null)
                {
                    var parts = campos.Split('|');

                    if (parts.Length >= 27)
                    {
                        txt_AclaracionDenominacion.Text = parts[0];
                        txt_AclaracionSector.Text = parts[1];
                        cb_AclaracionTrimestre.SelectedValue = parts[2];
                        cb_AclaracionNumero.SelectedValue = parts[3];
                        txt_AclaracionFolioAtencion.Text = parts[4];
                        cb_AclaracionEstadoConPend.SelectedValue = parts[5];
                        dp_AclaracionFechaAclaracionReclmacion.SelectedDate = DateTime.ParseExact(parts[6], "dd/MM/yyyy", null);
                        dp_AclaracionFechaAtencion.SelectedDate = DateTime.ParseExact(parts[7], "dd/MM/yyyy", null);
                        txt_AclaracionMedioAclaracionepcionCanal.Text = parts[8];
                        txt_AclaracionProductoServicio.Text = parts[9];
                        txt_AclaracionCausaMotivo.Text = parts[10];
                        dp_AclaracionFechaResolucion.SelectedDate = DateTime.ParseExact(parts[11], "dd/MM/yyyy", null);
                        dp_AclaracionFechaNotifiUsuario.SelectedDate = DateTime.ParseExact(parts[12], "dd/MM/yyyy", null);
                        txt_AclaracionEntidadFederativa.Text = parts[13];
                        txt_AclaracionCodigoPostal.Text = parts[14];
                        txt_AclaracionMunicipioAlcaldia.Text = parts[15];
                        txt_AclaracionLocalidad.Text = parts[16];
                        txt_AclaracionColonia.Text = parts[17];
                        cb_AclaracionMonetario.SelectedValue = parts[18];
                        txt_AclaracionMontoReclamado.Text = parts[19];
                        cb_AclaracionPori.SelectedValue = parts[20];
                        cb_AclaracionTipoPersona.SelectedValue = parts[21];
                        cb_AclaracionSexo.SelectedValue = parts[22];
                        cb_AclaracionEdad.SelectedValue = parts[23];
                        cb_AclaracionNivelAtencion.SelectedValue = parts[24];
                        txt_AclaracionFolioCondusef.Text = parts[25];
                        cb_AclaracionReversa.SelectedValue = parts[26];
                        cb_AclaracionOperacionExtranjero.SelectedValue = parts[27];

                        Toast.Correcto("Datos cargados correctamente.");
                        Toast.Correcto("Verifica los campos antes de enviar la solicitud.");
                    }
                    else
                    {
                        Toast.CreateLog("Aclaraciones", "Error al obtener la información previa");
                    }
                }
                else
                {
                    Toast.Error("No existe información para pre cargar.");
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al obtener los datos ", ex);
            }
            finally { campos = string.Empty; }
        }

        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            CargarPreInformacio();
        }
    }
}
