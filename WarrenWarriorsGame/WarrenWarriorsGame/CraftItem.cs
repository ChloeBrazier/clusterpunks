using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WarrenWarriorsGame
{
    public class CraftItem
    {
        private Attack dmg; // holds how much damage the attack should do
        List<Item> Components = new List<Item>(); //holds what components an item has. is used for crafting
        Item itemType;

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
		
        public CraftItem(Item Type) //create generic item generation
        {

            //--this is temporary and meant to be changed later--//

            itemType = Type;
			//when this is changed also change the inventory code
            switch (Type)
            {
                case Item.Empty:

                    break;
                case Item.Stick: //individual values can be read in or changed later
                    Components.Add(Item.Stick);
                    dmg = new Attack(3, 4);
                    break;
                case Item.Nails:
                    Components.Add(Item.Nails);
                    dmg = new Attack(3, 4);
                    break;
                case Item.Matches:
                    Components.Add(Item.Matches);
                    dmg = new Attack(3, 4);
                    break;
                case Item.Torch:
                    Components.Add(Item.Stick);
                    Components.Add(Item.Matches);
                    dmg = new Attack(5, 5);
                    break;
                case Item.SpikeBat:
                    Components.Add(Item.Stick);
                    Components.Add(Item.Nails);
                    dmg = new Attack(5, 5);
                    break;
                case Item.HotNails:
                    Components.Add(Item.Nails);
                    Components.Add(Item.Matches);
                    dmg = new Attack(5, 5);
                    break;
                case Item.SpikeTorch:
                    Components.Add(Item.Nails);
                    Components.Add(Item.Matches);
                    Components.Add(Item.Stick);
                    dmg = new Attack(7, 6);
                    break;

            }
            Components.Sort();

        }

        public CraftItem(CraftItem item1, CraftItem item2)
        {
            List<Item> materials = new List<Item>(); 

            //add components to the item
            foreach(Item i in item1.Components)
            {
                if (i != Item.Empty)
                {
                    materials.Add(i);
                }
            }
            foreach (Item i in item2.Components)
            {
                if (i != Item.Empty)
                {
                    materials.Add(i);
                }
            }
            //store the items components
            Components = materials;
            Components.Sort();

            //loop through all of the items
            foreach (CraftItem i in Config.AllItems)
            {
                //if the items have the same component as the new item
                if(Components == i.Components)
                {
                    //finish the creation of the item
                    dmg = i.dmg;
                    itemType = i.itemType;
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
                    return "Nails";
                case Item.Stick:
                    return "Stick";
                case Item.SpikeBat:
                    return "Spike Bat";
                case Item.Torch:
                    return "Torch";
                case Item.HotNails:
                    return "Hot Nails";
                case Item.SpikeTorch:
                    return "Spike Torch";


            }
            return "Item not found";
        }

		public static void Draw(SpriteBatch sb)//use this to draw when fully implemented
		{

		}

	}
}
