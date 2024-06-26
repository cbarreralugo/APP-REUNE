USE [api_reune]
GO
/****** Object:  Table [dbo].[tb_reune_ConfiguracionSistema_w]    Script Date: 20/05/2024 10:02:12 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tb_reune_ConfiguracionSistema_w]') AND type in (N'U'))
DROP TABLE [dbo].[tb_reune_ConfiguracionSistema_w]
GO
/****** Object:  Table [dbo].[tb_reune_ConfiguracionSistema_w]    Script Date: 20/05/2024 10:02:12 a. m. ******/
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
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (1, N'valida_login_api', N'a0erM2Z2Sccz+WfUb4k3UQ==', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (2, N'escribir_log', N'9yyoVaRSUSgaTR03GadA3A==', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (3, N'ruta_log', N'VKCWcHor6/Mtbg+TX8zrfHUG4K2EOzqFnaETSRdvMVE=', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (4, N'ruta_sesion_temporal', N'VKCWcHor6/Mtbg+TX8zrfBxSjEkADqiXutBGuX72PG30qWw3wGE83x+f1aeLEU9G', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (5, N'api_reune', N'0FM9qtQJNDmJN7TYidKFC7WG/3ckNTTFos4DCuqBhoIYmmVNhpCVYzrBoXC7kukz', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (6, N'key', N'SAM', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (7, N'mostrar_alertas', N'EkI4cVaDTsTuYPZl+dXNPQ==', 1)
INSERT [dbo].[tb_reune_ConfiguracionSistema_w] ([id_conf], [configuracion], [valor], [estatus]) VALUES (8, N'auto_regenerar_token_user', N'EkI4cVaDTsTuYPZl+dXNPQ==', 1)
GO
