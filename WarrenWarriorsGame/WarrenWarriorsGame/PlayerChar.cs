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
	
	public class PlayerChar:Unit
	{
		Boolean isAttacking = false;
		string name;

		public PlayerChar(SpriteFont spriteFont, CharType type)
		{
			font = spriteFont;

			//creates characters in a psedorandom method (this is meant to be temporary)
			switch (type)
			{
				case CharType.Heavy:
					Health = Config.getRandom(40, 51);
					atk = new Attack(Config.getRandom(10, 16), Config.getRandom(5, 11), new List<int>() { 3, 4, 5 });
					name = "Kevin's Grand-Dad";

					break;
				case CharType.Medium:
					Health = Config.getRandom(30, 41);
					name = "Kevin's Dad";

					if (Config.getRandom(1, 3) == 2)
					{
						atk = new Attack(Config.getRandom(10, 16), Config.getRandom(4, 6), new List<int>() { 4, 5 });
					}
					else
					{
						atk = new Attack(Config.getRandom(10, 16), Config.getRandom(4, 6), new List<int>() { 3, 4 });
					}
					
					break;
				case CharType.Light:
					Health = Config.getRandom(20, 31);
					atk = new Attack(Config.getRandom(5, 11), Config.getRandom(1, 3), new List<int>() {Config.getRandom(3,6)});
					name = "Kevin";
					break;

			}

		}


		/// <summary>
		/// draws the character based on the position it is given
		/// </summary>
		/// <param name="sb"></param>
		/// <param name="position"></param>
		public override void Draw(SpriteBatch sb,int position)
		{
			//---temporary solution---//
			Vector2 pos = new Vector2(12,0) + position * 5 * Config.LineSpacing;
			sb.DrawString(font, string.Format("{0}/{1}", name , Health),pos,Color.Black);

		}
		public override void Update(KeyboardState kbState, KeyboardState PrevkbState, GameTime time)
		{
			//---this does nothing right now but should contain the attack stuff---//
			throw new NotImplementedException();
		}
	}
}
