CREATE PROCEDURE [dbo].[PedidosActualizar]
    @Codigo int
	,@Cliente int 
	,@fechaPedido datetime
	,@Producto int 
	,@Cantidad int
	,@Subtotal float 
	,@Envio float
	,@Impuestos float 
	,@Total float 


AS BEGIN
SET NOCOUNT ON
declare @anterior int
declare @disponible int
  BEGIN TRANSACTION TRASA

    BEGIN TRY
	select @anterior = cantidad from dbo.Pedidos where Codigo = @Codigo;
	select @disponible = Cantidad_Disponible From dbo.Productos where Id_Productos = @Producto;
	select @disponible = @disponible + @anterior;
	if @disponible > @Cantidad
	begin
		SELECT 1 AS CodeError, 'No hay producto disponible para el pedido!!' AS MsgError
	end 
	else
	begin

	UPDATE dbo.Pedidos SET
	Cliente=@Cliente
	,fechaPedido=@fechaPedido
	,Producto=@Producto
	,Cantidad=@Cantidad
	,Subtotal=@Subtotal
	,Envio=@Envio
	,Impuestos=@Impuestos
	,Total=@Total
	WHERE 
	       Codigo =@Codigo
	
	  COMMIT TRANSACTION TRASA
	  SELECT 0 AS CodeError, '' AS MsgError

	  select @disponible = @disponible - @Cantidad;
		UPDATE dbo.Productos SET
		Cantidad_Disponible =@disponible
		WHERE 
			   Id_Productos =@Producto

	  end
  END TRY

  BEGIN CATCH

	   SELECT 
			 ERROR_NUMBER() AS CodeError,
			 ERROR_MESSAGE() AS MsgError
   
	   ROLLBACK TRANSACTION TRASA

   END CATCH

 END