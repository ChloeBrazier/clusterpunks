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
/// class that holds methods used to manage the game in its combat stat
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

        //field for a string queue for the battle log
        private Queue<string> logQueue;
        
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
            //will handle locking the screen and setting inEncounter to true
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

        /// <summary>
        /// basic method for the battle log that needs fleshing out
        /// must add way to handle all info in the log and properly display it
        /// (very basic)
        /// </summary>
        /// <param name="battleInfo"> takes in a string based on a given event in battle </param>
        /// <returns> the information added to the log </returns>
        public string BattleLog(string battleInfo)
        {
            //add the string to the battle log queue
            logQueue.Enqueue(battleInfo);

            //plans for implementation: 
            // - add string to queue when character attaks
            // - print all string in queue
            // - remove the item at the front of the queue if count is > x number
            // - draw latest info in the log in a different color?

            //return battle log info to be printed on screen
            string logString = logQueue.Dequeue();
            return logString;
        }
    }
}
