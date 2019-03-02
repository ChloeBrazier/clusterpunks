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
	
	public class PlayerChar: Unit
	{

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

        public PlayerChar(SpriteFont spriteFont, Game game, CharType type)
		{
			font = spriteFont;

			//creates characters in a psedorandom method (this is meant to be temporary)
			switch (type)
			{
				case CharType.Heavy:
					health = Config.getRandom(40, 51);
					atk = new Attack(Config.getRandom(10, 16), Config.getRandom(5, 11));
					name = "Kevin's Grand-Dad";
                    sprite = game.Content.Load<Texture2D>("player_char_ranger_red");

                    break;
				case CharType.Medium:
					health = Config.getRandom(30, 41);
					name = "Kevin's Dad";
                    sprite = game.Content.Load<Texture2D>("player_char_ranger_blue");
                    if (Config.getRandom(1, 3) == 2)
					{
						atk = new Attack(Config.getRandom(10, 16), Config.getRandom(4, 6));
					}
					else
					{
						atk = new Attack(Config.getRandom(10, 16), Config.getRandom(4, 6));
					}
					
					break;
				case CharType.Light:
					health = Config.getRandom(20, 31);
					atk = new Attack(Config.getRandom(5, 11), Config.getRandom(1, 3));
					name = "Kevin";
                    sprite = game.Content.Load<Texture2D>("player_char_ranger_fixed");

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
			Vector2 pos = new Vector2(12,0) + position * 5 * Config.LineSpacing;

            if(isAttacking != true)
            {
                sb.DrawString(font, string.Format("{0}/{1}/{2}", name, health, "Attack time: " + string.Format("{0: 0.00}", atk.Length)), pos, Color.Black);
                sb.Draw(sprite, new Rectangle((int)pos.X + 40, (int)pos.Y - 80, 212, 300), Color.White);
            }
			else
            {
                sb.DrawString(font, string.Format("{0}/{1}/{2}", name, health, "Attack time: " + string.Format("{0: 0.00}", atk.Length)), pos, Color.Red);
                sb.Draw(sprite, new Rectangle((int)pos.X + 40, (int)pos.Y - 80, 212, 300), Color.PaleVioletRed);
            }
		}

		public override void Update(KeyboardState kbState, KeyboardState PrevkbState, GameTime time)
		{
			//---this does nothing right now but should contain the attack stuff---//
			throw new NotImplementedException();
		}
	}
}
