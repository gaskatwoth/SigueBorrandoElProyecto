namespace proyectofinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FkFacturas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors");
            DropIndex("dbo.Servicios", new[] { "ProveedorIdProveedor" });
            CreateIndex("dbo.Facturas", "ProveedorIdProveedor");
            CreateIndex("dbo.Facturas", "AsistenteIdAsistente");
            CreateIndex("dbo.Facturas", "ServicioIdServicio");
            AddForeignKey("dbo.Facturas", "AsistenteIdAsistente", "dbo.Asistentes", "IdAsistente", cascadeDelete: true);
            AddForeignKey("dbo.Facturas", "ProveedorIdProveedor", "dbo.Proveedors", "IdProveedor", cascadeDelete: true);
            AddForeignKey("dbo.Facturas", "ServicioIdServicio", "dbo.Servicios", "IdServicio", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "ServicioIdServicio", "dbo.Servicios");
            DropForeignKey("dbo.Facturas", "ProveedorIdProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Facturas", "AsistenteIdAsistente", "dbo.Asistentes");
            DropIndex("dbo.Facturas", new[] { "ServicioIdServicio" });
            DropIndex("dbo.Facturas", new[] { "AsistenteIdAsistente" });
            DropIndex("dbo.Facturas", new[] { "ProveedorIdProveedor" });
            CreateIndex("dbo.Servicios", "ProveedorIdProveedor");
            AddForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors", "IdProveedor", cascadeDelete: true);
        }
    }
}
