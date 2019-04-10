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
        RoomSelect,
        ControlMenu,
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
        Snotlek,
        PunishedKevin
    }

    public enum Difficulty
    {
        None,
        Easy,
        Medium,
        Hard,
        Boss
    }

	

	/// <summary>
	/// Warren Warriors
	/// John Bateman
	/// Config is a static class that holds several generic methods and items
	/// 3/8/2019
	/// </summary>
	public static class Config
	{

		#region Inventory Buttons

		public const int INV_BUTTON_SIZE = 50;
		public const int INV_BUTTON_SPACE = 10;
		public const int INV_BUTTON_X_LOC = 10;
		public const int INV_BUTTON_Y_LOC = 300;

		public const string INV_BUTTON_NORMAL = "btnNormal";
		public const string INV_BUTTON_HOVERED = "btnHovered";
		public const string INV_BUTTON_CLICKED = "btnClicked";


		#endregion

		#region Crafting Button
		public const int CRAFT_BUTTON_X = 10;
		public const int CRAFT_BUTTON_Y = 420;
		public const int CRAFT_BUTTON_WIDTH = 390;
		public const int CRAFT_BUTTON_HEIGHT = 50;

		public const string CRAFT_BUTTON_NORMAL = "btnCraftNormal";
		public const string CRAFT_BUTTON_HOVERED = "btnCraftHovered";
		public const string CRAFT_BUTTON_CLICKED = "btnCraftSelected";
		#endregion

		#region Player Characters
		public const int PLAYER_BTN_X_POS = 70;
		public const int PLAYER_BTN_Y_POS = 240;
		public const int PLAYER_BTN_SPACING = 140;
		public const int PLAYER_BTN_SIZE = 50;

		public const string PLAYER_BTN_NORMAL = "btnNormal";
		public const string PLAYER_BTN_HOVERED = "btnHovered";
		public const string PLAYER_BTN_CLICKED = "btnClicked";

		public const int PLAYER_AVATAR_WIDTH = 120;
		public const int PLAYER_AVATAR_HEIGHT = 170;

		public const int PLAYER_AVATAR_X_LOC = 10;
		public const int PLAYER_AVATAR_Y_LOC = 60;
		public const int PLAYER_AVATAR_SPACING = 20;

		public const int HEALTH_X_POS = 25;
		public const int HEALTH_Y_POS = 255;
		public const int HEALTH_SPACING = 140;

        #endregion

        #region item Use Icon
        public const int USE_ICON_SIZE = 5;
        public const int USE_ICON_SPACING = 3;
        public const string USE_ICON = "itemUseIcon";
		#endregion

		#region Main Menu Buttons
		public static Point MAIN_MENU_BUTTON_WIDTH = new Point(192, 96);

		public static Point PLAY_BUTTON_XY = new Point(10,100);
		public static Point CONTROL_BUTTON_XY = new Point(10, 200);
		public static Point EXIT_BUTTON_XY = new Point(10, 300);
		


		public const string PLAY_BUTTON_NORM = "btnPlayNormal";
		public const string PLAY_BUTTON_HOVERED = "btnPlayHovered";
		public const string PLAY_BUTTON_CLICKED = "btnPlayClicked";

		public const string CONTROLS_BUTTON_NORM = "btnControlsNormal";
		public const string CONTROLS_BUTTON_HOVERED = "btnControlsHovered";
		public const string CONTROLS_BUTTON_CLICKED = "btnControlsSelected";

		public const string EXIT_BUTTON_NORM = "btnExitNormal";
		public const string EXIT_BUTTON_HOVERED = "btnExitHovered";
		public const string EXIT_BUTTON_CLICKED = "btnExitSelected";

		#endregion


		//random used for random generation
		private static Random rand = new Random();

		public static Vector2 LineSpacing = new Vector2(30, 0);


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
		public static  bool SingleKeyPress(Keys key,KeyboardState kb, KeyboardState pkb)
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
        public static int GetRandom(int min, int max)
		{
			return rand.Next(min, max);
		}

		//gets item names from temporary output
		public static string GetItemName(Item i)
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
