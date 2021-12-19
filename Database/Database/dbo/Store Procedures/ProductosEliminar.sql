CREATE PROCEDURE [dbo].[ProductosEliminar]
 @Id_Productos int

AS BEGIN
SET NOCOUNT ON
declare @producto int;
  BEGIN TRANSACTION TRASA
  BEGIN TRY

	Select @producto = producto From dbo.Pedidos where producto = @Id_Productos;
    Select @producto;
	if @Producto <> 0 
	begin
		SELECT 1 AS CodeError, 'El cliente no se puede eliminar ya que posee pedidos' AS MsgError
	end 
	else
	begin 
			
            DELETE FROM dbo.Productos WHERE Id_Productos=@Id_Productos
	
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