using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WarrenWarriorsGame
{
    /// <summary>
    /// Warren Warriors
    /// John Bateman
    /// Eddie Brazier
    /// main game functions
    ///3/8/2019
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

        //field for the combat handler
        CombatHandler combatHandler;

        //field for an enemy (spawning currently simplified for testing)
        Enemy buckShot;

        //field for the game's current state
        GameState gameState;

        //field for game music
        Song song;
        //temporary bool to make the song start only once
        bool songStart;

        //field for the menu's spritefont
        SpriteFont menuFont;

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

            //initialize game state as menu
            gameState = GameState.Menu;
            
            songStart = false;

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

            //initialize combat handler using loaded players and enemy
            combatHandler = new CombatHandler(handler.PlayerParty, buckShot);

            song = Content.Load<Song>("Power Rangers");  // Put the name of your song here instead of "song_title"

            //load temporary menu font
            menuFont = Content.Load<SpriteFont>("Arial-12");

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

            //switch statement to determine which state the game is in and run update methods accordingly
            switch(gameState)
            {
                case GameState.Menu:

                    //start game when the player presses enter
                    if (Config.singelKeyPress(Keys.Enter, kbState, PrevkbState) == true)
                    {
                        gameState = GameState.Combat;
                    }

                    break;
                case GameState.Combat:
                    
                    //play background music (temp)
                    
                    if(songStart == false)
                    {
                        MediaPlayer.Play(song);
                        MediaPlayer.IsRepeating = true;
                        songStart = true;
                    }
                    
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

                    //check party's health and enter GameOver state if it equals zero
                    int partyHealth = combatHandler.PartyHealth();
                    if(partyHealth == 0)
                    {
                        MediaPlayer.Stop();
                        gameState = GameState.GameOver;
                    }

                    break;
                case GameState.GameOver:

                    //return to menu when player presses Enter
                    if (Config.singelKeyPress(Keys.Enter, kbState, PrevkbState) == true)
                    {
                        gameState = GameState.Menu;
                    }

                    break;
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

            //switch statement to determine which state the game is in and run draw methods accordingly
            switch (gameState)
            {
                case GameState.Menu:

                    //temporary opening menu that informs the player to press enter to start the game
                    spriteBatch.DrawString
                        (
                        menuFont, 
                        "Press Enter to start the Game", 
                        new Vector2(GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2),
                        Color.Black
                        );

                    break;
                case GameState.Combat:

                    //draw characters and combat UI
                    handler.Draw(spriteBatch, gameUI);

                    //gameUI.DrawUI(spriteBatch);

                    //draw the enemy
                    buckShot.Draw(spriteBatch, 0);

                    break;
                case GameState.GameOver:

                    //temporary game over screen that informs the player to press enter to return to the menu
                    spriteBatch.DrawString
                        (
                        menuFont,
                        "Press Enter to return to the menu",
                        new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2),
                        Color.Black
                        );

                    break;
            }
            
            spriteBatch.End();

			base.Draw(gameTime);
        }

		
	}
}
