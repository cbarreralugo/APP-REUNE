using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Utilidades
{
    public static class SP_Log
    {
        //@nombre_usuario -- 0 significa que se traerán todos los logs
        //@accion -- 'C' para crear, 'O' para obtener
        public static string sp_reune_crear_obtener_log = "sp_reune_crear_obtener_log";
    }
    public static class SP_Configuraciones
    {
        //@accion  -- 'G' para obtener, 'U' para actualizar
        //@valida_login -- Nuevos valores para la actualización
        //@escribir_log  
        //@ruta_log  
        public static string sp_reune_obtener_update_configuracion = "sp_reune_obtener_update_configuracion";
        public static string sp_reune_obtener_solicitudes = "sp_reune_obtener_solicitudes";
    }
    public static class SP_Sesion
    {
        //@usuario
        //@password
        public static string sp_reune_obtener_sesion = "sp_reune_obtener_sesion";
    }
    public static class SP_Usuario
    {
        //@accion -- 'C' para crear, 'O' para obtener, 'E' para editar
        //@id_usuario  -- Usado para obtener o editar un usuario específico
        //@nombre
        //@password
        //@token
        public static string sp_reune_crear_obtener_editar_usuario = "sp_reune_crear_obtener_editar_usuario";
    }

    public static class SP_Historial
    {
        //@accion -- O para obtener, C para Crear
        //@idTipo -- Usado para filtrar el historial con el tipo de solicitud a ver
        //@numPeticion
        //@peticiones
        //@idUsuario
        //@EstatusPeticion
        public static string sp_reune_crear_obtener_historial = "sp_reune_crear_obtener_historial";
    }
}
