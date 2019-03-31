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

                    break;
				case CharType.Medium:
					health = Config.GetRandom(30, 41);
					name = "Kevin's Dad";
                    sprite = game.Content.Load<Texture2D>("player_char_ranger_blue");
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
			Vector2 pos = position * 5 * Config.LineSpacing;
            pos.X = pos.X - 10;
            pos.Y = pos.Y - 40;

            //vector for character info
            Vector2 textPos = new Vector2(470, 100);
            textPos.Y = textPos.Y * (1 + position);
            textPos.Y = textPos.Y + 100;

            if (this.Health > 0)
            {
                if (isAttacking != true)
                {
                    sb.DrawString(
                        font, 
                        string.Format("{0}/{1}/{2}", 
                        name, 
                        health, 
                        "Attack time: " + string.Format("{0: 0.00}", atk.Length)), 
                        textPos, 
                        Color.Black);
                    sb.Draw(sprite, new Rectangle((int)pos.X, (int)pos.Y, 212, 300), Color.White);
                }
                else
                {
                    sb.DrawString(
                        font, 
                        string.Format("{0}/{1}/{2}", 
                        name, 
                        health, 
                        "Attack time: " + string.Format("{0: 0.00}", 
                        atk.Length)),
                        textPos, 
                        Color.Red);
                    sb.Draw(sprite, new Rectangle((int)pos.X, (int)pos.Y, 212, 300), Color.PaleVioletRed);
                }
            }
            else
            {
                //player is grayed out when dead
                sb.DrawString(
                    font, 
                    string.Format("{0}/{1}", name, "Dead"),
                    textPos, 
                    Color.Black);
                sb.Draw(sprite, new Rectangle((int)pos.X, (int)pos.Y, 212, 300), Color.Gray);
            }
            
		}

		public override void Update(KeyboardState kbState, KeyboardState PrevkbState, GameTime time)
		{
			//---this does nothing right now but should contain the attack stuff---//
			throw new NotImplementedException();
		}
	}
}
