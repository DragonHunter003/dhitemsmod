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
            Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("WormSpawner"), 1, false, -1, false, false);
        }

        public override bool NewRightClick(int i, int j)
        {
            int spawnedWorms = Item.NewItem(i * 16, j * 16, 32, 32, ItemID.Worm, 10, false, 0, false);
            if (Main.netMode == 1)
            {
                NetMessage.SendData(21, -1, -1, null, spawnedWorms, 1f, 0f, 0f, 0, 0, 0);
            }
            return true;
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
