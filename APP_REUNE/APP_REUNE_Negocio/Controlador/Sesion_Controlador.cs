using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Controlador
{
    public class Sesion_Controlador
    {
        private static Sesion_Controlador _instancia;

        public static Sesion_Controlador Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sesion_Controlador();
                }
                return _instancia;
            }
        }

        public DataTable Obtener_Sesion(Sesion_Modelo session)
        {
            DataTable dt = new DataTable();
            string[,] parametro =
            {
                {"@usuario",session.nombre.ToString() },
                {"@password",session.password.ToString() } 
            };

            try
            {
                dt = ConnectorLibrary.App.GetCurrentConnector().Tabla(Utilidades.SP_Sesion.sp_reune_obtener_sesion, parametro);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DataTable();
            }
            finally { dt = null; }
        }
    }
}
