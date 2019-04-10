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
/// Noah Hulick
/// Class that holds icons for inventory (i.e items), or elements/images to be displayed on the UI.
/// </summary>
namespace WarrenWarriorsGame
{
    public static class UI
    {
        //Declare variables.

        //dictionary field for item UI
        static private Dictionary<Item, Texture2D> iconStorage;

        //separate List field for general game UI
        static private List<Texture2D> gameUI;

        static private Game coolGame;

        //Allow us to access the icon storage outside the class just in case.

        public static Dictionary<Item, Texture2D> IconStorage
        {
            get { return iconStorage; }
        }

        //accessor for game UI list
        public static List<Texture2D> GameUI
        {
            get
            {
                return gameUI;
            }
        }

        public static void Initialize(Game game)
        {
            iconStorage = new Dictionary<Item, Texture2D>();
            gameUI = new List<Texture2D>();
            coolGame = game;

        }
        //Store Icon/UI loads in here to make Game1 less messy.
        public static void Load()
        {
            //Load each item that will be loaded into inventory slots.
            //add each item to the icon storage dictionary with enum keys and texture values
            iconStorage.Add(Item.Empty, coolGame.Content.Load<Texture2D>("NewDefaultAttackSprite"));
            iconStorage.Add(Item.Nails, coolGame.Content.Load<Texture2D>("NewBladeIcon"));
            iconStorage.Add(Item.Stick, coolGame.Content.Load<Texture2D>("NewHandleIcon"));
            iconStorage.Add(Item.SpikeBat, coolGame.Content.Load<Texture2D>("NewKnifeIcon"));
            iconStorage.Add(Item.SpikeTorch, coolGame.Content.Load<Texture2D>("NewHotKnifeSprite"));
            iconStorage.Add(Item.Matches, coolGame.Content.Load<Texture2D>("BasicMatchSprite"));
            iconStorage.Add(Item.Torch, coolGame.Content.Load<Texture2D>("NewTorchSprite"));
            iconStorage.Add(Item.HotNails, coolGame.Content.Load<Texture2D>("HotBladeIcon"));
            
             

            //Load important information that will be displayed in the UI.
            gameUI.Add(coolGame.Content.Load<Texture2D>("HealthIcon")); //0
            gameUI.Add(coolGame.Content.Load<Texture2D>("InventoryIcon")); //1
            gameUI.Add(coolGame.Content.Load<Texture2D>("BasicUIBackground")); //2
            gameUI.Add(coolGame.Content.Load<Texture2D>("NewDefaultAttackSprite")); //3
            gameUI.Add(coolGame.Content.Load<Texture2D>("btnNormal")); //4
            gameUI.Add(coolGame.Content.Load<Texture2D>("btnHovered")); //5
            gameUI.Add(coolGame.Content.Load<Texture2D>("timer_icon")); //6
            gameUI.Add(coolGame.Content.Load<Texture2D>("game_background_prototype")); //7
        }

        
    }
}

