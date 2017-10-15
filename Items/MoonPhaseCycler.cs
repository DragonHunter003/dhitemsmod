using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
	public class MoonPhaseCycler : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moon Phase Cycler");
            Tooltip.SetDefault("Choose your moon phase at will!");
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
            recipe.AddIngredient(ItemID.IronBar, 25);
            recipe.anyIronBar = true;
            //recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddRecipeGroup("DragonHunterItems:CobaltBar", 10);
            recipe.AddIngredient(ItemID.SoulofLight, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool UseItem(Player player)
        {
            if (Main.moonPhase == 7)
                Main.moonPhase = 0;
            else Main.moonPhase++;
            return true;
        }

    }
}
