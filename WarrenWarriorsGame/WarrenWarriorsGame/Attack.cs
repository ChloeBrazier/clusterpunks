using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarrenWarriorsGame
{
    //class is currently being modified by Eddie for use in player-enemy interactions
	public class Attack //--not currently in use anywhere --//
	{
		//how much damage the attack does
		private int damage;

		//how long the attack takes
		private double Length;

		//holds the timer to keep track of if the player is attacking or not
		private double timer;

        /// <summary>
        /// parameterized constructor for attack that initializes a unit's base damage, base attack speed, 
        /// and the units targeted by the attack
        /// </summary>
        /// <param name="dmg">The base damage a unit can deal (damage modifier)</param>
        /// <param name="time"> The base time a unit takes to attack (timer modifier)</param>
		public Attack(int dmg, double time)
		{
			damage = dmg;
			Length = time;
		}

        /// <summary>
        /// method to handle combat encounters. May end up becoming its own class
        /// or split up between other classes
        /// </summary>
        public void CombatEncounter()
        {
            //encounter begins if (entire enemy sprite is on screen?)
            //(a timer counts down and an enemy is spawned?)

            //if the game ends up having any sort of player movement, lock player characters 
            //and the game screen in place until the encounter is over

            //bool inEncounter = true;

            //enemy attacks repeatedly until they die

            //player characters attack based on player input (duh)
            //once a player selects a weapon to attack with and chooses to attack,
            //a player attack is initiated on a timer based on weapon type and base player
            //attack speed

            //players and enemy take damage when a given attack timer ends
            //when a player character attacks the selected item is removed from their inventory

            //encounter ends when enemy health is 0
        }

        public void ExecuteAttack(Unit attackTarget)
        {
            //pause the attack timers of all other units,
            //damage enemy, then unpause other attack timers

            //may require an attack timer class and pause/unpause enums
        }

	}
}
