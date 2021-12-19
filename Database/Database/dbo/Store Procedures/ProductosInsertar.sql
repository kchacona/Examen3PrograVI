Create PROCEDURE [dbo].[ProductosInsertar]
	@Categoria varchar(250)
	,@Nombre varchar(250)
	,@Cantidad_Disponible int
	,@Caracteristica  varchar(250)
	,@Estado bit

AS BEGIN
SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

    BEGIN TRY
	
	INSERT INTO dbo.Productos
	(
	Categoria
	,Nombre
	,Cantidad_Disponible
	,Caracteristica
	,Estado
	)
	VALUES
	(
	@Caracteristica
	,@Nombre
	,@Cantidad_Disponible
	,@Caracteristica
	,@Estado
	)

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



