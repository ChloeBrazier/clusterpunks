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
    /// <summary>
    /// Warren Warriors
    /// John Bateman
    /// Eddie Brazier
    /// The player class that holds information about the player units
    /// 3/8/2019
    /// </summary>
    public class PlayerChar: Unit
	{
        //private field to store target icon
        private Texture2D icon;

        //public accessor/mutator for IsAttacking bool
        public bool IsAttacking
        {
            get
            {
                return isAttacking;
            }
            set
            {
                isAttacking = value;
            }
        }

        //accessor for attack
        public Attack Atk
        {
            get
            {
                return atk;
            }
        }

        //public accessor/mutator for health
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        //accessor for name
        public string Name
        {
            get
            {
                return name;
            }
        }

        //accessor for icon
        public Texture2D Icon
        {
            get
            {
                return icon;
            }
        }

        public PlayerChar(SpriteFont spriteFont, Game game, CharType type)
		{
			font = spriteFont;

			//creates characters in a psedorandom method (this is meant to be temporary)
			switch (type)
			{
				case CharType.Heavy:
					health = Config.GetRandom(40, 51);
					atk = new Attack(Config.GetRandom(10, 16), Config.GetRandom(5, 11));
					name = "Kevin's Grand-Dad";
                    sprite = game.Content.Load<Texture2D>("player_char_ranger_red");
                    icon = game.Content.Load<Texture2D>("ranger_target_icon");

                    break;
				case CharType.Medium:
					health = Config.GetRandom(30, 41);
					name = "The Farmer";
                    sprite = game.Content.Load<Texture2D>("farmer");
                    icon = game.Content.Load<Texture2D>("farmer_target_icon");
                    if (Config.GetRandom(1, 3) == 2)
					{
						atk = new Attack(Config.GetRandom(10, 16), Config.GetRandom(4, 6));
					}
					else
					{
						atk = new Attack(Config.GetRandom(10, 16), Config.GetRandom(4, 6));
					}
					
					break;
				case CharType.Light:
					health = Config.GetRandom(20, 31);
					atk = new Attack(Config.GetRandom(5, 11), Config.GetRandom(1, 3));
					name = "Kevin (Heroic)";
                    sprite = game.Content.Load<Texture2D>("player_char_ranger_fixed");
                    icon = game.Content.Load<Texture2D>("ranger_target_icon");

                    break;

			}

            //set isAttacking bool to false by default
            isAttacking = false;
		}


        /// <summary>
        /// draws the character based on the position it is given
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="position"></param>
        public override void Draw(SpriteBatch sb,int position)
		{
			//---temporary solution---//
            //Eddie: Added readout for formatted attack speed to test combat and
            //and made an if statement to change text color when attacking
			Vector2 pos = position * 5 * Config.LineSpacing;
            pos.X = pos.X - 10;
            pos.Y = pos.Y - 40;

            //vector for character info
            Vector2 textPos = new Vector2(470, 100);
            textPos.Y = textPos.Y * (1 + position);
            textPos.Y = textPos.Y + 100;

            if (this.Health > 0)
            {

                sb.DrawString(font, health.ToString(), new Vector2(Config.HEALTH_X_POS + Config.HEALTH_SPACING * position, Config.HEALTH_Y_POS), Color.Black);
                
                if (isAttacking != true)
                {
                    //player is normally colored when not attacking
                    sb.Draw(sprite, new Rectangle(Config.PLAYER_AVATAR_X_LOC + position * (Config.PLAYER_AVATAR_WIDTH + Config.PLAYER_AVATAR_SPACING), Config.PLAYER_AVATAR_Y_LOC, Config.PLAYER_AVATAR_WIDTH, Config.PLAYER_AVATAR_HEIGHT), Color.White);
                }
                else
                {
                    //player is red when attacking
                    sb.Draw(sprite, new Rectangle(Config.PLAYER_AVATAR_X_LOC + position * (Config.PLAYER_AVATAR_WIDTH + Config.PLAYER_AVATAR_SPACING), Config.PLAYER_AVATAR_Y_LOC, Config.PLAYER_AVATAR_WIDTH, Config.PLAYER_AVATAR_HEIGHT), Color.PaleVioletRed);
                }
            }
            else
            {
                //player is grayed out when dead
                sb.Draw(sprite, new Rectangle(Config.PLAYER_AVATAR_X_LOC + position * (Config.PLAYER_AVATAR_WIDTH + Config.PLAYER_AVATAR_SPACING), Config.PLAYER_AVATAR_Y_LOC, Config.PLAYER_AVATAR_WIDTH, Config.PLAYER_AVATAR_HEIGHT), Color.Gray);
            }
            
		}

		public override void Update(KeyboardState kbState, KeyboardState PrevkbState, GameTime time)
		{
			//---this does nothing right now but should contain the attack stuff---//
			throw new NotImplementedException();
		}
	}
}
