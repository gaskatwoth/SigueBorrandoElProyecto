namespace proyectofinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class equis : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Servicios", "Precio", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Servicios", "Precio", c => c.Double(nullable: false));
        }
    }
}
