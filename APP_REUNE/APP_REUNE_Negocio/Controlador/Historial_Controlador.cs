using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Controlador
{
    public class Historial_Controlador
    {
        private static Historial_Controlador _instancia;

        public static Historial_Controlador Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Historial_Controlador();
                }
                return _instancia;
            }
        }

        public DataTable Mostrar_Historial(int id)
        {
            DataTable dt = new DataTable();
            string[,] parametro =
            { 
                {"@accion","O" },
                {"@idTipo",id.ToString()},
                {"@numPeticion","" },
                {"@peticiones","" },
                {"@idUsuario","" },
                {"@EstatusPeticion","" }

            };

            try
            {
                dt = ConnectorLibrary.App.GetCurrentConnector().Tabla(Utilidades.SP_Historial.sp_reune_crear_obtener_historial, parametro);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DataTable();
            }
            finally { dt = null; }
        }

        public void Crear_Historial(Historial_Modelo modelo)
        {
            DataTable dt = new DataTable();
            string[,] parametro =
            {
                {"@accion","C" },
                {"@idTipo",modelo.idTipo.ToString()},
                {"@numPeticion",modelo.numPeticion.ToString() },
                {"@peticiones",modelo.peticiones.ToString() },
                {"@idUsuario",modelo.idUsuario.ToString() },
                {"@EstatusPeticion",modelo.EstatusPeticion.ToString() }

            };

            try
            {
                ConnectorLibrary.App.GetCurrentConnector().Tabla(Utilidades.SP_Historial.sp_reune_crear_obtener_historial, parametro);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
