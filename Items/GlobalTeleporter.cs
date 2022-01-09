using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace TMap.Items
{
	public class GlobalTeleporter : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("GlobalTeleporter"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Open the fullmap and rightclick while pressing leftshift.\nYou could teleport to the position your mouse targeted if you have the GlobalTeleporter in your inventory.\n\n You have dig out the world!");
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 999*5);
			recipe.AddIngredient(ItemID.Dynamite, 99*5);
			recipe.AddIngredient(ItemID.StoneBlock, 999*5);
			recipe.AddIngredient(ItemID.MudBlock, 999*5);
			recipe.AddIngredient(ItemID.SandBlock, 999*5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		/*
		public override void UpdateInventory(Player player)
		{
			((TMapPlayer)player.GetModPlayer(mod, "TMapPlayer")).GlobalTeleporter = true;
		}
		*/
	
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 99;
			Item.value = 5000000;
			Item.rare = 11;
		}

	}
}