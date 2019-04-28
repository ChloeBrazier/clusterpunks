using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

//Encounter Class
//Liam Perry
//Generates Combat per each room

namespace WarrenWarriorsGame
{
	public class Encounter
	{
		//field for random object
		Random r;

		//holds all of the player interaction
		private PlayerHandler handler;
		public PlayerHandler Handler
		{
			get { return handler; }
            set { handler = value; }
		}


		//field for the combat handler
		private CombatHandler combatHandler;
		public CombatHandler CombatHandler
		{
			get { return combatHandler; }
		}
		//field for an enemy (spawning currently simplified for testing)
		Enemy current;

		Difficulty roomDifficulty; //the difficulty of the encounter
		Enemy[] enemy; //the enemies that you will fight in the room

		public Encounter(Game g, Difficulty dif) //build the room based on difficulty
		{
			//create playerhandler, which in turn initializes player units
			handler = new PlayerHandler(g.Content.Load<SpriteFont>("Arial-12"), g); //initializes the player handler

			roomDifficulty = dif;
			//initialize enemy for testing
			r = new Random();
            int randomEnemy = 0;            

            //Randomizes Enemy based on room difficulty
            switch(dif)
            {
                case Difficulty.Easy:
                    randomEnemy = r.Next(0, 3);
                    break;
                case Difficulty.Medium:
                    randomEnemy = r.Next(0, 3);
                    break;
                case Difficulty.Hard:
                    randomEnemy = r.Next(2, 3);
                    break;
                case Difficulty.Boss:
                    randomEnemy = 3;
                    break;
            }

			
			current = new Enemy(g.Content.Load<SpriteFont>("Arial-12"), randomEnemy, handler.PlayerParty);
			current.LoadSprite(g);

            //Intialize Combat Handler using loaded players and enemies
            combatHandler = new CombatHandler(handler.PlayerParty, current);

		}

		//this will likely be used in the building of the dungeon but will not be called directly


		/// <summary>
		/// Handles the Combat in the room
		/// Most of this code is just moved from the Game1
		/// </summary>
		/// <param name="g"></param>
		/// <param name="kbState"></param>
		/// <param name="PrevkbState"></param>
		/// <param name="mState"></param>
		/// <param name="prevMsState"></param>
		/// <param name="gameTime"></param>
		public void CombatEncounter(Game g, KeyboardState kbState, KeyboardState PrevkbState, MouseState mState, MouseState prevMsState, GameTime gameTime)
		{
			//play background music (temp)

			//Eddie: commented out because it was driving me crazy while testing

			//if(songStart == false)
			//{
			//    MediaPlayer.Play(song);
			//    MediaPlayer.IsRepeating = true;
			//    songStart = true;
			//}

			if (combatHandler.InEncounter != true)
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


		}

		//Draws enemy sprite
		public void EnemyDraw(Game g, SpriteBatch sb, int pos)
		{
			current.Draw(sb, pos);
		}


	}
}
