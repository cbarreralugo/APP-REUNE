using APP_REUNE_Negocio.Controlador;
using APP_REUNE_Negocio.Modelo;
using EncryptionLibrary;
using System;
using System.Data;

namespace APP_REUNE_Negocio.Datos
{
    public class Configuracion_Datos
    {
        public enum tipo
        {
            Aclaraciones_General = 1,
            Reclamaciones_General = 2,
            Reclamaciones_SIC = 3,
            Reclamaciones_Seguros = 4,
            Reclamaciones_InstitucionesCreditos = 5
        }
        private readonly AESEncryptor AES = new AESEncryptor();

        public TipoSolicitudes_Modelo Obtener_TipoSolicitud(tipo id)
        {
            DataTable dt = new DataTable();
            TipoSolicitudes_Modelo modelo = new TipoSolicitudes_Modelo();
            try
            {
                dt = Configuracion_Controlador.Instancia.Obtener_TipoSolicitud(((int)id));

                if (dt.Rows.Count > 0)
                {
                    modelo.id = int.Parse(dt.Rows[0]["id"].ToString());
                    modelo.nombre = dt.Rows[0]["nombre"].ToString();
                    modelo.api = dt.Rows[0]["api"].ToString();
                    modelo.archivo = dt.Rows[0]["archivo"].ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return modelo;
        }

        public Configuraciones_Modelo Obtener_Configuracion()
        {
            Configuraciones_Modelo conf_ = new Configuraciones_Modelo();
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Configuracion_Controlador.Instancia.Obtener_Configuracion();
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string configuracion = row["configuracion"].ToString();
                        string valor = row["valor"].ToString();

                        try
                        {
                            string decryptedValue = AES.Decrypt(valor);

                            switch (configuracion)
                            {
                                case "valida_log_api":
                                    conf_.valida_login = Configuracion_Modelo.valida_login = int.Parse(decryptedValue);
                                    break;
                                case "escribir_log":
                                    conf_.escribir_log = Configuracion_Modelo.escribir_log = int.Parse(decryptedValue);
                                    break;
                                case "ruta_log":
                                    conf_.ruta_log = Configuracion_Modelo.ruta_log = decryptedValue;
                                    break;
                                case "ruta_sesion_temporal":
                                    conf_.ruta_sesion_temporal = Configuracion_Modelo.ruta_sesion_temporal = decryptedValue;
                                    break;
                                case "api_reune":
                                    conf_.api_reune = Configuracion_Modelo.api_reune = decryptedValue;
                                    break;
                                case "key":
                                    conf_.key = Configuracion_Modelo.key = decryptedValue;
                                    break;
                                case "mostrar_alertas":
                                    conf_.mostrar_alerts = Configuracion_Modelo.mostrar_alerts = int.Parse(decryptedValue);
                                    break;
                                case "auto_regenerar_token_user":
                                    conf_.auto_regenerar_token_user = Configuracion_Modelo.auto_regenerar_token_user = int.Parse(decryptedValue);
                                    break;
                                case "pre_info":
                                    conf_.pre_info = Configuracion_Modelo.pre_info = (decryptedValue);
                                    break;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Error de formato en configuración '{configuracion}': {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al desencriptar configuración '{configuracion}': {ex.Message}");
                        }
                    }
                    return conf_;
                }
                else
                {
                    return new Configuraciones_Modelo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return new Configuraciones_Modelo();
            }
            finally
            {
                dataTable.Dispose(); // Liberar los recursos utilizados por el DataTable
            }
        }

        public void Actualizar_Configuracion(Configuraciones_Modelo conf_)
        {
            DataTable dataTable = new DataTable();
            try
            {
                Configuracion_Controlador.Instancia.Actualizar_Configuracion(conf_);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string configuracion = row["configuracion"].ToString();
                        string valor = row["valor"].ToString();

                        switch (configuracion)
                        {
                            case "valida_log_api":
                                conf_.valida_login = Configuracion_Modelo.valida_login = int.Parse(valor);
                                break;
                            case "escribir_log":
                                conf_.escribir_log = Configuracion_Modelo.escribir_log = int.Parse(valor);
                                break;
                            case "ruta_log":
                                conf_.ruta_log = Configuracion_Modelo.ruta_log = valor;
                                break;
                            case "ruta_sesion_temporal":
                                conf_.ruta_sesion_temporal = Configuracion_Modelo.ruta_sesion_temporal = valor;
                                break;
                            case "api_reune":
                                conf_.api_reune = Configuracion_Modelo.api_reune = valor;
                                break;
                            case "key":
                                conf_.key = Configuracion_Modelo.key = valor;
                                break;
                            case "mostrar_alertas":
                                conf_.mostrar_alerts = Configuracion_Modelo.mostrar_alerts = int.Parse(valor);
                                break;
                            case "auto_regenerar_token_user":
                                conf_.auto_regenerar_token_user = Configuracion_Modelo.auto_regenerar_token_user = int.Parse(valor);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                dataTable.Dispose(); // Liberar los recursos utilizados por el DataTable
            }
        }
    }
}
