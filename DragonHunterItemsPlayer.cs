using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace DragonHunterItems
{
    public class DragonHunterItemsPlayer : ModPlayer
    {
        public bool intenseBattle = false;
        public bool offensiveBoost = false;
        public bool explorationBoost = false;
        public bool defensiveBoost = false;
        public bool movementBoost = false;
        public bool fishingHookBoost = false;

        public override void ResetEffects()
        {
            intenseBattle = false;
            offensiveBoost = false;
            explorationBoost = false;
            defensiveBoost = false;
            movementBoost = false;
            fishingHookBoost = false;
    }
        public override void UpdateDead()
        {
            intenseBattle = false;
            offensiveBoost = false;
            explorationBoost = false;
            defensiveBoost = false;
            movementBoost = false;
            fishingHookBoost = false;
        }

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (fishingHookBoost && item.fishingPole > 0)
            {
                const float ANGLE_SPREAD = 0.25f;
                const int AMOUNT_HOOKS = Items.FishingHookPotion.HOOKAMOUNT;

                float baseSpeed = (float)Math.Sqrt(speedX*speedX + speedY*speedY);
                float randomSpeed = Main.rand.NextFloat() * 0.2f + 0.9f;
                double baseAngle = Math.Atan2(speedX, speedY);

                for (int i = 0; i < AMOUNT_HOOKS; i++)
                {
                    double randomAngle = baseAngle + (-1f + 0.5f * i) * ANGLE_SPREAD;
                    speedX = baseSpeed * randomSpeed * (float)Math.Sin(randomAngle);
                    speedY = baseSpeed * randomSpeed * (float)Math.Cos(randomAngle);
                    Projectile.NewProjectile(new Vector2(position.X, position.Y), new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI);
                }


                return true;
            }
            return true;
        }

        public override void UpdateBadLifeRegen()
        {
            if (explorationBoost)
            {
                player.gills = true;
                player.findTreasure = true;
                Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
                player.nightVision = true;
                player.pickSpeed -= 0.25f;
                player.tileSpeed += 0.25f;
                player.wallSpeed += 0.25f;
                ++player.blockRange;
                player.dangerSense = true;
                player.fishingSkill += 15;
                player.sonarPotion = true;
                player.cratePotion = true;
            }

            if (defensiveBoost)
            {

                player.lavaImmune = true;
                player.fireWalk = true;
                player.buffImmune[24] = true;

                player.lifeRegen += 4;

                player.statDefense += 8;

                if ((double)player.thorns < 1.0)
                    player.thorns = 0.3333333f;


                player.lifeMagnet = true;

                player.lifeForce = true;
                player.statLifeMax2 += player.statLifeMax / 5;

                player.endurance += 0.1f;

                player.resistCold = true;

                player.wellFed = true;
                player.statDefense += 2;
                player.meleeCrit += 2;
                player.meleeDamage += 0.05f;
                player.meleeSpeed += 0.05f;
                player.magicCrit += 2;
                player.magicDamage += 0.05f;
                player.rangedCrit += 2;
                player.rangedDamage += 0.05f;
                player.thrownCrit += 2;
                player.thrownDamage += 0.05f;
                player.minionDamage += 0.05f;
                player.minionKB += 0.5f;
                player.moveSpeed += 0.2f;

            }

            if (movementBoost)
            {
                player.moveSpeed += 0.25f;

                player.slowFall = true;

                player.waterWalk = true;

                player.ignoreWater = true;
                player.accFlipper = true;
            }

            if (offensiveBoost)
            {
                player.manaRegenBuff = true;

                player.magicDamage += 0.2f;

                player.archery = true;

                player.detectCreature = true;

                player.kbBuff = true;

                ++player.maxMinions;

                player.ammoPotion = true;

                player.meleeCrit += 10;
                player.rangedCrit += 10;
                player.magicCrit += 10;
                player.thrownCrit += 10;

                player.inferno = true;
                Lighting.AddLight((int)((double)player.Center.X / 16.0), (int)((double)player.Center.Y / 16.0), 0.65f, 0.4f, 0.1f);
                int type = 24;
                float num1 = 200f;
                bool flag = player.infernoCounter % 60 == 0;
                int num2 = 10;
                if (player.whoAmI == Main.myPlayer)
                {
                    for (int index2 = 0; index2 < 200; ++index2)
                    {
                        NPC npc = Main.npc[index2];
                        if (npc.active && !npc.friendly && (npc.damage > 0 && !npc.dontTakeDamage) && (!npc.buffImmune[type] && (double)Vector2.Distance(player.Center, npc.Center) <= (double)num1))
                        {
                            if (npc.FindBuffIndex(type) == -1)
                                npc.AddBuff(type, 120, false);
                            if (flag)
                                player.ApplyDamageToNPC(npc, num2, 0.0f, 0, false);
                        }
                    }
                    if (player.hostile)
                    {
                        for (int playerTargetIndex = 0; playerTargetIndex < (int)byte.MaxValue; ++playerTargetIndex)
                        {
                            Player playerb = Main.player[playerTargetIndex];
                            if (playerb != player && playerb.active && (!playerb.dead && playerb.hostile) && (!playerb.buffImmune[type] && (playerb.team != player.team || playerb.team == 0)) && (double)Vector2.Distance(player.Center, player.Center) <= (double)num1)
                            {
                                if (player.FindBuffIndex(type) == -1)
                                    player.AddBuff(type, 120, true);
                                if (flag)
                                {
                                    player.Hurt(PlayerDeathReason.LegacyEmpty(), num2, 0, true, false, false, -1);
                                    if (Main.netMode != 0)
                                    {
                                        PlayerDeathReason reason = PlayerDeathReason.ByPlayer(player.whoAmI);
                                        NetMessage.SendPlayerHurt(playerTargetIndex, reason, num2, 0, false, true, 0, -1, -1);
                                    }
                                }
                            }
                        }
                    }
                }

                player.thrownDamage += 0.1f;
                player.meleeDamage += 0.1f;
                player.rangedDamage += 0.1f;
                player.magicDamage += 0.1f;
                player.minionDamage += 0.1f;

            }


        }
    }
}
