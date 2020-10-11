namespace CRUD_EntityFramework_Ti32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agenda", "Salario", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agenda", "Salario");
        }
    }
}
