using APP_REUNE.Service;
using APP_REUNE.Utilidad;
using APP_REUNE.Vista.PreInfo;
using APP_REUNE_Negocio.Datos;
using APP_REUNE_Negocio.Modelo;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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

            TipoSolicitudes_Modelo modelo = datos.Obtener_TipoSolicitud(Configuracion_Datos.tipo.Reclamaciones_General);
            fileName = modelo.archivo;
            id = modelo.id;
            api = modelo.api;
            // Limpiar todos los campos
            txt_RecDenominacion.Clear();
            txt_RecSector.Clear();
            cb_RecTrimestre.SelectedIndex = 0;
            cb_RecNumero.SelectedIndex = 0;
            txt_RecFolioAtencion.Clear();
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
            cb_RecMonetario.SelectedIndex = 0;
            txt_RecMontoReclamado.Clear();
            txt_RecImporteAbonado.Clear();
            dp_RecFechaAbonoImporte.SelectedDate = DateTime.Now;
            cb_RecPori.SelectedIndex = 0;
            cb_RecTipoPersona.SelectedIndex = 0;
            cb_RecSexo.SelectedIndex = 0;
            cb_RecEdad.SelectedIndex = 0;
            cb_RecSentidoResolucion.SelectedIndex = 0;
            cb_RecNivelAtencion.SelectedIndex = 0;
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
            dg_tabla.LoadData(null, "");//reiniciar tabla
            dg_tabla.Visibility = Visibility.Collapsed;//ocultar tabla
        }

        private async void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var reclamacion = new ReclamacionGeneral_Model
                {
                    RecDenominacion = txt_RecDenominacion.Text,
                    RecSector = txt_RecSector.Text,
                    RecTrimestre = int.TryParse(cb_RecTrimestre.SelectedValue?.ToString(), out var recTrimestre) ? recTrimestre : 0,
                    RecNumero = int.TryParse(cb_RecNumero.SelectedValue?.ToString(), out var recNumero) ? recNumero : 0,
                    RecFolioAtencion = txt_RecFolioAtencion.Text,
                    RecEstadoConPend = int.TryParse(cb_RecEstadoConPend.SelectedValue?.ToString(), out var recEstadoConPend) ? recEstadoConPend : 0,
                    RecFechaReclamacion = dp_RecFechaReclamacion.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecFechaAtencion = dp_RecFechaAtencion.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecMedioRecepcionCanal = int.TryParse(txt_RecMedioRecepcionCanal.Text, out var recMedioRecepcionCanal) ? recMedioRecepcionCanal : 0,
                    RecProductoServicio = txt_RecProductoServicio.Text,
                    RecCausaMotivo = txt_RecCausaMotivo.Text,
                    RecFechaResolucion = dp_RecFechaResolucion.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecFechaNotifiUsuario = dp_RecFechaNotifiUsuario.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecEntidadFederativa = int.TryParse(txt_RecEntidadFederativa.Text, out var recEntidadFederativa) ? recEntidadFederativa : 0,
                    RecCodigoPostal = int.TryParse(txt_RecCodigoPostal.Text, out var recCodigoPostal) ? recCodigoPostal : 0,
                    RecMunicipioAlcaldia = int.TryParse(txt_RecMunicipioAlcaldia.Text, out var recMunicipioAlcaldia) ? recMunicipioAlcaldia : 0,
                    RecLocalidad = int.TryParse(txt_RecLocalidad.Text, out var recLocalidad) ? recLocalidad : 0,
                    RecColonia = int.TryParse(txt_RecColonia.Text, out var recColonia) ? (int?)recColonia : null,
                    RecMonetario = cb_RecMonetario.Text,
                    RecMontoReclamado = int.TryParse(txt_RecMontoReclamado.Text, out var recMontoReclamado) ? (int?)recMontoReclamado : null,
                    RecImporteAbonado = int.TryParse(txt_RecImporteAbonado.Text, out var recImporteAbonado) ? (int?)recImporteAbonado : null,
                    RecFechaAbonoImporte = dp_RecFechaAbonoImporte.SelectedDate?.ToString("dd/MM/yyyy"),
                    RecPori = cb_RecPori.Text,
                    RecTipoPersona = int.TryParse(cb_RecTipoPersona.SelectedValue?.ToString(), out var recTipoPersona) ? recTipoPersona : 0,
                    RecSexo = cb_RecSexo.Text,
                    RecEdad = int.TryParse(cb_RecEdad.SelectedValue?.ToString(), out var recEdad) ? recEdad : 0,
                    RecSentidoResolucion = int.TryParse(cb_RecSentidoResolucion.SelectedValue?.ToString(), out var recSentidoResolucion) ? recSentidoResolucion : 0,
                    RecNivelAtencion = int.TryParse(cb_RecNivelAtencion.SelectedValue?.ToString(), out var recNivelAtencion) ? recNivelAtencion : 0,
                    RecFolioCondusef = txt_RecFolioCondusef.Text,
                    RecReversa = cb_RecReversa.Text
                };

                var reclamaciones = new List<ReclamacionGeneral_Model> { reclamacion };
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
                Toast.Sistema("Error: ", ex);
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
                campos = $"{txt_RecDenominacion.Text}|{txt_RecSector.Text}|{cb_RecTrimestre.SelectedValue}|{cb_RecNumero.SelectedValue}|{txt_RecFolioAtencion.Text}|{cb_RecEstadoConPend.SelectedValue}|{dp_RecFechaReclamacion.SelectedDate?.ToString("dd/MM/yyyy")}|{dp_RecFechaAtencion.SelectedDate?.ToString("dd/MM/yyyy")}|{txt_RecMedioRecepcionCanal.Text}|{txt_RecProductoServicio.Text}|{txt_RecCausaMotivo.Text}|{dp_RecFechaResolucion.SelectedDate?.ToString("dd/MM/yyyy")}|{dp_RecFechaNotifiUsuario.SelectedDate?.ToString("dd/MM/yyyy")}|{txt_RecEntidadFederativa.Text}|{txt_RecCodigoPostal.Text}|{txt_RecMunicipioAlcaldia.Text}|{txt_RecLocalidad.Text}|{txt_RecColonia.Text}|{cb_RecMonetario.SelectedValue}|{txt_RecMontoReclamado.Text}|{txt_RecImporteAbonado.Text}|{dp_RecFechaAbonoImporte.SelectedDate?.ToString("dd/MM/yyyy")}|{cb_RecPori.SelectedValue}|{cb_RecTipoPersona.SelectedValue}|{cb_RecSexo.SelectedValue}|{cb_RecEdad.SelectedValue}|{cb_RecSentidoResolucion.SelectedValue}|{cb_RecNivelAtencion.SelectedValue}|{txt_RecFolioCondusef.Text}|{cb_RecReversa.SelectedValue}";

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

                    if (parts.Length >= 28)
                    {
                        txt_RecDenominacion.Text = parts[0];
                        txt_RecSector.Text = parts[1];
                        cb_RecTrimestre.SelectedValue = parts[2];
                        cb_RecNumero.SelectedValue = parts[3];
                        txt_RecFolioAtencion.Text = parts[4];
                        cb_RecEstadoConPend.SelectedValue = parts[5];
                        dp_RecFechaReclamacion.SelectedDate = DateTime.ParseExact(parts[6], "dd/MM/yyyy", null);
                        dp_RecFechaAtencion.SelectedDate = DateTime.ParseExact(parts[7], "dd/MM/yyyy", null);
                        txt_RecMedioRecepcionCanal.Text = parts[8];
                        txt_RecProductoServicio.Text = parts[9];
                        txt_RecCausaMotivo.Text = parts[10];
                        dp_RecFechaResolucion.SelectedDate = DateTime.ParseExact(parts[11], "dd/MM/yyyy", null);
                        dp_RecFechaNotifiUsuario.SelectedDate = DateTime.ParseExact(parts[12], "dd/MM/yyyy", null);
                        txt_RecEntidadFederativa.Text = parts[13];
                        txt_RecCodigoPostal.Text = parts[14];
                        txt_RecMunicipioAlcaldia.Text = parts[15];
                        txt_RecLocalidad.Text = parts[16];
                        txt_RecColonia.Text = parts[17];
                        cb_RecMonetario.SelectedValue = parts[18];
                        txt_RecMontoReclamado.Text = parts[19];
                        txt_RecImporteAbonado.Text = parts[20];
                        dp_RecFechaAbonoImporte.SelectedDate = DateTime.ParseExact(parts[21], "dd/MM/yyyy", null);
                        cb_RecPori.SelectedValue = parts[22];
                        cb_RecTipoPersona.SelectedValue = parts[23];
                        cb_RecSexo.SelectedValue = parts[24];
                        cb_RecEdad.SelectedValue = parts[25];
                        cb_RecSentidoResolucion.SelectedValue = parts[26];
                        cb_RecNivelAtencion.SelectedValue = parts[27];
                        txt_RecFolioCondusef.Text = parts[28];
                        cb_RecReversa.SelectedValue = parts[29];

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


        private async void CargaMasivaJson_Click(object sender, RoutedEventArgs e)
        {
            string endpoint = api;
            if (endpoint != null)
            {
                var success = await Utilidad.SendDataFrom.SendDataFromJson<ReclamacionGeneral_Model>(endpoint, id);
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
                var success = await Utilidad.SendDataFrom.SendDataFromExcel<ReclamacionGeneral_Model>(endpoint, id);
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
                var success = await Utilidad.SendDataFrom.SendDataFromTxt<ReclamacionGeneral_Model>(endpoint, id);
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
            Historial_Datos datos = new Historial_Datos();
            DataTable dt = new DataTable();
            dt = datos.ObtenerHistorial((int)Configuracion_Datos.tipo.Reclamaciones_General);
            if (dt.Rows.Count > 0)
            {
                dg_tabla.LoadData(dt, "Historial de Solicitudes de Reclamaciones General");
                dg_tabla.Visibility = Visibility.Visible;
                Toast.Correcto("Historial de todas las solicitudes de Reclamaciones");
            }
            else
            {
                Toast.Error("No se encontraron registros", "No hay registros");
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
