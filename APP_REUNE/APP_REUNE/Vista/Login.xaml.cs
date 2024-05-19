using APP_REUNE.Service;
using APP_REUNE.Utilidad;
using APP_REUNE_Negocio.Datos;
using APP_REUNE_Negocio.Modelo;
using EncryptionLibrary;
using System;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace APP_REUNE.Vista
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Configuracion_Datos configuracion;
        AESEncryptor AES;
        public Login()
        {
            InitializeComponent();
            configuracion = new Configuracion_Datos();
            configuracion.Obtener_Configuracion();

            // Inicializar AES con la clave correcta 
            AES = new AESEncryptor();

            // Inicializar SesionTemporal con la clave de encriptación
            SesionTemporal.Initialize();

            var texto = Utilidad.SesionTemporal.ReadFile();
            if (texto != null)
            {
                var (part1, part2) = Utilidad.SesionTemporal.SplitContent(AES.Decrypt(texto));
                if (part1 != null && part2 != null)
                {
                    txt_email.Text = part1;
                    txt_pass.Password = part2;

                    Button_Click_1(null, null);
                }
            }
        }
        private void txt_email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_email.Text.Trim() != string.Empty)
            {
                img_emailcheck.Visibility = Visibility.Visible;
                email_path.Stroke = Brushes.Green;
            }
        }
        private void txt_pass_LostFocus(object sender, RoutedEventArgs e)
        {

        }


        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            //if (WindowState == WindowState.Normal)
            //    WindowState = WindowState.Maximized;
            //else
            //    WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string username = txt_email.Text;
            string password = txt_pass.Password.ToString().Trim();

            try
            {
                var token = await new ApiServiceLogin().IniciarSesion(username, password);
                if (token != null)
                {
                    // Login exitoso
                    img_passcncel.Visibility = Visibility.Hidden;
                    img_passcheck.Visibility = Visibility.Visible;
                    //pass_path.Stroke = Brushes.Green;
                    txt_pass.Foreground = Brushes.Black;
                    Sesion_Modelo modelo = new Sesion_Modelo();
                    modelo.password = password;
                    modelo.nombre = username;
                    Session_Datos session = new Session_Datos();
                    if (session.ObtenerSession(modelo))
                    {
                        if (Chek_Login.IsChecked == true)
                        {
                            SesionTemporal.Initialize();
                            Utilidad.SesionTemporal.CreateFile(username, password);
                            Toast.Correcto("Sesión guardada con exito");
                            Toast.CreateLog("Sesión guardad con exito en el equipo", "Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil");
                        }
                        Toast.Correcto("Hola de nuevo");
                        Toast.CreateLog("Inicio se sesión", "Se ingresa al sistema por medio de la app.");
                        Index index = new Index();
                        index.Show();
                        this.Close();

                    }
                    else
                    {
                        Toast.Error("Usuarion no encontrado en DB. ", "Error de logeo");
                    }
                }
                else
                {
                    // Login fallido
                    Storyboard s = (Storyboard)TryFindResource("Animate");
                    s.Begin();
                    img_passcncel.Visibility = Visibility.Visible;
                    img_passcheck.Visibility = Visibility.Hidden;
                    //pass_path.Stroke = Brushes.Red;
                    txt_pass.Foreground = Brushes.Red;
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Erro durante el inicio de sesión", ex);
            }
        }

        private void btn_Recuperar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
