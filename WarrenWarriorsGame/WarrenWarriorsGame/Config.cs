using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Warren Warriors
/// Eddie Brazier
/// static class that holds methods used throughout most other classes
/// 3/8/2019
/// </summary>
namespace WarrenWarriorsGame
{
    //enum for game states
    public enum GameState
    {
        Menu,
        Combat,
        GameOver
    }

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
	public enum SelectedState //finite state machine used for moving around characters
	{
		selected,
		deselected
	}

    public enum BtnState//used for the buttons in 
    {
        Default,
        Hovered,
        Selected
    }

    //enum used to determine enemy stats during enemy creation
    public enum EnemyType
    {
        Buckshot,
        SewCrow,
        Bandit,
        Custom
    }

    /// <summary>
    /// Warren Warriors
    /// John Bateman
    /// Config is a static class that holds several generic methods and items
    /// 3/8/2019
    /// </summary>
	public static class Config
	{

		//random used for random generation
		private static Random rand = new Random();

		public static Vector2 LineSpacing = new Vector2(0,14);


        public static CraftItem[] AllItems = {new CraftItem(Item.Empty),
                                                new CraftItem(Item.Stick),new CraftItem(Item.Matches),new CraftItem(Item.Nails),
                                                new CraftItem(Item.Torch), new CraftItem(Item.HotNails),new CraftItem(Item.SpikeBat),
                                                new CraftItem(Item.SpikeTorch)
                                                };

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

		//determines if this is the first frame the left mouse button is down
		public static bool SingleMouseClick(MouseState mouseState, MouseState prevMouseState)
		{
			if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
			{
				return true;
			}
			return false;

		}

        //determines if this is the first frame the right mouse button is down
        public static bool SingleRightMouseClick(MouseState mouseState, MouseState prevMouseState)
        {
            if (mouseState.RightButton == ButtonState.Pressed && prevMouseState.RightButton == ButtonState.Released)
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

		//gets item names from temporary output
		public static string getItemName(Item i)
		{
			switch( i)
			{
				case Item.Empty:
					return "(Empty)";
					break;
				case Item.Matches:
					return "Matches";
					break;
				case Item.Nails:
					return "Nails";
					break;
				case Item.Stick:
					return "Stick";
					break;
				case Item.SpikeBat:
					return "Spike Bat";
					break;
				case Item.Torch:
					return "Torch";
					break;
				case Item.HotNails:
					return "Hot Nails";
					break;
				case Item.SpikeTorch:
					return "Spike Torch";
					break;
				

			}

			return "Item Name Not Found";
		}


        
	}
}
