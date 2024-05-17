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
           //string key = txtToken.Text;
            string username = txtUsuario.Text.Trim();
            string password = txtPassword.Text;
            var apiService = new ApiService();
            // Datos de usuario 

            try
            {
                // Crear usuario con RestSharp
                bool resultRestSharp = await apiService.CreateUser(username, password);
                Console.WriteLine("Resultado usando RestSharp: " + resultRestSharp);

                if (resultRestSharp)
                {
                    CargarUsuarios();
                    Toast.CreateLog("Usuario creado", $"Se ha creado un nuevo usaurio \n username:{username} password: {password}");
                }
                else
                {
                    Toast.Error("Verifica que " + SesionUsuario_Modelo.nombre.ToString() + " este vigente.".ToString());
                }
            }
            catch (Exception ex)
            {
                Toast.Log("Error al crear el usuario", "Verifica que el token del Super usuario sea valido");
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
