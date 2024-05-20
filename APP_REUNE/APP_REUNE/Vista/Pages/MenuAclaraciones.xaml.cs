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
    /// Lógica de interacción para MenuAclaraciones.xaml
    /// </summary>
    public partial class MenuAclaraciones : Page
    {
        public MenuAclaraciones()
        {
            InitializeComponent();
            CargarCombo();
        }

        private void CargarCombo()
        {

            Util.CargarComboAclaraciones(cb_Aclaraciones, 0);
            // VerFrame(0);
        }

        private void VerFrame(int tab)
        {
            try
            {

                switch (tab)
                {
                    case 0:
                        frm_Aclaraciones.Navigate(new System.Uri("Vista/Pages/Aclaraciones/General.xaml", UriKind.RelativeOrAbsolute));
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

        private void cb_Aclaraciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int tab = (int)cb_Aclaraciones.SelectedValue;
                VerFrame(tab);
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al cargar la vista", ex);

            }
        }
    }
}
