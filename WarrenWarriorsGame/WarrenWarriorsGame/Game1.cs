using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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

        //fields for mouse states
        MouseState mState;
        MouseState prevMsState;

		PlayerHandler handler; //holds all of the player interaction

        //field for an enemy (spawning currently simplified for testing)
        Enemy buckShot;

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

            //create playerhandler, which in turn initializes player units
			handler = new PlayerHandler(Content.Load<SpriteFont>("Arial-12"),this); //initializes the player handler

            //load in texture2D for enemy (when implemented), may change later
            //Texture2D enemyTexture = enemyName.LoadSprite(enemytype);

            //initialize enemy for testing
            buckShot = new Enemy(Content.Load<SpriteFont>("Arial-12"), EnemyType.Buckshot, handler.PlayerParty);
            buckShot.LoadSprite(this, EnemyType.Buckshot);

            Song song = Content.Load<Song>("Power Rangers");  // Put the name of your song here instead of "song_title"
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;


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
            mState = Mouse.GetState();

            //now takes in gametime for use with the Attack classe's update method (also an enemy for temporary testing)
			handler.update(kbState, PrevkbState, mState, prevMsState, gameTime, buckShot); //updates all of the keyboardhandler

            //update enemy and handle combat

            if (buckShot.IsAttacking != true)
            {
                buckShot.CoolDown(gameTime);
            }
            else
            {
                buckShot.Update(kbState, PrevkbState, gameTime);
            }

			PrevkbState = kbState; //stores the previous keyboard state
            prevMsState = mState; //stores previous mouse state

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

			

			handler.Draw(spriteBatch,gameUI);

            //gameUI.DrawUI(spriteBatch);

            buckShot.Draw(spriteBatch, 0);
            
            spriteBatch.End();

			base.Draw(gameTime);
        }

		
	}
}
