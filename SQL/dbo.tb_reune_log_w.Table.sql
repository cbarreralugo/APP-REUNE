USE [api_reune]
GO
/****** Object:  Table [dbo].[tb_reune_log_w]    Script Date: 20/05/2024 10:02:12 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_reune_log_w]') AND type in (N'U'))
DROP TABLE [dbo].[tb_reune_log_w]
GO
/****** Object:  Table [dbo].[tb_reune_log_w]    Script Date: 20/05/2024 10:02:12 a. m. ******/
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
