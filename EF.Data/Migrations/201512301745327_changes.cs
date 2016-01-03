namespace EF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Sex", c => c.String());
        }
    }
}
