using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace RandomCustomItems
{
    class RandomCustomWorld : ModWorld
    {
        private static Vector2 spawnLocation;

        public override void Initialize()
        {
            // Find suitable spawn
            for (int i = 0; i < Main.worldSurface; i++)
            {
                Tile tile = Main.tile[500, i];
                if (tile.active() && tile.wall == 0)
                {
                    spawnLocation = new Vector2(500, i);
                    break;
                }
            }
        }

        // Called after initial world generation
        public override void PostWorldGen()
        {
        }

        public override void PostUpdate()
        {
            // Prevent player from changing spawn
            Main.spawnTileX = (int)spawnLocation.X;
            Main.spawnTileY = (int)spawnLocation.Y;

            // Spawn custom vendor npc if it hasn't spawned already
            if (!NPC.AnyNPCs(mod.NPCType("Town NPC")))
            {
                int num = NPC.NewNPC((Main.spawnTileX + 5) * 16, Main.spawnTileY * 16, mod.NPCType("Town NPC"), 0, 0f, 0f, 0f, 0f, 255);
                Main.npc[num].homeTileX = Main.spawnTileX + 5;
                Main.npc[num].homeTileY = Main.spawnTileY;
                Main.npc[num].direction = 1;
                Main.npc[num].homeless = true;
            }


        }
    }
}
