using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarrenWarriorsGame
{
    public class Encounter
    {
        Difficulty roomDifficulty; //the difficulty of the encounter
        Enemy[] enemy; //the enemies that you will fight in the room

        public Encounter(Difficulty dif) //build the room based on difficulty
        {
            roomDifficulty = dif;
            switch (roomDifficulty)
            {



            }

        }

        //this will likely be used in the building of the dungeon but will not be called directly


        /// <summary>
        /// WILL REMOVE WHEN FEATURES DESCRIBED HAVE ALL BEEN IMPLEMENTED
        /// </summary>
        public void CombatEncounter()
        {
            //temporary code for reference

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

        //instead this will be used to feed stuff into the combat handler when the time comes


    }
}
