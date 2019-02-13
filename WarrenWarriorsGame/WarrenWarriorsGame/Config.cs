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
	public enum CharType //used for generic character generation
	{
		Heavy,
		Medium,
		Light
	}

	public enum Item //item enum, can be edited later
	{
		Empty,
		Stick,
		Nails,
		Matches,
		Torch,
		SpikeBat,
		HotNails,
		SpikeTorch

	}
	public enum CharSwapState //finite state machine used for moving around characters
	{
		selected,
		deselected
	}

	public static class Config
	{

		//random used for random generation
		private static Random rand = new Random();

		public static Vector2 LineSpacing = new Vector2(0,14);

		/// <summary>
		/// Determines if this is the first frame the sent key is down
		/// </summary>
		/// <param name="key"> the key that has been sent</param>
		/// <param name="kb">The Current keyboard state</param>
		/// <param name="pkb">The Previous keyboard state</param>
		/// <returns>true if this is the first frame the key is down</returns>
		public static  bool singelKeyPress(Keys key,KeyboardState kb, KeyboardState pkb)
		{
			if (kb.IsKeyDown(key) && pkb.IsKeyUp(key))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Gets a random integer between min and max
		/// </summary>
		/// <param name="min">The inclusive lower bound</param>
		/// <param name="max">The Exclusive Upper Bound</param>
		/// <returns></returns>
		public static int getRandom(int min, int max)
		{
			return rand.Next(min, max);
		}

	}
}
