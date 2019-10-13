namespace TreeManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredLength : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Node", "IdParent", "dbo.Node");
            AddForeignKey("dbo.Node", "IdParent", "dbo.Node", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Node", "IdParent", "dbo.Node");
            AddForeignKey("dbo.Node", "IdParent", "dbo.Node", "Id", cascadeDelete: true);
        }
    }
}
