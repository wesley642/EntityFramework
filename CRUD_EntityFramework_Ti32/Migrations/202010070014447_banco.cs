﻿namespace CRUD_EntityFramework_Ti32.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agenda", "CEP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agenda", "CEP");
        }





    }
}
