using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomCustomItems.Projectiles.Minions
{
    public class CuckMinion : HoverShooter
    {
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.name = "Cuck Minion";
            projectile.width = 24;
            projectile.height = 32;
            Main.projFrames[projectile.type] = 3;
            projectile.friendly = true;
            Main.projPet[projectile.type] = true;
            projectile.minion = true;
            projectile.minionSlots = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targetting
            inertia = 20f;
            shoot = mod.ProjectileType("CuckMinionP");
            shootSpeed = 12f;
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
            if (player.dead)
            {
                modPlayer.minionName = false;
            }
            if (modPlayer.minionName)
            {
                projectile.timeLeft = 2;
            }
        }

        public override void CreateDust()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 2f, 2f, 2f);
        }

        public override void SelectFrame()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 3;
            }
        }

    }
}