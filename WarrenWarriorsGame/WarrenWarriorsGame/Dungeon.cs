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

        int DungeonDimension = 20;

		//Constructor for the Dungeon
		public Dungeon(Game g)
		{
			int roller;
			roomButtons = new Button[20, 20];
			dungeonlayout = new Encounter[20, 20];

            DungeonDimension = 7;

			roomButtons = new Button[DungeonDimension, DungeonDimension];
			dungeonlayout = new Encounter[DungeonDimension, DungeonDimension];

			//Creates Buttons in Array
			for (int x = 0; x < DungeonDimension; x++)
			{
				for (int y = 0; y < DungeonDimension; y++)
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
							roomButtons[x, y] = new Button(g.Content.Load<Texture2D>("RoomNormal"), g.Content.Load<Texture2D>("RoomNext"), g.Content.Load<Texture2D>("RoomCleared"), new Rectangle(x * 60, y * 60, 60, 60));
							break;
						case 2:
							dungeonlayout[x, y] = new Encounter(g, Difficulty.Medium);
							roomButtons[x, y] = new Button(g.Content.Load<Texture2D>("RoomNormal"), g.Content.Load<Texture2D>("RoomNext"), g.Content.Load<Texture2D>("RoomCleared"), new Rectangle(x * 60, y * 60, 60, 60));
							break;
						case 3:
							dungeonlayout[x, y] = new Encounter(g, Difficulty.Hard);
							roomButtons[x, y] = new Button(g.Content.Load<Texture2D>("RoomNormal"), g.Content.Load<Texture2D>("RoomNext"), g.Content.Load<Texture2D>("RoomCleared"), new Rectangle(x * 60, y * 60, 60, 60));
							break;
						case 4:
							dungeonlayout[x, y] = new Encounter(g, Difficulty.Boss);
							roomButtons[x, y] = new Button(g.Content.Load<Texture2D>("RoomNormal"), g.Content.Load<Texture2D>("RoomNext"), g.Content.Load<Texture2D>("RoomCleared"), new Rectangle(x * 60, y * 60, 60, 60));
							break;
					}
				}
			}

            dungeonlayout[6, 6] = new Encounter(g, Difficulty.Boss);
            roomButtons[6, 6] = new Button(g.Content.Load<Texture2D>("RoomNormal"), g.Content.Load<Texture2D>("RoomNext"), g.Content.Load<Texture2D>("RoomCleared"), new Rectangle(6 * 60, 6 * 60, 60, 60));
		}

		//Update Method
		//Checks if a button is clicked
		//If it is, generates an encounter
        //edit this to use a graph (? maybe) or use adjacency so that only the rooms that have adjacent rooms cleared are drawn
		public Encounter Update(MouseState ms, MouseState prev)
		{
			for (int x = 0; x < DungeonDimension; x++)
			{
				for (int y = 0; y < DungeonDimension; y++)
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
			for (int x = 0; x < DungeonDimension; x++)
			{
				for (int y = 0; y < DungeonDimension; y++)
				{
					if (roomButtons[x, y] != null)
					{
						roomButtons[x, y].Draw(sb);
					}

				}
			}
		}

        public bool GameWin()
        {
            if (dungeonlayout[19,19].CombatHandler.EnemyHealth() == 0)
            {
                return true;
            }
            return false;
        }
	}
}
