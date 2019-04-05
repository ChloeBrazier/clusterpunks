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
                    cooldown = 10;

                    break;
                case EnemyType.SewCrow:

                    //set non-randomized stats for sewcrow, a set enemy type
                    health = 60;
                    atk = new Attack(1, 3);
                    name = "Sew Crow";
                    cooldown = 3;

                    break;
                case EnemyType.Bandit:

                    //set non-randomized stats for bandit, a set enemy type
                    health = 75;
                    atk = new Attack(8, 6);
                    name = "Bandit";
                    cooldown = 5;

                    break;
                case EnemyType.Custom:
                    enemySprite = LoadEnemy("../../../../Content/[PUNISHED]Kevin.enemy");
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

                    sprite = game.Content.Load<Texture2D>("buckshot_fixed");

                    break;
                case EnemyType.SewCrow:

                    //sprite = game.Content.Load<Texture2D>("SEWCROW SPRITE FILE NAME HERE");

                    break;
                case EnemyType.Bandit:

                    //sprite = game.Content.Load<Texture2D>("BANDIT SPRITE FILE NAME HERE");

                    break;
                case EnemyType.Custom:

                    sprite = game.Content.Load<Texture2D>(enemySprite);

                    break;
            }
        }

        //required methods based on unit parent class
        public override void Draw(SpriteBatch sb, int position)
        {
            //Eddie: Added readout for attack speed to test combat and
            //and made an if statement to change text color when attacking
            Vector2 pos = new Vector2(470, 0) + position * 5 * Config.LineSpacing;

            //draw enemy based on its health
            if(this.Health > 0)
            {
                if (isAttacking != true)
                {
                    //enemy is drawn normally on cooldown
                    sb.DrawString(font, string.Format("{0}/{1}/{2:2.2}", name, Health, "Cooldown: " + string.Format("{0: 0.00}", cooldown)), pos, Color.Black);
                    sb.Draw(sprite, new Rectangle((int)pos.X + 40, (int)pos.Y, 212, 300), Color.White);
                }
                else
                {
                    //enemy turns red when it starts to attack
                    sb.DrawString(font, string.Format("{0}/{1}/{2}", name, Health, "Attack time: " + string.Format("{0: 0.00}", atk.Length)), pos, Color.Red);
                    sb.Draw(sprite, new Rectangle((int)pos.X + 40, (int)pos.Y, 212, 300), Color.PaleVioletRed);
                }
            }
            else
            {
                //enemy is grayed out when dead
                sb.DrawString(font, string.Format("{0}/{1}", name, "Dead"), pos, Color.Black);
                sb.Draw(sprite, new Rectangle((int)pos.X + 40, (int)pos.Y, 212, 300), Color.Gray);
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

            //Code to reduce the sprite filename to just the name
            String[] storage = longName.Split('\\');
            string shorterName = storage[storage.Length-1];
            String[] secondStorage = shorterName.Split('.');
            return secondStorage[0];

            
        }
    }
}
