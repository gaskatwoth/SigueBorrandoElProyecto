using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace proyectofinal
{
   public  class CuentaProveedor
    {
        

        [Key]public int IdCuenta { get; set; }
        public string Usuario { get; set; }
        public string contrasena { get; set; }
 
    }
}
