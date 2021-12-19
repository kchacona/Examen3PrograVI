using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductosEntity
    {
        public int? Id_Productos { get; set; }
        public string Categoria { get; set; }
        public string Nombre { get; set; }
        public string Cantidad_Disponible { get; set; }
        public string Caracteristica { get; set; }
        public bool Estado { get; set; }
    }
}
