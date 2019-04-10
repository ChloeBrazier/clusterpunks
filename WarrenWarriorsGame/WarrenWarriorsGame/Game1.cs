using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace WarrenWarriorsGame
{
    /// <summary>
    /// Warren Warriors
    /// Noah Hulick
    /// John Bateman
    /// Eddie Brazier
    /// main game functions
    ///3/8/2019
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


		KeyboardState kbState; //keyboard states for updating
		KeyboardState PrevkbState;

        //fields for mouse states
        MouseState mState;
        MouseState prevMsState;

		PlayerHandler handler; //holds all of the player interaction

        //field for the combat handler
        CombatHandler combatHandler;

        //field for an enemy (spawning currently simplified for testing)
        Enemy current;

        //field for the game's current state
        GameState gameState;

        //field for game music
        Song song;

        //temporary bool to make the song start only once
        bool songStart;

        //field for random object
        Random r;

        //field for the menu's spritefont
        SpriteFont menuFont;

		Texture2D TitleImage;
		List<Button> titleButtons = new List<Button>();

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
            r = new Random();
            int randomEnemy = r.Next(0, 4);
            current = new Enemy(Content.Load<SpriteFont>("Arial-12"), randomEnemy, handler.PlayerParty);
            current.LoadSprite(this);

            //initialize combat handler using loaded players and enemy
            combatHandler = new CombatHandler(handler.PlayerParty, current);

            song = Content.Load<Song>("Power Rangers");  // Put the name of your song here instead of "song_title"

            //load temporary menu font
            menuFont = Content.Load<SpriteFont>("Arial-12");

            // TODO: use this.Content to load your game content here
            UI.Initialize(this);
            UI.Load();

			TitleImage = Content.Load<Texture2D>("titleImage");
			titleButtons.Add(new Button(Content.Load<Texture2D>(Config.PLAY_BUTTON_NORM),
										Content.Load<Texture2D>(Config.PLAY_BUTTON_HOVERED), 
										Content.Load<Texture2D>(Config.PLAY_BUTTON_CLICKED), 
										new Rectangle(Config.PLAY_BUTTON_XY, Config.MAIN_MENU_BUTTON_WIDTH)));

			titleButtons.Add(new Button(Content.Load<Texture2D>(Config.CONTROLS_BUTTON_NORM), 
										Content.Load<Texture2D>(Config.CONTROLS_BUTTON_HOVERED), 
										Content.Load<Texture2D>(Config.CONTROLS_BUTTON_CLICKED), 
										new Rectangle(Config.CONTROL_BUTTON_XY, Config.MAIN_MENU_BUTTON_WIDTH)));

			titleButtons.Add(new Button(Content.Load<Texture2D>(Config.EXIT_BUTTON_NORM), 
										Content.Load<Texture2D>(Config.EXIT_BUTTON_HOVERED), 
										Content.Load<Texture2D>(Config.EXIT_BUTTON_CLICKED), 
										new Rectangle(Config.EXIT_BUTTON_XY, Config.MAIN_MENU_BUTTON_WIDTH)));

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

					for (int j = 0; j < titleButtons.Count; j++)
					{
						if (titleButtons[j].Update(mState))
						{
							switch(j)
							{
								case 0:
									gameState = GameState.Combat;
									break;
                                case 1:
                                    gameState = GameState.ControlMenu;
                                    break;
								case 2:
									Exit();
									break;
							}


						}

					}

                    //start game when the player presses enter
                    if (Config.SingleKeyPress(Keys.Enter, kbState, PrevkbState) == true)
                    {
                        gameState = GameState.Combat;
                    }

                    break;
                case GameState.Combat:

                    if(combatHandler.InEncounter != true)
                    {
                        //enter encounter using combat handler (move to dungeon nav-based class later)
                        combatHandler.EnterEncounter();
                    }
                    
                    //now takes in gametime for use with the Attack classe's update method (also an enemy for temporary testing)
                    handler.Update(kbState, PrevkbState, mState, prevMsState, gameTime, current); //updates all of the keyboardhandler

                    //update enemy and handle combat

                    if (current.IsAttacking != true)
                    {
                        current.CoolDown(gameTime);
                    }
                    else
                    {
                        current.Update(kbState, PrevkbState, gameTime);
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
                    if (Config.SingleKeyPress(Keys.Enter, kbState, PrevkbState) == true)
                    {
                        gameState = GameState.Menu;
                    }

                    break;
                case GameState.ControlMenu:
                    if (titleButtons[2].Update(mState))
                    {
                        for (int j = 0; j < titleButtons.Count; j++)
                        {
                            titleButtons[j].Deselect();
                        }
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
            GraphicsDevice.Clear(Color.SkyBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin();

            //switch statement to determine which state the game is in and run draw methods accordingly
            switch (gameState)
            {
                case GameState.Menu:
                    spriteBatch.Draw(TitleImage, new Vector2(0, 0), Color.White);
                    for (int j = 0; j < titleButtons.Count; j++)
                    {
                        titleButtons[j].Draw(spriteBatch);
                    }



                    break;
                case GameState.Combat:

                    //draw background
                    spriteBatch.Draw(
                        UI.GameUI[7], 
                        new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), 
                        Color.White
                        );

                    //draw characters and combat UI
                    handler.Draw(spriteBatch);
                    
                    //draw the enemy
                    current.Draw(spriteBatch, 0);

                    //update battlelog and draw it to the screen
                    BattleLog.Draw(this, spriteBatch, menuFont);

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

                case GameState.ControlMenu:
                    titleButtons[2].Draw(spriteBatch);
                    break;

                
            }
            
            spriteBatch.End();

			base.Draw(gameTime);
        }

		
	}
}
