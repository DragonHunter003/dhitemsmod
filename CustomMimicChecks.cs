using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using Terraria.ID;

namespace DragonHunterItems
{
    public class CustomMimicChecks : ModPlayer
    {
        public int LastOpenedChest;
        

           
    
        public override void PreUpdateBuffs()
        {
            if (Main.netMode != 1)
            {
                if (player.chest == -1 && this.LastOpenedChest >= 0 && Main.chest[this.LastOpenedChest] != null && Main.chest[this.LastOpenedChest] != null)
                {
                    int chestX = Main.chest[this.LastOpenedChest].x;
                    int chestY = Main.chest[this.LastOpenedChest].y;
                    CustomBigMimicSummonCheck(chestX, chestY);
                }
                this.LastOpenedChest = player.chest;
               
            }
        }

        public bool CustomBigMimicSummonCheck(int x, int y)
        {
            if (Main.netMode == 1 || !Main.hardMode)
            {
                return false;
            }

            int chestToCheckID = Chest.FindChest(x, y);

            if (chestToCheckID < 0)
            {
                return false;
            }

            int itemStackSize = 0;
            int emptyChestCheckNumber = 0;
            int summonItemUsed = 0;
  
            for (int i = 0; i < 40; i++)
            {
                int tileType = Main.tile[Main.chest[chestToCheckID].x,Main.chest[chestToCheckID].y].type;
                int tileSubType = (Main.tile[Main.chest[chestToCheckID].x, Main.chest[chestToCheckID].y].frameX / 36);

                if (TileID.Sets.BasicChest[tileType] && (tileType != 21 || tileSubType < 5 || tileSubType > 6) && Main.chest[chestToCheckID].item[i] != null && Main.chest[chestToCheckID].item[i].type > 0)
                {
                    int chestItemType = Main.chest[chestToCheckID].item[i].type;
                    if (chestItemType != mod.ItemType("CursedKey") && chestItemType != mod.ItemType("FrostKey") && chestItemType > 1)
                    {
                        emptyChestCheckNumber += 1;
                    }
                    else
                    {
                        if (chestItemType == mod.ItemType("CursedKey"))
                        {
                            //Add normal summon to summonItemUsed
                            itemStackSize += Main.chest[chestToCheckID].item[i].stack;
                            summonItemUsed += 1;

                        }
                        if (chestItemType == mod.ItemType("FrostKey"))
                        {
                            //Add frozen summon to summonItemUsed
                            itemStackSize += Main.chest[chestToCheckID].item[i].stack;
                            summonItemUsed += 2;

                        }
                    }
                }
            }

            if (emptyChestCheckNumber == 0 && summonItemUsed > 0 && itemStackSize == 1)
            {
                if (TileID.Sets.BasicChest[Main.tile[x, y].type])
                {
                    if (Main.tile[x, y].frameX % 36 != 0)
                    {
                        x--;
                    }
                    if (Main.tile[x, y].frameY % 36 != 0)
                    {
                        y--;
                    }
                    int number = Chest.FindChest(x, y);
                    for (int j = x; j <= x + 1; j++)
                    {
                        for (int k = y; k <= y + 1; k++)
                        {
                            if (TileID.Sets.BasicChest[(int)Main.tile[j, k].type])
                            {
                                Main.tile[j, k].active(false);
                            }
                        }
                    }
                    for (int l = 0; l < 40; l++)
                    {
                        Main.chest[chestToCheckID].item[l] = new Item();
                    }
                    Chest.DestroyChest(x, y);
                    int number2 = 1;
                    if (Main.tile[x, y].type == 467)
                    {
                        number2 = 5;
                    }
                    if (Main.tile[x, y].type >= TileID.Count)
                    {
                        number2 = 101;
                    }
                    NetMessage.SendData(34, -1, -1, null, number2, (float)x, (float)y, 0f, number, Main.tile[x, y].type, 0);
                    NetMessage.SendTileSquare(-1, x, y, 3, TileChangeType.None);
                }

                int npcToSummon = 0;
                int npcSubType = 0;

                switch(summonItemUsed)
                {
                    case 1:
                        npcToSummon = 85;
                        npcSubType = (Main.rand.Next(3) + 1);
                        break;
                    case 2:
                        npcToSummon = 85;
                        npcSubType = 4;
                        break;
                    default:
                        npcToSummon = 85;
                        //npcSubType = 0;
                        break;
                }

                int spawnedNPCID = NPC.NewNPC(x * 16 + 16, y * 16 + 32, npcToSummon);
                Main.npc[spawnedNPCID].whoAmI = spawnedNPCID;
                NetMessage.SendData(23, -1, -1, null, spawnedNPCID);
                Main.npc[spawnedNPCID].ai[3] = (float)npcSubType;
                Main.npc[spawnedNPCID].BigMimicSpawnSmoke();
                
            }

            return false;
        }


    }
    
}
