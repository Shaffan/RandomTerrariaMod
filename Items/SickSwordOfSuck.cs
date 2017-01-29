using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomCustomItems.Items
{
    public class SickSwordOfSuck : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Sick Sword of Suck";
            item.damage = 250;
            item.melee = true;
            item.width = 80;
            item.height = 80;
            item.toolTip = "Sucks harder than your mom on prom night.";
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            base.MeleeEffects(player, hitbox);
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
        }

        public override bool UseItem(Player player)
        {
            int hitboxWidth = player.Hitbox.Width;
            int hitboxX = player.Hitbox.X;
            // NPC.NewNPC(player.direction < 0 ? hitboxX - hitboxWidth * 8 : hitboxX + hitboxWidth * 8, player.Hitbox.Y, NPCID.Pixie);

            return true;
        }
    }
}
