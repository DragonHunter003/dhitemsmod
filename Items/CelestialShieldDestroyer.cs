using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
	public class CelestialShieldDestroyer : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Shield Destroyer");
        }
        public override void SetDefaults()
		{		
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
            item.noMelee = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 75);
            recipe.AddIngredient(ItemID.FragmentNebula, 100);
            recipe.AddIngredient(ItemID.FragmentSolar, 100);
            recipe.AddIngredient(ItemID.FragmentStardust, 100);
            recipe.AddIngredient(ItemID.FragmentVortex, 100);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool UseItem(Player player)
        {
            if (NPC.ShieldStrengthTowerNebula > 0)
            {
                NPC.ShieldStrengthTowerNebula = 1;
                NPC towerNPC = Main.npc[NPC.FindFirstNPC(NPCID.LunarTowerNebula)] ;
                Projectile.NewProjectile(towerNPC.Center.X, towerNPC.Center.Y, 0.0f, 0.0f, 629, 0, 0.0f, Main.myPlayer, (float)NPC.FindFirstNPC(NPCID.LunarTowerNebula), 0.0f);
            }
            if (NPC.ShieldStrengthTowerStardust > 0)
            {
                NPC.ShieldStrengthTowerStardust = 1;
                NPC towerNPC = Main.npc[NPC.FindFirstNPC(NPCID.LunarTowerStardust)];              
                Projectile.NewProjectile(towerNPC.Center.X, towerNPC.Center.Y, 0.0f, 0.0f, 629, 0, 0.0f, Main.myPlayer, (float)NPC.FindFirstNPC(NPCID.LunarTowerStardust), 0.0f);
            }
            if (NPC.ShieldStrengthTowerSolar > 0)
            {
                NPC.ShieldStrengthTowerSolar = 1;
                NPC towerNPC = Main.npc[NPC.FindFirstNPC(NPCID.LunarTowerSolar)];               
                Projectile.NewProjectile(towerNPC.Center.X, towerNPC.Center.Y, 0.0f, 0.0f, 629, 0, 0.0f, Main.myPlayer, (float)NPC.FindFirstNPC(NPCID.LunarTowerSolar), 0.0f);
            }
            if (NPC.ShieldStrengthTowerVortex > 0)
            {
                NPC.ShieldStrengthTowerVortex = 1;
                NPC towerNPC = Main.npc[NPC.FindFirstNPC(NPCID.LunarTowerVortex)];                                           
                Projectile.NewProjectile(towerNPC.Center.X, towerNPC.Center.Y, 0.0f, 0.0f, 629, 0, 0.0f, Main.myPlayer, (float)NPC.FindFirstNPC(NPCID.LunarTowerVortex), 0.0f);
            }
            return true;
        }
    }
}
