using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
	public class Lepidopterameter : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lepidopterameter");
            Tooltip.SetDefault("Checks butterfly spawnrate");
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
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.anyIronBar = true;
            recipe.SetResult(this);
            recipe.AddRecipe();
		}

        public override bool UseItem(Player player)
        {
            string text = (1.0f / ((float)NPC.butterflyChance + 1.0f) * 100.0f)+"%";
                Main.NewText(text, 255, 0, 0, true);
            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            NPC.butterflyChance = 0;
            return true;
        }

    }
}
