using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
    public class MovementPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Movement Potion");
            Tooltip.SetDefault("I feel like the sky's the limit!");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.useStyle = 2;
            item.useTime = 17;
            item.useAnimation = 17;
            item.consumable = true;
            item.buffType = mod.BuffType("MovementPotionsBuff");
            item.buffTime = 18000;
            item.maxStack = 30;
            item.UseSound = SoundID.Item3;
            item.value = 25000;
            item.rare = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SwiftnessPotion, 1);
            recipe.AddIngredient(ItemID.FeatherfallPotion, 1);
            recipe.AddIngredient(ItemID.WaterWalkingPotion, 1);
            recipe.AddIngredient(ItemID.FlipperPotion, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
