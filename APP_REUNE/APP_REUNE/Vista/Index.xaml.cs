using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
    }
}
