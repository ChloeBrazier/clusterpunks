using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WarrenWarriorsGame
{
    class Inventory
    {
		private Item[,] items = new Item[3,4]; 
		private SelectedState selected = SelectedState.deselected;
		private int SelectedItemX = -1;
		private int SelectedItemY = -1;

		private Button[,] invButtons = new Button[3,4];
		

		public Inventory(Game g)
		{
			int itemdrops;

			bool dropstick;
			bool dropmatch;
			bool dropnail;
			do //drops between 5 and 8 total items and at least one of the three generic items implemented for testing
			{ //--temporary--//
				itemdrops = 0;
				dropstick = false;
				dropnail = false;
				dropmatch = false;
				for (int j = 0; j < 3; j++)
				{
					for (int k = 0; k < 3; k++)
					{
						int r = Config.getRandom(0, 10);
						Item temp = Item.Empty;

						switch (r) //randomly generates items for the players to have as starting items
						{
							case 0:
								temp = Item.Stick;
								itemdrops += 1;
								dropstick = true;
								break;
							case 1:
								temp = Item.Nails;
								dropnail = true;
								itemdrops += 1;
								break;
							case 2:
								temp = Item.Matches;
								itemdrops += 1;
								dropmatch = true;
								break;
						}

						items[j, k] = temp;
					}
				}
			} while (!(itemdrops > 5 && itemdrops < 8) || (!dropstick || !dropnail || !dropmatch));
			
			//initialize an array of buttons for mouse controls with the x and y of the buttons corresponding directly to their items
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 4; k++)
				{
					if (k < 2) //determines if the button is in the first row and initializes
					{
						invButtons[j, k] = new Button(g.Content.Load<Texture2D>("btnNormal"), g.Content.Load<Texture2D>("btnHovered"), g.Content.Load<Texture2D>("btnClicked"), new Rectangle(10 + 60*k +j*130,300,50,50));
					}
					else
					{
						invButtons[j, k] = new Button(g.Content.Load<Texture2D>("btnNormal"), g.Content.Load<Texture2D>("btnHovered"), g.Content.Load<Texture2D>("btnClicked"), new Rectangle(10 + 60 * (k-2) + j*130, 360, 50, 50));
					}




				}
			}

		}


        public void update(KeyboardState kbState, KeyboardState PrevkbState,MouseState mState)
        {
			switch(selected)
			{
				case SelectedState.deselected:
					
					//First characters inventory
					if(Config.singelKeyPress(Keys.Q,kbState,PrevkbState))
					{
						SelectedItemX = 0;
						SelectedItemY = 0;
						selected = SelectedState.selected;
					}

					if(Config.singelKeyPress(Keys.W,kbState,PrevkbState))
					{
						SelectedItemX = 0;
						SelectedItemY = 1;
						selected = SelectedState.selected;

					}

					if(Config.singelKeyPress(Keys.A,kbState,PrevkbState))
					{
						SelectedItemX = 0;
						SelectedItemY = 2;
						selected = SelectedState.selected;
					}

					if(Config.singelKeyPress(Keys.S,kbState,PrevkbState))
					{
						SelectedItemX = 0;
						SelectedItemY = 3;
						selected = SelectedState.selected;
					}

					//second characters inventory
					if(Config.singelKeyPress(Keys.E,kbState,PrevkbState))
					{
						SelectedItemX = 1;
						SelectedItemY = 0;
						selected = SelectedState.selected;
					}

					if(Config.singelKeyPress(Keys.R,kbState,PrevkbState))
					{
						SelectedItemX = 1;
						SelectedItemY = 1;
						selected = SelectedState.selected;
					}

					if(Config.singelKeyPress(Keys.D,kbState,PrevkbState))
					{
						SelectedItemX = 1;
						SelectedItemY = 2;
						selected = SelectedState.selected;
					}

					if(Config.singelKeyPress(Keys.F,kbState,PrevkbState))
					{
						SelectedItemX = 1;
						SelectedItemY = 3;
						selected = SelectedState.selected;
					}

					//third characters inventory
					if(Config.singelKeyPress(Keys.T,kbState,PrevkbState))
					{
						SelectedItemX = 2;
						SelectedItemY = 0;
						selected = SelectedState.selected;
					}

					if(Config.singelKeyPress(Keys.Y,kbState,PrevkbState))
					{
						SelectedItemX = 2;
						SelectedItemY = 1;
						selected = SelectedState.selected;
					}

					if(Config.singelKeyPress(Keys.G,kbState,PrevkbState))
					{
						SelectedItemX = 2;
						SelectedItemY = 2;
						selected = SelectedState.selected;
					}

					if(Config.singelKeyPress(Keys.H,kbState,PrevkbState))
					{
						SelectedItemX = 2;
						SelectedItemY = 3;
						selected = SelectedState.selected;
					}


					for (int j = 0; j < 3; j++)
					{
						for (int k = 0; k < 4; k++)
						{
							if (invButtons[j, k].update(mState) == true)
							{
								selected = SelectedState.selected;
								SelectedItemX = j;
								SelectedItemY = k;
							}


						}
					}

							break;
				case SelectedState.selected:
					//first char inv
					if(Config.singelKeyPress(Keys.Q,kbState,PrevkbState))
					{
						Swap(0,0);
						selected = SelectedState.deselected;

					}
					if (Config.singelKeyPress(Keys.W,kbState,PrevkbState))
					{
						Swap(0,1);
						selected = SelectedState.deselected;

					}
					if (Config.singelKeyPress(Keys.A,kbState,PrevkbState))
					{
						Swap(0,2);
						selected = SelectedState.deselected;

					}
					if (Config.singelKeyPress(Keys.S,kbState,PrevkbState))
					{
						Swap(0,3);
						selected = SelectedState.deselected;

					}


					//second char inv
					if (Config.singelKeyPress(Keys.E,kbState,PrevkbState))
					{
						Swap(1,0);
						selected = SelectedState.deselected;

					}
					if (Config.singelKeyPress(Keys.R,kbState,PrevkbState))
					{
						Swap(1,1);
						selected = SelectedState.deselected;

					}
					if (Config.singelKeyPress(Keys.D,kbState,PrevkbState))
					{
						Swap(1,2);
						selected = SelectedState.deselected;

					}
					if (Config.singelKeyPress(Keys.F,kbState,PrevkbState))
					{
						Swap(1,3);
						selected = SelectedState.deselected;

					}

					//third char inv

					if (Config.singelKeyPress(Keys.T,kbState,PrevkbState))
					{
						Swap(2,0);
						selected = SelectedState.deselected;

					}
					if (Config.singelKeyPress(Keys.Y,kbState,PrevkbState))
					{
						Swap(2,1);
						selected = SelectedState.deselected;

					}
					if (Config.singelKeyPress(Keys.G,kbState,PrevkbState))
					{
						Swap(2,2);
						selected = SelectedState.deselected;

					}
					if (Config.singelKeyPress(Keys.H,kbState,PrevkbState))
					{
						Swap(2,3);
						selected = SelectedState.deselected;

					}

					if (Config.singelKeyPress(Keys.Tab, kbState, PrevkbState))
					{
						invButtons[SelectedItemX, SelectedItemY].deselect();
						selected = SelectedState.deselected;

					}

					//handles mouse controls
					for (int j = 0; j < 3; j++)
					{
						for (int k = 0; k < 4; k++)
						{
							if (invButtons[j, k].update(mState) == true)
							{

								invButtons[j, k].deselect();
								invButtons[SelectedItemX, SelectedItemY].deselect();
								selected = SelectedState.deselected;
								Swap(j, k);
							}


						}
					}


					break;
			}
        }

        public void Draw(SpriteBatch sb,SpriteFont font)
        {
            for(int j = 0; j<3; j++)//--temporary, draws text output for the items --//
			{
				for(int k = 0; k<4; k++)
				{
					Vector2 position = new Vector2(30,0);
					position += Config.LineSpacing + j * 5 * Config.LineSpacing + k*Config.LineSpacing;
					Color drawColor = Color.Black;

					if (j == SelectedItemX && k == SelectedItemY && selected == SelectedState.selected)
					{
						position -= new Vector2(5, 0);
						drawColor = Color.DarkBlue;
					}

					sb.DrawString(font, String.Format("{0}: {1}", getKeyName(j,k), Config.getItemName(items[j, k])), position, drawColor);

				}
			}

			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 4; k++)
				{//draws the buttons
					invButtons[j, k].draw(sb);
				}
			}
		}

		private void Swap(int x, int y) //swaps items in the items array with the item that is currently selected
		{
			Item temp = items[x,y];
			items[x,y] = items[SelectedItemX,SelectedItemY];
			items[SelectedItemX,SelectedItemY] = temp;

		}

		private string getKeyName(int x, int y) //gets the names of keys to be displayed
		{
			switch (x)
			{
				case 0:

					switch (y)
					{
						case 0:
							return "Q";
						case 1:
							return "W";
						case 2:
							return "A";
						case 3:
							return "S";

					}


					break;
				case 1:

					switch (y)
					{
						case 0:
							return "E";
						case 1:
							return "R";					
						case 2:
							return "D";
						case 3:
							return "F";



					}


					break;
				case 2:

					switch (y)
					{
						case 0:
							return "T";
						case 1:
							return "Y";
						case 2:
							return "G";
						case 3:
							return "H";



					}


					break;



			}


			return "key not found"; 
		}

		/// <summary>
		/// used to swap the inventory of two characters
		/// </summary>
		/// <param name="char1">the first character</param>
		/// <param name="char2"></param>
		public void CharSwap(int char1, int char2)
		{
			for (int j = 0; j < 4; j++) //swaps the items in each slot of each characters inventory
			{
				Item temp = items[char1, j];
				items[char1, j] = items[char2, j];
				items[char2, j] = temp;

			}

			if (SelectedItemX == char1) //if one of the characters is selected also update the buttons
			{
				invButtons[SelectedItemX, SelectedItemY].deselect();
				SelectedItemX = char2;
				invButtons[SelectedItemX, SelectedItemY].select();

			}
			else if (SelectedItemX == char2)
			{
				invButtons[SelectedItemX, SelectedItemY].deselect();
				SelectedItemX = char1;
				invButtons[SelectedItemX, SelectedItemY].select();
			}


		}
    }
}
