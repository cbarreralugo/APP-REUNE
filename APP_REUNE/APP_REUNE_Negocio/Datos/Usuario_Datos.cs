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
    public class Usuario_Datos
    {
        public DataTable ObtenerTodosUsuarios()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Usuario_Controlador.Instancia.Obtener_Todos_Usuarios();
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
        public void CrearUsuario(Usuario_Modelo modelo)
        { 
            try
            {
                Usuario_Controlador.Instancia.CrearUsuario(modelo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally {   }
        }
        public void Actualizar(Usuario_Modelo modelo)
        {
            try
            {
                Usuario_Controlador.Instancia.ActualizarUsuario(modelo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally { }
        }
    }
}
