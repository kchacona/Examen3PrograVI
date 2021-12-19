using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PedidosEntity
    {
        public PedidosEntity()
        {
            Clientes = Clientes ?? new ClientesEntity();
            Productos = Productos ?? new ProductosEntity();
        }
        public int? Codigo { get; set; }
        public int Cliente { get; set; }
        public DateTime fechaPedido { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
        public float Subtotal { get; set; }
        public float Envio { get; set; }
        public float Impuestos { get; set; }
        public float Total { get; set; }
        public virtual ClientesEntity Clientes { get; set; }
        public virtual ProductosEntity Productos { get; set; }

    }
}
