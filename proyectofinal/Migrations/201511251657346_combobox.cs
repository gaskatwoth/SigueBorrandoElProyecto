namespace proyectofinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class combobox : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facturas", "Fecha");
        }
    }
}
