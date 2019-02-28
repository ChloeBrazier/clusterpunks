using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*Warren Warriors Group Project
 *Cluster Punks
 *Enemy class
 */

namespace WarrenWarriorsGame
{
    public class Enemy: Unit
    {
        //field to reference the player's party
        PlayerChar[] playerParty;

        //public accessor for IsAttacking bool
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

        public Enemy(SpriteFont enemyFont, EnemyType type, PlayerChar[] Units)
        {
            //set font based on the spritefont that's passed in
            font = enemyFont;

            //initialize playerParty 
            playerParty = Units;

            //switch statement to determine enemy stats based on type
            switch (type)
            {
                case EnemyType.Buckshot:

                    //set non-randomized stats for buckshot, a set enemy type
                    health = 100;
                    atk = new Attack(10, 10);
                    name = "Buckshot";

                    break;
                case EnemyType.SewCrow:

                    //set non-randomized stats for sewcrow, a set enemy type
                    health = 60;
                    atk = new Attack(1, 3);
                    name = "Sew Crow";

                    break;
                case EnemyType.Bandit:

                    //set non-randomized stats for bandit, a set enemy type
                    health = 75;
                    atk = new Attack(8, 6);
                    name = "Bandit";

                    break;
                case EnemyType.Custom:

                    //here's where code for enemies created using the external tool
                    //will go, reading in an enemy file and setting stats based on it 

                    break;
            }

            //set isAttacking bool to false by default
            isAttacking = false;
        }

        /// <summary>
        /// method to load in the correct sprite based on enemy type
        /// </summary>
        /// <param name="game"> 
        /// object of the Game1 class used to load sprite content
        /// </param>
        public void LoadSprite(Game game, EnemyType type)
        {
            //switch statement that loads a sprite based on enemy type
            switch(type)
            {
                case EnemyType.Buckshot:

                    //sprite = game.Content.Load<Texture2D>("BUCKSHOT SPRITE FILE NAME HERE");

                    break;
                case EnemyType.SewCrow:

                    //sprite = game.Content.Load<Texture2D>("SEWCROW SPRITE FILE NAME HERE");

                    break;
                case EnemyType.Bandit:

                    //sprite = game.Content.Load<Texture2D>("BANDIT SPRITE FILE NAME HERE");

                    break;
                case EnemyType.Custom:

                    //loaded sprite is based on external tool and file IO

                    break;
            }
        }

        //required methods based on unit parent class
        public override void Draw(SpriteBatch sb, int position)
        {
            //Eddie: Added readout for attack speed to test combat and
            //and made an if statement to change text color when attacking
            Vector2 pos = new Vector2(300, 0) + position * 5 * Config.LineSpacing;

            if (isAttacking != true)
            {
                sb.DrawString(font, string.Format("{0}/{1}/{2}", name, Health, "Attack time: " + atk.Length), pos, Color.Black);
            }
            else
            {
                sb.DrawString(font, string.Format("{0}/{1}/{2}", name, Health, "Attack time: " + atk.Length), pos, Color.Red);
            }
        }
        
        public override void Update(KeyboardState kbState, KeyboardState PrevkbState, GameTime time)
        {

            //enemy attacks periodically until it dies
            //start the enemy on a cooldown of 15 seconds
            //double cooldown = 15;
            //cooldown = cooldown = time.ElapsedGameTime.TotalSeconds;
            //cooldown currently doesn't work properly
            
            //set isAttacking to true
            isAttacking = true;

            //enemy starts their attack timer
            atk.Length = atk.Length - time.ElapsedGameTime.TotalSeconds;

            //execute attack length when timer runs down
            if (atk.Length <= 0)
            {
                this.Atk.EndEnemyAttack(this, playerParty);
            }
            
        }
    }
}
