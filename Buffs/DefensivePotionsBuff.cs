using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Buffs
{
    public class DefensivePotionsBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Defensive Boost");
            Description.SetDefault("Gives you the effect of all defensive potions!");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<DragonHunterItemsPlayer>(mod).defensiveBoost = true;
        }
    }
}
