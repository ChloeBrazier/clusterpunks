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
		Item[,] items = new Item[3,4]; 
		SelectedState selected = SelectedState.deselected;
		int SelectedItemX = -1;
		int SelectedItemY = -1;

		public Inventory()
		{
			for(int j = 0;j<3;j++)
			{
				for (int k = 0; k<3;k++)
				{
					int r = Config.getRandom(0,10);
					Item temp = Item.Empty;

					switch(r) //randomly generates items for the players to have as starting items
					{
						case 0:
							temp = Item.Stick;
							break;
						case 1:
							temp = Item.Nails;
							break;
						case 2:
							temp = Item.Matches;
							break;
					}

					items[j,k] = temp;
				}
			}


		}


        public void update(KeyboardState kbState, KeyboardState PrevkbState)
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


					break;
				case SelectedState.selected:
					//first char inv
					if(Config.singelKeyPress(Keys.Q,kbState,PrevkbState))
					{
						Swap(0,0);
					}
					if(Config.singelKeyPress(Keys.W,kbState,PrevkbState))
					{
						Swap(0,1);
					}
					if(Config.singelKeyPress(Keys.A,kbState,PrevkbState))
					{
						Swap(0,2);
					}
					if(Config.singelKeyPress(Keys.S,kbState,PrevkbState))
					{
						Swap(0,3);
					}


					//second char inv
					if(Config.singelKeyPress(Keys.E,kbState,PrevkbState))
					{
						Swap(1,0);
					}
					if(Config.singelKeyPress(Keys.R,kbState,PrevkbState))
					{
						Swap(1,1);
					}
					if(Config.singelKeyPress(Keys.D,kbState,PrevkbState))
					{
						Swap(1,2);
					}
					if(Config.singelKeyPress(Keys.F,kbState,PrevkbState))
					{
						Swap(1,3);
					}

					//third char inv

					if(Config.singelKeyPress(Keys.T,kbState,PrevkbState))
					{
						Swap(2,0);
					}
					if(Config.singelKeyPress(Keys.Y,kbState,PrevkbState))
					{
						Swap(2,1);
					}
					if(Config.singelKeyPress(Keys.G,kbState,PrevkbState))
					{
						Swap(2,2);
					}
					if(Config.singelKeyPress(Keys.H,kbState,PrevkbState))
					{
						Swap(2,3);
					}

					break;
			}
        }

        public void Draw(SpriteBatch sb,SpriteFont font)
        {
            for(int j = 0; j<3; j++)
			{
				for(int k = 0; k<4; k++)
				{
					


				}


			}
        }

		private void Swap(int x, int y) //swaps items in the items array
		{
			Item temp = items[x,y];
			items[x,y] = items[SelectedItemX,SelectedItemY];
			items[SelectedItemX,SelectedItemY] = temp;

		}

    }
}
