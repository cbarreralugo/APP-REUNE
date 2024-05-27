using APP_REUNE.Service;
using APP_REUNE.Utilidad;
using APP_REUNE.Vista.PreInfo;
using APP_REUNE_Negocio.Datos;
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
    /// Lógica de interacción para InstitucionesCredito.xaml
    /// </summary>
    public partial class InstitucionesCredito : Page
    {
        Configuracion_Datos datos = new Configuracion_Datos();

        private string fileName = string.Empty;
        private int id = 0;
        private string api = string.Empty;

        public InstitucionesCredito()
        {
            InitializeComponent();
            CargarPreInformacio();
        }

        private void CargarPreInformacio()
        {

            TipoSolicitudes_Modelo modelo = datos.Obtener_TipoSolicitud(Configuracion_Datos.tipo.Reclamaciones_SIC);
            fileName = modelo.archivo;
            id = modelo.id;
            api = modelo.api;
            // Limpiar todos los campos
            txt_RecDenominacion.Clear();
            txt_RecSector.Clear();
            cb_RecTrimestre.SelectedIndex = 0;
            cb_RecNumero.SelectedIndex = 0;
            txt_RecFolioAtencion.Clear();
            txt_RecSubFolioAtencion.Clear();
            cb_RecEstadoConPend.SelectedIndex = 0;
            dp_RecFechaReclamacion.SelectedDate = DateTime.Now;
            dp_RecFechaAtencion.SelectedDate = DateTime.Now;
            txt_RecMedioRecepcionCanal.Clear();
            txt_RecProductoServicio.Clear();
            txt_RecCausaMotivo.Clear();
            dp_RecFechaResolucion.SelectedDate = DateTime.Now;
            dp_RecFechaNotifiUsuario.SelectedDate = DateTime.Now;
            txt_RecEntidadFederativa.Clear();
            txt_RecCodigoPostal.Clear();
            txt_RecMunicipioAlcaldia.Clear();
            txt_RecLocalidad.Clear();
            txt_RecColonia.Clear();
            cb_RecTipoPersona.SelectedIndex = 0;
            cb_RecNivelAtencion.SelectedIndex = 0;
            txt_RecClaveSIPRES.Clear();
            txt_RecFolioCondusef.Clear();
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
            txt_RecDenominacion.Text = CamposPreCargados.Denominacion;
            txt_RecSector.Text = CamposPreCargados.Sector;
            txt_RecEntidadFederativa.Text = CamposPreCargados.EntidadFederativa;
            txt_RecCodigoPostal.Text = CamposPreCargados.CodigoPostal;
            txt_RecMunicipioAlcaldia.Text = CamposPreCargados.DelegacionMunicipio;
            txt_RecLocalidad.Text = CamposPreCargados.Localidad;
            txt_RecColonia.Text = CamposPreCargados.Colonia;

        }

        private void DpFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Aquí puedes manejar lo que sucede cuando cambia la fecha seleccionada
            //MessageBox.Show("Fecha seleccionada: " + dp_RecFechaReclamacion.SelectedDate.Value.ToString("dd/MM/yyyy"));
        }
 
        private async void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var reclamacion = new ReclamacionCredito_Model
                {
                    RecDenominacion = txt_RecDenominacion.Text,
                    RecSector = txt_RecSector.Text,
                    RecTrimestre = int.Parse(cb_RecTrimestre.SelectedValue?.ToString() ?? "0"),
                    RecNumero = int.Parse(cb_RecNumero.SelectedValue?.ToString() ?? "0"),
                    RecFolioAtencion = txt_RecFolioAtencion.Text,
                    RecSubFolioAtencion = txt_RecSubFolioAtencion.Text,
                    RecEstadoConPend = int.Parse(cb_RecEstadoConPend.SelectedValue?.ToString() ?? "0"),
                    RecFechaReclamacion = dp_RecFechaReclamacion.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecFechaAtencion = dp_RecFechaAtencion.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecMedioRecepcionCanal = int.TryParse(txt_RecMedioRecepcionCanal.Text, out var medioRecepcionCanal) ? medioRecepcionCanal : 0,
                    RecProductoServicio = txt_RecProductoServicio.Text,
                    RecCausaMotivo = txt_RecCausaMotivo.Text,
                    RecFechaResolucion = dp_RecFechaResolucion.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecFechaNotifiUsuario = dp_RecFechaNotifiUsuario.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecEntidadFederativa = int.TryParse(txt_RecEntidadFederativa.Text, out var entidadFederativa) ? entidadFederativa : 0,
                    RecCodigoPostal = int.TryParse(txt_RecCodigoPostal.Text, out var codigoPostal) ? codigoPostal : 0,
                    RecMunicipioAlcaldia = int.TryParse(txt_RecMunicipioAlcaldia.Text, out var municipioAlcaldia) ? municipioAlcaldia : 0,
                    RecLocalidad = int.TryParse(txt_RecLocalidad.Text, out var localidad) ? localidad : 0,
                    RecColonia = string.IsNullOrEmpty(txt_RecColonia.Text) ? (int?)null : int.TryParse(txt_RecColonia.Text, out var colonia) ? colonia : (int?)null,
                    RecTipoPersona = int.TryParse(cb_RecTipoPersona.SelectedValue?.ToString(), out var tipoPersona) ? tipoPersona : 0,
                    RecNivelAtencion = int.TryParse(cb_RecNivelAtencion.SelectedValue?.ToString(), out var nivelAtencion) ? nivelAtencion : 0,
                    RecClaveSIPRES = int.TryParse(txt_RecClaveSIPRES.Text, out var claveSIPRES) ? claveSIPRES : 0,
                    RecFolioCondusef = txt_RecFolioCondusef.Text,
                    RecReversa = cb_RecReversa.Text
                };

                var reclamaciones = new List<ReclamacionCredito_Model> { reclamacion };
                string endpoint = api;
                if (endpoint != null)
                {
                    var success = await Utilidad.SendDataFrom.SendData(reclamaciones, endpoint, id);

                    if (success)
                    {
                        Toast.Correcto("Reclamación enviada correctamente.");
                    }
                    else
                    {
                        Toast.Error("Error al enviar la reclamación.");
                    }
                }
                else
                {
                    Toast.Error("Error, no se encontro api.");
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error: " ,ex);
            }
        }
        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            string campos = string.Empty;

            try
            {
                campos = $"{txt_RecDenominacion.Text}|{txt_RecSector.Text}|{cb_RecTrimestre.SelectedValue}|{cb_RecNumero.SelectedValue}|{txt_RecFolioAtencion.Text}|{txt_RecSubFolioAtencion.Text}|{cb_RecEstadoConPend.SelectedValue}|{dp_RecFechaReclamacion.SelectedDate?.ToString("dd/MM/yyyy")}|{dp_RecFechaAtencion.SelectedDate?.ToString("dd/MM/yyyy")}|{txt_RecMedioRecepcionCanal.Text}|{txt_RecProductoServicio.Text}|{txt_RecCausaMotivo.Text}|{dp_RecFechaResolucion.SelectedDate?.ToString("dd/MM/yyyy")}|{dp_RecFechaNotifiUsuario.SelectedDate?.ToString("dd/MM/yyyy")}|{txt_RecEntidadFederativa.Text}|{txt_RecCodigoPostal.Text}|{txt_RecMunicipioAlcaldia.Text}|{txt_RecLocalidad.Text}|{txt_RecColonia.Text}|{cb_RecTipoPersona.SelectedValue}|{cb_RecNivelAtencion.SelectedValue}|{txt_RecClaveSIPRES.Text}|{txt_RecFolioCondusef.Text}|{cb_RecReversa.SelectedValue}";

                if (SesionTemporal.GuardarPreInfo(campos, fileName))
                {
                    Toast.CreateLog("Reclamaciones", "Datos guardados correctamente.");
                }
                else
                {
                    Toast.CreateLog("Reclamaciones", "Error al guardar información previa");
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

                    if (parts.Length >= 24)
                    {
                        txt_RecDenominacion.Text = parts[0];
                        txt_RecSector.Text = parts[1];
                        cb_RecTrimestre.SelectedValue = parts[2];
                        cb_RecNumero.SelectedValue = parts[3];
                        txt_RecFolioAtencion.Text = parts[4];
                        txt_RecSubFolioAtencion.Text = parts[5];
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
                        cb_RecTipoPersona.SelectedValue = parts[19];
                        cb_RecNivelAtencion.SelectedValue = parts[20];
                        txt_RecClaveSIPRES.Text = parts[21];
                        txt_RecFolioCondusef.Text = parts[22];
                        cb_RecReversa.SelectedValue = parts[23];

                        Toast.Correcto("Datos cargados correctamente.");
                        Toast.Correcto("Verifica los campos antes de enviar la solicitud.");
                    }
                    else
                    {
                        Toast.CreateLog("Reclamaciones", "Error al obtener la información previa");
                    }
                }
                else
                {
                    Toast.Error("No existe información para pre cargar.");
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al cargar los datos ", ex);
            }
            finally { campos = string.Empty; }
        }
        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {
            CargarPreInformacio();
        }



        private async void CargaMasivaJson_Click(object sender, RoutedEventArgs e)
        {
            string endpoint = api;
            if (endpoint != null)
            {
                var success = await Utilidad.SendDataFrom.SendDataFromJson<ReclamacionCredito_Model>(endpoint, id);
                if (success)
                {
                    Toast.Correcto("Reclamación enviada correctamente.");
                }
                else
                {
                    Toast.Error("Error al enviar la reclamación.");
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
                var success = await Utilidad.SendDataFrom.SendDataFromExcel<ReclamacionCredito_Model>(endpoint, id);
                if (success)
                {
                    Toast.Correcto("Reclamación enviada correctamente.");
                }
                else
                {
                    Toast.Error("Error al enviar la reclamación.");
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
                var success = await Utilidad.SendDataFrom.SendDataFromTxt<ReclamacionCredito_Model>(endpoint, id);
                if (success)
                {
                    Toast.Correcto("Reclamación enviada correctamente.");
                }
                else
                {
                    Toast.Error("Error al enviar la reclamación.");
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
            Toast.Notifiacion("Acción no disponible por ahora");
        }

        private void EliminarHistorial_Click(object sender, RoutedEventArgs e)
        {
            Toast.Notifiacion("Acción no disponible por ahora");
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
