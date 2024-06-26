USE [api_reune]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_sesion]    Script Date: 20/05/2024 10:02:12 a. m. ******/
DROP PROCEDURE [dbo].[sp_reune_obtener_sesion]
GO
/****** Object:  StoredProcedure [dbo].[sp_reune_obtener_sesion]    Script Date: 20/05/2024 10:02:12 a. m. ******/
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
