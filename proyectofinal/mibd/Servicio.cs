using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace proyectofinal
{
    public class Servicio
    {
      
        [Key]public int IdServicio { get; set; }
        public virtual int ProveedorIdProveedor { get; set; }
        public string NombreServicio { get; set; }
        public int Precio { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
