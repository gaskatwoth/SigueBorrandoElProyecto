using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofinal.mibd
{
    public class index : DbContext
    {
        public DbSet<classejemplo> classejemplos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Asistente> Asistentes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<CuentaProveedor> CuentaProverdores { get; set; }

        

    }
}
