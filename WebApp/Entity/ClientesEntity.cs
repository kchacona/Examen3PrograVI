using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    
    public class ClientesEntity
    {
        public int? Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dirreccion { get; set; }
        public DateTime FechaNacimientos { get; set; }
        public int Telefono{ get; set; }
    }
}
