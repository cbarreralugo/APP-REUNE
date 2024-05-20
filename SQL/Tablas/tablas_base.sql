USE [api_reune]
GO
/****** Object:  Table [dbo].[tb_reune_configuraciones_w]    Script Date: 09/05/2024 02:48:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_reune_configuraciones_w](
	[id_configuracion] [int] NOT NULL,
	[valida_login] [int] NOT NULL,
	[escribir_log] [int] NOT NULL,
	[ruta_log] [varchar](200) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_reune_log_w]    Script Date: 09/05/2024 02:48:10 p. m. ******/
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
/****** Object:  Table [dbo].[tb_reune_tipoUsuario_c]    Script Date: 09/05/2024 02:48:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_reune_tipoUsuario_c](
	[id_tipo] [int] NOT NULL,
	[nombre] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_reune_usuarios_w]    Script Date: 09/05/2024 02:48:10 p. m. ******/
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
INSERT [dbo].[tb_reune_configuraciones_w] ([id_configuracion], [valida_login], [escribir_log], [ruta_log]) VALUES (1, 0, 2, N'C:\Log_Reune')
GO
INSERT [dbo].[tb_reune_tipoUsuario_c] ([id_tipo], [nombre]) VALUES (1, N'Super Usuario')
INSERT [dbo].[tb_reune_tipoUsuario_c] ([id_tipo], [nombre]) VALUES (2, N'Usuario Normal')
GO
INSERT [dbo].[tb_reune_usuarios_w] ([id_usuario], [nombre], [password], [token], [id_tipoUser], [fecha]) VALUES (1, N'CarlosBarreraLugo', N'K10sm4rt', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiJlY2ExNTE1OS0xNDE2LTQzYjItYTUxNy1iOWNhNmIxOTAzYTIiLCJ1c2VybmFtZSI6IkNhcmxvc0JhcnJlcmFMdWdvIiwiaW5zdGl0dWNpb25pZCI6IkNEREI2QzQzLUE5NTctNEUzQi1BNDNDLTNBOTBDM0M5IiwiaW5zdGl0dWNpb25DbGF2ZSI6OTc0LCJkZW5vbWluYWNpb25fc29jaWFsIjoiU2FtIEFzc2V0IE1hbmFnZW1lbnQsIFMuQS4gZGUgQy5WLiwgU29jaWVkYWQgT3BlcmFkb3JhIGRlIEZvbmRvcyBkZSBJbnZlcnNpw7NuIiwic2VjdG9yaWQiOjcwLCJzZWN0b3IiOiJTb2NpZWRhZGVzIE9wZXJhZG9yYXMgZGUgRm9uZG9zIGRlIEludmVyc2nDs24iLCJzeXN0ZW0iOiJSRVVORSIsImlhdCI6MTcxNTI3NjU1MCwiZXhwIjoxNzE3ODY4NTUwfQ.DdQocg0XGumvEI5qJ7e3esLJ5_H7r8sgoxel-wJ304o', 1, CAST(N'2024-09-05T14:33:59.000' AS DateTime))
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] ADD  DEFAULT ((1)) FOR [valida_login]
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] ADD  DEFAULT ((0)) FOR [escribir_log]
GO
