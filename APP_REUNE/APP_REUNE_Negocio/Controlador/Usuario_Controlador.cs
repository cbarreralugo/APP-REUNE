using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Controlador
{
    public class Usuario_Controlador
    {
        private static Usuario_Controlador _instancia;

        public static Usuario_Controlador Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Usuario_Controlador();
                }
                return _instancia;
            }
        }

        public DataTable Obtener_Todos_Usuarios()
        {
            //@accion -- 'C' para crear, 'O' para obtener, 'E' para editar
            //@id_usuario  -- Usado para obtener o editar un usuario específico
            //@nombre
            //@password
            //@token
            DataTable dt = new DataTable();
            string[,] parametro =
            {
                {"@accion","OT" },
                {"@id_usuario","" },
                {"@nombre","" },
                {"@password","" },
                {"@token","" }
            };

            try
            {
                dt = ConnectorLibrary.App.GetCurrentConnector().Tabla(Utilidades.SP_Usuario.sp_reune_crear_obtener_editar_usuario, parametro);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new DataTable();
            }
            finally { dt = null; }
        }
        public DataTable CrearUsuario(Usuario_Modelo modelo)
        {
            //@accion -- 'C' para crear, 'O' para obtener, 'E' para editar
            //@id_usuario  -- Usado para obtener o editar un usuario específico
            //@nombre
            //@password
            //@token
            DataTable dt = new DataTable();
            string[,] parametro =
            {
                {"@accion","C" },
                {"@id_usuario","" },
                {"@nombre",modelo.nombre.ToString() },
                {"@password",modelo.password.ToString()},
                {"@token",modelo.token.ToString() }
            };

            try
            {
                dt = ConnectorLibrary.App.GetCurrentConnector().Tabla(Utilidades.SP_Usuario.sp_reune_crear_obtener_editar_usuario, parametro);
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
