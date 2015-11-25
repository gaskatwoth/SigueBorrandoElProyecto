namespace proyectofinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviciosPk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "ProveedorIdProveedor", "dbo.Proveedors");
            DropIndex("dbo.Facturas", new[] { "ProveedorIdProveedor" });
            RenameColumn(table: "dbo.Facturas", name: "ProveedorIdProveedor", newName: "Proveedor_IdProveedor");
            AlterColumn("dbo.Facturas", "Proveedor_IdProveedor", c => c.Int());
            CreateIndex("dbo.Facturas", "Proveedor_IdProveedor");
            CreateIndex("dbo.Servicios", "ProveedorIdProveedor");
            AddForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors", "IdProveedor", cascadeDelete: true);
            AddForeignKey("dbo.Facturas", "Proveedor_IdProveedor", "dbo.Proveedors", "IdProveedor");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "Proveedor_IdProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors");
            DropIndex("dbo.Servicios", new[] { "ProveedorIdProveedor" });
            DropIndex("dbo.Facturas", new[] { "Proveedor_IdProveedor" });
            AlterColumn("dbo.Facturas", "Proveedor_IdProveedor", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Facturas", name: "Proveedor_IdProveedor", newName: "ProveedorIdProveedor");
            CreateIndex("dbo.Facturas", "ProveedorIdProveedor");
            AddForeignKey("dbo.Facturas", "ProveedorIdProveedor", "dbo.Proveedors", "IdProveedor", cascadeDelete: true);
        }
    }
}
