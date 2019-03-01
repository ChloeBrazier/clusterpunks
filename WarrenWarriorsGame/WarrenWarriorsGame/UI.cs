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
    class UI
    {
        //Declare variables.
        protected List<Texture2D> iconStorage;
        Game coolGame;

        //Allow us to access the icon storage outside the class just in case.

        public List<Texture2D> IconStorage
        {
            get { return iconStorage; }
        }
        public UI(Game coolGame)
        {
            iconStorage = new List<Texture2D>();
            this.coolGame = coolGame;

        }
        //Store Icon/UI loads in here to make Game1 less messy.
        public void Load()
        {
            //Load each item that will be loaded into inventory slots.
            iconStorage.Add(coolGame.Content.Load<Texture2D>("BladeIcon")); //0
            iconStorage.Add(coolGame.Content.Load<Texture2D>("HandleIcon")); //1
            iconStorage.Add(coolGame.Content.Load<Texture2D>("KnifeIcon")); //2

            //Load important information that will be displayed in the UI.
            iconStorage.Add(coolGame.Content.Load<Texture2D>("HealthIcon")); //3
            iconStorage.Add(coolGame.Content.Load<Texture2D>("InventoryIcon")); //4
            iconStorage.Add(coolGame.Content.Load<Texture2D>("BasicUIBackground")); //5
            iconStorage.Add(coolGame.Content.Load<Texture2D>("DefaultAttackIcon")); //6
            iconStorage.Add(coolGame.Content.Load<Texture2D>("btnNormal")); //7
            iconStorage.Add(coolGame.Content.Load<Texture2D>("btnHovered")); //8
        }

        public void DrawUI(SpriteBatch spriteBatch)
        {
            //For player one.

            //Draw the main background.
            spriteBatch.Draw(iconStorage[4], new Rectangle(0, 225, 128, 256), Color.White);

            //Draw the heart icon, Dimensions of the heart are 16 width, 14 height initially, so alter the size ONLY by multiples of those.
            spriteBatch.Draw(iconStorage[3], new Rectangle(5, 300, 32, 28), Color.White);

            //Draw the 4 Inventory slots for player 1.
            spriteBatch.Draw(iconStorage[7], new Rectangle(14, 350, 50, 50), Color.White);
            spriteBatch.Draw(iconStorage[7], new Rectangle(64, 350, 50, 50), Color.White);
            spriteBatch.Draw(iconStorage[7], new Rectangle(14, 400, 50, 50), Color.White);
            spriteBatch.Draw(iconStorage[7], new Rectangle(64, 400, 50, 50), Color.White);


            //For player two.
            //Main background
            spriteBatch.Draw(iconStorage[4], new Rectangle(128, 225, 128, 258), Color.White);

            //Draw health icon.
            spriteBatch.Draw(iconStorage[3], new Rectangle(133, 300, 32, 28), Color.White);

            //4 Inventory slots.

            spriteBatch.Draw(iconStorage[7], new Rectangle(142, 350, 50, 50), Color.White);
            spriteBatch.Draw(iconStorage[7], new Rectangle(192, 350, 50, 50), Color.White);
            spriteBatch.Draw(iconStorage[7], new Rectangle(142, 400, 50, 50), Color.White);
            spriteBatch.Draw(iconStorage[7], new Rectangle(192, 400, 50, 50), Color.White);

            //For player 3.
            //Main Background
            spriteBatch.Draw(iconStorage[4], new Rectangle(256, 225, 128, 256), Color.White);

            //Heart Icon.
            spriteBatch.Draw(iconStorage[3], new Rectangle(261, 300, 32, 28), Color.White);

            //4 Inventory slots.

            spriteBatch.Draw(iconStorage[7], new Rectangle(270, 350, 50, 50), Color.White);
            spriteBatch.Draw(iconStorage[7], new Rectangle(320, 350, 50, 50), Color.White);
            spriteBatch.Draw(iconStorage[7], new Rectangle(270, 400, 50, 50), Color.White);
            spriteBatch.Draw(iconStorage[7], new Rectangle(320, 400, 50, 50), Color.White);





        }
    }
}
