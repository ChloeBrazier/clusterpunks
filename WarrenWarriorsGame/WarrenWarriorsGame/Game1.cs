using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WarrenWarriorsGame
{
    /// <summary>
    /// This is the main type for your game.John Bateman
    /// ive made some more changes
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		KeyboardState kbState;
		KeyboardState PrevkbState;

		int selectedChar; //holds the position of the selected char
		SelectedState Swap = SelectedState.deselected; //gamestate used for if youre swapping characters
		Unit[] Units = new Unit[3]; //holds the units that will be displayed on screen

		Inventory playerInv;

		SpriteFont temp;//the temporary sprite font that we will be using

		public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
			// TODO: Add your initialization logic here

			playerInv = new Inventory();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


			//loads in the temporary font
			temp = Content.Load<SpriteFont>("Arial-12");


			//initializes the base units
			Units[0] = new PlayerChar(temp, CharType.Heavy);
			Units[1] = new PlayerChar(temp, CharType.Medium);
			Units[2] = new PlayerChar(temp, CharType.Light);
			// TODO: use this.Content to load your game content here
		}

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here
			kbState = Keyboard.GetState();

			//handles the swapping of characters (could be moved into a unique class/ method later
			switch (Swap)
			{
				case SelectedState.deselected:
					if (Config.singelKeyPress(Keys.NumPad1, kbState, PrevkbState) || Config.singelKeyPress(Keys.D1,kbState,PrevkbState))
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


			PrevkbState = kbState;
			base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

			// TODO: Add your drawing code here
			spriteBatch.Begin();

			for (int j = 0; j < Units.Length; j++)
			{
				Color drawcolor = Color.Black;

				Units[j].Draw(spriteBatch, j);

				if (j == selectedChar && Swap == SelectedState.selected)
				{
					drawcolor = Color.MonoGameOrange;
				}

				spriteBatch.DrawString(temp, string.Format("{0}:   ", j + 1), j * 5 * Config.LineSpacing, drawcolor);

			}

			playerInv.Draw(spriteBatch, temp);

			spriteBatch.End();

			base.Draw(gameTime);
        }

		private void SwapUnits(int pos1, int pos2)
		{
			Unit temp = Units[pos1];
			Units[pos1] = Units[pos2];
			Units[pos2] = temp;

		}
	}
}
