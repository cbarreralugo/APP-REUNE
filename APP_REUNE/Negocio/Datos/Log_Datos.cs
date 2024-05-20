using Negocio.Controlador;
using Negocio.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Datos
{
    public class Log_Datos
    {
        public DataTable ObtenerLog(Log_Modelo log_)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Log_Controlador.Instancia.Mostrar_Log(log_);
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

    }
}
}
