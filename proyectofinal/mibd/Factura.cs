using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace proyectofinal
{
  public  class Factura
    {

        [Key] public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public virtual int AsistenteIdAsistente { get; set; }
        public virtual int ServicioIdServicio { get; set; }

    }
}
