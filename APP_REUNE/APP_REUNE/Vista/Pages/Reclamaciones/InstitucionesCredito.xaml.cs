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

namespace APP_REUNE.Vista.Pages.Reclamaciones
{
    /// <summary>
    /// Lógica de interacción para InstitucionesCredito.xaml
    /// </summary>
    public partial class InstitucionesCredito : Page
    {
        public InstitucionesCredito()
        {
            InitializeComponent();
            dp_RecFechaReclamacion.SelectedDateChanged += DpFecha_SelectedDateChanged;
            CargarPreInformacio();
        }

        private void CargarPreInformacio()
        {
            Utilidad.Util.CargarComboTrimestre(cb_RecTrimestre);
            Utilidad.Util.CargarComboNumero(cb_RecNumero);
            Utilidad.Util.CargarComboEstadoConPend(cb_RecEstadoConPend);
            Utilidad.Util.CargarComboMonetario(cb_RecMonetario);
            Utilidad.Util.CargarComboPORI(cb_RecPori);
            Utilidad.Util.CargarComboTipoPersona(cb_RecTipoPersona);
            Utilidad.Util.CargarComboSexo(cb_RecSexo);
            Utilidad.Util.CargarComboEdad(cb_RecEdad);
            Utilidad.Util.CargarComboNivelAtencion(cb_RecNivelAtencion);
            Utilidad.Util.CargarComboReversa(cb_RecReversa);
            Utilidad.Util.CargarComboResolucion(cb_RecSentidoResolucion);
            txt_RecDenominacion.Text = "SAM Asset Management S.A. de C.V., Sociedad Operadora de Fondos de Inversión.";
            txt_RecSector.Text = "Sociedad Operadora de Fondos de Inversión";
            txt_RecEntidadFederativa.Text = "09";
            txt_RecCodigoPostal.Text = "5120";
            txt_RecMunicipioAlcaldia.Text = "004";
            
        }

        private void DpFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // Aquí puedes manejar lo que sucede cuando cambia la fecha seleccionada
            //MessageBox.Show("Fecha seleccionada: " + dp_RecFechaReclamacion.SelectedDate.Value.ToString("dd/MM/yyyy"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
