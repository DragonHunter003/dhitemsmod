using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DragonHunterItems.Projectiles
{
    public class ShotgunShot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shotgun Shot");
        }

        private const float BULLET_SPLIT_TIMER = 20;
        private const int ON_SPLIT_BULLET_NUMBER = 3;
        private const int BULLET_SPLIT_REPEAT_NUMBER = 5;

        private float spread()
        {
            return (float)Main.rand.Next(-200, 200) * 0.001f;
        }

        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
        }

        private void CreateSplitBullet()
        {
            //TODO Create system to sotp infinitely splitting bullets
        }
    }
}
