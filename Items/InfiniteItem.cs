using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
	public class InfiniteItem : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Gem");
            Tooltip.SetDefault("A strange energy emits from this gem...");
        }
        public override void SetDefaults()
		{		
			item.width = 40;
			item.height = 40;
			item.value = 10000;
			item.rare = 2;
            item.noMelee = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 175);
            recipe.AddIngredient(ItemID.FragmentNebula, 275);
            recipe.AddIngredient(ItemID.FragmentSolar, 275);
            recipe.AddIngredient(ItemID.FragmentStardust, 275);
            recipe.AddIngredient(ItemID.FragmentVortex, 275);
            recipe.AddIngredient(ItemID.LifeCrystal, 10);
            recipe.AddIngredient(ItemID.LifeFruit, 10);
            recipe.AddIngredient(ItemID.ManaCrystal, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateInventory(Player player)
        {
            player.HeldItem.consumable = false;
            player.inventory[player.selectedItem].consumable = false;
            for (int i = player.inventory.Length-1; i > 0; i--)
            {
                player.inventory[i].consumable = false;
            }
        }

    }
}
