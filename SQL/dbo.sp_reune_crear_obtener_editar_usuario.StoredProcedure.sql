USE [api_reune]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_crear_obtener_editar_usuario]    Script Date: 20/05/2024 10:02:12 a. m. ******/
DROP PROCEDURE [dbo].[sp_reune_crear_obtener_editar_usuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_crear_obtener_editar_usuario]    Script Date: 20/05/2024 10:02:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_reune_crear_obtener_editar_usuario]
    @accion CHAR(2), -- 'C' para crear, 'O' para obtener, 'E' para editar
    @id_usuario INT = NULL, -- Usado para obtener o editar un usuario específico
    @nombre VARCHAR(50) = NULL,
    @password VARCHAR(50) = NULL,
    @token VARCHAR(MAX) = NULL,
    @userid_api VARCHAR(MAX) = NULL,
    @username_api VARCHAR(200) = NULL,
    @password_api VARCHAR(MAX) = NULL,
    @institucionid_api VARCHAR(MAX) = NULL,
    @is_active_api VARCHAR(15) = NULL,
    @profileid_api VARCHAR(200) = NULL,
    @date_api VARCHAR(50) = NULL,
    @system_api VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
	--execute sp_reune_crear_obtener_editar_usuario 'OT'
    IF @accion = 'C' -- Crear un nuevo usuario
    BEGIN
        DECLARE @NewID INT;
        -- Obtener el máximo id_usuario actual y sumar 1 para el nuevo id
        SELECT @NewID = ISNULL(MAX(id_usuario), 0) + 1 FROM tb_reune_usuarios_w;

        INSERT INTO tb_reune_usuarios_w (id_usuario, nombre, password, token, id_tipoUser, fecha,
                                         userid_api, username_api, password_api, institucionid_api, 
                                         is_active_api, profileid_api, date_api, system_api)
        VALUES (@NewID, @nombre, @password, @token, 2, GETDATE(),
                @userid_api, @username_api, @password_api, @institucionid_api, 
                @is_active_api, @profileid_api, @date_api, @system_api); 

        SELECT @NewID AS 'NewUserID'; -- Retorna el ID del nuevo usuario creado
    END
    ELSE IF @accion = 'O' -- Obtener un usuario específico
    BEGIN
        SELECT *
        FROM tb_reune_usuarios_w
        WHERE id_usuario = @id_usuario;
    END
	ELSE IF @accion = 'OT' -- Obtener un usuario específico
    BEGIN
        SELECT 
		u.id_usuario as 'ID',
		tp.nombre as 'Tipo de usuario',
		u.username_api as 'Nombre de Usuario',
		u.password as 'Contraseña',
		u.fecha as 'Ultima actualización'
        FROM tb_reune_usuarios_w u
		Inner join tb_reune_tipoUsuario_c tp on u.id_tipoUser=tp.id_tipo
         
    END
    ELSE IF @accion = 'E' -- Editar un usuario existente
    BEGIN
        UPDATE tb_reune_usuarios_w
        SET --nombre = ISNULL(@nombre, nombre),
            --password = ISNULL(@password, password),
            token = ISNULL(@token, token),
            --userid_api = ISNULL(@userid_api, userid_api),
            --username_api = ISNULL(@username_api, username_api),
            --password_api = ISNULL(@password_api, password_api),
            --institucionid_api = ISNULL(@institucionid_api, institucionid_api),
            --is_active_api = ISNULL(@is_active_api, is_active_api),
            --profileid_api = ISNULL(@profileid_api, profileid_api),
            --date_api = ISNULL(@date_api, date_api),
            --system_api = ISNULL(@system_api, system_api),
            fecha = GETDATE() -- Actualizar la fecha a la actual
        WHERE nombre = @nombre;

        SELECT *
        FROM tb_reune_usuarios_w
        WHERE id_usuario = @id_usuario; -- Retorna los datos actualizados del usuario
    END
END;
GO
