CREATE PROCEDURE [dbo].[ProductosActualizar]
    @Id_Productos int
	,@Categoria varchar(250)
	,@Nombre varchar(250)
	,@Cantidad_Disponible int
	,@Caracteristica  varchar(250)
	,@Estado bit


AS BEGIN
SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

    BEGIN TRY
	
	UPDATE dbo.Productos SET
	Categoria = @Categoria 
	,Nombre = @Nombre
	,Cantidad_Disponible =@Cantidad_Disponible
	,Caracteristica =@Caracteristica
	,Estado =@Estado
	WHERE 
	       Id_Productos =@Id_Productos 
	
	  COMMIT TRANSACTION TRASA
	  SELECT 0 AS CodeError, '' AS MsgError

  END TRY

  BEGIN CATCH

	   SELECT 
			 ERROR_NUMBER() AS CodeError,
			 ERROR_MESSAGE() AS MsgError
   
	   ROLLBACK TRANSACTION TRASA

   END CATCH

 END