USE [api_reune]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_crear_obtener_log]    Script Date: 20/05/2024 10:02:12 a. m. ******/
DROP PROCEDURE [dbo].[sp_reune_crear_obtener_log]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_crear_obtener_log]    Script Date: 20/05/2024 10:02:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[sp_reune_crear_obtener_log]
    @nombre_usuario VARCHAR(50) = NULL, -- 0 significa que se traerán todos los logs
    @accion CHAR(1), -- 'C' para crear, 'O' para obtener
    @titulo VARCHAR(100) = NULL,
    @mensaje VARCHAR(MAX) = NULL,
    @equipo VARCHAR(50) = NULL
AS
BEGIN
		--execute [sp_reune_crear_obtener_log] '0','O'
		--execute [sp_reune_crear_obtener_log] 'CarlosBarreraLugo','C','Inicio de sesión','Se ingreso desde la app','CARLOS'

    IF @accion = 'O'
    BEGIN
        IF @nombre_usuario =''
        BEGIN
            SELECT Top 50
			tb_log.id_log,
			tb_user.id_usuario as 'ID Usuario',
			tb_user.nombre as 'Nombre de usuario',
			tb_tipo.nombre as 'Tipo de usuario',
			tb_log.titulo as 'Tipo de log',
			tb_log.mensaje as 'Mensaje',
			tb_log.fecha as 'Creado',
			tb_log.equipo as 'Nombre del dispositivo'
			FROM tb_reune_log_w tb_log
			INNER JOIN tb_reune_usuarios_w tb_user on tb_log.id_usuario = tb_user.id_usuario
			INNER JOIN tb_reune_tipoUsuario_c tb_tipo on tb_user.id_tipoUser = tb_tipo.id_tipo
			order by tb_log.id_log desc
        END
        ELSE
        BEGIN
            SELECT l.* FROM tb_reune_log_w l
            JOIN tb_reune_usuarios_w u ON l.id_usuario = u.id_usuario
            WHERE u.nombre = @nombre_usuario;
        END
    END
    ELSE IF @accion = 'C'
    BEGIN
        DECLARE @new_id_log INT;
        SELECT @new_id_log = ISNULL(MAX(id_log), 0) + 1 FROM tb_reune_log_w;

        INSERT INTO tb_reune_log_w(id_log, titulo, fecha, mensaje, equipo, id_usuario)
        VALUES(@new_id_log, @titulo, CONVERT(VARCHAR, GETDATE(), 120), @mensaje, @equipo, 
               (SELECT id_usuario FROM tb_reune_usuarios_w WHERE nombre = @nombre_usuario));

    END
END;
GO
