using APP_REUNE.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
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
          
        }

        private async void AgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            string key = txtToken.Password;
            string username = txtUsuario.Text;
            string password = txtPassword.Password;
            try
            {
                var token = await new ApiService().CreateSuperUser(key, username, password);
                if (!string.IsNullOrEmpty(token))
                {
                    MessageBox.Show("Súper usuario creado exitosamente. Token: " + token); 
                }
                else
                {
                    MessageBox.Show("No se recibió un token válido.");
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
