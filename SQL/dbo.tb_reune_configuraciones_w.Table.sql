USE [api_reune]
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] DROP CONSTRAINT [DF__tb_reune___escri__3B75D760]
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] DROP CONSTRAINT [DF__tb_reune___valid__3A81B327]
GO
/****** Object:  Table [dbo].[tb_reune_configuraciones_w]    Script Date: 20/05/2024 10:02:12 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_reune_configuraciones_w]') AND type in (N'U'))
DROP TABLE [dbo].[tb_reune_configuraciones_w]
GO
/****** Object:  Table [dbo].[tb_reune_configuraciones_w]    Script Date: 20/05/2024 10:02:12 a. m. ******/
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
INSERT [dbo].[tb_reune_configuraciones_w] ([id_configuracion], [valida_login], [escribir_log], [ruta_log], [api_reune]) VALUES (1, 0, 2, N'C:\Log_Reune', N'https://api-reune-pruebas.condusef.gob.mx/')
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] ADD  DEFAULT ((1)) FOR [valida_login]
GO
ALTER TABLE [dbo].[tb_reune_configuraciones_w] ADD  DEFAULT ((0)) FOR [escribir_log]
GO
