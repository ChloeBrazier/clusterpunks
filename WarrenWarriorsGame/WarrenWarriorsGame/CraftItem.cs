﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WarrenWarriorsGame
{
    class CraftItem
    {
        private Attack dmg; // holds how much damage the attack should do
        List<Item> Components = new List<Item>(); //holds what components an item has. is used for crafting

        public CraftItem(Item Type) //create generic item generation
        {
            switch (Type)
            {
                case Item.Empty:

                    break;
                case Item.Stick: //individual values can be read in or changed later
                    Components.Add(Item.Stick);
                    dmg = new Attack(3, 4, new List<int>() { 3 });
                    break;
                case Item.Nails:
                    Components.Add(Item.Nails);
                    dmg = new Attack(3, 4, new List<int>() { 4 });
                    break;
                case Item.Matches:
                    Components.Add(Item.Matches);
                    dmg = new Attack(3, 4, new List<int>() { 5 });
                    break;
                case Item.Torch:
                    Components.Add(Item.Stick);
                    Components.Add(Item.Matches);
                    dmg = new Attack(5, 5, new List<int>() { 3, 5 });
                    break;
                case Item.SpikeBat:
                    Components.Add(Item.Stick);
                    Components.Add(Item.Nails);
                    dmg = new Attack(5, 5, new List<int>() { 3, 4 });
                    break;
                case Item.HotNails:
                    Components.Add(Item.Nails);
                    Components.Add(Item.Matches);
                    dmg = new Attack(5, 5, new List<int>() { 5, 4 });
                    break;
                case Item.SpikeTorch:
                    Components.Add(Item.Nails);
                    Components.Add(Item.Matches);
                    Components.Add(Item.Stick);
                    dmg = new Attack(7, 6, new List<int>() { 3, 4,5 });
                    break;

            }
        }

    }
}