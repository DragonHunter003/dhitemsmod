using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
    public class IntenseBattlePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Concentrated Battle Potion");
            Tooltip.SetDefault("A strengthened Battle Potion");             
        }
        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 24;
            item.useStyle = 2;
            item.useTime = 17;
            item.useAnimation = 17;
            item.consumable = true;
            item.buffType = mod.BuffType("IntenseBattlePotionBuff");
            item.buffTime = 10800;
            item.maxStack = 30;
            item.UseSound = SoundID.Item3;
            item.value = 25000;
            item.rare = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BattlePotion, 5);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
