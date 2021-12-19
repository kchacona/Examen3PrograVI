CREATE PROCEDURE [dbo].[PedidosEliminar]
 @Codigo int

AS BEGIN
SET NOCOUNT ON
declare @anterior int;
declare @disponible int;
declare @producto int;
  BEGIN TRANSACTION TRASA
  BEGIN TRY

	Select @anterior = cantidad From dbo.Pedidos where Codigo = @Codigo;
	Select @producto = producto From dbo.Pedidos where Codigo = @Codigo;
	select @disponible = Cantidad_Disponible From dbo.Productos where Id_Productos = @Producto;
	select @disponible = @disponible + @anterior;
    DELETE FROM dbo.Pedidos WHERE Codigo=@Codigo
	UPDATE dbo.Productos SET
		Cantidad_Disponible =@disponible
		WHERE 
			   Id_Productos =@Producto
	
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