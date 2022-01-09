using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Terraria.GameInput;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
*/

namespace TMap
{
	public class TMap : Mod
	{
	}

	public class TMapPlayer : ModPlayer{
		//bool GlobalTeleporter = false;

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			
			bool allow = true;

			if (allow && Main.mapFullscreen)
			{
				allow = true;
			} else {
				allow = false;
			}

			if ( allow && Main.mouseRight && !(Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftShift)) )
			{
				allow = true;
			} else {
				allow = false;
			}

			if (allow)
			{
				for (int v = 0; v < 200; ++v)
				{
					NPC npc = Main.npc[v];
					if (npc.active && npc.boss)
					{
						allow = false;
						break;
					}
				}
			}

			if (allow) 
			{
				Mod TMapMod = ModLoader.GetMod("TMap");
				//ModItem GlobalTeleporterItem ;
				bool success = TMapMod.TryFind<ModItem>("GlobalTeleporter", out ModItem GlobalTeleporterItem);
				for (int v=0; v < 58; v+=1)
				{
					Item tempItem = Player.inventory[v];
					if ( tempItem.type == GlobalTeleporterItem.Type ) 
					{
						allow = true;
						break;
					} else {
						allow = false;
					}
				}
			}

			if ( allow )
			{
				int mapWidth = Main.maxTilesX * 16;
				int mapHeight = Main.maxTilesY * 16;
				Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

				cursorPosition.X -= Main.screenWidth / 2;
				cursorPosition.Y -= Main.screenHeight / 2;

				Vector2 mapPosition = Main.mapFullscreenPos;
				Vector2 cursorWorldPosition = mapPosition;

				cursorPosition /= 16;
				cursorPosition *= 16 / Main.mapFullscreenScale;
				cursorWorldPosition += cursorPosition;
				cursorWorldPosition *= 16;

				cursorWorldPosition.Y -= Player.height;
				if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
				else if (cursorWorldPosition.X + Player.width > mapWidth) cursorWorldPosition.X = mapWidth - Player.width;
				if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
				else if (cursorWorldPosition.Y + Player.height > mapHeight) cursorWorldPosition.Y = mapHeight - Player.height;
				
				Player.Teleport(cursorWorldPosition, 0, 0);
				NetMessage.SendData(65, -1, -1, (NetworkText) null, 0, (float) Player.whoAmI, (float) cursorWorldPosition.X, (float) cursorWorldPosition.Y, 1, 0, 0);
				Main.mapFullscreen = false;
				
				for (int index = 0; index < 120; ++index)
				Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-10f,10f), Main.rand.NextFloat(-10f,10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
			}
		}
	}
}