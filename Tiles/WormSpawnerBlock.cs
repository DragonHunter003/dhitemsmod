using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace DragonHunterItems.Tiles
{
    public class WormSpawnerBlock : ModTile
    {
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("WormSpawner"), 1, false, 0, false, false);
        }

        public override void RightClick(int i, int j)
        {
            Item.NewItem(i* 16, j * 16, 32, 32, ItemID.Worm, 10, false, 0, false, false);
           // NPC.NewNPC(i * 16, j * 16, NPCID.Worm);
        }

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[] {16,16};
            TileObjectData.addTile(Type);
        }
    }
}
