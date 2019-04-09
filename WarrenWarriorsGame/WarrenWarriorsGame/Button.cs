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
    /// buttons class that is used for clickable objects in the game
    /// 3/8/2019
    /// </summary>
    class Button
    {
        private BtnState state = BtnState.Default;

        private Texture2D normal;
        private Texture2D hovered;
        private Texture2D selected;
        private Rectangle location;
		private Rectangle drawLocation;
        private MouseState prevMouseState;

        public Rectangle Location
        {
            get
            {
                return location;
            }
        }

        /// <summary>
        /// creates a button with three states
        /// </summary>
        /// <param name="norm">the normal texture of the button </param>
        /// <param name="hover">the texture of a button that has been hovered over</param>
        /// <param name="click">the texture of a button that has been selected</param>
        /// <param name="position">the size and position of the button</param>
        public Button(Texture2D norm, Texture2D hover, Texture2D click, Rectangle position)
        {
            normal = norm;
            hovered = hover;
            selected = click;
            location = position;
			drawLocation = position;
        }

		/// <summary>
		/// creates a button with three states
		/// </summary>
		/// <param name="norm">the normal texture of the button </param>
		/// <param name="hover">the texture of a button that has been hovered over</param>
		/// <param name="click">the texture of a button that has been selected</param>
		/// <param name="position">the size and position of the button</param>
		public Button(Texture2D norm, Texture2D hover, Texture2D click, Rectangle hitbox, Rectangle drawLocation)
		{
			normal = norm;
			hovered = hover;
			selected = click;
			location = hitbox;
			this.drawLocation = drawLocation;
		}

		/// <summary>
		/// returns true if the mouse is being clicked and changes what sprite it's using
		/// </summary>
		/// <param name="ms">the current mouse state</param>
		/// <returns></returns>
		public Boolean Update(MouseState ms)
        {
			//don't worry about this it just works
            if (state != BtnState.Selected) //if the button is not selected
            {
                if (location.Contains(ms.Position)) //if the button is being hovered over
                {
                    state = BtnState.Hovered; //change it to be hovered over
                    if (Config.SingleMouseClick(ms,prevMouseState)) //if it is being clicked on select it
                    {
                        state = BtnState.Selected;
						prevMouseState = ms;

						return true;
                    }
                }
                else
                {
                    //if it is not being hoevered over draw it as it's default
                    state = BtnState.Default;
					prevMouseState = ms;

					return false;
                }
            }

			prevMouseState = ms;
			return false;


        }

        public void Draw(SpriteBatch sb)
        {
            //draws the button in its current state
            switch (state)
            {
                case BtnState.Default:
                    sb.Draw(normal, drawLocation, Color.White);
                    break;
                case BtnState.Hovered:
                    sb.Draw(hovered, drawLocation, Color.White);
                    break;
                case BtnState.Selected:
                    sb.Draw(selected, drawLocation, Color.White);
                    break;
            }

        }


        public void Select() //used to be called by other methods to select or deselect buttons from other methods
        {
            state = BtnState.Selected;
        }

        public void Deselect()
        {
            state = BtnState.Default;
        }


    }
}
