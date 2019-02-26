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
        UI gameUI;
		KeyboardState kbState; //keyboard states for updating
		KeyboardState PrevkbState;

		PlayerHandler handler; //holds all of the player interaction


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
			IsMouseVisible = true; //set up the mouse

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

			handler = new PlayerHandler(Content.Load<SpriteFont>("Arial-12"),this); //initializes the player handler

            // TODO: use this.Content to load your game content here
            gameUI = new UI(this);
            gameUI.Load();
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

			handler.update(kbState, PrevkbState,Mouse.GetState()); //updates all of the keyboardhandler

			PrevkbState = kbState; //stores the previous keyboard state

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

			gameUI.Draw(spriteBatch); 

			handler.Draw(spriteBatch);

            
            spriteBatch.End();

			base.Draw(gameTime);
        }

		
	}
}
