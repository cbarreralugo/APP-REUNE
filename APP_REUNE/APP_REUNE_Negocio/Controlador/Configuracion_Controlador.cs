using APP_REUNE_Negocio.Modelo;
using EncryptionLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace APP_REUNE_Negocio.Controlador
{
    public class Configuracion_Controlador
    {
        private static Configuracion_Controlador _instancia;
        AESEncryptor AES;

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

        public DataTable Obtener_Configuracion()
        {
            DataTable dt = new DataTable();
            string[,] parametro =
            {
                {"@accion","G" },
                {"@valida_log_api",""},
                {"@escribir_log","" },
                {"@ruta_log","" } ,
                {"@ruta_sesion_temporal","" } ,
                {"@api_reune","" },
                {"@auto_regenerar_token_user","" } 

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

        public DataTable Actualizar_Configuracion(Configuraciones_Modelo conf_)
        {
            DataTable dt = new DataTable();
            string[,] parametro =
            {
                {"@accion","U" },
                {"@valida_log_api",AES.Encrypt(conf_.valida_login.ToString() )},
                {"@escribir_log",AES.Encrypt(conf_.escribir_log.ToString()) },
                {"@ruta_log",AES.Encrypt(conf_.ruta_log.ToString()) } ,
                {"@ruta_sesion_temporal",AES.Encrypt(conf_.ruta_sesion_temporal.ToString()) } ,
                {"@api_reune",AES.Encrypt(conf_.api_reune.ToString()) },
                {"@auto_regenerar_token_user",AES.Encrypt(conf_.auto_regenerar_token_user.ToString()) } ,
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
    }
}
