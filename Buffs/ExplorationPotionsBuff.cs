using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Buffs
{
    public class ExplorationPotionsBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Exploration Boost");
            Description.SetDefault("Gives you the effect of all exploration potions!");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<DragonHunterItemsPlayer>(mod).explorationBoost = true;
        }
    }
}
