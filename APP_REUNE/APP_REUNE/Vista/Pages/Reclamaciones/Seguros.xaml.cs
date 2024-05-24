using APP_REUNE.Service;
using APP_REUNE.Utilidad;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace APP_REUNE.Vista.Pages.Reclamaciones
{
    /// <summary>
    /// Lógica de interacción para Seguros.xaml
    /// </summary>
    public partial class Seguros : Page
    {
        private readonly ReclamacionesSeguros_Service _service;
        private readonly string fileName = "ReclamacionesSeguros.txt";

        public Seguros()
        {
            InitializeComponent();
            CargarPreInformacio();
            _service = new ReclamacionesSeguros_Service();
        }

        private void CargarPreInformacio()
        {
            txt_RecDenominacion.Text = string.Empty;
            txt_RecSector.Text = string.Empty;
            cb_RecRamo.SelectedIndex =0;
            cb_RecTrimestre.SelectedIndex = 0;
            cb_RecNumero.SelectedIndex = 0;
            txt_RecFolioAtencion.Text = string.Empty;
            cb_RecEstadoConPend.SelectedIndex = 0;
            dp_RecFechaReclamacion.SelectedDate = DateTime.Now;
            dp_RecFechaAtencion.SelectedDate = DateTime.Now;
            txt_RecMedioRecepcionCanal.Text = string.Empty;
            txt_RecProductoServicio.Text = string.Empty;
            txt_RecCausaMotivo.Text = string.Empty;
            dp_RecFechaResolucion.SelectedDate = DateTime.Now;
            dp_RecFechaNotifiUsuario.SelectedDate = DateTime.Now;
            txt_RecEntidadFederativa.Text = string.Empty;
            txt_RecCodigoPostal.Text = string.Empty;
            txt_RecMunicipioAlcaldia.Text = string.Empty;
            txt_RecLocalidad.Text = string.Empty;
            txt_RecColonia.Text = string.Empty;
            cb_RecMonetario.SelectedIndex = 0;
            txt_RecMontoReclamado.Text = string.Empty;
            txt_RecImporteAbonado.Text = string.Empty;
            dp_RecFechaAbonoImporte.SelectedDate = DateTime.Now;
            cb_RecPori.SelectedIndex = 0;
            cb_RecTipoPersona.SelectedIndex = 0;
            cb_RecSexo.SelectedIndex = 0;
            cb_RecEdad.SelectedIndex = 0;
            cb_RecSentidoResolucion.SelectedIndex = 0;
            cb_RecNivelAtencion.SelectedIndex = 0;
            txt_RecFolioCondusef.Text = string.Empty;
            cb_RecReversa.SelectedIndex = 0;
            Utilidad.Util.CargarComboTrimestre(cb_RecTrimestre);
            Utilidad.Util.CargarComboNumero(cb_RecNumero);
            Utilidad.Util.CargarComboEstadoConPend(cb_RecEstadoConPend);
            Utilidad.Util.CargarComboMonetario(cb_RecMonetario);
            Utilidad.Util.CargarComboPORI(cb_RecPori);
            Utilidad.Util.CargarComboTipoPersona(cb_RecTipoPersona);
            Utilidad.Util.CargarComboSexo(cb_RecSexo);
            Utilidad.Util.CargarComboEdad(cb_RecEdad);
            Utilidad.Util.CargarComboNivelAtencion(cb_RecNivelAtencion);
            Utilidad.Util.CargarComboReversa(cb_RecReversa);
            Utilidad.Util.CargarComboResolucion(cb_RecSentidoResolucion);
            Utilidad.Util.CargarComboRamo(cb_RecRamo);
            txt_RecDenominacion.Text = "SAM Asset Management S.A. de C.V., Sociedad Operadora de Fondos de Inversión.";
            txt_RecSector.Text = "Sociedad Operadora de Fondos de Inversión";
            txt_RecEntidadFederativa.Text = "09";
            txt_RecCodigoPostal.Text = "5120";
            txt_RecMunicipioAlcaldia.Text = "004";
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

                    var reclamaciones = JsonConvert.DeserializeObject<List<ReclamacionSeguros_Model>>(jsonContent);

                    if (reclamaciones != null)
                    {
                        var success = await _service.SendReclamacionesSeguros(reclamaciones);

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
                Toast.Sistema("Error al leer archivo json: ", ex);
            }
        }

        private async void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var reclamacion = new ReclamacionSeguros_Model
                {
                    RecDenominacion = txt_RecDenominacion.Text,
                    RecSector = txt_RecSector.Text,
                    RecRamo = int.Parse(cb_RecRamo.SelectedValue.ToString()),
                    RecTrimestre = int.Parse(cb_RecTrimestre.SelectedValue.ToString()),
                    RecNumero = int.Parse(cb_RecNumero.SelectedValue.ToString()),
                    RecFolioAtencion = txt_RecFolioAtencion.Text,
                    RecEstadoConPend = int.Parse(cb_RecEstadoConPend.SelectedValue.ToString()),
                    RecFechaReclamacion = dp_RecFechaReclamacion.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecFechaAtencion = dp_RecFechaAtencion.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecMedioRecepcionCanal = int.Parse(txt_RecMedioRecepcionCanal.Text),
                    RecProductoServicio = txt_RecProductoServicio.Text,
                    RecCausaMotivo = txt_RecCausaMotivo.Text,
                    RecFechaResolucion = dp_RecFechaResolucion.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecFechaNotifiUsuario = dp_RecFechaNotifiUsuario.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecEntidadFederativa = int.Parse(txt_RecEntidadFederativa.Text),
                    RecCodigoPostal = int.Parse(txt_RecCodigoPostal.Text),
                    RecMunicipioAlcaldia = int.Parse(txt_RecMunicipioAlcaldia.Text),
                    RecLocalidad = string.IsNullOrEmpty(txt_RecLocalidad.Text) ? (int?)null : int.Parse(txt_RecLocalidad.Text),
                    RecColonia = string.IsNullOrEmpty(txt_RecColonia.Text) ? (int?)null : int.Parse(txt_RecColonia.Text),
                    RecMonetario = cb_RecMonetario.SelectedValue.ToString(),
                    RecMontoReclamado = string.IsNullOrEmpty(txt_RecMontoReclamado.Text) ? (decimal?)null : decimal.Parse(txt_RecMontoReclamado.Text),
                    RecImporteAbonado = string.IsNullOrEmpty(txt_RecImporteAbonado.Text) ? (decimal?)null : decimal.Parse(txt_RecImporteAbonado.Text),
                    RecFechaAbonoImporte = dp_RecFechaAbonoImporte.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecPori = cb_RecPori.SelectedValue.ToString(),
                    RecTipoPersona = int.Parse(cb_RecTipoPersona.SelectedValue.ToString()),
                    RecSexo = cb_RecSexo.SelectedValue.ToString(),
                    RecEdad = int.Parse(cb_RecEdad.SelectedValue.ToString()),
                    RecSentidoResolucion = int.Parse(cb_RecSentidoResolucion.SelectedValue.ToString()),
                    RecNivelAtencion = int.Parse(cb_RecNivelAtencion.SelectedValue.ToString()),
                    RecFolioCondusef = txt_RecFolioCondusef.Text,
                    RecReversa = cb_RecReversa.SelectedValue.ToString()
                };

                var reclamaciones = new List<ReclamacionSeguros_Model> { reclamacion };
                var success = await _service.SendReclamacionesSeguros(reclamaciones);

                if (success)
                {
                    Toast.Correcto("Reclamación enviada correctamente.");
                }
                else
                {
                    Toast.Error("Error al enviar la reclamación.");
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al enviar la reclamación: ", ex);
            }
        }

        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            CargarPreInformacio();
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            string campos = string.Empty;

            try
            {
                campos = $"{txt_RecDenominacion.Text}|{txt_RecSector.Text}|{cb_RecRamo.SelectedValue}|{cb_RecTrimestre.SelectedValue}|{cb_RecNumero.SelectedValue}|{txt_RecFolioAtencion.Text}|{cb_RecEstadoConPend.SelectedValue}|{dp_RecFechaReclamacion.SelectedDate?.ToString("dd/MM/yyyy")}|{dp_RecFechaAtencion.SelectedDate?.ToString("dd/MM/yyyy")}|{txt_RecMedioRecepcionCanal.Text}|{txt_RecProductoServicio.Text}|{txt_RecCausaMotivo.Text}|{dp_RecFechaResolucion.SelectedDate?.ToString("dd/MM/yyyy")}|{dp_RecFechaNotifiUsuario.SelectedDate?.ToString("dd/MM/yyyy")}|{txt_RecEntidadFederativa.Text}|{txt_RecCodigoPostal.Text}|{txt_RecMunicipioAlcaldia.Text}|{txt_RecLocalidad.Text}|{txt_RecColonia.Text}|{cb_RecMonetario.SelectedValue}|{txt_RecMontoReclamado.Text}|{txt_RecImporteAbonado.Text}|{dp_RecFechaAbonoImporte.SelectedDate?.ToString("dd/MM/yyyy")}|{cb_RecPori.SelectedValue}|{cb_RecTipoPersona.SelectedValue}|{cb_RecSexo.SelectedValue}|{cb_RecEdad.SelectedValue}|{cb_RecSentidoResolucion.SelectedValue}|{cb_RecNivelAtencion.SelectedValue}|{txt_RecFolioCondusef.Text}|{cb_RecReversa.SelectedValue}";

                if (SesionTemporal.GuardarPreInfo(campos, fileName))
                {
                    Toast.Correcto("Datos guardados correctamente.");
                }
                else
                {
                    Toast.Error("Error al guardar información previa");
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al guardar los datos: ", ex);
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

                    if (parts.Length >= 30)
                    {
                        txt_RecDenominacion.Text = parts[0];
                        txt_RecSector.Text = parts[1];
                        cb_RecRamo.SelectedValue = parts[2];
                        cb_RecTrimestre.SelectedValue = parts[3];
                        cb_RecNumero.SelectedValue = parts[4];
                        txt_RecFolioAtencion.Text = parts[5];
                        cb_RecEstadoConPend.SelectedValue = parts[6];
                        dp_RecFechaReclamacion.SelectedDate = DateTime.ParseExact(parts[7], "dd/MM/yyyy", null);
                        dp_RecFechaAtencion.SelectedDate = DateTime.ParseExact(parts[8], "dd/MM/yyyy", null);
                        txt_RecMedioRecepcionCanal.Text = parts[9];
                        txt_RecProductoServicio.Text = parts[10];
                        txt_RecCausaMotivo.Text = parts[11];
                        dp_RecFechaResolucion.SelectedDate = DateTime.ParseExact(parts[12], "dd/MM/yyyy", null);
                        dp_RecFechaNotifiUsuario.SelectedDate = DateTime.ParseExact(parts[13], "dd/MM/yyyy", null);
                        txt_RecEntidadFederativa.Text = parts[14];
                        txt_RecCodigoPostal.Text = parts[15];
                        txt_RecMunicipioAlcaldia.Text = parts[16];
                        txt_RecLocalidad.Text = parts[17];
                        txt_RecColonia.Text = parts[18];
                        cb_RecMonetario.SelectedValue = parts[19];
                        txt_RecMontoReclamado.Text = parts[20];
                        txt_RecImporteAbonado.Text = parts[21];
                        dp_RecFechaAbonoImporte.SelectedDate = DateTime.ParseExact(parts[22], "dd/MM/yyyy", null);
                        cb_RecPori.SelectedValue = parts[23];
                        cb_RecTipoPersona.SelectedValue = parts[24];
                        cb_RecSexo.SelectedValue = parts[25];
                        cb_RecEdad.SelectedValue = parts[26];
                        cb_RecSentidoResolucion.SelectedValue = parts[27];
                        cb_RecNivelAtencion.SelectedValue = parts[28];
                        txt_RecFolioCondusef.Text = parts[29];
                        cb_RecReversa.SelectedValue = parts[30];

                        Toast.Correcto("Datos cargados correctamente.");
                        Toast.Correcto("Verifica los campos antes de enviar la solicitud.");
                    }
                    else
                    {
                        Toast.CreateLog("Seguros", "Error al obtener la información previa");
                    }
                }
                else
                {
                    Toast.Error("No existe información para pre cargar.");
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al cargar los datos: ", ex);
            }
            finally { campos = string.Empty; }
        }
    }
}
