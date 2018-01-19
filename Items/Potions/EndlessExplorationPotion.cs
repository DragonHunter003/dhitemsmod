using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items.Potions
{
    public class EndlessExplorationPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bottomless Exploration Potion");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(mod.ItemType("ExplorationPotion"));
            item.maxStack = 1;
            item.consumable = false;
            item.buffTime = 216000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ExplorationPotion"), 30);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
