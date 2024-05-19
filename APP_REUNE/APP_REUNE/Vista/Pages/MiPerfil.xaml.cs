using APP_REUNE.Service;
using APP_REUNE_Negocio.Datos;
using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para MiPerfil.xaml
    /// </summary>
    public partial class MiPerfil : Page
    {
        public MiPerfil()
        {
            InitializeComponent(); 
            ObtenerPerfil();
            RenovarToken();
        }

        private void RenovarToken()
        {
            int bandera = Configuracion_Modelo.auto_regenerar_token_user;
            if (bandera == 0)
            {
                btnRenovar.Visibility= Visibility.Collapsed;
            }
        }

        private void ObtenerPerfil()
        {
            string fe_inicio = txt_fecha.Text = SesionUsuario_Modelo.fecha;
            txt_Password.Text = SesionUsuario_Modelo.password;
            txt_TipoUser.Text = SesionUsuario_Modelo.id_usuario == 1 ? "Super Usuario" : "Usuario normal";
            txt_Token.Text = SesionUsuario_Modelo.token;
            txt_UserName.Text = SesionUsuario_Modelo.nombre; 
            // Convertir la cadena de fecha a DateTime
            if (DateTime.TryParse(fe_inicio.Substring(0,10), out DateTime fechaActual))
            {
                // Límite de días para renovar el token
                int limiteDias = 30;

                // Calcular la fecha límite sumando el límite de días a la fecha actual
                DateTime fechaLimite = fechaActual.AddDays(limiteDias);

                // Supongamos que tomamos la fecha actual del sistema para los cálculos (puedes ajustar según sea necesario)
                DateTime ahora = DateTime.Now;

                // Calcular los días restantes
                int diasRestantes = (fechaLimite - ahora).Days;

                // Mostrar los días restantes
                lb_fechaRenovar.Content =$"Quedan 23 días para renovar el token. No pierdas tu acceso";
            }
            else
            {
                lb_fechaRenovar.Content = "No logramos calcular tu fecha límite de acceso, pero debes renovar el token cada 30 días";
            }
             
        }

        private async void btnRenovar_Click(object sender, RoutedEventArgs e)
        {
            string username = SesionUsuario_Modelo.nombre; // Asumiendo que el nombre del usuario se ingresa en un campo de texto
            string password = SesionUsuario_Modelo.password; // Asumiendo que la contraseña se ingresa en un campo de texto
            var apiService = new ApiService();

            try
            {
                bool result = await apiService.RenewToken(username, password);
                if (result)
                {
                    Toast.CreateLog("Token renovado", $"El token para el usuario {username} ha sido renovado.");
                    Configuracion_Datos datos = new Configuracion_Datos();
                    datos.Obtener_Configuracion();
                    ObtenerPerfil();
                }
                else
                {
                    Toast.Error("Error al renovar el token", "No se pudo renovar el token, por favor intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                Toast.Log("Error al renovar el token", "Verifica que el token del Super usuario sea valido");
            }
        }

        private async void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            // Eliminar el archivo de sesión temporal
            Utilidad.SesionTemporal.DeleteFile();

            // Crear y guardar el log
            await Task.Run(() =>
            {
                Toast.Correcto("Sesión cerrada en el dispositivo actual"); 
            });

            // Cerrar la aplicación
            Application.Current.Shutdown();
        }
    }
}
