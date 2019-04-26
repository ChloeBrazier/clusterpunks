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
    
    public class AnimatedSprite
    {
        Texture2D spriteTexture;
        float timer;
        float interval = 200f;
        int currentFrame;
        int spriteWidth;
        int spriteHeight;
        int spriteSheet;
        int numOfFrames;
        Rectangle sourceRect;
        Vector2 position;
        Vector2 origin;


        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
        }
        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }


        public AnimatedSprite(Texture2D spriteImage, int currentFrame, int spriteWidth, int spriteHeight, int numOfFrames)
        {
            this.numOfFrames = numOfFrames;
            this.spriteTexture = spriteImage;
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
        }

        

        public void Animate(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(timer > interval)
            {
                currentFrame++;
                if (currentFrame > numOfFrames)
                {
                    currentFrame = 0;
                }
                timer = 0;
            }


        }
        
            

        
        
    }
}
