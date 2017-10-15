using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems
{
	class DragonHunterItems : Mod
	{
		public DragonHunterItems()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + "Cobalt Bar", new int[] 
            {
                ItemID.CobaltBar,
                ItemID.PalladiumBar
            });
            RecipeGroup.RegisterGroup("DragonHunterItems:CobaltBar", group);
        }
    }

    class SpawnRateMultiplier : GlobalNPC
    {

       static float maxSpawnsMultiplier = 5f;
       static float spawnRateMultiplier = 10f;

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.FindBuffIndex( mod.BuffType("IntenseBattlePotionBuff") ) != -1)
            {
                spawnRate /= (int)spawnRateMultiplier;
                maxSpawns *= (int)maxSpawnsMultiplier;
            }
        }
    }
}
