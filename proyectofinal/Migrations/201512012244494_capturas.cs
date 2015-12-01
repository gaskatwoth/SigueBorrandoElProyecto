namespace proyectofinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capturas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "Proveedor_IdProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Facturas", "ServicioIdServicio", "dbo.Servicios");
            DropIndex("dbo.Facturas", new[] { "ServicioIdServicio" });
            DropIndex("dbo.Facturas", new[] { "Proveedor_IdProveedor" });
            RenameColumn(table: "dbo.Facturas", name: "Proveedor_IdProveedor", newName: "ProveedorIdProveedor");
            AddColumn("dbo.Facturas", "Servicio_IdServicio", c => c.Int());
            AddColumn("dbo.Facturas", "Servicio_IdServicio1", c => c.Int());
            AlterColumn("dbo.Facturas", "ProveedorIdProveedor", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "ProveedorIdProveedor");
            CreateIndex("dbo.Facturas", "Servicio_IdServicio");
            CreateIndex("dbo.Facturas", "Servicio_IdServicio1");
            AddForeignKey("dbo.Facturas", "Servicio_IdServicio", "dbo.Servicios", "IdServicio");
            AddForeignKey("dbo.Facturas", "ProveedorIdProveedor", "dbo.Proveedors", "IdProveedor", cascadeDelete: true);
            AddForeignKey("dbo.Facturas", "Servicio_IdServicio1", "dbo.Servicios", "IdServicio");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "Servicio_IdServicio1", "dbo.Servicios");
            DropForeignKey("dbo.Facturas", "ProveedorIdProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Facturas", "Servicio_IdServicio", "dbo.Servicios");
            DropIndex("dbo.Facturas", new[] { "Servicio_IdServicio1" });
            DropIndex("dbo.Facturas", new[] { "Servicio_IdServicio" });
            DropIndex("dbo.Facturas", new[] { "ProveedorIdProveedor" });
            AlterColumn("dbo.Facturas", "ProveedorIdProveedor", c => c.Int());
            DropColumn("dbo.Facturas", "Servicio_IdServicio1");
            DropColumn("dbo.Facturas", "Servicio_IdServicio");
            RenameColumn(table: "dbo.Facturas", name: "ProveedorIdProveedor", newName: "Proveedor_IdProveedor");
            CreateIndex("dbo.Facturas", "Proveedor_IdProveedor");
            CreateIndex("dbo.Facturas", "ServicioIdServicio");
            AddForeignKey("dbo.Facturas", "ServicioIdServicio", "dbo.Servicios", "IdServicio", cascadeDelete: true);
            AddForeignKey("dbo.Facturas", "Proveedor_IdProveedor", "dbo.Proveedors", "IdProveedor");
        }
    }
}
