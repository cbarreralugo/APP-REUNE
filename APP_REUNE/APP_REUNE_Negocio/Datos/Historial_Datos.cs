using APP_REUNE_Negocio.Controlador;
using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Datos
{
    public class Historial_Datos
    {
        public DataTable ObtenerHistorial(int id)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Historial_Controlador.Instancia.Mostrar_Historial(id);
                if (dataTable.Rows.Count > 0)
                {
                    return dataTable;
                }
                else
                {
                    return new DataTable();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally { dataTable = new DataTable(); }
            return dataTable;
        }
        public void CrearHistorial(Historial_Modelo modelo)
        {
            try
            {
                Historial_Controlador.Instancia.Crear_Historial(modelo);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
