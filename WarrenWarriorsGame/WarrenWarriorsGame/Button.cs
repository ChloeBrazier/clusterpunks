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


    }
}
