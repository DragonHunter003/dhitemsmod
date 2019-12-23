using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace DragonHunterItems.Tiles
{
    public class EZDuplicatorBlock : ModTile
    {
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 32, mod.ItemType("EZDuplicator"), 1, false, 0, false, false);
        }

        public override void RightClick(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];

            Item selectedItem = player.inventory[player.selectedItem];
            Item.NewItem(i * 16, j * 16, 32, 32, selectedItem.type, selectedItem.stack, false, 0, false, false);
            if (selectedItem.maxStack > 1 && selectedItem.stack != 1)
            {
                selectedItem.stack -= 1;
            }
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
