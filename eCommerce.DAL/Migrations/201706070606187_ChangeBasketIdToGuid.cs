namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBasketIdToGuid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            DropPrimaryKey("dbo.Baskets");

            DropColumn("dbo.Baskets", "Id"); // drops column
            DropColumn("dbo.BasketItems", "BasketId");

            AddColumn("dbo.Baskets", "Id", c => c.Guid());
            AddColumn("dbo.BasketItems", "Basket_Id", c => c.Guid());
          

            AlterColumn("dbo.Baskets", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Baskets", "Id");
            CreateIndex("dbo.BasketItems", "Basket_Id");
            AddForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets", "Id");
          
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "Basket_Id" });
            DropPrimaryKey("dbo.Baskets");
            AlterColumn("dbo.Baskets", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.BasketItems", "Basket_Id");
            AddPrimaryKey("dbo.Baskets", "Id");
            CreateIndex("dbo.BasketItems", "BasketId");
            AddForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets", "Id", cascadeDelete: true);
        }
    }
}
