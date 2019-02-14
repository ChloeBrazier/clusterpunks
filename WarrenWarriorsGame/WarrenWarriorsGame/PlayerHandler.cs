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
	public class PlayerHandler
	{
		SpriteFont text;

		int selectedChar; //holds the position of the selected char
		SelectedState Swap = SelectedState.deselected; //gamestate used for if youre swapping characters
		Unit[] Units = new Unit[3]; //holds the units that will be displayed on screen

		Inventory playerInv;

		public PlayerHandler(SpriteFont font)
		{
			//initializes the inventory of the player
			playerInv = new Inventory();

			//initializes the base units
			Units[0] = new PlayerChar(font, CharType.Heavy);
			Units[1] = new PlayerChar(font, CharType.Medium);
			Units[2] = new PlayerChar(font, CharType.Light);

			text = font;
		}

		public void update(KeyboardState kbState,KeyboardState PrevkbState)
		{
			switch (Swap)
			{
				case SelectedState.deselected:
					if (Config.singelKeyPress(Keys.NumPad1, kbState, PrevkbState) || Config.singelKeyPress(Keys.D1, kbState, PrevkbState))
					{
						selectedChar = 0;
						Swap = SelectedState.selected;
					}
					if (Config.singelKeyPress(Keys.NumPad2, kbState, PrevkbState) || Config.singelKeyPress(Keys.D2, kbState, PrevkbState))
					{
						selectedChar = 1;
						Swap = SelectedState.selected;
					}
					if (Config.singelKeyPress(Keys.NumPad3, kbState, PrevkbState) || Config.singelKeyPress(Keys.D3, kbState, PrevkbState))
					{
						selectedChar = 2;
						Swap = SelectedState.selected;
					}

					break;
				case SelectedState.selected:

					if (Config.singelKeyPress(Keys.NumPad1, kbState, PrevkbState) || Config.singelKeyPress(Keys.D1, kbState, PrevkbState))
					{
						SwapUnits(selectedChar, 0);
						playerInv.CharSwap(selectedChar, 0);
						Swap = SelectedState.deselected;
					}
					if (Config.singelKeyPress(Keys.NumPad2, kbState, PrevkbState) || Config.singelKeyPress(Keys.D2, kbState, PrevkbState))
					{
						SwapUnits(selectedChar, 1);
						playerInv.CharSwap(selectedChar, 1);
						Swap = SelectedState.deselected;
					}
					if (Config.singelKeyPress(Keys.NumPad3, kbState, PrevkbState) || Config.singelKeyPress(Keys.D3, kbState, PrevkbState))
					{
						SwapUnits(selectedChar, 2);
						playerInv.CharSwap(selectedChar, 2);
						Swap = SelectedState.deselected;
					}
					break;


			}

			playerInv.update(kbState, PrevkbState);

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			for (int j = 0; j < Units.Length; j++)
			{
				Color drawcolor = Color.Black;

				Units[j].Draw(spriteBatch, j);

				if (j == selectedChar && Swap == SelectedState.selected)
				{
					drawcolor = Color.MonoGameOrange;
				}

				spriteBatch.DrawString(text, string.Format("{0}:   ", j + 1), j * 5 * Config.LineSpacing, drawcolor);

			}

			playerInv.Draw(spriteBatch, text);
		}



		private void SwapUnits(int pos1, int pos2)
		{
			Unit temp = Units[pos1];
			Units[pos1] = Units[pos2];
			Units[pos2] = temp;

		}


	}
}
