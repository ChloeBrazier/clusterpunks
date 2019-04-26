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

        AnimationHandler animHandler;

		KeyboardState kbState; //keyboard states for updating
		KeyboardState PrevkbState;

        //fields for mouse states
        MouseState mState;
        MouseState prevMsState;

		//field for dungeon
		Dungeon mainDungeon;

        //Map Background Sprite
        Texture2D MapBackground;

		//field for encounter
		Encounter current;

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

		List<Texture2D> ControlsSheet = new List<Texture2D>();
		Button[] controlsIncrementer = new Button[2];
		int controlspage = 0;

        //create playerhandler, which in turn initializes player units
        PlayerHandler handler; //initializes the player handler

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
            animHandler = new AnimationHandler();
            animHandler.Initalize();
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

			//Creates Dungeon
			mainDungeon = new Dungeon(this);

			controlsIncrementer[0] = new Button(Content.Load<Texture2D>("btnNextNormal"),
												Content.Load<Texture2D>("btnNextHovered"),
												Content.Load<Texture2D>("btnNextClicked"),
												new Rectangle(Config.EXIT_BUTTON_XY.X + 660, Config.EXIT_BUTTON_XY.Y + 50, 50, 50));
			controlsIncrementer[1] = new Button(Content.Load<Texture2D>("btnPrevNormal"),
												Content.Load<Texture2D>("btnPrevHovered"),
												Content.Load<Texture2D>("btnPrevClicked"),
												new Rectangle(Config.EXIT_BUTTON_XY.X + 600, Config.EXIT_BUTTON_XY.Y + 50, 50, 50));

			ControlsSheet.Add(Content.Load<Texture2D>("btnCraftNormal"));
			ControlsSheet.Add(Content.Load<Texture2D>("btnCraftHovered"));
			ControlsSheet.Add(Content.Load<Texture2D>("itemUseIcon"));

            //load in texture2D for enemy (when implemented), may change later
            //Texture2D enemyTexture = enemyName.LoadSprite(enemytype);

            //inititalize the player handler
            handler = new PlayerHandler(Content.Load<SpriteFont>("Arial-12"), this);

            song = Content.Load<Song>("Power Rangers");  // Put the name of your song here instead of "song_title"

			//load temporary menu font
			menuFont = Content.Load<SpriteFont>("Arial-12");

			// TODO: use this.Content to load your game content here
			UI.Initialize(this);
			UI.Load();

            MapBackground = Content.Load<Texture2D>("MapBack");

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
            animHandler.UpdateAnimation(gameTime);
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
                                    mainDungeon = new Dungeon(this);
									gameState = GameState.RoomSelect;
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
                        gameState = GameState.RoomSelect;
                    }

                    break;

				case GameState.RoomSelect:
					//Lets Player select a room to go to
					current = mainDungeon.Update(mState, prevMsState);

					if (current != null)
					{
						gameState = GameState.Combat;
                        current.Handler = handler;
					}
					break;
				case GameState.Combat:

					//Initiates combat in the current room, with the encounter generated
					current.CombatEncounter(this, kbState, PrevkbState, mState, prevMsState, gameTime);

					//check party's health and enter GameOver state if it equals zero
					int partyHealth = current.CombatHandler.PartyHealth();
					if (partyHealth == 0)
					{
						MediaPlayer.Stop();
						gameState = GameState.GameOver;
					}

					//checks enemy's health. when it hits zero, drops loot and returns to room select
					int enemyHealth = current.CombatHandler.EnemyHealth();
					if (enemyHealth <= 0)
					{
                        if (mainDungeon.GameWin())
                        {
                            gameState = GameState.Win;
                            handler = new PlayerHandler(Content.Load<SpriteFont>("Arial-12"), this);
                        }
                        else
                        {
                            gameState = GameState.RoomSelect;
                            current.Handler.PlayerInv.DropItems(0, 10);
                            current.Handler.EndEncounter();
                            BattleLog.ClearLog();
                        }
					}

					break;
				case GameState.GameOver:

                    //return to menu when player presses Enter
                    if (Config.SingleKeyPress(Keys.Enter, kbState, PrevkbState) == true)
                    {
                        gameState = GameState.Menu;

                        foreach (Button b in titleButtons)
                        {
                            b.Deselect();
                        }
                    }

                    break;
                case GameState.ControlMenu:

					if (controlsIncrementer[0].Update(mState))
					{
						controlsIncrementer[0].Deselect();
						controlspage++;
						if (controlspage == 3)
						{
							controlspage = 0;
						}
					}
					else if (controlsIncrementer[1].Update(mState))
					{
						controlsIncrementer[1].Deselect();
						controlspage--;
						if (controlspage == -1)
						{
							controlspage = 2;
						}
					}


                    if (titleButtons[2].Update(mState))
                    {
                        for (int j = 0; j < titleButtons.Count; j++)
                        {
                            titleButtons[j].Deselect();
                        }
                        gameState = GameState.Menu;
                    }
                    break;

                case GameState.Win:
                    if (Config.SingleKeyPress(Keys.Enter, kbState, PrevkbState))
                    {
                        gameState = GameState.Menu;
                        foreach (Button b in titleButtons)
                        {
                            b.Deselect();
                        }
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
				case GameState.RoomSelect:
                    spriteBatch.Draw(MapBackground, new Vector2(0, 0), Color.White);
                    mainDungeon.Draw(spriteBatch);
					break;
				case GameState.Combat:

					//draw background
					spriteBatch.Draw(
						UI.GameUI[7],
						new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height),
						Color.DarkGray //Changed to Dark Gray to make the UI and Characters stand out more
						);

					//draw characters and combat UI
					current.Handler.Draw(spriteBatch);

					//draw the enemy
					current.EnemyDraw(this, spriteBatch, 0);

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
					foreach (Button b in controlsIncrementer)
					{
						b.Draw(spriteBatch);
					}
					spriteBatch.Draw(ControlsSheet[controlspage], new Vector2(0, 0), Color.White);
                    break;

                case GameState.Win:
                    spriteBatch.DrawString(menuFont, "You win, press enter to return to menu", new Vector2(50, 50), Color.White);
                    break;

                
            }
            
            spriteBatch.End();

			base.Draw(gameTime);
        }

		
	}
}
