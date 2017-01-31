using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.World.Generation;

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
            ShedGen(Main.spawnTileX, Main.spawnTileY);
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
        }

        public override void PostUpdate()
        {
            // Prevent player from changing spawn
            // Main.spawnTileX = (int)spawnLocation.X;
            // Main.spawnTileY = (int)spawnLocation.Y;

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

        private void ShedGen(int i, int j)
        {
            int[,] shed = new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 2, 2, 2, 2, 2, 2, 2, 1 },
                { 1, 2, 2, 2, 2, 2, 2, 2, 1 },
                { 1, 2, 2, 2, 2, 2, 2, 2, 1 },
                { 1, 2, 2, 2, 2, 2, 2, 2, 1 },
                { 1, 2, 2, 2, 2, 2, 2, 2, 1 },
                { 1, 2, 2, 2, 2, 2, 2, 2, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };

            for (int y = 0; y < shed.GetLength(0); y++)
            {
                for (int x = 0; x < shed.GetLength(1); x++)
                {
                    int k = i + x - shed.GetLength(0) / 2; // centers the house around the player's spawn
                    int l = j + y - shed.GetLength(1) + 2;
                    if (WorldGen.InWorld(k, l, 30))
                    {
                        Tile mytile = Framing.GetTileSafely(k, l); // If the tile at the given point is null, it invokes Main.tile[x, y] = new Tile();
                        switch (shed[y, x])
                        {
                            case 1:
                                mytile.type = TileID.WoodBlock;
                                mytile.active(true);
                                break;
                            case 2:
                                mytile.wall = WallID.Wood;
                                break;
                        }

                    }
                }

            }
        }
    }
}
