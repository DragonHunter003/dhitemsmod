using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
    public class OffensivePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Offensive Potion");
            Tooltip.SetDefault("A potion that will fill you with strength");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.useStyle = 2;
            item.useTime = 17;
            item.useAnimation = 17;
            item.consumable = true;
            item.buffType = mod.BuffType("OffensivePotionsBuff");
            item.buffTime = 18000;
            item.maxStack = 30;
            item.UseSound = SoundID.Item3;
            item.value = 25000;
            item.rare = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ManaRegenerationPotion, 1);
            recipe.AddIngredient(ItemID.MagicPowerPotion, 1);
            recipe.AddIngredient(ItemID.ArcheryPotion, 1);
            recipe.AddIngredient(ItemID.HunterPotion, 1);
            recipe.AddIngredient(ItemID.TitanPotion, 1);
            recipe.AddIngredient(ItemID.SummoningPotion, 1);
            recipe.AddIngredient(ItemID.AmmoReservationPotion, 1);
            recipe.AddIngredient(ItemID.RagePotion, 1);
            recipe.AddIngredient(ItemID.InfernoPotion, 1);
            recipe.AddIngredient(ItemID.WrathPotion, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
