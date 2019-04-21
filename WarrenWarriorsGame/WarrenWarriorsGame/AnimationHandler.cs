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
    
    public class AnimationHandler
    {
        private int frame; //Current frame of the animation.
        private double timeCounter; //Keeps track of the amount of time that has passed.
        private double fps; //The speed of the animation
        private double timePerFrame; //Amount of time per frame.

        public int Frame
        {
            get { return frame; }
        }

        public void Initalize()
        {
            fps = 1;
            timePerFrame = 1 / fps;

        }

        public void UpdateAnimation(GameTime gameTime)
        {
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeCounter >= timePerFrame)
            {
                frame += 1;

                timeCounter -= timePerFrame;
            }
        }

        public void Update(GameTime time)
        {
            UpdateAnimation(time);
        }
        
        
    }
}
