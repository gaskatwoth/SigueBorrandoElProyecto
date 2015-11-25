namespace proyectofinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProveedorTabla : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asistentes",
                c => new
                    {
                        IdAsistente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.IdAsistente);
            
            CreateTable(
                "dbo.CuentaProveedors",
                c => new
                    {
                        IdCuenta = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        contrasena = c.String(),
                    })
                .PrimaryKey(t => t.IdCuenta);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        IdFactura = c.Int(nullable: false, identity: true),
                        ProveedorIdProveedor = c.Int(nullable: false),
                        AsistenteIdAsistente = c.Int(nullable: false),
                        ServicioIdServicio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFactura);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        IdProveedor = c.Int(nullable: false, identity: true),
                        NombreProveedor = c.String(),
                        Direccion = c.String(),
                        Giro = c.String(),
                    })
                .PrimaryKey(t => t.IdProveedor);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        IdServicio = c.Int(nullable: false, identity: true),
                        ProveedorIdProveedor = c.Int(nullable: false),
                        NombreServicio = c.String(),
                        Precio = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdServicio)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorIdProveedor, cascadeDelete: true)
                .Index(t => t.ProveedorIdProveedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors");
            DropIndex("dbo.Servicios", new[] { "ProveedorIdProveedor" });
            DropTable("dbo.Servicios");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Facturas");
            DropTable("dbo.CuentaProveedors");
            DropTable("dbo.Asistentes");
        }
    }
}
