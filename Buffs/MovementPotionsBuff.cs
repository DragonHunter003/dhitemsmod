using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Buffs
{
    public class MovementPotionsBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Movement Boost");
            Description.SetDefault("Gives you the effect of all movement potions!");
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<DragonHunterItemsPlayer>(mod).movementBoost = true;
        }
    }
}
