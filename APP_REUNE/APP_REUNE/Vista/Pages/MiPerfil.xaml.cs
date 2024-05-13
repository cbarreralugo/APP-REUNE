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
    }
}
