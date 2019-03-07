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
    /// <summary>
    /// Warren Warriors
    /// John
    /// Eddie Brazier
    /// Handles the players inventory as well as crafting
    /// 3/8/2019
    /// </summary>
    class Inventory
    {
		private CraftItem[,] items = new CraftItem[3,4]; 
		private SelectedState selected = SelectedState.deselected;
		private int SelectedItemX = -1;
		private int SelectedItemY = -1;

		private Button[,] invButtons = new Button[3,4];

        private CraftItem selectedToCraft;
        private Button craftButton;
		private SelectedState craftState = SelectedState.deselected;
		

		public Inventory(Game g)
		{
            //drops items for the players
            DropItems();
           
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


			craftButton = new Button(g.Content.Load<Texture2D>("btnNormal"), g.Content.Load<Texture2D>("btnHovered"), g.Content.Load<Texture2D>("btnClicked"), new Rectangle(10,420,390,50));
		}


        public void Update(KeyboardState kbState, KeyboardState PrevkbState,MouseState mState, MouseState prevMsState, PlayerChar[] Units)
        {
            Boolean madeSelection = false;

            //--Temporary--//
            //refills the players inventory
            if(Config.SingleKeyPress(Keys.Down,kbState,PrevkbState))
            {
                DropItems();

            }


			switch(selected)
			{
				case SelectedState.deselected:
					
					//First characters inventory
                    //cannot access when attacking
					if(Config.SingleKeyPress(Keys.Q,kbState,PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						SelectedItemX = 0;
						SelectedItemY = 0;
                        madeSelection = true;

						selected = SelectedState.selected;
					}

					if(Config.SingleKeyPress(Keys.W,kbState,PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						SelectedItemX = 0;
						SelectedItemY = 1;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

					if(Config.SingleKeyPress(Keys.A,kbState,PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						SelectedItemX = 0;
						SelectedItemY = 2;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

					if(Config.SingleKeyPress(Keys.S,kbState,PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						SelectedItemX = 0;
						SelectedItemY = 3;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

					//second characters inventory
                    //cannot access while attacking
					if(Config.SingleKeyPress(Keys.E,kbState,PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						SelectedItemX = 1;
						SelectedItemY = 0;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

					if(Config.SingleKeyPress(Keys.R,kbState,PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						SelectedItemX = 1;
						SelectedItemY = 1;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

					if(Config.SingleKeyPress(Keys.D,kbState,PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						SelectedItemX = 1;
						SelectedItemY = 2;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

					if(Config.SingleKeyPress(Keys.F,kbState,PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						SelectedItemX = 1;
						SelectedItemY = 3;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

					//third characters inventory
                    //cannot access while attacking
					if(Config.SingleKeyPress(Keys.T,kbState,PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						SelectedItemX = 2;
						SelectedItemY = 0;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

					if(Config.SingleKeyPress(Keys.Y,kbState,PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						SelectedItemX = 2;
						SelectedItemY = 1;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

					if(Config.SingleKeyPress(Keys.G,kbState,PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						SelectedItemX = 2;
						SelectedItemY = 2;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

					if(Config.SingleKeyPress(Keys.H,kbState,PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						SelectedItemX = 2;
						SelectedItemY = 3;
						selected = SelectedState.selected;
                        madeSelection = true;
                    }

                    if (madeSelection)
                    {
                        invButtons[SelectedItemX, SelectedItemY].Select();
                    }

					for (int j = 0; j < 3; j++)
					{
						for (int k = 0; k < 4; k++)
						{
							if (invButtons[j, k].Update(mState) == true)
							{
								selected = SelectedState.selected;
								SelectedItemX = j;
								SelectedItemY = k;
							}


						}
					}

					//dont call update for craft button because it cannot be used unless you have already selected an item

							break;
				case SelectedState.selected:
					//first char inv
					if(Config.SingleKeyPress(Keys.Q,kbState,PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						Swap(0,0);
						selected = SelectedState.deselected;

					}
					if (Config.SingleKeyPress(Keys.W,kbState,PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						Swap(0,1);
						selected = SelectedState.deselected;

					}
					if (Config.SingleKeyPress(Keys.A,kbState,PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						Swap(0,2);
						selected = SelectedState.deselected;

					}
					if (Config.SingleKeyPress(Keys.S,kbState,PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						Swap(0,3);
						selected = SelectedState.deselected;

					}


					//second char inv
					if (Config.SingleKeyPress(Keys.E,kbState,PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						Swap(1,0);
						selected = SelectedState.deselected;

					}
					if (Config.SingleKeyPress(Keys.R,kbState,PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						Swap(1,1);
						selected = SelectedState.deselected;

					}
					if (Config.SingleKeyPress(Keys.D,kbState,PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						Swap(1,2);
						selected = SelectedState.deselected;

					}
					if (Config.SingleKeyPress(Keys.F,kbState,PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						Swap(1,3);
						selected = SelectedState.deselected;

					}

					//third char inv

					if (Config.SingleKeyPress(Keys.T,kbState,PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						Swap(2,0);
						selected = SelectedState.deselected;

					}
					if (Config.SingleKeyPress(Keys.Y,kbState,PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						Swap(2,1);
						selected = SelectedState.deselected;

					}
					if (Config.SingleKeyPress(Keys.G,kbState,PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						Swap(2,2);
						selected = SelectedState.deselected;

					}
					if (Config.SingleKeyPress(Keys.H,kbState,PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						Swap(2,3);
						selected = SelectedState.deselected;

					}

                    //deselects any selected items?
					if (Config.SingleKeyPress(Keys.Tab, kbState, PrevkbState))
					{
						invButtons[SelectedItemX, SelectedItemY].Deselect();
						selected = SelectedState.deselected;
						foreach (Button b in invButtons)
						{
							b.Deselect();
						}

					}

                    //initiate an attack with a selected item if the space bar is pressed
                    //or if the right mouse button is clicked
                    if (Config.SingleKeyPress(Keys.Space, kbState, PrevkbState) || Config.SingleRightMouseClick(mState, prevMsState))
                    {
                        //create an item object to send to a given character's attack method
                        CraftItem usedItem = items[SelectedItemX, SelectedItemY];

                        //deselect the item so the slot isn't selected after an attack executes
                        invButtons[SelectedItemX, SelectedItemY].Deselect();
                        selected = SelectedState.deselected;

                        //party member attacks based on the selected item's x value
                        //start the party member's attack and set isAttacking to true
                        Units[SelectedItemX].IsAttacking = Units[SelectedItemX].Atk.StartAttack(items, usedItem, SelectedItemX, SelectedItemY);
                    }

					//handles mouse controls
					for (int j = 0; j < 3; j++)
					{
						for (int k = 0; k < 4; k++)
						{
							if (invButtons[j, k].Update(mState) == true)
							{

								invButtons[j, k].Deselect();
								invButtons[SelectedItemX, SelectedItemY].Deselect();
								selected = SelectedState.deselected;
								Swap(j, k);
							}


						}
					}

					//Handles crafting controls
					if(craftButton.Update(mState) || Config.SingleKeyPress(Keys.LeftShift,kbState,PrevkbState) || Config.SingleKeyPress(Keys.RightShift,kbState,PrevkbState))
					{
						switch (craftState)
						{
							case SelectedState.deselected:
								selectedToCraft = items[SelectedItemX, SelectedItemY];
								items[SelectedItemX, SelectedItemY] = new CraftItem(Item.Empty);

								craftState = SelectedState.selected;
								craftButton.Deselect();

								break;
							case SelectedState.selected:
								items[SelectedItemX, SelectedItemY] = new CraftItem(items[SelectedItemX, SelectedItemY], selectedToCraft);

								craftState = SelectedState.deselected;
								craftButton.Deselect();

								break;


						}
						selected = SelectedState.deselected;
						invButtons[SelectedItemX, SelectedItemY].Deselect();

					}


					break;
			}

        }

        public void Draw(SpriteBatch sb,SpriteFont font,UI uI)
        {
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 4; k++)
				{//draws the buttons
					invButtons[j, k].Draw(sb);

                    //draws the ui icons to their resepective buttons
                    Rectangle drawpos = new Rectangle(invButtons[j, k].Location.Left+5, invButtons[j, k].Location.Top+5, invButtons[j, k].Location.Width-10, invButtons[j, k].Location.Height-10);
                    sb.Draw(uI.IconStorage[items[j, k].ItemType],drawpos , Color.White);

				}
			}
            
			craftButton.Draw(sb);
		}

		private void Swap(int x, int y) //swaps items in the items array with the item that is currently selected
		{
            invButtons[SelectedItemX, SelectedItemY].Deselect();
            invButtons[x, y].Deselect();

			CraftItem temp = items[x,y];
			items[x,y] = items[SelectedItemX,SelectedItemY];
			items[SelectedItemX,SelectedItemY] = temp;

		}

		private string GetKeyName(int x, int y) //gets the names of keys to be displayed
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
				CraftItem temp = items[char1, j];
				items[char1, j] = items[char2, j];
				items[char2, j] = temp;

			}

			if (SelectedItemX == char1) //if one of the characters is selected also update the buttons
			{
				invButtons[SelectedItemX, SelectedItemY].Deselect();
				SelectedItemX = char2;
				invButtons[SelectedItemX, SelectedItemY].Select();

			}
			else if (SelectedItemX == char2)
			{
				invButtons[SelectedItemX, SelectedItemY].Deselect();
				SelectedItemX = char1;
				invButtons[SelectedItemX, SelectedItemY].Select();
			}


		}

        /// <summary>
        /// drops items to the player
        /// </summary>
        public void DropItems()
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
                    for (int k = 0; k < 4; k++)
                    {
                        int r = Config.GetRandom(0, 10);
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

                        items[j, k] = new CraftItem(temp);
                    }
                }
            } while (!(itemdrops > 5 && itemdrops < 8) || (!dropstick || !dropnail || !dropmatch));
        }
    }
}