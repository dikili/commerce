namespace EF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TopicContructer : DbMigration
    {
        public override void Up()
        {

            AlterColumn("Topics", "IsVisible", c => c.Boolean(defaultValue: true));
            Sql("Update Topics Set ProductCategory='General'");
        }
        
        public override void Down()
        {
        }
    }
}
