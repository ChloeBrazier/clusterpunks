using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarrenWarriorsGame
{
	public class Attack //--not currently in use anywhere --//
	{
		//how much damage the attack does
		private int damage;
		//how long the attack takes
		private double Length;
		//holds the timer to keep track of if the player is attacking or not
		private double timer;

		private List<int> positions = new List<int>();

		public Attack(int dmg, double time, List<int> targets)
		{
			damage = dmg;
			Length = time;
			positions = targets;
		}

	}
}
