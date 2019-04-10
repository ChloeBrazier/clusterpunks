using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*Name(s):
 *Instructor: Erin Cascioli
 *Course: IGME 106
 *Group Project: Cluster Punks
 *Battle Log class: a static class that contains methods to print combat information
 *on screen and clear information when necessary
 */

namespace WarrenWarriorsGame
{
    static class BattleLog
    {
        //field for a string queue for the battle log
        static private Queue<string> logQueue = new Queue<string>();

        /// <summary>
        /// adds a string to the queue summarizing a player character's attack
        /// </summary>
        /// <param name="charName"> The name of the player character who is attacking </param>
        /// <param name="targetName"> the enemy being attacked </param>
        /// <param name="item"> the item the player is attacking with </param>
        public static void AddPlayerAttackEnd(string charName, string targetName, int damage)
        {
            logQueue.Enqueue(charName + " attacked " + targetName + " for " + damage + " damage");
        }

        /// <summary>
        /// adds a string that informs the user that a player character has started their attack
        /// </summary>
        /// <param name="player"> The party member whose attack has been initiated </param>
        public static void AddPlayerAttackStart(PlayerChar player)
        {
            logQueue.Enqueue(player.Name + " is attacking the enemy!");
        }

        /// <summary>
        /// adds a string to the queue summarizing an enemy's attack
        /// </summary>
        /// <param name="enemyName"> the name of the enemy </param>
        /// <param name="targetName"> the player char attacked by the enemy </param>
        public static void AddEnemyAttack(string enemyName, string targetName)
        {
            logQueue.Enqueue(enemyName + " is attacking " + targetName + "!");
        }

        /// <summary>
        /// adds a string to the log when player positions are switched
        /// </summary>
        /// <param name="enemyName"> the name of the enemy </param>
        /// <param name="targetName"> the name of the enemy's new target </param>
        public static void ChangeEnemyTarget(string enemyName, string targetName)
        {
            logQueue.Enqueue(enemyName + " is now attacking " + targetName + "!");
        }

        public static void AddEnemyAttackEnd(string enemyName, string targetName, int enemyDamage)
        {
            logQueue.Enqueue(enemyName + " attacked " + targetName + " for " + enemyDamage + " damage!");
        }

        /// <summary>
        /// adds a string to the log when a player crafts and item
        /// </summary>
        /// <param name="charName"> the name of the party member who crafts an item </param>
        /// <param name="item"> the item that was crafted </param>
        public static void AddCraft(CraftItem item)
        {
            logQueue.Enqueue("Crafted " + item.ToString());
        }

        /// <summary>
        /// notifies player that the room they have entered has
        /// no enemies and they will receive items
        /// </summary>
        public static void ItemDrops()
        {
            logQueue.Enqueue("Nobody's here... but there's a stash of ITEMS");
            logQueue.Enqueue("~INVENTORY REFILLED~");
        }

        /// <summary>
        /// informs player of the enemy they will face 
        /// in the current room
        /// </summary>
        /// <param name="enemyName"> the name of the enemy in the current room</param>
        public static void EnemySpawn(string enemyName)
        {
            logQueue.Enqueue(enemyName + " has appeared!");
            logQueue.Enqueue("~TIME TO FIGHT~");
        }

        /// <summary>
        /// checks the size of the queue and removes the oldest
        /// string when count exceeds a certain number
        /// </summary>
        public static void CheckQueue()
        {
            if(logQueue.Count > 6)
            {
                logQueue.Dequeue();
            }
        }

        /// <summary>
        /// clears the battle log (used after an encounter)
        /// </summary>
        public static void ClearLog()
        {
            logQueue.Clear();
        }

        /// <summary>
        /// update method that prints the battle log on screen
        /// </summary>
        public static void Draw(Game g, SpriteBatch sb, SpriteFont font)
        {
            //create a temporary vector to control spacing of log text
            Vector2 logVector = new Vector2(460, (g.GraphicsDevice.Viewport.Height/3 * 2));
            Console.WriteLine(logVector);

            //run checkqueue to get rid of the oldest message in the log
            CheckQueue();

            //create temporary array to print log info
            string[] logArray = logQueue.ToArray();

            //create log text color that changes depending on whether
            //the text is the latest in the log
            Color logTextColor = Color.White;

            //print all info in the log
            for(int i = 0; i < logArray.Length; i++)
            {
                //change text to red if item is latest in the queue
                if(i == logArray.Length - 1)
                {
                    logTextColor = Color.Red;
                }

                sb.DrawString(
                    font, 
                    logArray[i], 
                    new Vector2(logVector.X, logVector.Y + (i * 15)), 
                    logTextColor
                    );
            }
        }
    }
}
