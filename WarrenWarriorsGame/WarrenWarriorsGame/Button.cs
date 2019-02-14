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
    class Button
    {
        private ButtonState state = ButtonState.Default;

        Texture2D normal;
        Texture2D hovered;
        Texture2D selected;
        Rectangle location;

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

        }

        public void update(MouseState ms)
        {
            if (state != ButtonState.Selected) //if the button is not selected
            {
                if (location.Contains(ms.Position)) //if the button is being hovered over
                {
                    state = ButtonState.Hovered; //change it to be hovered over
                    if (ms.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) //if it is being clicked on select it
                    {
                        state = ButtonState.Selected;

                    }
                }
                else
                {
                    //if it is not being hoevered over draw it as it's default
                    state = ButtonState.Default;

                }
            }

        }

        public void draw(SpriteBatch sb)
        {
            //draws the button
            switch (state)
            {
                case ButtonState.Default:
                    sb.Draw(normal, location, Color.White);
                    break;
                case ButtonState.Hovered:
                    sb.Draw(hovered, location, Color.White);
                    break;
                case ButtonState.Selected:
                    sb.Draw(selected, location, Color.White);
                    break;
            }

        }


        public void select()
        {
            state = ButtonState.Selected;
        }
        public void deselect()
        {
            state = ButtonState.Default;
        }


    }
}
