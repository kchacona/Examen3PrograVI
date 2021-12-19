CREATE PROCEDURE [dbo].[PedidosInsertar]
	 @Cliente int 
	,@fechaPedido datetime
	,@Producto int 
	,@Cantidad int
	,@Subtotal float 
	,@Envio float
	,@Impuestos float 
	,@Total float 

AS BEGIN
SET NOCOUNT ON
Declare @disponible int
  BEGIN TRANSACTION TRASA

    BEGIN TRY
	Select @disponible = Cantidad_Disponible From dbo.Productos where Id_Productos = @Producto;
    Select @disponible;
	if @disponible > @Cantidad
	begin
		SELECT 1 AS CodeError, 'No hay producto disponible para el pedido!!' AS MsgError
	end 
	else
	begin
	INSERT INTO dbo.Pedidos
	(
	Cliente
	,fechaPedido
	,Producto
	,Cantidad
	,Subtotal 
	,Envio
	,Impuestos
	,Total
	)
	VALUES
	(
	@Cliente
	,@fechaPedido
	,@Producto
	,@Cantidad
	,@Subtotal 
	,@Envio
	,@Impuestos
	,@Total
	)

	select @disponible = @disponible - @Cantidad;
	UPDATE dbo.Productos SET
	Cantidad_Disponible =@disponible
	WHERE 
	       Id_Productos =@Producto
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



