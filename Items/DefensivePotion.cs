using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
    public class DefensivePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Defensive Potion");
            Tooltip.SetDefault("A potion that will make you a lot thougher");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.useStyle = 2;
            item.useTime = 17;
            item.useAnimation = 17;
            item.consumable = true;
            item.buffType = mod.BuffType("DefensivePotionsBuff");
            item.buffTime = 18000;
            item.maxStack = 30;
            item.UseSound = SoundID.Item3;
            item.value = 25000;
            item.rare = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianSkinPotion, 3);
            recipe.AddIngredient(ItemID.RegenerationPotion, 3);
            recipe.AddIngredient(ItemID.IronskinPotion, 3);
            recipe.AddIngredient(ItemID.ThornsPotion, 3);
            recipe.AddIngredient(ItemID.CookedFish, 3);
            recipe.AddIngredient(ItemID.HeartreachPotion, 3);
            recipe.AddIngredient(ItemID.LifeforcePotion, 3);
            recipe.AddIngredient(ItemID.EndurancePotion, 3);
            recipe.AddIngredient(ItemID.WarmthPotion, 3);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
