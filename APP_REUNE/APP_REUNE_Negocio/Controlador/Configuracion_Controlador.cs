using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Controlador
{
    public class Configuracion_Controlador
    {
        private static Configuracion_Controlador _instancia;

        public static Configuracion_Controlador Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Configuracion_Controlador();
                }
                return _instancia;
            }
        }

        public DataTable Obtener_Configuracion(Configuraciones_Modelo conf_)
        {
            DataTable dt = new DataTable();
            string[,] parametro =
            {
                {"@accion","G" },
                {"@valida_login",conf_.valida_login.ToString() },
                {"@escribir_log",conf_.escribir_log.ToString() },
                {"@ruta_log",conf_.ruta_log.ToString() }

            };

            try
            {
                dt = ConnectorLibrary.App.GetCurrentConnector().Tabla(Utilidades.SP_Configuraciones.sp_reune_obtener_update_configuracion, parametro);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DataTable();
            }
            finally { dt = null; }
        }

        public void Actualizar_Configuracion(Configuraciones_Modelo conf_)
        {
            DataTable dt = new DataTable();

            string[,] parametro =
             {
                {"@accion","U" },
                {"@valida_login",conf_.valida_login.ToString() },
                {"@escribir_log",conf_.escribir_log.ToString() },
                {"@ruta_log",conf_.ruta_log.ToString() }
            };

            try
            {
                ConnectorLibrary.App.GetCurrentConnector().Tabla(Utilidades.SP_Configuraciones.sp_reune_obtener_update_configuracion, parametro);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
