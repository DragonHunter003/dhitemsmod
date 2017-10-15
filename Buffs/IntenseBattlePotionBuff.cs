using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Buffs
{
    public class IntenseBattlePotionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Intense Battle");
            Description.SetDefault("Enemy spawn rate greatly increased");
            Main.buffNoTimeDisplay[Type] = false;
        }
    }
}
