USE [api_reune]
GO
/****** Object:  Table [dbo].[tb_reune_tipoUsuario_c]    Script Date: 20/05/2024 10:02:12 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_reune_tipoUsuario_c]') AND type in (N'U'))
DROP TABLE [dbo].[tb_reune_tipoUsuario_c]
GO
/****** Object:  Table [dbo].[tb_reune_tipoUsuario_c]    Script Date: 20/05/2024 10:02:12 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_reune_tipoUsuario_c](
	[id_tipo] [int] NOT NULL,
	[nombre] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[tb_reune_tipoUsuario_c] ([id_tipo], [nombre]) VALUES (1, N'Super Usuario')
INSERT [dbo].[tb_reune_tipoUsuario_c] ([id_tipo], [nombre]) VALUES (2, N'Usuario Normal')
GO
