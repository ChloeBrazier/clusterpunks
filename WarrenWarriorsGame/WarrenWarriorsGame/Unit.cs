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
    /// a class meant to be used for a generic handler as well as being used as an outline for the enemy and ai
    /// 3/8/2019
    /// </summary>
	public abstract class Unit 
	{
        protected string name;
        protected int health;
        protected bool isAttacking;
		protected SpriteFont font;
		protected Texture2D sprite;
        protected AnimatedSprite animSprite;
		protected Attack atk;

		public abstract void Update(KeyboardState kbState, KeyboardState PrevkbState, GameTime time);
		public abstract void Draw(SpriteBatch sb,int position);
	}
}
