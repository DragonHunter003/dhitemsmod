using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
    public class ExplorationPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exploration Potion");
            Tooltip.SetDefault("This brew will make spelunking a whole lot easier");
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.useStyle = 2;
            item.useTime = 17;
            item.useAnimation = 17;
            item.consumable = true;
            item.buffType = mod.BuffType("ExplorationPotionsBuff");
            item.buffTime = 18000;
            item.maxStack = 30;
            item.UseSound = SoundID.Item3;
            item.value = 25000;
            item.rare = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NightOwlPotion, 1);
            recipe.AddIngredient(ItemID.SpelunkerPotion, 1);
            recipe.AddIngredient(ItemID.ShinePotion, 1);
            recipe.AddIngredient(ItemID.BuilderPotion, 1);
            recipe.AddIngredient(ItemID.MiningPotion, 1);
            recipe.AddIngredient(ItemID.CratePotion, 1);
            recipe.AddIngredient(ItemID.FishingPotion, 1);
            recipe.AddIngredient(ItemID.SonarPotion, 1);
            recipe.AddIngredient(ItemID.TrapsightPotion, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
