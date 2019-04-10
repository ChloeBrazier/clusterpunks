using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Dungeon Class
//Liam Perry
//Handles Arrays for the Dungeon and its navigation
namespace WarrenWarriorsGame
{
	public class Dungeon
	{
		//Random Attribute
		Random rn = new Random();

		//Arrays of buttons and encounters
		Button[,] roomButtons;
		Encounter[,] dungeonlayout;

		//Constructor for the Dungeon
		public Dungeon(Game g)
		{
			int roller;
			roomButtons = new Button[20, 20];
			dungeonlayout = new Encounter[20, 20];

			//Creates Buttons in Array
			for (int x = 0; x < 20; x++)
			{
				for (int y = 0; y < 20; y++)
				{
					//Generates a random encounter difficulty for each room
					roller = rn.Next(0, 5);
					switch (roller)
					{
						case 0:
							dungeonlayout[x, y] = new Encounter(g, Difficulty.None);
							roomButtons[x, y] = null;
							break;
						case 1:
							dungeonlayout[x, y] = new Encounter(g, Difficulty.Easy);
							roomButtons[x, y] = new Button(g.Content.Load<Texture2D>("RoomNormal"), g.Content.Load<Texture2D>("RoomNext"), g.Content.Load<Texture2D>("RoomCleared"), new Rectangle(x * 20, y * 20, 15, 15));
							break;
						case 2:
							dungeonlayout[x, y] = new Encounter(g, Difficulty.Medium);
							roomButtons[x, y] = new Button(g.Content.Load<Texture2D>("RoomNormal"), g.Content.Load<Texture2D>("RoomNext"), g.Content.Load<Texture2D>("RoomCleared"), new Rectangle(x * 20, y * 20, 15, 15));
							break;
						case 3:
							dungeonlayout[x, y] = new Encounter(g, Difficulty.Hard);
							roomButtons[x, y] = new Button(g.Content.Load<Texture2D>("RoomNormal"), g.Content.Load<Texture2D>("RoomNext"), g.Content.Load<Texture2D>("RoomCleared"), new Rectangle(x * 20, y * 20, 15, 15));
							break;
						case 4:
							dungeonlayout[x, y] = new Encounter(g, Difficulty.Boss);
							roomButtons[x, y] = new Button(g.Content.Load<Texture2D>("RoomNormal"), g.Content.Load<Texture2D>("RoomNext"), g.Content.Load<Texture2D>("RoomCleared"), new Rectangle(x * 20, y * 20, 15, 15));
							break;
					}
				}
			}
		}

		//Update Method
		//Checks if a button is clicked
		//If it is, generates an encounter
		public Encounter Update(MouseState ms, MouseState prev)
		{
			for (int x = 0; x < 20; x++)
			{
				for (int y = 0; y < 20; y++)
				{
					if (roomButtons[x, y] != null)
					{
						if (roomButtons[x, y].Update(ms) && Config.SingleMouseClick(ms, prev))
						{
							Encounter fight = dungeonlayout[x, y];
							return fight;
						}
					}
				}
			}
			return null;
		}

		//Draw Method
		//Draws the array of buttons
		public void Draw(SpriteBatch sb)
		{
			for (int x = 0; x < 20; x++)
			{
				for (int y = 0; y < 20; y++)
				{
					if (roomButtons[x, y] != null)
					{
						roomButtons[x, y].Draw(sb);
					}

				}
			}
		}

	}
}
