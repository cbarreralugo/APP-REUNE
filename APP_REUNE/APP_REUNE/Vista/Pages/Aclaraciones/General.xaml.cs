using APP_REUNE.Service;
using APP_REUNE.Utilidad;
using APP_REUNE.Vista.PreInfo;
using APP_REUNE_Negocio.Datos;
using APP_REUNE_Negocio.Modelo;
using APP_REUNE_Negocio.Utilidades;
using ClosedXML.Excel;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
        Configuracion_Datos datos = new Configuracion_Datos();

        private string fileName = string.Empty;
        private int id = 0;
        private string api = string.Empty;

        public General()
        {
            InitializeComponent();
            CargarPreInformacio();
        }

        private void CargarPreInformacio()
        {

            TipoSolicitudes_Modelo modelo = datos.Obtener_TipoSolicitud(Configuracion_Datos.tipo.Aclaraciones_General);
            fileName = modelo.archivo;
            id = modelo.id;
            api = modelo.api;
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
            dg_tabla.LoadData(null, "");//reiniciar tabla
            dg_tabla.Visibility = Visibility.Collapsed;//ocultar tabla
            btn_Cargar_Click(null, null);
        }

        private async void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var aclaracion = new Aclaracion_Model
                {
                    AclaracionDenominacion = txt_AclaracionDenominacion.Text,
                    AclaracionSector = txt_AclaracionSector.Text,
                    AclaracionTrimestre = ((Combo)cb_AclaracionTrimestre.SelectedItem)?.ID ?? (int?)null,
                    AclaracionNumero = ((Combo)cb_AclaracionNumero.SelectedItem)?.ID ?? (int?)null,
                    AclaracionFolioAtencion = txt_AclaracionFolioAtencion.Text,
                    AclaracionEstadoConPend = ((Combo)cb_AclaracionEstadoConPend.SelectedItem)?.ID ?? (int?)null,
                    AclaracionFechaAclaracion = dp_AclaracionFechaAclaracionReclmacion.SelectedDate?.ToString("dd/MM/yyyy"),
                    AclaracionFechaAtencion = dp_AclaracionFechaAtencion.SelectedDate?.ToString("dd/MM/yyyy"),
                    AclaracionMedioRecepcionCanal = !string.IsNullOrEmpty(txt_AclaracionMedioAclaracionepcionCanal.Text) ? int.Parse(txt_AclaracionMedioAclaracionepcionCanal.Text) : (int?)null,
                    AclaracionProductoServicio = txt_AclaracionProductoServicio.Text,
                    AclaracionCausaMotivo = txt_AclaracionCausaMotivo.Text,
                    AclaracionFechaResolucion = dp_AclaracionFechaResolucion.SelectedDate?.ToString("dd/MM/yyyy"),
                    AclaracionFechaNotifiUsuario = dp_AclaracionFechaNotifiUsuario.SelectedDate?.ToString("dd/MM/yyyy"),
                    AclaracionEntidadFederativa = !string.IsNullOrEmpty(txt_AclaracionEntidadFederativa.Text) ? int.Parse(txt_AclaracionEntidadFederativa.Text) : (int?)null,
                    AclaracionCodigoPostal = !string.IsNullOrEmpty(txt_AclaracionCodigoPostal.Text) ? int.Parse(txt_AclaracionCodigoPostal.Text) : (int?)null,
                    AclaracionMunicipioAlcaldia = !string.IsNullOrEmpty(txt_AclaracionMunicipioAlcaldia.Text) ? int.Parse(txt_AclaracionMunicipioAlcaldia.Text) : (int?)null,
                    AclaracionLocalidad = !string.IsNullOrEmpty(txt_AclaracionLocalidad.Text) ? int.Parse(txt_AclaracionLocalidad.Text) : (int?)null,
                    AclaracionColonia = !string.IsNullOrEmpty(txt_AclaracionColonia.Text) ? int.Parse(txt_AclaracionColonia.Text) : (int?)null,
                    AclaracionMonetario = ((Combo)cb_AclaracionMonetario.SelectedItem)?.IDs,
                    AclaracionMontoReclamado = !string.IsNullOrEmpty(txt_AclaracionMontoReclamado.Text) ? decimal.Parse(txt_AclaracionMontoReclamado.Text) : (decimal?)null,
                    AclaracionPori = ((Combo)cb_AclaracionPori.SelectedItem)?.IDs,
                    AclaracionTipoPersona = ((Combo)cb_AclaracionTipoPersona.SelectedItem)?.ID ?? (int?)null,
                    AclaracionSexo = ((Combo)cb_AclaracionSexo.SelectedItem)?.IDs,
                    AclaracionEdad = ((Combo)cb_AclaracionEdad.SelectedItem)?.ID ?? (int?)null,
                    AclaracionNivelAtencion = ((Combo)cb_AclaracionNivelAtencion.SelectedItem)?.ID ?? (int?)null,
                    AclaracionFolioCondusef = string.IsNullOrEmpty(txt_AclaracionFolioCondusef.Text) ? null : txt_AclaracionFolioCondusef.Text,
                    AclaracionReversa = ((Combo)cb_AclaracionReversa.SelectedItem)?.IDs,
                    AclaracionOperacionExtranjero = ((Combo)cb_AclaracionOperacionExtranjero.SelectedItem)?.IDs
                };

                var aclaraciones = new List<Aclaracion_Model> { aclaracion };

                string endpoint = api;
                if (endpoint != null)
                {
                    var success = await Utilidad.SendDataFrom.SendData(aclaraciones, endpoint, id);

                    if (success)
                    {
                        Toast.Correcto("Aclaración enviada correctamente.");
                    }
                    else
                    {
                        Toast.Error("Error al enviar la aclaración.");
                    }
                }
                else
                {
                    Toast.Error("Error, no se encontró API.");
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

                    if (parts.Length >= 28)
                    {
                        txt_AclaracionDenominacion.Text = parts[0];
                        txt_AclaracionSector.Text = parts[1];
                        cb_AclaracionTrimestre.SelectedValue = parts[2] != "" ? int.Parse(parts[2]) : (int?)null;
                        cb_AclaracionNumero.SelectedValue = parts[3] != "" ? int.Parse(parts[3]) : (int?)null;
                        txt_AclaracionFolioAtencion.Text = parts[4];
                        cb_AclaracionEstadoConPend.SelectedValue = parts[5] != "" ? int.Parse(parts[5]) : (int?)null;
                        dp_AclaracionFechaAclaracionReclmacion.SelectedDate = parts[6] != "" ? DateTime.ParseExact(parts[6], "dd/MM/yyyy", null) : (DateTime?)null;
                        dp_AclaracionFechaAtencion.SelectedDate = parts[7] != "" ? DateTime.ParseExact(parts[7], "dd/MM/yyyy", null) : (DateTime?)null;
                        txt_AclaracionMedioAclaracionepcionCanal.Text = parts[8];
                        txt_AclaracionProductoServicio.Text = parts[9];
                        txt_AclaracionCausaMotivo.Text = parts[10];
                        dp_AclaracionFechaResolucion.SelectedDate = parts[11] != "" ? DateTime.ParseExact(parts[11], "dd/MM/yyyy", null) : (DateTime?)null;
                        dp_AclaracionFechaNotifiUsuario.SelectedDate = parts[12] != "" ? DateTime.ParseExact(parts[12], "dd/MM/yyyy", null) : (DateTime?)null;
                        txt_AclaracionEntidadFederativa.Text = parts[13];
                        txt_AclaracionCodigoPostal.Text = parts[14];
                        txt_AclaracionMunicipioAlcaldia.Text = parts[15];
                        txt_AclaracionLocalidad.Text = parts[16];
                        txt_AclaracionColonia.Text = parts[17];
                        cb_AclaracionMonetario.SelectedValue = parts[18];
                        txt_AclaracionMontoReclamado.Text = parts[19];
                        cb_AclaracionPori.SelectedValue = parts[20];
                        cb_AclaracionTipoPersona.SelectedValue = parts[21] != "" ? int.Parse(parts[21]) : (int?)null;
                        cb_AclaracionSexo.SelectedValue = parts[22];
                        cb_AclaracionEdad.SelectedValue = parts[23] != "" ? int.Parse(parts[23]) : (int?)null;
                        cb_AclaracionNivelAtencion.SelectedValue = parts[24] != "" ? int.Parse(parts[24]) : (int?)null;
                        txt_AclaracionFolioCondusef.Text = parts[25];
                        cb_AclaracionReversa.SelectedValue = parts[26] != "" ? int.Parse(parts[26]) : (int?)null;
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

        private async void CargaMasivaJson_Click(object sender, RoutedEventArgs e)
        {
            string endpoint = api; 
            if (endpoint != null)
            {
                var success = await Utilidad.SendDataFrom.SendDataFromJson<Aclaracion_Model>(endpoint,id);

                if (success)
                {
                    Toast.Correcto("Aclaración enviada correctamente.");
                }
                else
                {
                    Toast.Error("Error al enviar la aclaración.");
                }
            }
            else
            {
                Toast.Error("Error, no se encontro api.");
            }
        }

        private async void CargaMasivaExcel_Click(object sender, RoutedEventArgs e)
        {
            string endpoint = api;
            if (endpoint != null)
            {
                var success = await Utilidad.SendDataFrom.SendDataFromExcel<Aclaracion_Model>(endpoint,id);

                if (success)
                {
                    Toast.Correcto("Aclaración enviada correctamente.");
                }
                else
                {
                    Toast.Error("Error al enviar la aclaración.");
                }
            }
            else
            {
                Toast.Error("Error, no se encontro api.");
            }
        }

        private async void CargaMasivaTxt_Click(object sender, RoutedEventArgs e)
        {
            string endpoint = api;
            if (endpoint != null)
            {
                var success = await Utilidad.SendDataFrom.SendDataFromTxt<Aclaracion_Model>(endpoint,id);

                if (success)
                {
                    Toast.Correcto("Aclaración enviada correctamente.");
                }
                else
                {
                    Toast.Error("Error al enviar la aclaración.");
                }
            }
            else
            {
                Toast.Error("Error, no se encontro api.");
            }
        }

        private void Nueva_Click(object sender, RoutedEventArgs e)
        {
            CargarPreInformacio();
        }

        private void Historial_Click(object sender, RoutedEventArgs e)
        {
            Historial_Datos datos = new Historial_Datos();
            DataTable dt = new DataTable();
            dt = datos.ObtenerHistorial((int)Configuracion_Datos.tipo.Aclaraciones_General);
            if (dt.Rows.Count > 0)
            {
                dg_tabla.LoadData(dt, "Historial de Solicitudes de Aclaraciones General"); 
                dg_tabla.Visibility = Visibility.Visible;
                Toast.Correcto("Historial de todas las solicitudes de Aclaraciones");
            }
            else
            {
                Toast.Error("No se encontraron registros","No hay registros");
            }
        }

        private void EliminarHistorial_Click(object sender, RoutedEventArgs e)
        {
            Toast.Denegado("No tienes permisos para realizar esta acción");
        }

        private void ReiniciarSistema_Click(object sender, RoutedEventArgs e)
        {
            SesionTemporal.RestartApplication();
        }

        private void ComoFunciona_Click(object sender, RoutedEventArgs e)
        {
            ComoFunciona cf = new ComoFunciona();
            cf.Show();
        }

        private void NotificarFallaSistema_Click(object sender, RoutedEventArgs e)
        {
            Ayuda notificar = new Ayuda();
            notificar.Show();
        }
    }
}
