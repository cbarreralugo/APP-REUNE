using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
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
using APP_REUNE_Negocio.Controlador;
using APP_REUNE_Negocio.Datos;

namespace APP_REUNE.Vista.Pages
{
    /// <summary>
    /// Lógica de interacción para Log.xaml
    /// </summary>
    public partial class Log : Page
    {
        public Log()
        {
            InitializeComponent();
            CargarLog();
        }

        private void CargarLog()
        {
            DataTable table = new DataTable();
            Log_Modelo modelo = new Log_Modelo();
            Log_Datos datos = new Log_Datos();
            try
            {
                modelo.nombreUsuario = "";
                modelo.titulo = "";
                modelo.mensaje = "";
                modelo.equipo = "";
                table = datos.ObtenerLog(modelo);
                if (table.Rows.Count > 0)
                {
                    dg_Log.ItemsSource = null;
                    dg_Log.ItemsSource = table.DefaultView;
                    Toast.Correcto("Log general del sistema");
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Cargar log en tabla. ", ex);
            }
        }
    }
}
