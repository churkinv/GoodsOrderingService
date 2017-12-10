namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "OrderDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
