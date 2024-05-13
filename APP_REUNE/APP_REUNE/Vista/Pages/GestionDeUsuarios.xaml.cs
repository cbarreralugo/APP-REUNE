using APP_REUNE.Service;
using APP_REUNE_Negocio.Datos;
using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
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


namespace APP_REUNE.Vista.Pages
{
    /// <summary>
    /// Lógica de interacción para GestionDeUsuarios.xaml
    /// </summary>
    public partial class GestionDeUsuarios : Page
    {
        public GestionDeUsuarios()
        {
            InitializeComponent();
            
            CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            Usuario_Datos usuario_Datos = new Usuario_Datos(); 
            DataTable table = new DataTable();
            try
            {
                table=usuario_Datos.ObtenerTodosUsuarios();
                dg_tabla.LoadData(table, "Todos los usuarios");

            }
            catch (Exception ex)
            {
                table =new DataTable();  
                Toast.Sistema("Error al obtener los usuarios registrados", ex);
            }
        }

        private async void AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
           // string key = txtToken.Password;
            string username = txtUsuario.Text.Trim();
            string password = txtPassword.Text;
            try
            { 
                var token = await new ApiService().CreateUser(username.Replace(" ",""), password);
                if (token)
                {
                    CargarUsuarios();
                }
                else
                {
                    Toast.Error("Verifica que "+ SesionUsuario_Modelo.nombre.ToString() + " este vigente.".ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el súper usuario: " + ex.Message);
            }
        }

        private void EditarUsuario_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void EliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
             
        }

        private void RecargarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            CargarUsuarios();
        }
    }
}
