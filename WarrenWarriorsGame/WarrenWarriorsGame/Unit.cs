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
	public abstract class Unit
	{
		protected int Health;
		protected SpriteFont font;
		protected Texture2D sprite; //its a tool that will help us later
		protected Attack atk;

		public abstract void Update(KeyboardState kbState, KeyboardState PrevkbState, GameTime time);
		public abstract void Draw(SpriteBatch sb,int position);
	}
}
