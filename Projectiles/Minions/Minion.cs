using System;
using Terraria;
using Terraria.ModLoader;

namespace RandomCustomItems.Projectiles.Minions
{
    public abstract class Minion : ModProjectile
    {
        public override void AI()
        {
            CheckActive();
            Behavior();
        }

        public abstract void CheckActive();

        public abstract void Behavior();
    }
}