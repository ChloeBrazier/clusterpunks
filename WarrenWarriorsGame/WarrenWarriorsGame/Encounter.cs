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
        }

        //this will likely be used in the building of the dungeon but will not be called directly
        //instead this will be used to feed stuff into the combat handler when the time comes


    }
}
