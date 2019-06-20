namespace PortalStudent.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SandwichIngredients", name: "Sandwich_SandwichId", newName: "SandwichId");
            RenameColumn(table: "dbo.SandwichIngredients", name: "Ingredient_IngredientId", newName: "IngredientId");
            RenameIndex(table: "dbo.SandwichIngredients", name: "IX_Sandwich_SandwichId", newName: "IX_SandwichId");
            RenameIndex(table: "dbo.SandwichIngredients", name: "IX_Ingredient_IngredientId", newName: "IX_IngredientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SandwichIngredients", name: "IX_IngredientId", newName: "IX_Ingredient_IngredientId");
            RenameIndex(table: "dbo.SandwichIngredients", name: "IX_SandwichId", newName: "IX_Sandwich_SandwichId");
            RenameColumn(table: "dbo.SandwichIngredients", name: "IngredientId", newName: "Ingredient_IngredientId");
            RenameColumn(table: "dbo.SandwichIngredients", name: "SandwichId", newName: "Sandwich_SandwichId");
        }
    }
}
