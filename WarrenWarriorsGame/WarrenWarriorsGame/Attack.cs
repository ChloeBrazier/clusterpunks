using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Warren Warriors
/// Eddie Brazier
/// class that holds methods used to execute player and enemy attacks
/// 3/8/2019
/// </summary>
namespace WarrenWarriorsGame
{
    //class is currently being modified by Eddie for use in player-enemy interactions
	public class Attack //--not currently in use anywhere --//
	{
        //the base damage of a generated player character
        private int baseDamage;

        //the basic time a generated player takes to attack
        private double baseLength;

		//how much damage the attack does
		private int damage;

		//how long the attack takes
		private double length;

		//holds the timer to keep track of if the player is attacking or not
		//private double timer;
        //may remove due to implementation of isAttacking bool

        //accessors for attack damage and length
        public int Damage
        {
            get
            {
                return damage;
            }
        }

        //also contains mutator(subject to change)
        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        /// <summary>
        /// parameterized constructor for attack that initializes a unit's base damage, base attack speed, 
        /// and the units targeted by the attack
        /// </summary>
        /// <param name="dmg">The base damage a unit can deal (damage modifier)</param>
        /// <param name="time"> The base time a unit takes to attack (timer modifier)</param>
		public Attack(int dmg, double time)
		{
            //initialize base damage upon creation
			baseDamage = dmg;
			baseLength = time;

            //set initial current damage to passed-in values
            damage = dmg;
            length = time;
		}

        public bool StartAttack(CraftItem[,] inventory, CraftItem usedItem, int x, int y)
        {
            //set player damage to item damage (only if armed)
            if(usedItem.ItemType != Item.Empty)
            {
                damage = usedItem.Dmg.damage;
                length = usedItem.Dmg.Length;
            }
            
            //remove used item from inventory
            inventory[x, y] = new CraftItem(Item.Empty);

            //return true to change isAttacking
            return true;
        }
        
        public void EndPlayerAttack(Enemy attackTarget, PlayerChar attacker)
        {
            //may require an attack timer class and pause/unpause enums

            //damage the enemy
            attackTarget.Health = attackTarget.Health - attacker.Atk.damage;

            //set isAttacking to false
            attacker.IsAttacking = false;

            //add attack information to the battle log
            BattleLog.AddPlayerAttack(attacker.Name, attackTarget.Name, attacker.Atk.damage);

            //reset attack timer
            ResetAttack(attacker, "Player");
        }

        public void EndEnemyAttack(Enemy enemy, PlayerChar[] playerParty, int playerNumber)
        {
            //set attacked player to the passed-in player number
            int attackedPlayer = playerNumber;

            //damage the chosen player
            playerParty[attackedPlayer].Health = playerParty[attackedPlayer].Health - enemy.Atk.Damage;

            //set enemy's isAttacking to false
            enemy.IsAttacking = false;

            //reset enemy attack
            enemy.Atk.ResetAttack(enemy, "Enemy");
        }

        /// <summary>
        /// resets the length (and damage, for the player) of a character's attack
        /// after they finish an attack
        /// </summary>
        /// <param name="character"> The character whose attack is reset</param>
        /// <param name="charType"> 
        /// a hardcoded (subject to change) method to check which entity 
        /// in the game needs their attack reset
        /// </param>
        public void ResetAttack(Unit character, string charType)
        {
            if(charType == "Player")
            {
                PlayerChar player = (PlayerChar)character;
                player.Atk.length = player.Atk.baseLength;
                player.Atk.damage = player.Atk.baseDamage;
            }
            else
            {
                Enemy enemy = (Enemy)character;
                enemy.Atk.length = enemy.Atk.baseLength;
            }
        }

        public void PlayerUpdate(GameTime gameTime, Enemy enemy, PlayerChar attacker)
        {
            //count down on the attack timer and run endattack when it finishes
            length = length - gameTime.ElapsedGameTime.TotalSeconds;

            //run EndAttack when timer reaches zero
            if(length <= 0)
            {
                EndPlayerAttack(enemy, attacker);
            }
        }
	}
}
