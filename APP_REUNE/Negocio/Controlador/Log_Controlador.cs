using Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace Negocio.Controlador
{
    public class Log_Controlador
    {
        private static Log_Controlador _instancia;

        public static Log_Controlador Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Log_Controlador();
                }
                return _instancia;
            }
        }

        public DataTable Mostrar_Log(Log_Modelo log_)
        {
            DataTable dt = new DataTable();
            string[,] parametro =
            {
                {"@nombre_usuario",log_.nombreUsuario.ToString() },
                {"@accion","O" },
                {"@titulo",log_.titulo.ToString() },
                {"@mensaje",log_.mensaje.ToString() },
                {"@equipo",log_.equipo.ToString() }

            };

            try
            {
                dt = ConnectorLibrary.App.GetCurrentConnector().Tabla(Utilidades.SP_Log.sp_reune_crear_obtener_log, parametro);
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
