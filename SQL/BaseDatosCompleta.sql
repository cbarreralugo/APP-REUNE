USE [api_reune]
GO
/****** Object:  Table [dbo].[tb_reune_configuraciones_w]    Script Date: 13/05/2024 05:48:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_reune_configuraciones_w](
	[id_configuracion] [int] NOT NULL,
	[valida_login] [int] NOT NULL,
	[escribir_log] [int] NOT NULL,
	[ruta_log] [varchar](200) NOT NULL,
	[api_reune] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_reune_log_w]    Script Date: 13/05/2024 05:48:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_reune_log_w](
	[id_log] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[titulo] [varchar](100) NOT NULL,
	[fecha] [varchar](22) NOT NULL,
	[mensaje] [varchar](max) NULL,
	[equipo] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_reune_tipoUsuario_c]    Script Date: 13/05/2024 05:48:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_reune_tipoUsuario_c](
	[id_tipo] [int] NOT NULL,
	[nombre] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_reune_usuarios_w]    Script Date: 13/05/2024 05:48:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_reune_usuarios_w](
	[id_usuario] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[token] [varchar](max) NULL,
	[id_tipoUser] [int] NULL,
	[fecha] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tb_reune_configuraciones_w] ([id_configuracion], [valida_login], [escribir_log], [ruta_log], [api_reune]) VALUES (1, 0, 2, N'C:\Log_Reune', N'https://api-reune-pruebas.condusef.gob.mx/')
GO
INSERT [dbo].[tb_reune_tipoUsuario_c] ([id_tipo], [nombre]) VALUES (1, N'Super Usuario')
GO
INSERT [dbo].[tb_reune_tipoUsuario_c] ([id_tipo], [nombre]) VALUES (2, N'Usuario Normal')
GO
INSERT [dbo].[tb_reune_usuarios_w] ([id_usuario], [nombre], [password], [token], [id_tipoUser], [fecha]) VALUES (1, N'CarlosBarreraLugo', N'K10sm4rt', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiJlY2ExNTE1OS0xNDE2LTQzYjItYTUxNy1iOWNhNmIxOTAzYTIiLCJ1c2VybmFtZSI6IkNhcmxvc0JhcnJlcmFMdWdvIiwiaW5zdGl0dWNpb25pZCI6IkNEREI2QzQzLUE5NTctNEUzQi1BNDNDLTNBOTBDM0M5IiwiaW5zdGl0dWNpb25DbGF2ZSI6OTc0LCJkZW5vbWluYWNpb25fc29jaWFsIjoiU2FtIEFzc2V0IE1hbmFnZW1lbnQsIFMuQS4gZGUgQy5WLiwgU29jaWVkYWQgT3BlcmFkb3JhIGRlIEZvbmRvcyBkZSBJbnZlcnNpw7NuIiwic2VjdG9yaWQiOjcwLCJzZWN0b3IiOiJTb2NpZWRhZGVzIE9wZXJhZG9yYXMgZGUgRm9uZG9zIGRlIEludmVyc2nDs24iLCJzeXN0ZW0iOiJSRVVORSIsImlhdCI6MTcxNTE4ODA2MSwiZXhwIjoxNzE3NzgwMDYxfQ.-vrjA_1pH_E1VwoCDJgitmNFf8-27d3UNHkvkUWgzvw', 1, CAST(N'2024-09-05T14:33:59.000' AS DateTime))
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] ADD  DEFAULT ((1)) FOR [valida_login]
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] ADD  DEFAULT ((0)) FOR [escribir_log]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_crear_obtener_editar_usuario]    Script Date: 13/05/2024 05:48:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_reune_crear_obtener_editar_usuario]
    @accion CHAR(2), -- 'C' para crear, 'O' para obtener, 'E' para editar
    @id_usuario INT = NULL, -- Usado para obtener o editar un usuario específico
    @nombre VARCHAR(50) = NULL,
    @password VARCHAR(50) = NULL,
    @token VARCHAR(MAX) = NULL
AS
BEGIN
--EXEC sp_reune_crear_obtener_editar_usuario 'C', @nombre = 'NuevoNombre', @password = 'NuevaPass', @token = 'NuevoToken';
--EXEC sp_reune_crear_obtener_editar_usuario 'O', @id_usuario = 1;
--EXEC sp_reune_crear_obtener_editar_usuario 'E', @id_usuario = 1, @nombre = 'NombreEditado', @password = 'PassEditada', @token = 'TokenEditado';

    SET NOCOUNT ON;

    IF @accion = 'C' -- Crear un nuevo usuario
    BEGIN
        DECLARE @NewID INT;
        -- Obtener el máximo id_usuario actual y sumar 1 para el nuevo id
        SELECT @NewID = ISNULL(MAX(id_usuario), 0) + 1 FROM tb_reune_usuarios_w;

        INSERT INTO tb_reune_usuarios_w (id_usuario, nombre, password, token, id_tipoUser, fecha)
        VALUES (@NewID, @nombre, @password, @token, 2, GETDATE()); -- '2' para Usuario Normal

        SELECT @NewID AS 'NewUserID'; -- Retorna el ID del nuevo usuario creado
    END
    ELSE IF @accion = 'O' -- Obtener un usuario específico
    BEGIN
        SELECT id_usuario, nombre, password, token, id_tipoUser, fecha
        FROM tb_reune_usuarios_w
        WHERE id_usuario = @id_usuario;
    END
	 ELSE IF @accion = 'OT' -- Obtener todos
    BEGIN
        SELECT tb_u.id_usuario as 'Id',
			   tb_u.nombre as 'Nombre de usuario',
			   tb_u.password, '*****' as 'Token', 
			   tb_tipo.nombre as 'Tipo de usuario', 
			   tb_u.fecha as 'Ultima actualización'
        FROM tb_reune_usuarios_w tb_u
		INNER JOIN tb_reune_tipoUsuario_c tb_tipo on tb_u.id_tipoUser=tb_tipo.id_tipo
    END
    ELSE IF @accion = 'E' -- Editar un usuario existente
    BEGIN
        UPDATE tb_reune_usuarios_w
        SET nombre = ISNULL(@nombre, nombre),
            password = ISNULL(@password, password),
            token = ISNULL(@token, token),
            fecha = GETDATE() -- Actualizar la fecha a la actual
        WHERE id_usuario = @id_usuario;

        SELECT id_usuario, nombre, password, token, id_tipoUser, fecha
        FROM tb_reune_usuarios_w
        WHERE id_usuario = @id_usuario; -- Retorna los datos actualizados del usuario
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_crear_obtener_log]    Script Date: 13/05/2024 05:48:13 p. m. ******/
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
/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_sesion]    Script Date: 13/05/2024 05:48:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_reune_obtener_sesion]
    @usuario VARCHAR(50),
    @password VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
	--execute sp_reune_obtener_sesion 'CarlosBarreraLugo','K10sm4rt'
    --select * from tb_reune_usuarios_w
       SELECT 
        id_usuario, 
        nombre, 
        password, 
        token, 
        id_tipoUser,
        fecha AS FechaToken,
        GETDATE() AS FechaActual,
        CASE 
            WHEN DATEDIFF(day, GETDATE(), CAST(fecha AS DATE)) > 0 THEN 30
            ELSE 30 - DATEDIFF(day, CAST(fecha AS DATE), GETDATE()) 
        END AS DiasRestantes
    FROM tb_reune_usuarios_w
    WHERE nombre = @usuario AND password = @password;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_update_configuracion]    Script Date: 13/05/2024 05:48:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[sp_reune_obtener_update_configuracion]
    @accion CHAR(1), -- 'G' para obtener, 'U' para actualizar
    @valida_login INT = NULL, -- Nuevos valores para la actualización
    @escribir_log INT = NULL,
    @ruta_log VARCHAR(200) = NULL,
    @api_reune VARCHAR(max) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @accion = 'G' -- Obtener la configuración
    BEGIN
        SELECT id_configuracion, valida_login, escribir_log, ruta_log, api_reune
        FROM dbo.tb_reune_configuraciones_w;
    END
    ELSE IF @accion = 'U' -- Actualizar la configuración
    BEGIN
        -- Asumimos que siempre habrá exactamente un registro, actualizamos ese registro
        UPDATE dbo.tb_reune_configuraciones_w
        SET valida_login = ISNULL(@valida_login, valida_login),
            escribir_log = ISNULL(@escribir_log, escribir_log),
            ruta_log = ISNULL(@ruta_log, ruta_log),
			api_reune = ISNULL(@api_reune, api_reune)
        WHERE id_configuracion = (SELECT TOP 1 id_configuracion FROM dbo.tb_reune_configuraciones_w);

        -- Devolvemos la configuración actualizada
        SELECT id_configuracion, valida_login, escribir_log, ruta_log, api_reune
        FROM dbo.tb_reune_configuraciones_w;
    END
END;
GO
