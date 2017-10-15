using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
	public class DayNightCycler : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Day Night Cycler");
            Tooltip.SetDefault("Switch day and night at will!");
        }
        public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
            item.noMelee = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 45);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.SoulofLight, 35);
            recipe.AddIngredient(ItemID.SoulofNight, 35);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool UseItem(Player player)
        {
            if (Main.dayTime)
                Main.time = 53999.0;
            else Main.time = 32399.0;
            return true;
        }

    }
}
