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

        //field for a target enemy used in the attack method
        //no longer initialized upon attack object creation
        private Unit attackTarget;

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

	}
}
