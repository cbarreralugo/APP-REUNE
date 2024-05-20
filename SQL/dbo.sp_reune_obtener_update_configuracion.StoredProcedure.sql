USE [api_reune]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_update_configuracion]    Script Date: 20/05/2024 10:02:12 a. m. ******/
DROP PROCEDURE [dbo].[sp_reune_obtener_update_configuracion]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_update_configuracion]    Script Date: 20/05/2024 10:02:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_reune_obtener_update_configuracion]
    @accion CHAR(1), -- 'G' para obtener, 'U' para actualizar
    @valida_log_api INT = NULL, -- Nuevos valores para la actualización
    @escribir_log INT = NULL,
    @ruta_log VARCHAR(200) = NULL,
	@ruta_sesion_temporal varchar(200) =NULL,
    @api_reune VARCHAR(max) = NULL,
	@auto_regenerar_token_user VARCHAR(max)=NULL
AS
BEGIN
    SET NOCOUNT ON;
	--execute sp_reune_obtener_update_configuracion 'G'
    IF @accion = 'G' -- Obtener la configuración
    BEGIN
        SELECT configuracion, valor
        FROM dbo.tb_reune_configuracionSistema_w
       -- WHERE configuracion IN ('valida_log_api', 'escribir_log', 'ruta_log', 'api_reune');
    END
    ELSE IF @accion = 'U' -- Actualizar la configuración
    BEGIN
        -- Actualizamos los registros correspondientes
        IF @valida_log_api IS NOT NULL
        BEGIN
            UPDATE dbo.tb_reune_configuracionSistema_w
            SET valor = @valida_log_api
            WHERE configuracion = 'valida_log_api';
        END

        IF @escribir_log IS NOT NULL
        BEGIN
            UPDATE dbo.tb_reune_configuracionSistema_w
            SET valor = @escribir_log
            WHERE configuracion = 'escribir_log';
        END

        IF @ruta_log IS NOT NULL
        BEGIN
            UPDATE dbo.tb_reune_configuracionSistema_w
            SET valor = @ruta_log
            WHERE configuracion = 'ruta_log';
        END

        IF @api_reune IS NOT NULL
        BEGIN
            UPDATE dbo.tb_reune_configuracionSistema_w
            SET valor = @api_reune
            WHERE configuracion = 'api_reune';
        END

        -- Devolvemos la configuración actualizada
        SELECT configuracion, valor
        FROM dbo.tb_reune_configuracionSistema_w
    END
END;


--USE [api_reune]
--GO
--/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_update_configuracion]    Script Date: 19/05/2024 08:06:52 a. m. ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
-- ALTER PROCEDURE [dbo].[sp_reune_obtener_update_configuracion]
--    @accion CHAR(1), -- 'G' para obtener, 'U' para actualizar
--    @valida_login INT = NULL, -- Nuevos valores para la actualización
--    @escribir_log INT = NULL,
--    @ruta_log VARCHAR(200) = NULL,
--    @api_reune VARCHAR(max) = NULL
--AS
--BEGIN
--    SET NOCOUNT ON;

--    IF @accion = 'G' -- Obtener la configuración
--    BEGIN
--        SELECT id_configuracion, valida_login, escribir_log, ruta_log, api_reune
--        FROM dbo.tb_reune_configuraciones_w;
--    END
--    ELSE IF @accion = 'U' -- Actualizar la configuración
--    BEGIN
--        -- Asumimos que siempre habrá exactamente un registro, actualizamos ese registro
--        UPDATE dbo.tb_reune_configuraciones_w
--        SET valida_login = ISNULL(@valida_login, valida_login),
--            escribir_log = ISNULL(@escribir_log, escribir_log),
--            ruta_log = ISNULL(@ruta_log, ruta_log),
--			api_reune = ISNULL(@api_reune, api_reune)
--        WHERE id_configuracion = (SELECT TOP 1 id_configuracion FROM dbo.tb_reune_configuraciones_w);

--        -- Devolvemos la configuración actualizada
--        SELECT id_configuracion, valida_login, escribir_log, ruta_log, api_reune
--        FROM dbo.tb_reune_configuraciones_w;
--    END
--END;
GO
