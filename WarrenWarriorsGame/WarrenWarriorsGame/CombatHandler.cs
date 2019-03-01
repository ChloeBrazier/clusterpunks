﻿using System;
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
    public class CombatHandler
    {
        //field for a bool that determines if a combat encounter 
        //has been intiiated
        private bool inEncounter;

        //field for the player party
        PlayerChar[] playerParty;

        //field for enemy
        Enemy enemy;
        
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
    }
}