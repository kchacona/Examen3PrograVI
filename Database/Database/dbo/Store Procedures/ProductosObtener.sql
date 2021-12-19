CREATE PROCEDURE [dbo].[ProductosObtener]
      @Id_Productos int= NULL
AS BEGIN
  SET NOCOUNT ON

  SELECT 
     P.Categoria,
     P.Nombre,
     P.Cantidad_Disponible,
     P.Caracteristica,
     P.Estado

     
    FROM dbo.Productos P
    WHERE
    (@Id_Productos IS NULL OR Id_Productos=@Id_Productos)

END