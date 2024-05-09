using APP_REUNE.Service; 
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace APP_REUNE.Vista
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void txt_email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_email.Text.Trim() != string.Empty)
            {
                img_emailcheck.Visibility = Visibility.Visible;
                email_path.Stroke = Brushes.Green;
            }
        }
        private  void txt_pass_LostFocus(object sender, RoutedEventArgs e)
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

                   
                    
                    Toast_.Correcto("Hola de nuevo");
                    Toast_.CreateLog("Inicio se sesión", "Se ingresa al sistema por medio de la app.");
                    Index index = new Index();
                    index.Show();
                    this.Close();
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
                MessageBox.Show("Error durante el inicio de sesión: " + ex.Message);
            }
        }





    }
}
