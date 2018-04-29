using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Items
{
    public class OmniBucket : ModItem
    {

        int liquidID = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omni Bucket");
            Tooltip.SetDefault("It somehow seems to hold infinite liquids");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
            item.noMelee = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LavaBucket, 33);
            recipe.AddIngredient(ItemID.WaterBucket, 33);
            recipe.AddIngredient(ItemID.HoneyBucket, 33);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.altFunctionUse == 2)
                {

                    string text = "";
                    liquidID++;
                    switch (liquidID)
                    {
                        case 1:
                            text = "Now placing Lava";
                            Main.NewText(text, 255, 0, 0, false);
                            break;
                        case 2:
                            text = "Now placing Honey";
                            Main.NewText(text, 255, 200, 0, false);
                            break;
                        case 3:
                            liquidID = 0;
                            text = "Now placing Water";
                            Main.NewText(text, 0, 200, 255, false);
                            break;
                        default:
                            text = "Now placing Water";
                            Main.NewText(text, 0, 200, 255, false);
                            liquidID = 0;
                            break;
                    }

                }
                else
                {
                    Main.tile[Player.tileTargetX, Player.tileTargetY].liquidType(liquidID);
                    Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
                    Liquid.AddWater(Player.tileTargetX, Player.tileTargetY);
                    if (Main.netMode == 1)
                    {
                        NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
                    }
                }
            }
                return true;
            

        }
    }
}
