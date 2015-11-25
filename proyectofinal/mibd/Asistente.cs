using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace proyectofinal
{
    public class Asistente
    {
   
    [Key] public int IdAsistente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

       public virtual ICollection<Factura> Facturas { get; set; }


    }

}
