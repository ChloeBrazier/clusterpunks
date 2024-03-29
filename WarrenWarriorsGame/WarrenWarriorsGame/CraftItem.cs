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
    /// <summary>
    /// Warren Warriors
    /// John Bateman
    /// Noah Hulick
    /// items held in player inventory. hold an attack 
    /// 3/8/2019
    /// </summary>
    public class CraftItem
    {
        private Attack dmg; // holds how much damage the attack should do
        List<Item> Components = new List<Item>(); //holds what components an item has. is used for crafting
        Item itemType;
        int duration; //item durability

        //string to hold an item's name
        string itemName;

       //stringt to hold an item's information

        private string itemInfo;

        //accessor for item damage
        public Attack Dmg
        {
            get
            {
                return dmg;
            }
        }

        //accessor for item type
        public Item ItemType
        {
            get
            {
                return itemType;
            }
        }

        //accessor for item name
        public string ItemName
        {
            get
            {
                return itemName;
            }
        }

        //accessor for item information
        public string ItemInfo
        {
            get
            {
                return itemInfo;
            }
        }

        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
		
        public CraftItem(Item Type) //create generic item generation
        {

            //--this is temporary and meant to be changed later--//

            itemType = Type;
			//when this is changed also change the inventory code
            switch (Type)
            {
                case Item.Empty:

                    itemName = "unarmed";
                    duration = 0;
                    itemInfo = "Default attack, deals 2 damage.";
                    break;
                case Item.Stick: //individual values can be read in or changed later
                    itemName = "a stick";
                    Components.Add(Item.Stick);
                    dmg = new Attack(3, 4);
                    duration = 3;
                    itemInfo = "Tier 1 item, deals 3 damage.";
                    break; 
                case Item.Nails:
                    itemName = "a blade";
                    Components.Add(Item.Nails);
                    dmg = new Attack(3, 4);
                    duration = 3;
                    itemInfo = "Tier 1 item, deals 3 damage.";
                    break;
                case Item.Matches:
                    itemName = "some matches";
                    Components.Add(Item.Matches);
                    dmg = new Attack(3, 4);
                    duration = 3;
                    itemInfo = "Tier 1 item, deals 3 damage,";
                    break;
                case Item.Torch:
                    itemName = "a torch";
                    itemInfo = "Tier 2 item, deals 5 damage.";
                    Components.Add(Item.Stick);
                    Components.Add(Item.Matches);
                    dmg = new Attack(5, 5);
                    duration = 4;
                    break;
                case Item.SpikeBat:
                    itemName = "a knife";
                    Components.Add(Item.Stick);
                    Components.Add(Item.Nails);
                    dmg = new Attack(5, 5);
                    duration = 4;
                    itemInfo = "Tier 2 item, deals 5 damage.";
                    break;
                case Item.HotNails:
                    itemName = "a heated blade";
                    Components.Add(Item.Nails);
                    Components.Add(Item.Matches);
                    dmg = new Attack(5, 5);
                    duration = 4;
                    itemInfo = "Tier 2 item, deal 5 damage.";
                    break;

                case Item.SpikeTorch:
                    itemName = "a hot knife";
                    Components.Add(Item.Nails);
                    Components.Add(Item.Matches);
                    Components.Add(Item.Stick);
                    dmg = new Attack(7, 6);
                    duration = 5;
                    itemInfo = "Tier 3 item, deals 7 damage.";
                    break;

            }

            Components.Sort();

        }

        /// <summary>
        /// send in two craftitems and outputs a third from the craffting, order does not matter, level two items can be combined, combining an item that is already contained causes no changes
        /// </summary>
        /// <param name="item1">the first item</param>
        /// <param name="item2">the second item</param>
        public CraftItem(CraftItem item1, CraftItem item2)
        {

            //add components to the item only if the component isn't empty
            foreach(Item i in item1.Components)
            {
                if (i != Item.Empty && Components.IndexOf(i)==-1)
                {
                    Components.Add(i);
                }
            }
            foreach (Item i in item2.Components)
            {
                if (i != Item.Empty && Components.IndexOf(i) == -1)
                {
                    Components.Add(i);
                }
            }
            //store the items components

            if (Components.Count() == 0)
            {
                CraftItem temp = new CraftItem(Item.Empty);
                dmg = temp.dmg;
                itemType = temp.ItemType;
                itemInfo = temp.ItemInfo;
            }

            Components.Sort();

            //loop through all of the items
            foreach (CraftItem i in Config.AllItems)
            {
                //if the items have the same component as the new item
                if(Components.Except(i.Components).ToList<Item>().Count() == 0 && i.Components.Except(Components).ToList<Item>().Count() == 0) 
                {
                    //finish the creation of the item
                    dmg = i.dmg;
                    itemType = i.itemType;
                    duration = i.Duration;
                    itemInfo = i.itemInfo;

                    //add crafting notification to battle log
                    BattleLog.AddCraft(this);
                }

            }


        }

		public override string ToString() //-- when fully implemented you may change this or use the draw method
		{
            switch (ItemType)
            {
                case Item.Empty:
                    return "(Empty)";
                case Item.Matches:
                    return "Matches";
                case Item.Nails:
                    return "Blade";
                case Item.Stick:
                    return "Stick";
                case Item.SpikeBat:
                    return "Knife";
                case Item.Torch:
                    return "Torch";
                case Item.HotNails:
                    return "Heated Blade";
                case Item.SpikeTorch:
                    return "Flaming Knife";


            }
            return "Item not found";
        }

		public static void Draw(SpriteBatch sb)//use this to draw when fully implemented
		{

		}

	}
}
