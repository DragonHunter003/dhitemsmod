using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Buffs
{
    public class FishingHookPotionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hooks");
            Description.SetDefault("My fishing hook seem to be multiplying");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<DragonHunterItemsPlayer>(mod).fishingHookBoost = true;
        }
    }
}
