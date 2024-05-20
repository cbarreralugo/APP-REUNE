using APP_REUNE.Utilidad;
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
    /// Lógica de interacción para MenuReclamaciones.xaml
    /// </summary>
    public partial class MenuReclamaciones : Page
    {
        public MenuReclamaciones()
        {
            InitializeComponent();
            CargarCombo();
        }

        private void CargarCombo()
        {

            Util.CargarComboReclamaciones(cb_Reclamaciones, 0);
           // VerFrame(0);
        }

        private void VerFrame(int tab)
        {
            try
            {

                switch (tab)
                {
                    case 0:
                        frm_Reclamaciones.Navigate(new System.Uri("Vista/Pages/Reclamaciones/InstitucionesCredito.xaml", UriKind.RelativeOrAbsolute));
                        break;
                    case 1:
                        frm_Reclamaciones.Navigate(new System.Uri("Vista/Pages/Reclamaciones/General.xaml", UriKind.RelativeOrAbsolute));
                        break;
                    case 2:
                        frm_Reclamaciones.Navigate(new System.Uri("Vista/Pages/Reclamaciones/Seguros.xaml", UriKind.RelativeOrAbsolute));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al mostrar frame", ex);
            }
        }

        private void cb_Reclamaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int tab = (int)cb_Reclamaciones.SelectedValue;
                VerFrame(tab);
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al cargar la vista", ex);

            }
        }
    }
}
