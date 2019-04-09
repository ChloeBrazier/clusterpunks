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
    public class UI
    {
        //Declare variables.

        //dictionary field for item UI
        private Dictionary<Item, Texture2D> iconStorage;

        //separate List field for general game UI
        private List<Texture2D> gameUI;

        Game coolGame;

        //Allow us to access the icon storage outside the class just in case.

        public Dictionary<Item, Texture2D> IconStorage
        {
            get { return iconStorage; }
        }

        //accessor for game UI list
        public List<Texture2D> GameUI
        {
            get
            {
                return gameUI;
            }
        }

        public UI(Game coolGame)
        {
            iconStorage = new Dictionary<Item, Texture2D>();
            gameUI = new List<Texture2D>();
            this.coolGame = coolGame;

        }
        //Store Icon/UI loads in here to make Game1 less messy.
        public void Load()
        {
            //Load each item that will be loaded into inventory slots.
            //add each item to the icon storage dictionary with enum keys and texture values
            iconStorage.Add(Item.Empty, coolGame.Content.Load<Texture2D>("NewDefaultAttackSprite"));
            iconStorage.Add(Item.Nails, coolGame.Content.Load<Texture2D>("NewBladeIcon"));
            iconStorage.Add(Item.Stick, coolGame.Content.Load<Texture2D>("NewHandleIcon"));
            iconStorage.Add(Item.SpikeBat, coolGame.Content.Load<Texture2D>("NewKnifeIcon"));
            iconStorage.Add(Item.SpikeTorch, coolGame.Content.Load<Texture2D>("NewHotKnifeSprite"));
            iconStorage.Add(Item.Matches, coolGame.Content.Load<Texture2D>("NewMatchSprite"));
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

        public void DrawUI(SpriteBatch spriteBatch)
        {
            //For player one.

            //Draw the main background.
            spriteBatch.Draw(gameUI[2], new Rectangle(0, 225, 128, 256), Color.White);

            //Draw the heart icon, Dimensions of the heart are 16 width, 14 height initially, so alter the size ONLY by multiples of those.
            spriteBatch.Draw(gameUI[0], new Rectangle(5, 300, 32, 28), Color.White);

            //For player two.
            //Main background
            spriteBatch.Draw(gameUI[2], new Rectangle(128, 225, 128, 258), Color.White);

            //Draw health icon.
            spriteBatch.Draw(gameUI[0], new Rectangle(133, 300, 32, 28), Color.White);

            

            //For player 3.
            //Main Background
            spriteBatch.Draw(gameUI[2], new Rectangle(256, 225, 128, 256), Color.White);

            //Heart Icon.
            spriteBatch.Draw(gameUI[0], new Rectangle(261, 300, 32, 28), Color.White);

            
        }
    }
}

