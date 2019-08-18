using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace DragonHunterItems.Items.Placeables
{
    public class WormSpawner : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Worm Spawner");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTime = 10;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.autoReuse = true;
            item.useTurn = true;
            item.consumable = true;
            item.createTile = mod.TileType("WormSpawnerBlock");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Worm,49);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
