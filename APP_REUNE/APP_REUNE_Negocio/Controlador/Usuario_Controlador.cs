using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
                {"@token","" },
                {"@userid_api","" },
                {"@username_api","" },
                {"@password_api","" },
                {"@institucionid_api","" },
                {"@is_active_api","" },
                {"@profileid_api","" },
                {"@date_api","" },
                {"@system_api","" }
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
                {"@token",modelo.token.ToString() },
                {"@userid_api",modelo.userid_api.ToString()  },
                {"@username_api",modelo.username_api.ToString()  },
                {"@password_api",modelo.password_api.ToString()  },
                {"@institucionid_api",modelo.institucionid_api.ToString() },
                {"@is_active_api",modelo.is_active_api.ToString()},
                {"@profileid_api",modelo.profileid_api.ToString()  }, 
                {"@date_api",modelo.date_api.ToString()  },
                {"@system_api",modelo.system_api.ToString()}
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
