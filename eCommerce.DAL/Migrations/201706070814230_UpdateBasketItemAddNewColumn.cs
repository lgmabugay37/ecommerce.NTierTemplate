namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBasketItemAddNewColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "Basket_Id" });
            DropColumn("dbo.BasketItems", "BasketId");
            DropColumn("dbo.BasketItems", "Basket_Id");
          
            //RenameColumn(table: "dbo.BasketItems", name: "Basket_Id", newName: "BasketId");
            DropPrimaryKey("dbo.BasketItems");
            DropColumn("dbo.BasketItems", "BasketItemsId");

            AddColumn("dbo.BasketItems", "BasketItemId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BasketItems", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.BasketItems", "BasketId", c => c.Guid(nullable: false));
            //AlterColumn("dbo.BasketItems", "BasketId", c => c.Guid(nullable: false));

            AddPrimaryKey("dbo.BasketItems", "BasketItemId");
            CreateIndex("dbo.BasketItems", "BasketId");
            AddForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets", "Id", cascadeDelete: true);
           // DropColumn("dbo.BasketItems", "BasketItemsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BasketItems", "BasketItemsId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            DropPrimaryKey("dbo.BasketItems");
            AlterColumn("dbo.BasketItems", "BasketId", c => c.Guid());
            AlterColumn("dbo.BasketItems", "BasketId", c => c.Int(nullable: false));
            DropColumn("dbo.BasketItems", "Quantity");
            DropColumn("dbo.BasketItems", "BasketItemId");
            AddPrimaryKey("dbo.BasketItems", "BasketItemsId");
            RenameColumn(table: "dbo.BasketItems", name: "BasketId", newName: "Basket_Id");
            AddColumn("dbo.BasketItems", "BasketId", c => c.Int(nullable: false));
            CreateIndex("dbo.BasketItems", "Basket_Id");
            AddForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets", "Id");
        }
    }
}
