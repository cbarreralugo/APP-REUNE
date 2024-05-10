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
    public class Configuracion_Datos
    {
        public Configuraciones_Modelo Obtener_Configuracion()
        {
            Configuraciones_Modelo conf_ = new Configuraciones_Modelo();
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Configuracion_Controlador.Instancia.Obtener_Configuracion();
                if (dataTable.Rows.Count > 0)
                {
                    conf_.id_configuracion = Configuracion_Modelo.id_configuracion= int.Parse(dataTable.Rows[0]["id_configuracion"].ToString());
                    conf_.valida_login = Configuracion_Modelo.valida_login = int.Parse(dataTable.Rows[0]["valida_login"].ToString());
                    conf_.escribir_log = Configuracion_Modelo.escribir_log = int.Parse(dataTable.Rows[0]["escribir_log"].ToString());
                    conf_.ruta_log = Configuracion_Modelo.ruta_log = (dataTable.Rows[0]["ruta_log"].ToString());
                    conf_.api_reune = Configuracion_Modelo.api_reune = (dataTable.Rows[0]["api_reune"].ToString());
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
            }
            finally { dataTable = new DataTable(); }
            return new Configuraciones_Modelo();
        }
        public void Actualizar_Configuracion(Configuraciones_Modelo conf_)
        {
            try
            {
                Configuracion_Controlador.Instancia.Actualizar_Configuracion(conf_);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
