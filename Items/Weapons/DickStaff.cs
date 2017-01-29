using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomCustomItems.Items.Weapons
{
    public class DickStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "The Staff of McCuckbf";
            item.damage = 140;
            item.summon = true;
            item.mana = 10;
            item.width = 26;
            item.height = 28;
            item.toolTip = "Summons a minion of questionable origin\nand consistency to fight for you.";
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 30, 0, 0);
            item.rare = 11;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("CuckMinion");
            item.shootSpeed = 7f;
            item.buffTime = 10000000;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}