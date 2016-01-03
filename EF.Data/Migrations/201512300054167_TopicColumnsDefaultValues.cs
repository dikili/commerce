using System.Data.Entity.Migrations.Builders;

namespace EF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TopicColumnsDefaultValues : DbMigration
    {
        public override void Up()
        {
           //AlterColumn("Topics","IsVisible",c=>c.Boolean(defaultValue:true));
          // AlterColumn("Topics","ProductCategory",c=>c.String(defaultValue:"General"));
            //because string is nullable,even though value is not provided it will act as if it is provided
            //with a null value;
            //Sql("Update Topics Set ProductCategory='General'");
        }
        
        public override void Down()
        {
        }
    }
}
