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
        public static void AddPlayerAttack(string charName, string targetName, int damage)
        {
            logQueue.Enqueue(charName + " attacked " + targetName + " for " + damage + " damage");
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

        /// <summary>
        /// adds a string to the log when a player crafts and item
        /// </summary>
        /// <param name="charName"> the name of the party member who crafts an item </param>
        /// <param name="item"> the item that was crafted </param>
        public static void AddCraft(CraftItem item)
        {
            logQueue.Enqueue("Crafted " + item.ItemName);
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
        /// clears the battle log
        /// </summary>
        public static void ClearLog()
        {
            logQueue.Clear();
        }

        /// <summary>
        /// update method that prints the battle log on screen
        /// </summary>
        public static void Update(Game g, SpriteBatch sb, SpriteFont font)
        {
            CheckQueue();
            foreach(string battleInfo in logQueue)
            {
                sb.DrawString(
                    font, 
                    battleInfo, 
                    new Vector2((g.GraphicsDevice.Viewport.Width/2 * 2), g.GraphicsDevice.Viewport.Height/2), 
                    Color.Black
                    );
            }
        }
    }
}
