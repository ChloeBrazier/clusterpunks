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

        //Dungeon Size Control
        int DungeonDimension;

		//Arrays of buttons and encounters
		Button[,] roomButtons;
		Encounter[,] dungeonlayout;


		//Constructor for the Dungeon
		public Dungeon(Game g)
		{
			int roller;

            DungeonDimension = 7;

			roomButtons = new Button[DungeonDimension, DungeonDimension];
			dungeonlayout = new Encounter[DungeonDimension, DungeonDimension];

			//Creates Buttons in Array
			for (int x = 0; x < DungeonDimension; x++)
			{
				for (int y = 0; y < DungeonDimension; y++)
				{
					//Generates a random encounter difficulty for each room
					roller = rn.Next(1, 4);
					switch (roller)
					{
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
						if (checkAdjacent(x,y) && roomButtons[x, y].Update(ms) && Config.SingleMouseClick(ms, prev))
						{
							Encounter fight = dungeonlayout[x, y];
                            dungeonlayout[x, y] = null;
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
            roomButtons[0, 0].Draw(sb);
            if(roomButtons[0,0].State == BtnState.Selected)
            {
                for (int x = 0; x < DungeonDimension; x++)
                {
                    for (int y = 0; y < DungeonDimension; y++)
                    {
                        if (roomButtons[x, y] != null && checkAdjacent(x, y))
                        {
                            roomButtons[x, y].Draw(sb);
                        }

                    }
                }
            }
		}

        public bool GameWin()
        {
            if (dungeonlayout[DungeonDimension - 1, DungeonDimension - 1] == null)
            {
                return true;
            }

            return false;
        }

        private Boolean checkAdjacent(int x, int y)
        {

            if (x == 0)
            {
                if (y == 0)
                {
                    return true;
                }
                else if (y == DungeonDimension - 1)
                {
                    if (roomButtons[x, y - 1].State == BtnState.Selected || roomButtons[x + 1, y].State == BtnState.Selected)
                    {
                        return true;
                    }
                }
                else if (roomButtons[x, y - 1].State == BtnState.Selected || roomButtons[x + 1, y].State == BtnState.Selected || roomButtons[x, y + 1].State == BtnState.Selected)
                {
                    return true;
                }
            }

            else if (y == 0)
            {
                if (x == 0)
                {
                    return true;
                }
                else if (x == DungeonDimension - 1)
                {
                    if (roomButtons[x - 1, y ].State == BtnState.Selected || roomButtons[x , y + 1].State == BtnState.Selected)
                    {
                        return true;
                    }
                }
                else if (roomButtons[x-1, y].State == BtnState.Selected || roomButtons[x + 1, y].State == BtnState.Selected || roomButtons[x, y + 1].State == BtnState.Selected)
                {
                    return true;
                }
            }
            else if (x == DungeonDimension - 1)
            {
                if (y == DungeonDimension - 1)
                {
                    if (roomButtons[x, y - 1].State == BtnState.Selected || roomButtons[x - 1, y].State == BtnState.Selected)
                    {
                        return true;
                    }
                }
                else if (roomButtons[x - 1, y].State == BtnState.Selected || roomButtons[x, y + 1].State == BtnState.Selected || roomButtons[x, y - 1].State == BtnState.Selected)
                {
                    return true;
                }
            }
            else if (y == DungeonDimension - 1)
            {
                if (x == DungeonDimension - 1)
                {
                    if (roomButtons[x, y - 1].State == BtnState.Selected || roomButtons[x - 1, y].State == BtnState.Selected)
                    {
                        return true;
                    }
                }
                else if (roomButtons[x - 1, y].State == BtnState.Selected || roomButtons[x + 1, y].State == BtnState.Selected || roomButtons[x, y - 1].State == BtnState.Selected)
                {
                    return true;
                }
            }
            else if (roomButtons[x - 1, y].State == BtnState.Selected || roomButtons[x, y - 1].State == BtnState.Selected || roomButtons[x + 1, y].State == BtnState.Selected || roomButtons[x, y + 1].State == BtnState.Selected)
            {
                    return true;
            }
            return false;
        }


	}
}
