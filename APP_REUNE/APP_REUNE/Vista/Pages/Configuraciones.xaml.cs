using APP_REUNE.Utilidad;
using APP_REUNE_Negocio.Datos;
using APP_REUNE_Negocio.Modelo;
using APP_REUNE_Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes; 

namespace APP_REUNE.Vista.Pages
{
    /// <summary>
    /// Lógica de interacción para Configuraciones.xaml
    /// </summary>
    public partial class Configuraciones : Page
    {
        public Configuraciones()
        {
            InitializeComponent();
            ObtenerDatosDB();
        }

        private void ObtenerDatosDB()
        {
            Configuracion_Datos datos = new Configuracion_Datos();
            try
            {
                datos.Obtener_Configuracion();
                txt_API.Text = Configuracion_Modelo.api_reune;
                int check = Configuracion_Modelo.valida_login; 
                Util.CargarComboLog(cb_log,Configuracion_Modelo.escribir_log);
                txt_RutaLog.Text = Configuracion_Modelo.ruta_log;
                Chek_Login.IsChecked = check == 1; 
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al obtener la configuración del sistema.", ex);
            }
        } 

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            Configuracion_Datos datos = new Configuracion_Datos();
            Configuraciones_Modelo modelo = new Configuraciones_Modelo();
            try
            {
                modelo.api_reune = txt_API.Text;
                modelo.ruta_log = txt_RutaLog.Text;
                modelo.valida_login = Chek_Login.IsChecked==true?1:0;
                modelo.escribir_log= (int)cb_log.SelectedValue;
                datos.Actualizar_Configuracion(modelo);
                ObtenerDatosDB();
                Toast.Correcto("Los datos de configuración se han actualizado");
                Toast.CreateLog("Cambio de configuraciones", "Los datos de configuración del sistema se han actualizado");
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al obtener la configuración del sistema.", ex); 
                Toast.CreateLog("Cambio de configuraciones sin exito", "Se intento realizar cambios generales a la configuración del sistema, pero no se obtubo exito. \n" +
                                "Verifica que esta acción se esperaba realizar.\n si el cambio es necesario, Pide que el administrador realice la operación manualmente en Base de Datos");
            }
        }
    }
}
