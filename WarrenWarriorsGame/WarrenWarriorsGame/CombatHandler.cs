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
/// class that holds methods used to manage the game in its combat state
/// 3/8/2019
/// </summary>
namespace WarrenWarriorsGame
{
    public class CombatHandler
    {
        //field for a bool that determines if a combat encounter 
        //has been intiiated
        private bool inEncounter;

        //field for the player party
        private PlayerChar[] playerParty;

        //field for enemy
        private Enemy enemy;

        //accessor for inEncounter
        public bool InEncounter
        {
            get
            {
                return inEncounter;
            }
        }

        public CombatHandler(PlayerChar[] Units, Enemy nme)
        {
            //initialize player party
            playerParty = Units;

            //initialize enemy
            enemy = nme;

            //set inEnounter to false as a default
            inEncounter = false;
        }

        public void EnterEncounter()
        {
            //set inEncounter to true
            inEncounter = true;

            //send in enemy's encounter text
            BattleLog.EnemySpawn(enemy.Name);
        }

        public void CheckEncounter()
        {
            //will handle checking if an encounter is over
            //based on player and enemy health

            //if all players die, end encounter and run gameover (when it's made)
            //if enemy dies, end encounter and continue the game
        }

        /// <summary>
        /// method that returns the palyer party's total health
        /// </summary>
        /// <returns> the party's total health </returns>
        public int PartyHealth()
        {
            int partyHealth = 0;

            foreach(PlayerChar player in playerParty)
            {
                partyHealth = partyHealth + player.Health;
            }

            return partyHealth;
        }

		public int EnemyHealth()
		{
			int enemyHealth = enemy.Health;
			return enemyHealth;
		}
	}
}
