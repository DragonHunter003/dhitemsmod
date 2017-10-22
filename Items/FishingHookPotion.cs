using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
    public class FishingHookPotion : ModItem
    {
        public const int HOOKAMOUNT = 5;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fishing Hook Potion");
            Tooltip.SetDefault("Gives your fishing rod an additional "+HOOKAMOUNT+" hooks!");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.useStyle = 2;
            item.useTime = 17;
            item.useAnimation = 17;
            item.consumable = true;
            item.buffType = mod.BuffType("FishingHookPotionBuff");
            item.buffTime = 18000;
            item.maxStack = 30;
            item.UseSound = SoundID.Item3;
            item.value = 25000;
            item.rare = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FishingPotion, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
