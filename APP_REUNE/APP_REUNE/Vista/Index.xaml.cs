using System; 
using System.Windows;
using System.Windows.Controls.Primitives; 
using System.Windows.Input; 
using APP_REUNE_Negocio.Modelo;

namespace APP_REUNE.Vista
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Index : Window
    {
        public Index()
        {
            InitializeComponent();
            validarSesion();
        }

        private void validarSesion()
        {
            if (SesionUsuario_Modelo.id_usuario != 0)
            {
                if (SesionUsuario_Modelo.id_tipoUser == 1)
                {
                    Toast.Correcto("Haz ingresado como Super Usuario", "Bienvenido");
                    AccesoSuperUsuario();
                }
                else
                {
                    Toast.Correcto("Haz ingresado como Usuario general", "Bienvenido");
                    this.AccesoUsuarioGeneral();
                }
            }
            else
            {
                Toast.Denegado("No tienes los permisos necesarios para ingresar");
                this.AccesoDenegado();
            }
        }

        private void AccesoDenegado()
        {
             
            btnDashboard.Visibility = Visibility.Collapsed;
            btnConsultas.Visibility = Visibility.Collapsed;
            btnGestionDeUsuario.Visibility = Visibility.Collapsed;
            btnConfiguraciones.Visibility = Visibility.Collapsed;
            btnAyudaYSoporte.Visibility = Visibility.Collapsed;
            btnPerfilDeUsuario.Visibility = Visibility.Collapsed;
            btnLog.Visibility = Visibility.Collapsed;
        }

        private void AccesoUsuarioGeneral()
        {
            btnDashboard.Visibility = Visibility.Visible;
            btnConsultas.Visibility = Visibility.Visible;
            btnGestionDeUsuario.Visibility = Visibility.Collapsed;
            btnConfiguraciones.Visibility = Visibility.Collapsed;
            btnAyudaYSoporte.Visibility = Visibility.Visible;
            btnPerfilDeUsuario.Visibility = Visibility.Visible;
            btnLog.Visibility = Visibility.Collapsed;
        }

        private void AccesoSuperUsuario()
        {
            btnDashboard.Visibility = Visibility.Visible;
            btnConsultas.Visibility = Visibility.Visible;
            btnGestionDeUsuario.Visibility = Visibility.Visible;
            btnConfiguraciones.Visibility = Visibility.Visible;
            btnAyudaYSoporte.Visibility = Visibility.Visible;
            btnPerfilDeUsuario.Visibility = Visibility.Visible;
            btnLog.Visibility = Visibility.Visible;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void btnHome_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnHome;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Home";
            }
        }

        private void btnHome_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnDashboard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnDashboard;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Dashboard";
            }
        }

        private void btnDashboard_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnConsultas_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnConsultas;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Consultas";
            }
        }

        private void btnConsultas_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }


        private void btnConsultastock_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnGestionDeUsuario_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnGestionDeUsuario;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Gestión de Usuarios";
            }
        }

        private void btnGestionDeUsuario_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnConfiguraciones_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnConfiguraciones;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Configuraciones";
            }
        }

        private void btnConfiguraciones_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnAyudaYSoporte_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnAyudaYSoporte;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Ayuda y soporte";
            }
        }

        private void btnAyudaYSoporte_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnPerfilDeUsuario_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnPerfilDeUsuario;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Perfil de usuario";
            }
        }

        private void btnPerfilDeUsuario_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        private void btnLog_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnLog;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Log de sistema";
            }
        }

        private void btnLog_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        // End: MenuLeft PopupButton //

        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Vista/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Vista/Pages/Dashboard.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnConsultas_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Vista/Pages/SolicitarConsulta.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnGestionDeUsuario_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Vista/Pages/GestionDeUsuarios.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Vista/Pages/Log.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnConfiguraciones_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Vista/Pages/Configuraciones.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
