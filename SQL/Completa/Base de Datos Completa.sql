USE [api_reune]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_update_configuracion]    Script Date: 20/05/2024 10:12:12 a. m. ******/
DROP PROCEDURE [dbo].[sp_reune_obtener_update_configuracion]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_sesion]    Script Date: 20/05/2024 10:12:12 a. m. ******/
DROP PROCEDURE [dbo].[sp_reune_obtener_sesion]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_crear_obtener_log]    Script Date: 20/05/2024 10:12:12 a. m. ******/
DROP PROCEDURE [dbo].[sp_reune_crear_obtener_log]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_crear_obtener_editar_usuario]    Script Date: 20/05/2024 10:12:12 a. m. ******/
DROP PROCEDURE [dbo].[sp_reune_crear_obtener_editar_usuario]
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] DROP CONSTRAINT [DF__tb_reune___escri__3B75D760]
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] DROP CONSTRAINT [DF__tb_reune___valid__3A81B327]
GO
/****** Object:  Table [dbo].[tb_reune_usuarios_w]    Script Date: 20/05/2024 10:12:12 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_reune_usuarios_w]') AND type in (N'U'))
DROP TABLE [dbo].[tb_reune_usuarios_w]
GO
/****** Object:  Table [dbo].[tb_reune_tipoUsuario_c]    Script Date: 20/05/2024 10:12:12 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_reune_tipoUsuario_c]') AND type in (N'U'))
DROP TABLE [dbo].[tb_reune_tipoUsuario_c]
GO
/****** Object:  Table [dbo].[tb_reune_log_w]    Script Date: 20/05/2024 10:12:12 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_reune_log_w]') AND type in (N'U'))
DROP TABLE [dbo].[tb_reune_log_w]
GO
/****** Object:  Table [dbo].[tb_reune_ConfiguracionSistema_w]    Script Date: 20/05/2024 10:12:12 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_reune_ConfiguracionSistema_w]') AND type in (N'U'))
DROP TABLE [dbo].[tb_reune_ConfiguracionSistema_w]
GO
/****** Object:  Table [dbo].[tb_reune_configuraciones_w]    Script Date: 20/05/2024 10:12:12 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_reune_configuraciones_w]') AND type in (N'U'))
DROP TABLE [dbo].[tb_reune_configuraciones_w]
GO
/****** Object:  Table [dbo].[tb_reune_configuraciones_w]    Script Date: 20/05/2024 10:12:12 a. m. ******/
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
/****** Object:  Table [dbo].[tb_reune_ConfiguracionSistema_w]    Script Date: 20/05/2024 10:12:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_reune_ConfiguracionSistema_w](
	[id_conf] [int] NULL,
	[configuracion] [varchar](50) NULL,
	[valor] [varchar](max) NULL,
	[estatus] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_reune_log_w]    Script Date: 20/05/2024 10:12:12 a. m. ******/
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
/****** Object:  Table [dbo].[tb_reune_tipoUsuario_c]    Script Date: 20/05/2024 10:12:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_reune_tipoUsuario_c](
	[id_tipo] [int] NOT NULL,
	[nombre] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_reune_usuarios_w]    Script Date: 20/05/2024 10:12:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_reune_usuarios_w](
	[id_usuario] [int] NOT NULL,
	[userid_api] [varchar](max) NOT NULL,
	[username_api] [varchar](200) NOT NULL,
	[password_api] [varchar](max) NOT NULL,
	[institucionid_api] [varchar](max) NOT NULL,
	[is_active_api] [varchar](15) NOT NULL,
	[profileid_api] [varchar](200) NOT NULL,
	[date_api] [varchar](50) NOT NULL,
	[system_api] [varchar](200) NOT NULL,
	[nombre] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[token] [varchar](max) NULL,
	[id_tipoUser] [int] NULL,
	[fecha] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[tb_reune_configuraciones_w] ([id_configuracion], [valida_login], [escribir_log], [ruta_log], [api_reune]) VALUES (1, 0, 2, N'C:\Log_Reune', N'https://api-reune-pruebas.condusef.gob.mx/')
GO
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (1, N'valida_login_api', N'a0erM2Z2Sccz+WfUb4k3UQ==', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (2, N'escribir_log', N'9yyoVaRSUSgaTR03GadA3A==', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (3, N'ruta_log', N'VKCWcHor6/Mtbg+TX8zrfHUG4K2EOzqFnaETSRdvMVE=', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (4, N'ruta_sesion_temporal', N'VKCWcHor6/Mtbg+TX8zrfBxSjEkADqiXutBGuX72PG30qWw3wGE83x+f1aeLEU9G', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (5, N'api_reune', N'0FM9qtQJNDmJN7TYidKFC7WG/3ckNTTFos4DCuqBhoIYmmVNhpCVYzrBoXC7kukz', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (6, N'key', N'SAM', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (7, N'mostrar_alertas', N'EkI4cVaDTsTuYPZl+dXNPQ==', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (8, N'auto_regenerar_token_user', N'EkI4cVaDTsTuYPZl+dXNPQ==', 1)
GO
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (1, 1, N'Inicio de sesión', N'2024-05-09 20:37:00', N'Se ingreso desde la app', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (2, 1, N'Inicio se sesión', N'2024-05-10 07:59:58', N'===========
**Inicio se sesión**
[10-05-2024, 07:59:13] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (3, 1, N'Inicio se sesión', N'2024-05-10 08:25:51', N'===========
**Inicio se sesión**
[10-05-2024, 08:25:39] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (4, 1, N'Inicio se sesión', N'2024-05-10 10:23:16', N'===========
**Inicio se sesión**
[10-05-2024, 10:22:58] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (5, 1, N'Inicio se sesión', N'2024-05-11 11:55:33', N'===========
**Inicio se sesión**
[11-05-2024, 11:55:33] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (6, 1, N'Inicio se sesión', N'2024-05-11 12:15:40', N'===========
**Inicio se sesión**
[11-05-2024, 12:15:40] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (7, 1, N'Inicio se sesión', N'2024-05-11 12:30:51', N'===========
**Inicio se sesión**
[11-05-2024, 12:30:51] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (8, 1, N'Inicio se sesión', N'2024-05-11 12:45:03', N'===========
**Inicio se sesión**
[11-05-2024, 12:45:03] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (10, 1, N'Inicio se sesión', N'2024-05-11 13:55:44', N'===========
**Inicio se sesión**
[11-05-2024, 13:55:43] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (14, 1, N'Inicio se sesión', N'2024-05-11 14:53:07', N'===========
**Inicio se sesión**
[11-05-2024, 14:53:07] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (16, 1, N'Inicio se sesión', N'2024-05-11 15:04:15', N'===========
**Inicio se sesión**
[11-05-2024, 15:04:15] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (18, 1, N'Inicio se sesión', N'2024-05-11 20:08:07', N'===========
**Inicio se sesión**
[11-05-2024, 20:08:07] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (19, 1, N'Inicio se sesión', N'2024-05-11 20:12:43', N'===========
**Inicio se sesión**
[11-05-2024, 20:12:43] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (20, 1, N'Inicio se sesión', N'2024-05-11 20:14:27', N'===========
**Inicio se sesión**
[11-05-2024, 20:14:27] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (21, 1, N'Error al crear el usuario: Javier', N'2024-05-11 20:27:38', N'===========
**Error al crear el usuario: Javier**
[11-05-2024, 20:27:38] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (22, 1, N'Error al crear el usuario: Javier', N'2024-05-11 20:28:00', N'===========
**Error al crear el usuario: Javier**
[11-05-2024, 20:28:00] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (23, 1, N'Error al crear el usuario: Javier', N'2024-05-11 20:28:11', N'===========
**Error al crear el usuario: Javier**
[11-05-2024, 20:28:11] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (24, 1, N'Error al crear el usuario: Javier', N'2024-05-11 20:28:21', N'===========
**Error al crear el usuario: Javier**
[11-05-2024, 20:28:21] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (25, 1, N'Inicio se sesión', N'2024-05-11 20:30:47', N'===========
**Inicio se sesión**
[11-05-2024, 20:30:47] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (26, 1, N'Error al crear el usuario: ', N'2024-05-11 20:31:30', N'===========
**Error al crear el usuario: **
[11-05-2024, 20:31:29] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (27, 1, N'Error al crear el usuario: JAvier', N'2024-05-11 20:31:48', N'===========
**Error al crear el usuario: JAvier**
[11-05-2024, 20:31:48] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (28, 1, N'Error al crear el usuario: JAvier', N'2024-05-11 20:32:00', N'===========
**Error al crear el usuario: JAvier**
[11-05-2024, 20:32:00] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (29, 1, N'Inicio se sesión', N'2024-05-11 22:15:12', N'===========
**Inicio se sesión**
[11-05-2024, 22:15:12] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (30, 1, N'Error al crear el usuario: cd', N'2024-05-11 22:15:24', N'===========
**Error al crear el usuario: cd**
[11-05-2024, 22:15:24] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (31, 1, N'Inicio se sesión', N'2024-05-11 23:01:13', N'===========
**Inicio se sesión**
[11-05-2024, 23:01:13] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (32, 1, N'Inicio se sesión', N'2024-05-11 23:03:37', N'===========
**Inicio se sesión**
[11-05-2024, 23:03:37] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (33, 1, N'Inicio se sesión', N'2024-05-11 23:06:11', N'===========
**Inicio se sesión**
[11-05-2024, 23:06:11] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (34, 1, N'Inicio se sesión', N'2024-05-12 15:04:38', N'===========
**Inicio se sesión**
[12-05-2024, 15:04:38] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (35, 1, N'Inicio se sesión', N'2024-05-12 15:09:50', N'===========
**Inicio se sesión**
[12-05-2024, 15:09:50] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (36, 1, N'Inicio se sesión', N'2024-05-12 15:11:00', N'===========
**Inicio se sesión**
[12-05-2024, 15:11:00] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (37, 1, N'Inicio se sesión', N'2024-05-12 15:15:50', N'===========
**Inicio se sesión**
[12-05-2024, 15:15:50] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (38, 1, N'Inicio se sesión', N'2024-05-12 15:20:54', N'===========
**Inicio se sesión**
[12-05-2024, 15:20:53] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (9, 1, N'Inicio se sesión', N'2024-05-11 13:26:53', N'===========
**Inicio se sesión**
[11-05-2024, 13:26:53] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (11, 1, N'Inicio se sesión', N'2024-05-11 14:38:18', N'===========
**Inicio se sesión**
[11-05-2024, 14:38:18] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (12, 1, N'Cambio de configuraciones sin exito', N'2024-05-11 14:39:11', N'===========
**Cambio de configuraciones sin exito**
[11-05-2024, 14:39:11] - Creación de log.
Mensaje: Se intento realizar cambios generales a la configuración del sistema, pero no se obtubo exito. 
Verifica que esta acción se esperaba realizar.
 si el cambio es necesario, Pide que el administrador realice la operación manualmente en Base de Datos
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (39, 1, N'Inicio se sesión', N'2024-05-12 15:56:42', N'===========
**Inicio se sesión**
[12-05-2024, 15:56:42] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (40, 1, N'Inicio se sesión', N'2024-05-12 16:00:38', N'===========
**Inicio se sesión**
[12-05-2024, 16:00:38] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (41, 1, N'Inicio se sesión', N'2024-05-12 16:04:35', N'===========
**Inicio se sesión**
[12-05-2024, 16:04:35] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (43, 1, N'Inicio se sesión', N'2024-05-12 17:28:11', N'===========
**Inicio se sesión**
[12-05-2024, 17:28:11] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (46, 1, N'Inicio se sesión', N'2024-05-12 18:09:26', N'===========
**Inicio se sesión**
[12-05-2024, 18:09:26] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (47, 1, N'Inicio se sesión', N'2024-05-12 18:21:45', N'===========
**Inicio se sesión**
[12-05-2024, 18:21:44] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (48, 1, N'Inicio se sesión', N'2024-05-12 18:23:58', N'===========
**Inicio se sesión**
[12-05-2024, 18:23:58] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (50, 1, N'Inicio se sesión', N'2024-05-12 18:34:28', N'===========
**Inicio se sesión**
[12-05-2024, 18:34:28] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (51, 1, N'Inicio se sesión', N'2024-05-12 18:49:36', N'===========
**Inicio se sesión**
[12-05-2024, 18:49:36] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (52, 1, N'Inicio se sesión', N'2024-05-12 21:30:42', N'===========
**Inicio se sesión**
[12-05-2024, 21:30:41] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (53, 1, N'Inicio se sesión', N'2024-05-12 21:35:38', N'===========
**Inicio se sesión**
[12-05-2024, 21:35:38] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (54, 1, N'Inicio se sesión', N'2024-05-12 22:19:53', N'===========
**Inicio se sesión**
[12-05-2024, 22:19:52] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (55, 1, N'Inicio se sesión', N'2024-05-12 22:22:50', N'===========
**Inicio se sesión**
[12-05-2024, 22:22:50] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (56, 1, N'Inicio se sesión', N'2024-05-12 22:30:09', N'===========
**Inicio se sesión**
[12-05-2024, 22:30:08] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (57, 1, N'Inicio se sesión', N'2024-05-12 22:33:30', N'===========
**Inicio se sesión**
[12-05-2024, 22:33:29] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (58, 1, N'Inicio se sesión', N'2024-05-12 22:35:53', N'===========
**Inicio se sesión**
[12-05-2024, 22:35:53] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (59, 1, N'Inicio se sesión', N'2024-05-12 22:38:53', N'===========
**Inicio se sesión**
[12-05-2024, 22:38:53] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (60, 1, N'Inicio se sesión', N'2024-05-12 22:47:27', N'===========
**Inicio se sesión**
[12-05-2024, 22:47:26] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (61, 1, N'Se exporto información en un .txt', N'2024-05-12 22:47:42', N'===========
**Se exporto información en un .txt**
[12-05-2024, 22:47:42] - Creación de log.
Mensaje: Los datos de la tabla Log de actividades de usuario 
Se exporto a la ubicación local:C:\Users\carlo\Downloads\Prueba.txt con exito!!!
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (62, 1, N'Se exporto información en un .csv', N'2024-05-12 22:48:29', N'===========
**Se exporto información en un .csv**
[12-05-2024, 22:48:29] - Creación de log.
Mensaje: Los datos de la tabla Log de actividades de usuario 
Se exporto a la ubicación local:C:\Users\carlo\Downloads\test.csv con exito!!!
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (63, 1, N'Inicio se sesión', N'2024-05-12 23:00:34', N'===========
**Inicio se sesión**
[12-05-2024, 23:00:33] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (73, 1, N'Inicio se sesión', N'2024-05-15 11:18:50', N'===========
**Inicio se sesión**
[15-05-2024, 11:18:50] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (74, 1, N'Error al crear el usuario: JavierPacheco', N'2024-05-15 11:37:42', N'===========
**Error al crear el usuario: JavierPacheco**
[15-05-2024, 11:37:42] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (75, 1, N'Error al crear el usuario: JavierPacheco', N'2024-05-15 11:49:45', N'===========
**Error al crear el usuario: JavierPacheco**
[15-05-2024, 11:49:45] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (76, 1, N'Error al crear el usuario: JavierPacheco', N'2024-05-15 11:54:56', N'===========
**Error al crear el usuario: JavierPacheco**
[15-05-2024, 11:54:56] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (77, 1, N'Error al crear el usuario: JavierPacheco', N'2024-05-15 11:58:57', N'===========
**Error al crear el usuario: JavierPacheco**
[15-05-2024, 11:58:57] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (78, 1, N'Inicio se sesión', N'2024-05-15 12:03:53', N'===========
**Inicio se sesión**
[15-05-2024, 12:03:53] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (81, 1, N'Inicio se sesión', N'2024-05-16 12:25:14', N'===========
**Inicio se sesión**
[16-05-2024, 12:25:14] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (13, 1, N'Inicio se sesión', N'2024-05-11 14:45:54', N'===========
**Inicio se sesión**
[11-05-2024, 14:45:54] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (15, 1, N'Inicio se sesión', N'2024-05-11 15:01:49', N'===========
**Inicio se sesión**
[11-05-2024, 15:01:48] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (17, 1, N'Inicio se sesión', N'2024-05-11 15:08:32', N'===========
**Inicio se sesión**
[11-05-2024, 15:08:31] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (42, 1, N'Inicio se sesión', N'2024-05-12 16:08:05', N'===========
**Inicio se sesión**
[12-05-2024, 16:08:05] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (66, 1, N'Inicio se sesión', N'2024-05-13 08:42:56', N'===========
**Inicio se sesión**
[13-05-2024, 08:42:56] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (71, 1, N'Inicio se sesión', N'2024-05-15 10:47:09', N'===========
**Inicio se sesión**
[15-05-2024, 10:47:09] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (72, 1, N'Error al crear el usuario: veronica.leon@santanderam.com', N'2024-05-15 10:48:46', N'===========
**Error al crear el usuario: veronica.leon@santanderam.com**
[15-05-2024, 10:48:46] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (79, 1, N'Inicio se sesión', N'2024-05-15 12:09:21', N'===========
**Inicio se sesión**
[15-05-2024, 12:09:21] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (80, 1, N'Error al crear el usuario: Javier', N'2024-05-15 12:09:45', N'===========
**Error al crear el usuario: Javier**
[15-05-2024, 12:09:45] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (82, 1, N'Error al crear el usuario: Fransisco', N'2024-05-16 12:30:11', N'===========
**Error al crear el usuario: Fransisco**
[16-05-2024, 12:30:11] - Creación de log.
Mensaje: Verifica que el token de super usuario sea valido y cuente con los permisos necesarios
 No se logro crear el usuario.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (83, 1, N'Inicio se sesión', N'2024-05-16 13:27:28', N'===========
**Inicio se sesión**
[16-05-2024, 13:27:28] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (114, 1, N'Inicio se sesión', N'2024-05-17 11:49:07', N'===========
**Inicio se sesión**
[17-05-2024, 11:49:07] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (115, 1, N'Inicio se sesión', N'2024-05-17 11:58:35', N'===========
**Inicio se sesión**
[17-05-2024, 11:58:35] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (116, 1, N'Inicio se sesión', N'2024-05-17 12:04:36', N'===========
**Inicio se sesión**
[17-05-2024, 12:04:35] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (117, 1, N'Inicio se sesión', N'2024-05-17 12:37:35', N'===========
**Inicio se sesión**
[17-05-2024, 12:37:35] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (118, 1, N'Inicio se sesión', N'2024-05-17 12:45:31', N'===========
**Inicio se sesión**
[17-05-2024, 12:45:31] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (119, 1, N'Inicio se sesión', N'2024-05-17 12:49:06', N'===========
**Inicio se sesión**
[17-05-2024, 12:49:06] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (120, 1, N'Usuario creado', N'2024-05-17 12:50:32', N'===========
**Usuario creado**
[17-05-2024, 12:50:32] - Creación de log.
Mensaje: Usuario: Sofia creado
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (121, 1, N'Usuario creado', N'2024-05-17 12:50:45', N'===========
**Usuario creado**
[17-05-2024, 12:50:45] - Creación de log.
Mensaje: Se ha creado un nuevo usaurio 
 username:Sofia password: 1234
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (122, 1, N'Inicio se sesión', N'2024-05-17 16:45:23', N'===========
**Inicio se sesión**
[17-05-2024, 16:45:23] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (123, 1, N'Usuario creado', N'2024-05-17 16:53:03', N'===========
**Usuario creado**
[17-05-2024, 16:53:03] - Creación de log.
Mensaje: Se ha creado un nuevo usaurio 
 username:cbarreralugo@gmail.com password: 1230
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (124, 1, N'Inicio se sesión', N'2024-05-17 16:57:38', N'===========
**Inicio se sesión**
[17-05-2024, 16:57:38] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (126, 1, N'Inicio se sesión', N'2024-05-17 17:06:25', N'===========
**Inicio se sesión**
[17-05-2024, 17:06:25] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (127, 1, N'Inicio se sesión', N'2024-05-17 17:51:51', N'===========
**Inicio se sesión**
[17-05-2024, 17:51:50] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (132, 1, N'Inicio se sesión', N'2024-05-19 11:59:05', N'===========
**Inicio se sesión**
[19-05-2024, 11:59:05] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (133, 1, N'Sesión guardad con exito en el equipo', N'2024-05-19 12:01:32', N'===========
**Sesión guardad con exito en el equipo**
[19-05-2024, 12:01:32] - Creación de log.
Mensaje: Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (134, 1, N'Inicio se sesión', N'2024-05-19 12:01:32', N'===========
**Inicio se sesión**
[19-05-2024, 12:01:32] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (136, 1, N'Inicio se sesión', N'2024-05-19 13:10:52', N'===========
**Inicio se sesión**
[19-05-2024, 13:10:52] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (137, 1, N'Inicio se sesión', N'2024-05-19 13:16:17', N'===========
**Inicio se sesión**
[19-05-2024, 13:16:17] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (138, 1, N'Inicio se sesión', N'2024-05-19 13:16:45', N'===========
**Inicio se sesión**
[19-05-2024, 13:16:45] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (139, 1, N'Inicio se sesión', N'2024-05-19 13:17:20', N'===========
**Inicio se sesión**
[19-05-2024, 13:17:20] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (141, 1, N'Inicio se sesión', N'2024-05-19 13:29:30', N'===========
**Inicio se sesión**
[19-05-2024, 13:29:30] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (142, 1, N'Inicio se sesión', N'2024-05-19 14:27:18', N'===========
**Inicio se sesión**
[19-05-2024, 14:27:18] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (44, 1, N'Inicio se sesión', N'2024-05-12 17:34:00', N'===========
**Inicio se sesión**
[12-05-2024, 17:34:00] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (45, 1, N'Inicio se sesión', N'2024-05-12 18:03:18', N'===========
**Inicio se sesión**
[12-05-2024, 18:03:17] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (49, 1, N'Inicio se sesión', N'2024-05-12 18:29:16', N'===========
**Inicio se sesión**
[12-05-2024, 18:29:15] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (64, 1, N'Inicio se sesión', N'2024-05-12 23:44:34', N'===========
**Inicio se sesión**
[12-05-2024, 23:44:34] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
GO
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (65, 1, N'Se exporto información en un .csv', N'2024-05-12 23:45:30', N'===========
**Se exporto información en un .csv**
[12-05-2024, 23:45:30] - Creación de log.
Mensaje: Los datos de la tabla Todos los usuarios 
Se exporto a la ubicación local:C:\Users\carlo\Downloads\usuarios.csv con exito!!!
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (125, 1, N'Usuario creado', N'2024-05-17 16:58:23', N'===========
**Usuario creado**
[17-05-2024, 16:58:23] - Creación de log.
Mensaje: Se ha creado un nuevo usaurio 
 username:cbarrera@gmail.com password: qwe123
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (128, 1, N'Inicio se sesión', N'2024-05-19 07:59:48', N'===========
**Inicio se sesión**
[19-05-2024, 07:59:48] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (135, 1, N'Inicio se sesión', N'2024-05-19 12:28:57', N'===========
**Inicio se sesión**
[19-05-2024, 12:28:57] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (147, 1, N'Sesión guardad con exito en el equipo', N'2024-05-19 14:36:30', N'===========
**Sesión guardad con exito en el equipo**
[19-05-2024, 14:36:30] - Creación de log.
Mensaje: Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (148, 1, N'Inicio se sesión', N'2024-05-19 14:36:30', N'===========
**Inicio se sesión**
[19-05-2024, 14:36:30] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (149, 1, N'Inicio se sesión', N'2024-05-19 14:48:09', N'===========
**Inicio se sesión**
[19-05-2024, 14:48:08] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (150, 1, N'Inicio se sesión', N'2024-05-19 14:52:55', N'===========
**Inicio se sesión**
[19-05-2024, 14:52:55] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (151, 1, N'Inicio se sesión', N'2024-05-19 18:08:25', N'===========
**Inicio se sesión**
[19-05-2024, 18:08:25] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (152, 1, N'Inicio se sesión', N'2024-05-19 18:10:09', N'===========
**Inicio se sesión**
[19-05-2024, 18:10:09] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (153, 1, N'Inicio se sesión', N'2024-05-19 18:12:32', N'===========
**Inicio se sesión**
[19-05-2024, 18:12:32] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (154, 1, N'Usuario creado', N'2024-05-19 18:14:36', N'===========
**Usuario creado**
[19-05-2024, 18:14:36] - Creación de log.
Mensaje: Se ha creado un nuevo usaurio 
 username:carlos password: 123
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (155, 1, N'Inicio se sesión', N'2024-05-19 18:46:22', N'===========
**Inicio se sesión**
[19-05-2024, 18:46:22] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (156, 1, N'Error al procesar Aclarciones', N'2024-05-19 18:53:12', N'===========
**Error al procesar Aclarciones**
[19-05-2024, 18:53:12] - Creación de log.
Mensaje: {"error":"Hubo un error en el servidor"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (157, 1, N'Inicio se sesión', N'2024-05-19 19:00:16', N'===========
**Inicio se sesión**
[19-05-2024, 19:00:16] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (158, 1, N'Error al procesar Aclarciones', N'2024-05-19 19:01:35', N'===========
**Error al procesar Aclarciones**
[19-05-2024, 19:01:35] - Creación de log.
Mensaje: {"error":"Hubo un error en el servidor"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (159, 1, N'Error al procesar Aclarciones', N'2024-05-19 19:02:32', N'===========
**Error al procesar Aclarciones**
[19-05-2024, 19:02:32] - Creación de log.
Mensaje: {"error":"Hubo un error en el servidor"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (160, 1, N'Error al procesar Aclarciones', N'2024-05-19 19:02:53', N'===========
**Error al procesar Aclarciones**
[19-05-2024, 19:02:53] - Creación de log.
Mensaje: {"error":"Hubo un error en el servidor"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (161, 1, N'Inicio se sesión', N'2024-05-19 19:03:08', N'===========
**Inicio se sesión**
[19-05-2024, 19:03:08] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (162, 6, N'Sesión guardad con exito en el equipo', N'2024-05-19 19:11:45', N'===========
**Sesión guardad con exito en el equipo**
[19-05-2024, 19:11:45] - Creación de log.
Mensaje: Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (163, 6, N'Inicio se sesión', N'2024-05-19 19:11:45', N'===========
**Inicio se sesión**
[19-05-2024, 19:11:45] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (164, 6, N'Inicio se sesión', N'2024-05-19 19:29:17', N'===========
**Inicio se sesión**
[19-05-2024, 19:29:17] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (165, 6, N'Inicio se sesión', N'2024-05-19 19:33:51', N'===========
**Inicio se sesión**
[19-05-2024, 19:33:51] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (166, 6, N'Inicio se sesión', N'2024-05-19 19:34:27', N'===========
**Inicio se sesión**
[19-05-2024, 19:34:27] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (167, 6, N'Inicio se sesión', N'2024-05-19 19:42:33', N'===========
**Inicio se sesión**
[19-05-2024, 19:42:33] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (168, 6, N'Inicio se sesión', N'2024-05-19 19:46:43', N'===========
**Inicio se sesión**
[19-05-2024, 19:46:43] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (169, 6, N'Inicio se sesión', N'2024-05-19 20:50:01', N'===========
**Inicio se sesión**
[19-05-2024, 20:50:01] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (172, 6, N'Inicio se sesión', N'2024-05-20 09:37:01', N'===========
**Inicio se sesión**
[20-05-2024, 09:37:01] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (67, 1, N'Inicio se sesión', N'2024-05-13 08:55:22', N'===========
**Inicio se sesión**
[13-05-2024, 08:55:22] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (68, 1, N'Inicio se sesión', N'2024-05-13 17:01:10', N'===========
**Inicio se sesión**
[13-05-2024, 17:01:09] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (69, 1, N'Inicio se sesión', N'2024-05-13 17:15:00', N'===========
**Inicio se sesión**
[13-05-2024, 17:15:00] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (70, 1, N'Se exporto información en un .txt', N'2024-05-13 17:15:56', N'===========
**Se exporto información en un .txt**
[13-05-2024, 17:15:56] - Creación de log.
Mensaje: Los datos de la tabla Todos los usuarios 
Se exporto a la ubicación local:C:\Users\carlo\Downloads\Prueba.txt con exito!!!
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (92, 1, N'Inicio se sesión', N'2024-05-16 14:08:33', N'===========
**Inicio se sesión**
[16-05-2024, 14:08:33] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (93, 1, N'Error al crear el usuario: user12', N'2024-05-16 14:10:26', N'===========
**Error al crear el usuario: user12**
[16-05-2024, 14:10:26] - Creación de log.
Mensaje: Respuesta de la API: {"msg":"Token no válido"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (103, 1, N'Inicio se sesión', N'2024-05-16 14:33:49', N'===========
**Inicio se sesión**
[16-05-2024, 14:33:49] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (113, 1, N'Inicio se sesión', N'2024-05-17 11:36:38', N'===========
**Inicio se sesión**
[17-05-2024, 11:36:38] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (84, 1, N'Error al crear el usuario: user1', N'2024-05-16 13:28:35', N'===========
**Error al crear el usuario: user1**
[16-05-2024, 13:28:35] - Creación de log.
Mensaje: Respuesta de la API: {"msg":"Token no válido"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (85, 1, N'Error al crear el usuario: user1', N'2024-05-16 13:29:43', N'===========
**Error al crear el usuario: user1**
[16-05-2024, 13:29:43] - Creación de log.
Mensaje: Respuesta de la API: {"msg":"Token no válido"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (94, 1, N'Inicio se sesión', N'2024-05-16 14:13:43', N'===========
**Inicio se sesión**
[16-05-2024, 14:13:43] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (95, 1, N'Error al crear el usuario: User12', N'2024-05-16 14:14:06', N'===========
**Error al crear el usuario: User12**
[16-05-2024, 14:14:06] - Creación de log.
Mensaje: Respuesta de la API: {"msg":"Token no válido"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (96, 1, N'Error al crear el usuario: User12', N'2024-05-16 14:14:14', N'===========
**Error al crear el usuario: User12**
[16-05-2024, 14:14:14] - Creación de log.
Mensaje: Excepción capturada: Error en el servidor remoto: (401) No autorizado.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (97, 1, N'Error al crear el usuario: User12', N'2024-05-16 14:15:39', N'===========
**Error al crear el usuario: User12**
[16-05-2024, 14:15:39] - Creación de log.
Mensaje: Respuesta de la API: {"msg":"Token no válido"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (140, 1, N'Inicio se sesión', N'2024-05-19 13:18:59', N'===========
**Inicio se sesión**
[19-05-2024, 13:18:59] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (86, 1, N'Inicio se sesión', N'2024-05-16 13:30:17', N'===========
**Inicio se sesión**
[16-05-2024, 13:30:17] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (87, 1, N'Inicio se sesión', N'2024-05-16 13:33:41', N'===========
**Inicio se sesión**
[16-05-2024, 13:33:41] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (88, 1, N'Inicio se sesión', N'2024-05-16 13:36:53', N'===========
**Inicio se sesión**
[16-05-2024, 13:36:53] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (89, 1, N'Error al crear el usuario: user1', N'2024-05-16 13:39:38', N'===========
**Error al crear el usuario: user1**
[16-05-2024, 13:39:38] - Creación de log.
Mensaje: Respuesta de la API: {"msg":"Token no válido"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (90, 1, N'Inicio se sesión', N'2024-05-16 13:51:06', N'===========
**Inicio se sesión**
[16-05-2024, 13:51:06] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (91, 1, N'Error al crear el usuario: user01', N'2024-05-16 13:53:00', N'===========
**Error al crear el usuario: user01**
[16-05-2024, 13:52:59] - Creación de log.
Mensaje: Respuesta de la API: {"msg":"Token no válido"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (98, 1, N'Inicio se sesión', N'2024-05-16 14:19:34', N'===========
**Inicio se sesión**
[16-05-2024, 14:19:34] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (99, 1, N'Error al crear el usuario: u1', N'2024-05-16 14:19:45', N'===========
**Error al crear el usuario: u1**
[16-05-2024, 14:19:45] - Creación de log.
Mensaje: Respuesta de la API: {"msg":"Token no válido"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (100, 1, N'Inicio se sesión', N'2024-05-16 14:26:30', N'===========
**Inicio se sesión**
[16-05-2024, 14:26:30] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (101, 1, N'Error al crear el usuario: u1', N'2024-05-16 14:26:46', N'===========
**Error al crear el usuario: u1**
[16-05-2024, 14:26:46] - Creación de log.
Mensaje: Respuesta de la API: {"msg":"Token no válido"}
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (102, 1, N'Inicio se sesión', N'2024-05-16 14:30:07', N'===========
**Inicio se sesión**
[16-05-2024, 14:30:07] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (104, 1, N'Sesión guardad con exito en el equipo', N'2024-05-16 15:41:59', N'===========
**Sesión guardad con exito en el equipo**
[16-05-2024, 15:41:59] - Creación de log.
Mensaje: Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (105, 1, N'Inicio se sesión', N'2024-05-16 15:42:02', N'===========
**Inicio se sesión**
[16-05-2024, 15:42:02] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (106, 1, N'Inicio se sesión', N'2024-05-16 15:44:42', N'===========
**Inicio se sesión**
[16-05-2024, 15:44:42] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (107, 1, N'Inicio se sesión', N'2024-05-16 15:45:31', N'===========
**Inicio se sesión**
[16-05-2024, 15:45:31] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (108, 1, N'Sesión guardad con exito en el equipo', N'2024-05-16 15:47:02', N'===========
**Sesión guardad con exito en el equipo**
[16-05-2024, 15:47:01] - Creación de log.
Mensaje: Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (109, 1, N'Inicio se sesión', N'2024-05-16 15:47:02', N'===========
**Inicio se sesión**
[16-05-2024, 15:47:02] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (110, 1, N'Sesión guardad con exito en el equipo', N'2024-05-16 16:42:42', N'===========
**Sesión guardad con exito en el equipo**
[16-05-2024, 16:42:42] - Creación de log.
Mensaje: Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (111, 1, N'Inicio se sesión', N'2024-05-16 16:42:42', N'===========
**Inicio se sesión**
[16-05-2024, 16:42:42] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (112, 1, N'Inicio se sesión', N'2024-05-16 16:46:30', N'===========
**Inicio se sesión**
[16-05-2024, 16:46:30] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (170, 6, N'Sesión guardad con exito en el equipo', N'2024-05-20 09:13:49', N'===========
**Sesión guardad con exito en el equipo**
[20-05-2024, 09:13:48] - Creación de log.
Mensaje: Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (171, 6, N'Inicio se sesión', N'2024-05-20 09:13:49', N'===========
**Inicio se sesión**
[20-05-2024, 09:13:49] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (129, 1, N'Inicio se sesión', N'2024-05-19 11:52:25', N'===========
**Inicio se sesión**
[19-05-2024, 11:52:15] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (130, 1, N'Sesión guardad con exito en el equipo', N'2024-05-19 11:53:14', N'===========
**Sesión guardad con exito en el equipo**
[19-05-2024, 11:53:14] - Creación de log.
Mensaje: Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (131, 1, N'Inicio se sesión', N'2024-05-19 11:53:14', N'===========
**Inicio se sesión**
[19-05-2024, 11:53:14] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (143, 1, N'Sesión guardad con exito en el equipo', N'2024-05-19 14:33:28', N'===========
**Sesión guardad con exito en el equipo**
[19-05-2024, 14:33:28] - Creación de log.
Mensaje: Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (144, 1, N'Inicio se sesión', N'2024-05-19 14:33:28', N'===========
**Inicio se sesión**
[19-05-2024, 14:33:28] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (145, 1, N'Sesión guardad con exito en el equipo', N'2024-05-19 14:35:09', N'===========
**Sesión guardad con exito en el equipo**
[19-05-2024, 14:35:09] - Creación de log.
Mensaje: Se almaceno las credenciales en el equipo de forma local, para hacer un logeo facil
Equipo: CARLOS
===========', N'CARLOS')
INSERT [dbo].[tb_reune_log_w] ([id_log], [id_usuario], [titulo], [fecha], [mensaje], [equipo]) VALUES (146, 1, N'Inicio se sesión', N'2024-05-19 14:35:09', N'===========
**Inicio se sesión**
[19-05-2024, 14:35:09] - Creación de log.
Mensaje: Se ingresa al sistema por medio de la app.
Equipo: CARLOS
===========', N'CARLOS')
GO
INSERT [dbo].[tb_reune_tipoUsuario_c] ([id_tipo], [nombre]) VALUES (1, N'Super Usuario')
INSERT [dbo].[tb_reune_tipoUsuario_c] ([id_tipo], [nombre]) VALUES (2, N'Usuario Normal')
GO
INSERT [dbo].[tb_reune_usuarios_w] ([id_usuario], [userid_api], [username_api], [password_api], [institucionid_api], [is_active_api], [profileid_api], [date_api], [system_api], [nombre], [password], [token], [id_tipoUser], [fecha]) VALUES (1, N'eca15159-1416-43b2-a517-b9ca6b1903a2', N'CarlosBarreraLugo', N'974', N'CDDB6C43-A957-4E3B-A43C-3A90C3C9', N'70', N'Sociedades Operadoras de Fondos de Inversión', N'1715791356|1718383356', N'REUNE', N'CarlosBarreraLugo', N'K10sm4rt', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiJlY2ExNTE1OS0xNDE2LTQzYjItYTUxNy1iOWNhNmIxOTAzYTIiLCJ1c2VybmFtZSI6IkNhcmxvc0JhcnJlcmFMdWdvIiwiaW5zdGl0dWNpb25pZCI6IkNEREI2QzQzLUE5NTctNEUzQi1BNDNDLTNBOTBDM0M5IiwiaW5zdGl0dWNpb25DbGF2ZSI6OTc0LCJkZW5vbWluYWNpb25fc29jaWFsIjoiU2FtIEFzc2V0IE1hbmFnZW1lbnQsIFMuQS4gZGUgQy5WLiwgU29jaWVkYWQgT3BlcmFkb3JhIGRlIEZvbmRvcyBkZSBJbnZlcnNpw7NuIiwic2VjdG9yaWQiOjcwLCJzZWN0b3IiOiJTb2NpZWRhZGVzIE9wZXJhZG9yYXMgZGUgRm9uZG9zIGRlIEludmVyc2nDs24iLCJzeXN0ZW0iOiJSRVVORSIsImlhdCI6MTcxNTc5MTM1NiwiZXhwIjoxNzE4MzgzMzU2fQ.Sn6q_IMxAH4-WSo26NCvDhMewQAYMMn3SF4Cc1rl4KE', 1, CAST(N'2024-09-05T14:33:59.000' AS DateTime))
INSERT [dbo].[tb_reune_usuarios_w] ([id_usuario], [userid_api], [username_api], [password_api], [institucionid_api], [is_active_api], [profileid_api], [date_api], [system_api], [nombre], [password], [token], [id_tipoUser], [fecha]) VALUES (2, N'3462bdcd-23a9-4851-9237-3ffbf542f96d', N'veronica.leon@santanderam.com', N'$2a$10$B7buKPi7fRllug8BJr/Q1eRZbl1mlC9PTD.z.RPHAQJboHP18pCwK', N'CDDB6C43-A957-4E3B-A43C-3A90C3C9', N'true', N'1', N'2024-05-15T06:00:00.000Z', N'8b2d9355-84de-470f-99b4-69dd3b39a03e', N'veronica.leon@santanderam.com', N'K10sm4rt', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiIzNDYyYmRjZC0yM2E5LTQ4NTEtOTIzNy0zZmZiZjU0MmY5NmQiLCJ1c2VybmFtZSI6InZlcm9uaWNhLmxlb25Ac2FudGFuZGVyYW0uY29tIiwiaW5zdGl0dWNpb25pZCI6IkNEREI2QzQzLUE5NTctNEUzQi1BNDNDLTNBOTBDM0M5IiwiaW5zdGl0dWNpb25DbGF2ZSI6OTc0LCJkZW5vbWluYWNpb25fc29jaWFsIjoiU2FtIEFzc2V0IE1hbmFnZW1lbnQsIFMuQS4gZGUgQy5WLiwgU29jaWVkYWQgT3BlcmFkb3JhIGRlIEZvbmRvcyBkZSBJbnZlcnNpw7NuIiwic2VjdG9yaWQiOjcwLCJzZWN0b3IiOiJTb2NpZWRhZGVzIE9wZXJhZG9yYXMgZGUgRm9uZG9zIGRlIEludmVyc2nDs24iLCJzeXN0ZW0iOiJSRVVORSIsImlhdCI6MTcxNTc5MTgxMywiZXhwIjoxNzE4MzgzODEzfQ.5nmKbVTTnUwhT5CfUd9dzIlabW97SrTSElNwcAavcqc', 2, CAST(N'2024-05-16T12:19:00.000' AS DateTime))
INSERT [dbo].[tb_reune_usuarios_w] ([id_usuario], [userid_api], [username_api], [password_api], [institucionid_api], [is_active_api], [profileid_api], [date_api], [system_api], [nombre], [password], [token], [id_tipoUser], [fecha]) VALUES (3, N'c788dfff-3ca4-469f-9730-037776d9b2a6', N'kathia.solis@santanderam.com', N'$2a$10$DebEsdOeV/wHid7xBwiGAua0L8dwfwVxOJ4.Ofqb0CTT88vXN0C7a', N'CDDB6C43-A957-4E3B-A43C-3A90C3C9', N'true', N'1', N'2024-05-16T06:00:00.000Z', N'8b2d9355-84de-470f-99b4-69dd3b39a03e', N'kathia.solis@santanderam.com', N'Pkq3ty', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiJjNzg4ZGZmZi0zY2E0LTQ2OWYtOTczMC0wMzc3NzZkOWIyYTYiLCJ1c2VybmFtZSI6ImthdGhpYS5zb2xpc0BzYW50YW5kZXJhbS5jb20iLCJpbnN0aXR1Y2lvbmlkIjoiQ0REQjZDNDMtQTk1Ny00RTNCLUE0M0MtM0E5MEMzQzkiLCJpbnN0aXR1Y2lvbkNsYXZlIjo5NzQsImRlbm9taW5hY2lvbl9zb2NpYWwiOiJTYW0gQXNzZXQgTWFuYWdlbWVudCwgUy5BLiBkZSBDLlYuLCBTb2NpZWRhZCBPcGVyYWRvcmEgZGUgRm9uZG9zIGRlIEludmVyc2nDs24iLCJzZWN0b3JpZCI6NzAsInNlY3RvciI6IlNvY2llZGFkZXMgT3BlcmFkb3JhcyBkZSBGb25kb3MgZGUgSW52ZXJzacOzbiIsInN5c3RlbSI6IlJFVU5FIiwiaWF0IjoxNzE1ODYwNzQwLCJleHAiOjE3MTg0NTI3NDB9.MubfkJSlUp94e_brMlo5vlqTFmLPtqvVruGi9I5fnbA', 2, CAST(N'2024-05-16T12:19:00.000' AS DateTime))
INSERT [dbo].[tb_reune_usuarios_w] ([id_usuario], [userid_api], [username_api], [password_api], [institucionid_api], [is_active_api], [profileid_api], [date_api], [system_api], [nombre], [password], [token], [id_tipoUser], [fecha]) VALUES (4, N'fa5f77af-4e6f-46ce-bd66-06b2ffeaad91', N'luzma.telles@santanderam.com', N'$2a$10$dH9ibM006fMd/aX8WAy3IeHRM/PSfU62l0uC1L37QVaOIhIRfUuAG', N'CDDB6C43-A957-4E3B-A43C-3A90C3C9', N'true', N'1', N'2024-05-16T06:00:00.000Z', N'8b2d9355-84de-470f-99b4-69dd3b39a03e', N'luzma.telles@santanderam.com', N'S10ktr4', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiJmYTVmNzdhZi00ZTZmLTQ2Y2UtYmQ2Ni0wNmIyZmZlYWFkOTEiLCJ1c2VybmFtZSI6Imx1em1hLnRlbGxlc0BzYW50YW5kZXJhbS5jb20iLCJpbnN0aXR1Y2lvbmlkIjoiQ0REQjZDNDMtQTk1Ny00RTNCLUE0M0MtM0E5MEMzQzkiLCJpbnN0aXR1Y2lvbkNsYXZlIjo5NzQsImRlbm9taW5hY2lvbl9zb2NpYWwiOiJTYW0gQXNzZXQgTWFuYWdlbWVudCwgUy5BLiBkZSBDLlYuLCBTb2NpZWRhZCBPcGVyYWRvcmEgZGUgRm9uZG9zIGRlIEludmVyc2nDs24iLCJzZWN0b3JpZCI6NzAsInNlY3RvciI6IlNvY2llZGFkZXMgT3BlcmFkb3JhcyBkZSBGb25kb3MgZGUgSW52ZXJzacOzbiIsInN5c3RlbSI6IlJFVU5FIiwiaWF0IjoxNzE1ODYwNTk0LCJleHAiOjE3MTg0NTI1OTR9.x5IvT-wl8SXYyzCAXOBXKFUqC7xqOJYQ1Co0mBP9oP8', 2, CAST(N'2024-05-16T12:20:00.000' AS DateTime))
INSERT [dbo].[tb_reune_usuarios_w] ([id_usuario], [userid_api], [username_api], [password_api], [institucionid_api], [is_active_api], [profileid_api], [date_api], [system_api], [nombre], [password], [token], [id_tipoUser], [fecha]) VALUES (5, N'f0042729-fa90-4f8c-a871-2ecdd446a9e4', N'marina.josa@santanderam.com', N'$2a$10$gd1Y3SfyA2VYb42uqKgS7uisnWMvHBEDdvzc7m9B2Boluvlowu.k6', N'CDDB6C43-A957-4E3B-A43C-3A90C3C9', N'true', N'1', N'2024-05-16T06:00:00.000Z', N'8b2d9355-84de-470f-99b4-69dd3b39a03e', N'marina.josa@santanderam.com', N'JkHv43', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiJmMDA0MjcyOS1mYTkwLTRmOGMtYTg3MS0yZWNkZDQ0NmE5ZTQiLCJ1c2VybmFtZSI6Im1hcmluYS5qb3NhQHNhbnRhbmRlcmFtLmNvbSIsImluc3RpdHVjaW9uaWQiOiJDRERCNkM0My1BOTU3LTRFM0ItQTQzQy0zQTkwQzNDOSIsImluc3RpdHVjaW9uQ2xhdmUiOjk3NCwiZGVub21pbmFjaW9uX3NvY2lhbCI6IlNhbSBBc3NldCBNYW5hZ2VtZW50LCBTLkEuIGRlIEMuVi4sIFNvY2llZGFkIE9wZXJhZG9yYSBkZSBGb25kb3MgZGUgSW52ZXJzacOzbiIsInNlY3RvcmlkIjo3MCwic2VjdG9yIjoiU29jaWVkYWRlcyBPcGVyYWRvcmFzIGRlIEZvbmRvcyBkZSBJbnZlcnNpw7NuIiwic3lzdGVtIjoiUkVVTkUiLCJpYXQiOjE3MTU4NjA4NTUsImV4cCI6MTcxODQ1Mjg1NX0.FyhhB-HzTm2iA9-3m58_8FlqvG80J0baALS6mkdbjKo', 2, CAST(N'2024-05-16T12:20:00.000' AS DateTime))
INSERT [dbo].[tb_reune_usuarios_w] ([id_usuario], [userid_api], [username_api], [password_api], [institucionid_api], [is_active_api], [profileid_api], [date_api], [system_api], [nombre], [password], [token], [id_tipoUser], [fecha]) VALUES (6, N'd901b0db-3a95-4464-9ae1-62012e3dc24a', N'cbarrera@gmail.com', N'$2a$10$ldoZGF5wiYA2w0tNfz1qYeHz2sgfus6W9ft.ADUGwCN.qdc2O4uGi', N'CDDB6C43-A957-4E3B-A43C-3A90C3C9', N'True', N'1', N'2024-05-17T06:00:00.000Z', N'8b2d9355-84de-470f-99b4-69dd3b39a03e', N'cbarrera@gmail.com', N'qwe123', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiJkOTAxYjBkYi0zYTk1LTQ0NjQtOWFlMS02MjAxMmUzZGMyNGEiLCJ1c2VybmFtZSI6ImNiYXJyZXJhQGdtYWlsLmNvbSIsImluc3RpdHVjaW9uaWQiOiJDRERCNkM0My1BOTU3LTRFM0ItQTQzQy0zQTkwQzNDOSIsImluc3RpdHVjaW9uQ2xhdmUiOjk3NCwiZGVub21pbmFjaW9uX3NvY2lhbCI6IlNhbSBBc3NldCBNYW5hZ2VtZW50LCBTLkEuIGRlIEMuVi4sIFNvY2llZGFkIE9wZXJhZG9yYSBkZSBGb25kb3MgZGUgSW52ZXJzacOzbiIsInNlY3RvcmlkIjo3MCwic2VjdG9yIjoiU29jaWVkYWRlcyBPcGVyYWRvcmFzIGRlIEZvbmRvcyBkZSBJbnZlcnNpw7NuIiwic3lzdGVtIjoiUkVVTkUiLCJpYXQiOjE3MTU5ODY2OTksImV4cCI6MTcxODU3ODY5OX0.vwbApYHNzxC-KKMrKOgRJe-z16zQ_uvIrYzLC5R2Isk', 2, CAST(N'2024-05-17T16:58:23.227' AS DateTime))
INSERT [dbo].[tb_reune_usuarios_w] ([id_usuario], [userid_api], [username_api], [password_api], [institucionid_api], [is_active_api], [profileid_api], [date_api], [system_api], [nombre], [password], [token], [id_tipoUser], [fecha]) VALUES (7, N'a43dcbad-bef7-4bf3-bf54-73dc6fdaf91b', N'carlos', N'$2a$10$jIYdb5B7nhx6KBwyqDJNr.sCrCnjRZBgauJhrvMrmB4X7QzPec0yu', N'CDDB6C43-A957-4E3B-A43C-3A90C3C9', N'True', N'1', N'2024-05-19T06:00:00.000Z', N'8b2d9355-84de-470f-99b4-69dd3b39a03e', N'carlos', N'123', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiJhNDNkY2JhZC1iZWY3LTRiZjMtYmY1NC03M2RjNmZkYWY5MWIiLCJ1c2VybmFtZSI6ImNhcmxvcyIsImluc3RpdHVjaW9uaWQiOiJDRERCNkM0My1BOTU3LTRFM0ItQTQzQy0zQTkwQzNDOSIsImluc3RpdHVjaW9uQ2xhdmUiOjk3NCwiZGVub21pbmFjaW9uX3NvY2lhbCI6IlNhbSBBc3NldCBNYW5hZ2VtZW50LCBTLkEuIGRlIEMuVi4sIFNvY2llZGFkIE9wZXJhZG9yYSBkZSBGb25kb3MgZGUgSW52ZXJzacOzbiIsInNlY3RvcmlkIjo3MCwic2VjdG9yIjoiU29jaWVkYWRlcyBPcGVyYWRvcmFzIGRlIEZvbmRvcyBkZSBJbnZlcnNpw7NuIiwic3lzdGVtIjoiUkVVTkUiLCJpYXQiOjE3MTYxNjQwMjMsImV4cCI6MTcxODc1NjAyM30.F0h64wQ6UrPzmRa4I3IEKUiKrvrsk3CJprhhGDqeVfI', 2, CAST(N'2024-05-19T18:14:33.623' AS DateTime))
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] ADD  DEFAULT ((1)) FOR [valida_login]
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] ADD  DEFAULT ((0)) FOR [escribir_log]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_crear_obtener_editar_usuario]    Script Date: 20/05/2024 10:12:12 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[sp_reune_crear_obtener_log]    Script Date: 20/05/2024 10:12:12 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_sesion]    Script Date: 20/05/2024 10:12:12 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_update_configuracion]    Script Date: 20/05/2024 10:12:12 a. m. ******/
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
