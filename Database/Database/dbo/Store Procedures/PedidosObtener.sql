CREATE PROCEDURE [dbo].[ProductosObtener]
      @Codigo int= NULL
AS BEGIN
  SET NOCOUNT ON

  SELECT 
     P.Cliente
	,P.fechaPedido
	,P.Producto 
	,P.Cantidad
	,P.Subtotal
	,P.Envio
	,P.Impuestos 
	,P.Total
    FROM dbo.Pedido P
    WHERE
    (@Id_Productos IS NULL OR Id_Productos=@Id_Productos)

END