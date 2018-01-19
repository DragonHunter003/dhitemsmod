using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items.Potions
{
    public class EndlessOffensivePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bottomless Offensive Potion");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(mod.ItemType("OffensivePotion"));
            item.maxStack = 1;
            item.consumable = false;
            item.buffTime = 216000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("OffensivePotion"), 30);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
