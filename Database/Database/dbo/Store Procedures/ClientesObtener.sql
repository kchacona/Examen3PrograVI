CREATE PROCEDURE [dbo].[ClientesObtener]
      @Cedula int= NULL
AS BEGIN
  SET NOCOUNT ON

  SELECT 
     C.Cedula,
     C.Nombre,
     C.Apellidos,
     C.Dirreccion,
     C.FechaNacimientos,
     C.Telefono
     
    FROM dbo.Clientes C
    WHERE
    (@Cedula IS NULL OR Cedula=@Cedula)

END