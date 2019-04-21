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
    public class Inventory
    {
		private CraftItem[,] items = new CraftItem[3,4]; 
		private SelectedState selected = SelectedState.deselected;
		private int SelectedItemX = -1;
		private int SelectedItemY = -1;

		private Button[,] invButtons = new Button[3,4];

        private CraftItem selectedToCraft;
        private Button craftButton;
        private Button AttackButton;
		private SelectedState craftState = SelectedState.deselected;
        private Texture2D useIcon;
		

		public Inventory(Game g)
		{
            

            //initialize an array of buttons for mouse controls with the x and y of the buttons corresponding directly to their items
            for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 4; k++)
				{
					if (k < 2) //determines if the button is in the first row and initializes
					{
						invButtons[j, k] = new Button(g.Content.Load<Texture2D>(Config.INV_BUTTON_NORMAL), g.Content.Load<Texture2D>(Config.INV_BUTTON_HOVERED), g.Content.Load<Texture2D>(Config.INV_BUTTON_CLICKED),
							new Rectangle(Config.INV_BUTTON_X_LOC + (Config.INV_BUTTON_SIZE + Config.INV_BUTTON_SPACE) * k + j * 2 * (2 * Config.INV_BUTTON_SPACE + Config.INV_BUTTON_SIZE), //x position
							Config.INV_BUTTON_Y_LOC, //y position
							Config.INV_BUTTON_SIZE, Config.INV_BUTTON_SIZE)); //width and height
					}
					else
					{
						invButtons[j, k] = new Button(g.Content.Load<Texture2D>(Config.INV_BUTTON_NORMAL), g.Content.Load<Texture2D>(Config.INV_BUTTON_HOVERED), g.Content.Load<Texture2D>(Config.INV_BUTTON_CLICKED),
							new Rectangle(Config.INV_BUTTON_X_LOC + (Config.INV_BUTTON_SIZE + Config.INV_BUTTON_SPACE) * (k-2) + j* 2 * (2 * Config.INV_BUTTON_SPACE + Config.INV_BUTTON_SIZE), //x position
							Config.INV_BUTTON_Y_LOC + (Config.INV_BUTTON_SIZE+Config.INV_BUTTON_SPACE), //y position
							Config.INV_BUTTON_SIZE, Config.INV_BUTTON_SIZE)); //widht and height
					}


					items[j, k] = new CraftItem(Item.Empty); //initialize the array

				}
			}

            useIcon = g.Content.Load<Texture2D>(Config.USE_ICON);


			//drops items for the players
			DropItems(5, 8);

			craftButton = new Button(g.Content.Load<Texture2D>(Config.CRAFT_BUTTON_NORMAL), g.Content.Load<Texture2D>(Config.CRAFT_BUTTON_HOVERED), g.Content.Load<Texture2D>(Config.CRAFT_BUTTON_CLICKED), new Rectangle(Config.CRAFT_BUTTON_X,Config.CRAFT_BUTTON_Y,Config.CRAFT_BUTTON_WIDTH,Config.CRAFT_BUTTON_HEIGHT));
            AttackButton = new Button(g.Content.Load<Texture2D>(Config.CRAFT_BUTTON_NORMAL), g.Content.Load<Texture2D>(Config.CRAFT_BUTTON_HOVERED), g.Content.Load<Texture2D>(Config.CRAFT_BUTTON_CLICKED), new Rectangle(Config.CRAFT_BUTTON_X + 5 + Config.CRAFT_BUTTON_WIDTH, Config.CRAFT_BUTTON_Y, Config.CRAFT_BUTTON_WIDTH, Config.CRAFT_BUTTON_HEIGHT));
        }

        
        public void Update(KeyboardState kbState, KeyboardState PrevkbState,MouseState mState, MouseState prevMsState, PlayerChar[] Units)
        {
            Boolean madeSelection = false;

            //--Temporary--//
            //refills the players inventory
            if(Config.SingleKeyPress(Keys.Down,kbState,PrevkbState))
            {
                DropItems(5,8);

            }


            switch (selected)
			{
				case SelectedState.deselected:

					#region player keyboard controls
					//First characters inventory
					//cannot access when attacking
					if (Config.SingleKeyPress(Keys.Q, kbState, PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						SelectedItemX = 0;
						SelectedItemY = 0;
						madeSelection = true;

						selected = SelectedState.selected;
					}
					else if (Config.SingleKeyPress(Keys.W, kbState, PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						SelectedItemX = 0;
						SelectedItemY = 1;
						selected = SelectedState.selected;
						madeSelection = true;
					}
					else if (Config.SingleKeyPress(Keys.A, kbState, PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						SelectedItemX = 0;
						SelectedItemY = 2;
						selected = SelectedState.selected;
						madeSelection = true;
					}
					else if (Config.SingleKeyPress(Keys.S, kbState, PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
					{
						SelectedItemX = 0;
						SelectedItemY = 3;
						selected = SelectedState.selected;
						madeSelection = true;
					}
					//second characters inventory
					//cannot access while attacking
					else if (Config.SingleKeyPress(Keys.E, kbState, PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						SelectedItemX = 1;
						SelectedItemY = 0;
						selected = SelectedState.selected;
						madeSelection = true;
					}
					else if (Config.SingleKeyPress(Keys.R, kbState, PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						SelectedItemX = 1;
						SelectedItemY = 1;
						selected = SelectedState.selected;
						madeSelection = true;
					}
					else if (Config.SingleKeyPress(Keys.D, kbState, PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						SelectedItemX = 1;
						SelectedItemY = 2;
						selected = SelectedState.selected;
						madeSelection = true;
					}
					else if (Config.SingleKeyPress(Keys.F, kbState, PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
					{
						SelectedItemX = 1;
						SelectedItemY = 3;
						selected = SelectedState.selected;
						madeSelection = true;
					}
					//third characters inventory
					//cannot access while attacking
					else if (Config.SingleKeyPress(Keys.T, kbState, PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						SelectedItemX = 2;
						SelectedItemY = 0;
						selected = SelectedState.selected;
						madeSelection = true;
					}
					else if (Config.SingleKeyPress(Keys.Y, kbState, PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						SelectedItemX = 2;
						SelectedItemY = 1;
						selected = SelectedState.selected;
						madeSelection = true;
					}
					else if (Config.SingleKeyPress(Keys.G, kbState, PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
					{
						SelectedItemX = 2;
						SelectedItemY = 2;
						selected = SelectedState.selected;
						madeSelection = true;
					}
					else if (Config.SingleKeyPress(Keys.H, kbState, PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
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
                    #endregion

                    for (int j = 0; j < 3; j++)
					{
						for (int k = 0; k < 4; k++)
						{
							if (!Units[j].IsAttacking && invButtons[j, k].Update(mState) == true) //player inv is locked when attacking
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

                    #region Player Keyboard Controls
                    //first char inv
                    if (Config.SingleKeyPress(Keys.Q, kbState, PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
                    {
                        Swap(0, 0);
                        selected = SelectedState.deselected;

                    }
                    else if (Config.SingleKeyPress(Keys.W, kbState, PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
                    {
                        Swap(0, 1);
                        selected = SelectedState.deselected;

                    }
                    else if (Config.SingleKeyPress(Keys.A, kbState, PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
                    {
                        Swap(0, 2);
                        selected = SelectedState.deselected;

                    }
                    else if (Config.SingleKeyPress(Keys.S, kbState, PrevkbState) && Units[0].IsAttacking == false && Units[0].Health > 0)
                    {
                        Swap(0, 3);
                        selected = SelectedState.deselected;

                    }


                    //second char inv
                    else if (Config.SingleKeyPress(Keys.E, kbState, PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
                    {
                        Swap(1, 0);
                        selected = SelectedState.deselected;

                    }
                    else if (Config.SingleKeyPress(Keys.R, kbState, PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
                    {
                        Swap(1, 1);
                        selected = SelectedState.deselected;

                    }
                    else if (Config.SingleKeyPress(Keys.D, kbState, PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
                    {
                        Swap(1, 2);
                        selected = SelectedState.deselected;

                    }
                    else if (Config.SingleKeyPress(Keys.F, kbState, PrevkbState) && Units[1].IsAttacking == false && Units[1].Health > 0)
                    {
                        Swap(1, 3);
                        selected = SelectedState.deselected;

                    }

                    //third char inv

                    else if (Config.SingleKeyPress(Keys.T, kbState, PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
                    {
                        Swap(2, 0);
                        selected = SelectedState.deselected;

                    }
                    else if (Config.SingleKeyPress(Keys.Y, kbState, PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
                    {
                        Swap(2, 1);
                        selected = SelectedState.deselected;

                    }
                    else if (Config.SingleKeyPress(Keys.G, kbState, PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
                    {
                        Swap(2, 2);
                        selected = SelectedState.deselected;

                    }
                    else if (Config.SingleKeyPress(Keys.H, kbState, PrevkbState) && Units[2].IsAttacking == false && Units[2].Health > 0)
                    {
                        Swap(2, 3);
                        selected = SelectedState.deselected;

                    }
                    #endregion

                    //deselects any selected items?
                    if (Config.SingleKeyPress(Keys.Tab, kbState, PrevkbState))
                    {
                        invButtons[SelectedItemX, SelectedItemY].Deselect(); //player inv is locked when attacking
                        selected = SelectedState.deselected;
                        foreach (Button b in invButtons)
                        {
                            b.Deselect();
                        }

                    }


                    //initiate an attack with a selected item if the space bar is pressed
                    //or if the right mouse button is clicked
                    if (Config.SingleKeyPress(Keys.Space, kbState, PrevkbState) || Config.SingleRightMouseClick(mState, prevMsState) || AttackButton.Update(mState))
                    {
                        //create an item object to send to a given character's attack method
                        CraftItem usedItem = items[SelectedItemX, SelectedItemY];

                        //deselect the item so the slot isn't selected after an attack executes
                        invButtons[SelectedItemX, SelectedItemY].Deselect();
                        selected = SelectedState.deselected;

                        //party member attacks based on the selected item's x value
                        //start the party member's attack and set isAttacking to true
                        Units[SelectedItemX].IsAttacking = Units[SelectedItemX].Atk.StartAttack(items, usedItem, SelectedItemX, SelectedItemY);

                        //send info for attack initiation to battle log
                        BattleLog.AddPlayerAttackStart(Units[SelectedItemX]);
                        AttackButton.Deselect();
                    }

                    //handles mouse controls
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            if (Units[j].IsAttacking == false)
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
                    }

                    //Handles crafting controls
                    if (items[SelectedItemX, SelectedItemY].ItemType != Item.Empty && (craftButton.Update(mState) || Config.SingleKeyPress(Keys.LeftShift, kbState, PrevkbState) || Config.SingleKeyPress(Keys.RightShift, kbState, PrevkbState)))
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

        public void Draw(SpriteBatch sb,SpriteFont font)
        {
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 4; k++)
				{//draws the buttons
					invButtons[j, k].Draw(sb);

                    //draws the ui icons to their resepective buttons
                    Rectangle drawpos = new Rectangle(invButtons[j, k].Location.Left+5, invButtons[j, k].Location.Top+5, invButtons[j, k].Location.Width-10, invButtons[j, k].Location.Height-10);
                    sb.Draw(UI.IconStorage[items[j, k].ItemType],drawpos , Color.White);

                    for (int i = 0; i < items[j, k].Duration; i++)
                    {
                        sb.Draw(useIcon,
                            new Rectangle(drawpos.X + 1 + (Config.USE_ICON_SPACING+Config.USE_ICON_SIZE)*i,drawpos.Y + 33,Config.USE_ICON_SIZE,Config.USE_ICON_SIZE)
                            , Color.White);
                    }
				}
			}
            craftButton.Draw(sb);
            AttackButton.Draw(sb);
            
            //If the mouse is hovered over an inventory slot, draw a tooltip.
            MouseState ms = Mouse.GetState();
            Rectangle mouseRect = new Rectangle(ms.X, ms.Y, 1, 1);
			
            for(int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (invButtons[j, k].Location.Intersects(mouseRect))
                    {
                        
                            sb.DrawString(font, items[j,k].ItemInfo, new Vector2(0, 405), Color.White);
                        
                    } 
                }
            }
			if (craftState == SelectedState.selected)
			{
				sb.Draw(UI.IconStorage[selectedToCraft.ItemType], new Rectangle(Config.CRAFT_BUTTON_X + Config.CRAFT_BUTTON_WIDTH / 2 - 20, Config.CRAFT_BUTTON_Y + 10, 40, 40), Color.White);
			}
		}

		private void Swap(int x, int y) //swaps items in the items array with the item that is currently selected
		{
            invButtons[SelectedItemX, SelectedItemY].Deselect();
            invButtons[x, y].Deselect();

			CraftItem temp = items[x,y];
			items[x,y] = items[SelectedItemX,SelectedItemY];
			items[SelectedItemX,SelectedItemY] = temp;

			SelectedItemX = -1;
			SelectedItemY = -1;

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
		/// drops items into the players inventory
		/// </summary>
		/// <param name="min">inclusive minimum number of items to drop</param>
		/// <param name="max">exclusive maximum number of items to drop</param>
        public void DropItems(int min, int max)
        {
            int itemdrops =0;
			int fullSlots;

			bool dropstick;
            bool dropmatch;
			bool dropnail;
           
            
			fullSlots = 0;

			int numToDrop = Config.GetRandom(min, max);
			List<CraftItem> tempItems;

			do
			{
				tempItems = new List<CraftItem>(); //set/reset variables 

				dropstick = false;
				dropnail = false;
				dropmatch = false;

				for (int i = 0; i < numToDrop; i++) //loop through and drop the randomly generated number of items to drop
				{
					int r = Config.GetRandom(0, 3);
					Item temp = Item.Empty;

					switch (r) //randomly generates a list of items to be dropped into the players inventory
					{
						case 0:
							temp = Item.Stick;
							dropstick = true;
							break;
						case 1:
							temp = Item.Nails;
							dropnail = true;
							break;
						case 2:
							temp = Item.Matches;
							dropmatch = true;
							break;
					}

					tempItems.Add(new CraftItem(temp));

				}
			} while ((!dropmatch || !dropstick || !dropnail) && numToDrop >3); //loop if one of the basic components is not in the drop pool 
																			   // does not loop if the number of items to drop is less than three (because then you couldn't get all three

			int j = 0;
			int k = 0; //add the items to the players inventorys
			do
			{
				if (items[j, k].ItemType == Item.Empty)
				{
					items[j, k] = tempItems[itemdrops];
					itemdrops++;
				}
				
				fullSlots++;
				j++;
				if (j > 2)
				{
					j = 0;
					k++;
				}

			} while (itemdrops < tempItems.Count && fullSlots < 10);
            
        }
    }
}