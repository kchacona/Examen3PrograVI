CREATE PROCEDURE [dbo].[ClientesEliminar]
 @Cedula int

AS BEGIN
SET NOCOUNT ON
declare @cliente int;
  BEGIN TRANSACTION TRASA
  BEGIN TRY

	Select @cliente = Cliente From dbo.Pedidos where Cliente = @Cedula;
    Select @cliente;
	if @cliente <> 0 
	begin
		SELECT 1 AS CodeError, 'El cliente no se puede eliminar ya que posee pedidos' AS MsgError
	end 
	else
	begin 
			
            DELETE FROM dbo.Clientes WHERE Cedula=@Cedula
	
	  COMMIT TRANSACTION TRASA
	  SELECT 0 AS CodeError, '' AS MsgError

	end

  END TRY

  BEGIN CATCH

	   SELECT 
			 ERROR_NUMBER() AS CodeError,
			 ERROR_MESSAGE() AS MsgError
   
	   ROLLBACK TRANSACTION TRASA

   END CATCH

 END