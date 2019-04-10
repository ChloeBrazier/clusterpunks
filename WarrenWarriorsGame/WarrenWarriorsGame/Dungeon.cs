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
    public class Dungeon
    {
        Random rn = new Random();
        Button[,] roomButtons;
        Encounter[,] dungeonlayout;

        public Dungeon(Game g)
        {
            int roller;
            roomButtons = new Button[20, 20];
            dungeonlayout = new Encounter[20, 20];

            //Creates Buttons in Array
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    roller = rn.Next(0, 5);
                    switch (roller)
                    {
                        case 0:
                            dungeonlayout[x, y] = new Encounter(Difficulty.None);
                            break;
                        case 1:
                            dungeonlayout[x, y] = new Encounter(Difficulty.Easy);
                            break;
                        case 2:
                            dungeonlayout[x, y] = new Encounter(Difficulty.Medium);
                            break;
                        case 3:
                            dungeonlayout[x, y] = new Encounter(Difficulty.Hard);
                            break;
                        case 4:
                            dungeonlayout[x, y] = new Encounter(Difficulty.Boss);
                            break;
                    }

                    //Need sprites for button modes before this can be implemented
                    roomButtons[x, y] = new Button(g.Content.Load<Texture2D>("RoomNormal"), g.Content.Load<Texture2D>("RoomNext"), g.Content.Load<Texture2D>("RoomCleared"), new Rectangle(x*20, y*20, 15,15));
                    
                    
                }
            }
        }
        public void Update()
        {
            /*
             used to select which encounter the user will be fighting next
             */
        }
        public void Draw()
        {
            /*
             draw only the rooms the user can select to the screen
             
             */
        }

    }
}
