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
    //Warren Warriors
    //Noah Hulick
    //Class that's an alternative to a regular sprite that has special methods and fields for the sole purpose of animation
    
    //Noah's note: If you want this to work properly, make sure the dimensions of your image itself are exactly/extremely close to whatever you're drawing it as.
    //I.E if it's a player avatar, make sure your sprite has 170 height and 120 width, etc. etc.
    
    public class AnimatedSprite
    {
        //Holds whatever sprite texture is being passed in.
        Texture2D spriteTexture;
        //Keeps track of time.
        float timer;
        //How often the frame rotates (in milliseconds)
        float interval;
        //Keeps track of the current frame the spritesheet is on.
        int currentFrame;
        //Width of the individual sprite in the spritesheet.
        int spriteWidth;
        //Height of the individual sprite in the spritesheet.
        int spriteHeight;
        //How many frames are in the spritesheet.
        int numOfFrames;
        Rectangle sourceRect;
        


        
        //Property that lets you set and return the texture if needed.
        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
        }
        //Property that lets you set and return the source rectangle if needed.
        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }
        //Returns whatever frame the animation is currently on.
        public int CurrentFrame
        {
            get { return currentFrame; }
        }

        //Constructor that lets us pass in whatever texture we're using, the current frame (usually should be set to 0/1), the dimensions, how many frames, and how
        //Fast we want the animation to be.
        public AnimatedSprite(Texture2D spriteImage, int currentFrame, int spriteWidth, int spriteHeight, int numOfFrames, float interval)
        {
            this.numOfFrames = numOfFrames;
            this.spriteTexture = spriteImage;
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            this.interval = interval;
        }

        
        //Actually handles the animation itself.
        public void Animate(GameTime gameTime)
        {
            //Advances the timer.
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //If the timer goes past a certain interval, move to the next frame.
            if(timer > interval)
            {
                currentFrame++;
                //If the frame is greater than how many frames are in the image, go back to the base frame.
                if (currentFrame > numOfFrames-1)
                {
                    currentFrame = 0;
                }
                timer = 0;
            }
            //Update the source rectangle to simulate animation.
            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
            

        }
        
            

        
        
    }
}
