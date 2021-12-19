CREATE TABLE dbo.Pedidos
(
Codigo INT NOT NULL IDENTITY(1,1) CONSTRAINT
PK_Pedidos PRIMARY KEY CLUSTERED(Codigo)
,Cliente int NOT NULL CONSTRAINT FK_Cliente FOREIGN KEY (Cliente)
REFERENCES Clientes(Cedula)
,fechaPedido datetime NOT NULL
,Producto int NOT NULL CONSTRAINT FK_Producto FOREIGN KEY (Producto)
REFERENCES Productos(Id_Productos)
,Cantidad int NOT NULL
,Subtotal float NOT NULL
,Envio float NOT NULL
,Impuestos float NOT NUll
,Total float NOT NULL
)
WITH (DATA_COMPRESSION = PAGE)
GO

