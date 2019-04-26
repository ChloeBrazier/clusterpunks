using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

/// <summary>
/// Warren Warriors
/// Eddie Brazier, Liam Perry
/// The enemy class which holds information and methods pertaining to enemies
/// 3/8/2019
/// </summary>
namespace WarrenWarriorsGame
{
    public class Enemy: Unit
    {
        //field to reference the player's party
        private PlayerChar[] playerParty;

        //field for enemy cooldown
        private double cooldown;

        //Field to store enemy sprite when loaded in
        private string enemySprite;

        //field for an int for an attacked player
        int attackedPlayer;

        //field to hold a reference to the enemy's current target
        private PlayerChar currentTarget;

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

        //accessor for name
        public string Name
        {
            get
            {
                return name;
            }
        }

        public Enemy(SpriteFont enemyFont, int type, PlayerChar[] Units)
        {
            //set font based on the spritefont that's passed in
            font = enemyFont;

            //initialize playerParty 
            playerParty = Units;

            //switch statement to determine enemy stats based on type
            switch (type)
            {
                case 0:

                    //set non-randomized stats for buckshot, a set enemy type
                    enemySprite = LoadEnemy("../../../../Content/Buckshot.enemy");

                    break;
                case 1:

                    //set non-randomized stats for sewcrow, a set enemy type
                    enemySprite = LoadEnemy("../../../../Content/sew_crow.enemy");

                    break;
                case 2:
                    enemySprite = LoadEnemy("../../../../Content/Snotlek.enemy");

                    break;
                case 3:
                    enemySprite = LoadEnemy("../../../../Content/[PUNISHED]Kevin.enemy");
                    break;
            }

            //set isAttacking bool to false by default
            isAttacking = false;
        }

        /// <summary>
        /// method to load in the enemy sprite
        /// </summary>
        /// <param name="game"> 
        /// object of the Game1 class used to load sprite content
        /// </param>
        public void LoadSprite(Game game)
        {
            sprite = game.Content.Load<Texture2D>(enemySprite);
        }

        //required methods based on unit parent class
        public override void Draw(SpriteBatch sb, int position)
        {
            //Eddie: Added readout for attack speed to test combat and
            //and made an if statement to change text color when attacking
            Vector2 pos = new Vector2(510, 0) + position * 5 * Config.LineSpacing;
            Vector2 textPos = new Vector2(pos.X + (212/3), pos.Y + 250);

            //draw enemy based on its health
            if(this.Health > 0)
            {
                if (isAttacking != true)
                {
                    //enemy is drawn normally on cooldown
                    sb.Draw(UI.GameUI[8], new Rectangle((int)textPos.X, (int)textPos.Y, 50, 50), Color.White);
                    sb.DrawString(font, string.Format("Cooldown: " + string.Format("{0: 0.00}", cooldown)), textPos, Color.Black);
                    sb.Draw(sprite, new Rectangle((int)pos.X, (int)pos.Y, 212, 250), Color.White);
                }
                else
                {
                    //enemy turns red when it starts to attack
                    sb.Draw(UI.GameUI[6], new Rectangle((int)textPos.X, (int)textPos.Y, 50, 50), Color.White);
                    sb.DrawString(font, string.Format("Attack time: " + string.Format("{0: 0.00}", atk.Length)), textPos, Color.Red);
                    sb.Draw(sprite, new Rectangle((int)pos.X, (int)pos.Y, 212, 250), Color.PaleVioletRed);
                }
            }
            else
            {
                //enemy is grayed out when dead
                sb.Draw(sprite, new Rectangle((int)pos.X, (int)pos.Y, 212, 250), Color.Gray);
            }
        }
        
        public override void Update(KeyboardState kbState, KeyboardState PrevkbState, GameTime time)
        {
            //enemy only takes action if it has health
            if(this.Health > 0)
            {
                //enemy starts their attack timer
                atk.Length = atk.Length - time.ElapsedGameTime.TotalSeconds;

                //if the position of the attacked party member is swapped,
                //inform the player that the swapped-in member is being attacked
                if(currentTarget != playerParty[attackedPlayer])
                {
                    //add info to the combat log
                    BattleLog.ChangeEnemyTarget(this.name, playerParty[attackedPlayer].Name);

                    //set current target to the new attacked player
                    currentTarget = playerParty[attackedPlayer];
                }
                
                //execute attack when timer runs down
                if (atk.Length <= 0)
                {
                    this.Atk.EndEnemyAttack(this, playerParty, attackedPlayer);
                }
            }
        }

        public void CoolDown(GameTime time)
        {
            //enemy attacks periodically until it dies
            
            //start the enemy on a cooldown of 15 seconds
            cooldown = cooldown - time.ElapsedGameTime.TotalSeconds;

            if(cooldown <= 0)
            {
                cooldown = 15;
                atk.ResetAttack(this, "Enemy");
                isAttacking = true;

                //roll for a randomly attacked player
                attackedPlayer = Config.GetRandom(0, 3);

                //set current target to the player in the spot that was rolled
                currentTarget = playerParty[attackedPlayer];

                //inform the user which player is being attacked
                BattleLog.AddEnemyAttack(this.name, playerParty[attackedPlayer].Name);
            }
        }

        //Method to load in custom enemies
        public string LoadEnemy(string filename)
        {
            //Fie Reader
            System.IO.StreamReader reader = new StreamReader(filename);
            
            //Storage Variables
            int attack;
            int speed;
            int cooldownTime;

            //Data Reading
            name = reader.ReadLine();
            Int32.TryParse(reader.ReadLine(), out health);
            Int32.TryParse(reader.ReadLine(), out attack);
            Int32.TryParse(reader.ReadLine(), out speed);
            atk = new Attack(attack, speed);
            Int32.TryParse(reader.ReadLine(), out cooldownTime);
            cooldown = cooldownTime;
            string longName = reader.ReadLine();
            reader.Close(); //Close Reader

            health = 1;

            //Code to reduce the sprite filename to just the name
            String[] storage = longName.Split('\\');
            string shorterName = storage[storage.Length-1];
            String[] secondStorage = shorterName.Split('.');
            return secondStorage[0];

            
        }
    }
}
