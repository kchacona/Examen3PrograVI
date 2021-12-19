CREATE PROCEDURE [dbo].[ClientesActualizar]
    @Cedula int
	,@Nombre VARCHAR(250) 
	,@Apellidos VARCHAR(250) 
	,@Dirreccion VARCHAR(250)
	,@FechaNacimientos Datetime 
	,@Telefono Int


AS BEGIN
SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

    BEGIN TRY
	
	UPDATE dbo.Clientes SET
	Nombre = @Nombre
	,Apellidos = @Apellidos
	,Dirreccion  = @Dirreccion
	,FechaNacimientos  = @FechaNacimientos
	,Telefono  = @Telefono 
	WHERE 
	       Cedula=@Cedula
	
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