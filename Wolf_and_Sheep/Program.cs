﻿using System;

namespace Wolf_and_Sheep
{
    class Program
    {
        // Starts the game with the menu

        /// <summary>
        /// Starts the game with the menu
        /// </summary>    
        static void Main(string[] args)
        {
            //Variables

            int menu_action = 0;
            string menu_awnser;
            string wolfstartpos;
            bool chosen_map = false;
            int [] wolfpos = new int [2];
            int [] sheep1pos = new int [2];
            int [] sheep2pos = new int [2];
            int [] sheep3pos = new int [2];
            int [] sheep4pos = new int [2];

            //Menu

            while(true)
            {
                Console.WriteLine("Welcome to Wolf and Sheep : The Game");
                Console.WriteLine("               Start                ");
                Console.WriteLine("               Rules                ");
                Console.WriteLine("               Quit                 ");
                menu_awnser = Console.ReadLine();

                /*
                    Depending of what the player choses, the game may start
                    , show the rules or quit the program.
                    The player can also quit at any moment of the game.
                */
                switch (menu_awnser)
                {
                    case "Start":
                        menu_action = 1;
                        break;
                    case "Rules":
                        menu_action = 2;
                        break;
                    case "Quit":
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Quitting the game ...");
                        Console.WriteLine("-----------------------------------");
                        return;
                }

                // The game starts

                if (menu_action == 1)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("May the game begin !");
                    Console.WriteLine("-----------------------------------");
                    break;
                }

                // Show the rules

                else if (menu_action == 2)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Wolf:");
                    Console.Write("As a wolf, you have to move to the other"); 
                    Console.Write("side of the board to win");
                    Console.WriteLine("You can move in every direction");
                    Console.WriteLine("Sheep:");
                    Console.Write("As the sheep, you have to block every");
                    Console.Write("movement of the wolf to win");
                    Console.WriteLine("You can move only forward");
                    Console.WriteLine("-----------------------------------");
                }
                
            }
            
            //Map creation

            int [,] map = new int [8,8];
            
            //Wolf and Sheep initial position (1=Wolf, 2=Sheep)

            //Wolf initial position

            Console.WriteLine("Preparing board :");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Player 1, choose Wolf starting position");
            Console.WriteLine("(0,1; 0,3; 0,5 or 0,7)");
            wolfstartpos = Console.ReadLine();

            /* 
                Depending of the player is choice, the wolf
                can start in 4 different cases. If the player don't put the
                right case, the code will ask again to put a right one.
            */
            while(chosen_map != true)
            {
                switch (wolfstartpos)
                {
                    case "0,1":
                        map[0,1] = 1;
                        wolfpos[0] = 0;
                        wolfpos[1] = 1;
                        Console.WriteLine("----------------------------------");
                        Console.Write($"The wolf starts at {wolfpos[0]},");
                        Console.WriteLine($"{wolfpos[1]}");
                        chosen_map = true;
                        break;
                    
                    case "0,3":
                        map[0,3] = 1;
                        wolfpos[0] = 0;
                        wolfpos[1] = 3;
                        Console.WriteLine("----------------------------------");
                        Console.Write($"The wolf starts at {wolfpos[0]},");
                        Console.WriteLine($"{wolfpos[1]}");
                        chosen_map = true;
                        break;
                    
                    case "0,5":
                        map[0,5] = 1;
                        wolfpos[0] = 0;
                        wolfpos[1] = 5;
                        Console.WriteLine("----------------------------------");
                        Console.Write($"The wolf starts at {wolfpos[0]},");
                        Console.WriteLine($"{wolfpos[1]}");
                        chosen_map = true;
                        break;
                    
                    case "0,7":
                        map[0,7] = 1;
                        wolfpos[0] = 0;
                        wolfpos[1] = 7;
                        Console.WriteLine("----------------------------------");
                        Console.Write($"The wolf starts at {wolfpos[0]},");
                        Console.WriteLine($"{wolfpos[1]}");
                        chosen_map = true;
                        break;
                    
                    case "Quit":
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Quitting the game ...");
                        Console.WriteLine("-----------------------------------");
                        return;

                    default:
                        Console.WriteLine("That's not a valid option");
                        wolfstartpos = Console.ReadLine();
                        break;
                }
            }
            
            //Sheep initial position

            for(int i=0; i<7; i+=2)
            {
                map[7,i] = 2;
            }
            sheep1pos[0] = 7;
            sheep1pos[1] = 0;
            sheep2pos[0] = 7;
            sheep2pos[1] = 2;
            sheep3pos[0] = 7;
            sheep3pos[1] = 4;
            sheep4pos[0] = 7;
            sheep4pos[1] = 6;

            //Starts the game

            while (true)
            {
                // Beginning of the player controlling the wolf's turn

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Player 1, it's your turn:");
                Console.WriteLine("-----------------------------------");

                // Initiation of the module for the movement of the wolf

                wolfpos = WolfMovement(map, wolfpos);

                // Win condition for wolf

                if(wolfpos[0] == 7)
                {
                    Console.WriteLine("Good job Player 1, you won !!!");
                    break;
                }

                // Win condition for the sheep

                if(wolfpos[0] == 999)
                {
                    Console.WriteLine("Good job Player 2, you won !!!");
                    break;
                }

                // If the player controlling the wolf want to quit the game

                if(wolfpos[0] == -999)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Quitting the game ...");
                    Console.WriteLine("-----------------------------------");
                    return;
                }
                
                // Beginning of the player controlling the sheep's turn

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Player 2, it's your turn:");
                Console.WriteLine("-----------------------------------");
                ChoseSheep(ref sheep1pos, ref sheep2pos, ref sheep3pos, 
                ref sheep4pos, ref map);

                // If the player controlling the sheep want to quit the game

                if((sheep1pos[0] == -999) || (sheep2pos[0] == -999) || 
                (sheep3pos[0] == -999) || (sheep4pos[0] == -999))
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Quitting the game ...");
                    Console.WriteLine("-----------------------------------");
                    return;
                }

            }

            // The game is over and it shows how the board is before quitting
            Board(map);
            Console.WriteLine("Game Over");

        }
        
        // Method for Wolf movements

        /// <summary>
        /// Method for Wolf movements
        /// </summary>
        static int [] WolfMovement(int [,] map, int [] pos)
        {
            //Variable to see if the wolf can move
            int possible_mov = 0;

            //Shows the board

            Board(map);

            /* 
                This will analyze the black cases around the wolf and tell
                which ones are free
            */
            Console.WriteLine("Doable Movements :");
            for(int x=-1; x<2; x++)
            {
                if(x != 0)
                {
                    for(int y =-1; y<2; y++)
                    {
                        if((pos[0]+x > -1) && (pos[0]+x < 8) && (pos[1]+y > -1) 
                        && (pos[1]+y < 8))
                        {
                            if(y != 0)
                            {
                                if(map[pos[0]+x,pos[1]+y] != 2)
                                {
                                    Console.WriteLine($"{pos[0]+x}, {pos[1]+y}");
                                    map[pos[0]+x,pos[1]+y] = 3;
                                    possible_mov += 1;
                                }
                            }
                        }
                    }
                }
            }

            // This is to check if the wolf lost or not

            if (possible_mov == 0)
            {
                Console.WriteLine("You can't move your wolf");
                pos[0] = 999;
                return pos;
            }

            // With the preview choices the player must choose where to go

            Console.WriteLine("Choose your destination (x and then y) :");

            // Asks for x and y coordinates to move

            while (true)
            {
                Console.Write("x = ");
                string f_x = Console.ReadLine();

                // See if he wants to quit

                if (f_x == "Quit")
                {
                    pos[0] = -999;
                    return pos;
                }

                Console.Write("y = ");
                string f_y = Console.ReadLine();

                // See if he wants to quit

                if (f_y == "Quit")
                {
                    pos[0] = -999;
                    return pos;
                }

                int futur_x =int.Parse(f_x);
                int futur_y =int.Parse(f_y);

                if ((futur_x > -1) && (futur_x < 8) && (futur_y > -1) && 
                (futur_y < 8) && (map[futur_x,futur_y] == 3))
                {
                    //Actualize positions

                    map[pos[0], pos[1]] = 0;
                    pos[0] = futur_x;
                    pos[1] = futur_y;
                    map[pos[0], pos[1]] = 1;
                    break;
                }

                else
                {
                    Console.WriteLine("You can't go there, try again");
                }
            }

            Console.WriteLine($"The Wolf is now at {pos[0]}, {pos[1]}");

            return pos;
        }
        
        // Method to choose the Sheep that will move

        /// <summary>
        /// Method to choose the Sheep that will move
        /// </summary>
        static void ChoseSheep(ref int [] sheep1pos, ref int [] sheep2pos, 
        ref int [] sheep3pos, ref int [] sheep4pos, ref int [,] map)
        {
            //Variables 

            string sheepchosen;
            bool chosen_sheep = false;
            
            //Shows the board and demands the player to choose a sheep

            Board(map);
            Console.WriteLine("Which sheep are you going to move?");
            Console.WriteLine("(S1, S2, S3 or S4)");
            sheepchosen = Console.ReadLine();

            while(chosen_sheep != true)
            {
                switch (sheepchosen)
                {
                    case "S1":
                        chosen_sheep = true;
                        sheep1pos = Sheepmovement(map, sheep1pos);
                        break;
                    
                    case "S2":
                        chosen_sheep = true;
                        sheep2pos = Sheepmovement(map, sheep2pos);
                        break;
                    
                    case "S3":
                        chosen_sheep = true;
                        sheep3pos = Sheepmovement(map, sheep3pos);
                        break;
                    
                    case "S4":
                        chosen_sheep = true;
                        sheep4pos = Sheepmovement(map, sheep4pos);
                        break;

                    case "Quit":
                        chosen_sheep = true;
                        sheep1pos[0] = -999;
                        break;
                    
                    default:
                        Console.WriteLine("That's not a valid option");
                        sheepchosen = Console.ReadLine();
                        break;
                }
            }
        }
        // Method for the Sheep movement

        /// <summary>
        /// Method for the Sheep movement
        /// </summary>
        static int [] Sheepmovement(int [,] map, int [] pos)
        {
            //Variable to see if the sheep can move

            int possible_mov = 0;

            /* 
                This will analyze the black cases in front of the chosen sheep 
                and tell which ones are free
            */

            Console.WriteLine("Doable Movements :");

            for(int y =-1; y<2; y++)
            {
                if((pos[0]-1 > -1) && (pos[0]-1 < 8) && (pos[1]+y > -1) && 
                (pos[1]+y < 8))
                {
                    if(y != 0)
                    {
                        if((map[pos[0]-1,pos[1]+y] != 2) && (map[pos[0]-1,
                        pos[1]+y] != 1))
                        {
                            Console.WriteLine($"{pos[0]-1}, {pos[1]+y}");
                            map[pos[0]-1,pos[1]+y] = 3;
                            possible_mov += 1;
                        }
                    }
                }
            }

            /* 
                This is to check if the sheep can move or not 
                if not, he loses a turn
            */
            if (possible_mov == 0)
            {
                Console.Write("You can't move with this sheep, you lost");
                Console.WriteLine("your turn");
                return pos;
            }

            else
            {
 
                //With the preview choices the player must choose where to go

                Console.WriteLine("Choose your destination (x and then y) :");

                //Asks for x and y coordinates to move

                while (true)
                {
                    Console.Write("x = ");
                    string f_x = Console.ReadLine();

                    // See if he wants to quit

                    if (f_x == "Quit")
                    {
                        pos[0] = -999;
                        return pos;
                    }

                    Console.Write("y = ");
                    string f_y = Console.ReadLine();

                    // See if he wants to quit

                    if (f_y == "Quit")
                    {
                        pos[0] = -999;
                        return pos;
                    }

                    int futur_x =int.Parse(f_x);
                    int futur_y =int.Parse(f_y);
                    if ((futur_x > -1) && (futur_x < 8) && (futur_y > -1) && 
                    (futur_y < 8) && (map[futur_x,futur_y] == 3))
                    {
                        //Actualize positions

                        map[pos[0], pos[1]] = 0;
                        pos[0] = futur_x;
                        pos[1] = futur_y;
                        map[pos[0], pos[1]] = 2;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You can't go there, try again");
                    }
                }

                Console.WriteLine($"Now this Sheep is at {pos[0]}, {pos[1]}");

                return pos;
            }
        }

        // Draws the board

        /// <summary>
        /// Draws the board
        /// </summary>
        static void Board(int [,] map)
        {
            int count_down = 0;
            for(int x=0; x<11; x++)
            {
                for(int y =0; y<11; y++)
                {
                    // This will draw the numbers on the top of the board

                    if (x == 0)
                    {
                        if (y < 2)
                        {
                            Console.Write(" ");
                        }
                        else 
                        {
                            Console.Write(count_down);
                            count_down += 1;
                            if (count_down > 7)
                            {
                                count_down = 0;
                                break;
                            }
                        }
                    }

                    // This will draw the numbers on the left of the board

                    else if ((x > 0) && (y == 0))
                    {
                        if((x == 1) || (x == 10))
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write(count_down);
                            count_down += 1;
                        }
                    }

                    // This will make the top and the bottom of the board

                    else if ((y > 0) && ((x == 1) || (x == 10)))
                    {
                        Console.Write("_");
                    }

                    // This will make the sides of the board

                    else if ((x > 1) && ((y == 1) || (y == 10)))
                    {
                        Console.Write("|");
                    }

                    // This will draw the inside of the board

                    else
                    {
                        if(map[x-2,y-2] == 3 )
                        {
                            map[x-2,y-2] = 0;
                            Console.Write("-");
                        }
                        else if(map[x-2,y-2] == 0 )
                        {
                            Console.Write("-");
                        }
                        else if(map[x-2,y-2] == 1 )
                        {
                            Console.Write("W");
                        }
                        else if(map[x-2,y-2] == 2 )
                        {
                            Console.Write("S");
                        }
                    }
                }
                
                Console.WriteLine(" ");
            }
        }
    }
}