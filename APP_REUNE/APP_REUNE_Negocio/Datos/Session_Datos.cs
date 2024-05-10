using APP_REUNE_Negocio.Controlador;
using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Datos
{
    public class Session_Datos
    {
        public bool ObtenerSession(Sesion_Modelo sesion)
        {
            bool reply = false;
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = Sesion_Controlador.Instancia.Obtener_Sesion(sesion);
                if (dataTable.Rows.Count > 0)
                {

                    sesion = new Sesion_Modelo()
                    {
                        id_usuario = SesionUsuario_Modelo.id_usuario = int.Parse(dataTable.Rows[0]["id_usuario"].ToString()),
                        nombre = SesionUsuario_Modelo.nombre = (dataTable.Rows[0]["nombre"].ToString()),
                        password = SesionUsuario_Modelo.password = (dataTable.Rows[0]["password"].ToString()),
                        token = SesionUsuario_Modelo.token = (dataTable.Rows[0]["token"].ToString()),
                        id_tipoUser = SesionUsuario_Modelo.id_tipoUser = int.Parse(dataTable.Rows[0]["id_tipoUser"].ToString()),
                        fecha = SesionUsuario_Modelo.fecha = (dataTable.Rows[0]["FechaToken"].ToString()),
                        diasRestantes = int.Parse(dataTable.Rows[0]["DiasRestantes"].ToString()),
                    };
                    reply = true;
                }
                else
                {
                    sesion = new Sesion_Modelo();
                    reply = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                reply = false;
            }
            finally { dataTable = new DataTable(); }
            return reply;
        }
    }
}
