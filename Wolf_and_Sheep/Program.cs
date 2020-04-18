using System;

namespace Wolf_and_Sheep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string wolfstartpos;
            bool chosen_map = false;
            int [] wolfpos = new int [2];
            int [] sheep1pos = new int [2];
            int [] sheep2pos = new int [2];
            int [] sheep3pos = new int [2];
            int [] sheep4pos = new int [2];
            
            //Map creation

            int [,] map = new int [8,8];
            
            //Wolf and Sheep initial position (1=Wolf, 2=Sheep)

            //Wolf initial position
            Console.WriteLine("Player 1 Turn:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Choose Wolf starting position");
            Console.WriteLine("(A2, A4, A6 or A8)");
            wolfstartpos = Console.ReadLine();
            while(chosen_map != true)
            {
                switch (wolfstartpos)
                {
                    case "A2":
                        map[0,1] = 1;
                        wolfpos[0] = 0;
                        wolfpos[1] = 1;
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine($"The wolf starts at 'A2' {wolfpos[0]},{wolfpos[1]}");
                        chosen_map = true;
                        break;
                    
                    case "A4":
                        map[0,3] = 1;
                        wolfpos[0] = 0;
                        wolfpos[1] = 3;
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine($"The wolf starts at 'A4' {wolfpos[0]},{wolfpos[1]}");
                        chosen_map = true;
                        break;
                    
                    case "A6":
                        map[0,5] = 1;
                        wolfpos[0] = 0;
                        wolfpos[1] = 5;
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine($"The wolf starts at 'A6' {wolfpos[0]},{wolfpos[1]}");
                        chosen_map = true;
                        break;
                    
                    case "A8":
                        map[0,7] = 1;
                        wolfpos[0] = 0;
                        wolfpos[1] = 7;
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine($"The wolf starts at 'A8' {wolfpos[0]},{wolfpos[1]}");
                        chosen_map = true;
                        break;
                    
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
            ChoseSheep(ref sheep1pos, ref sheep2pos, ref sheep3pos, ref sheep4pos, ref map);
        }
        static void ChoseSheep(ref int [] sheep1pos, ref int [] sheep2pos, ref int [] sheep3pos, ref int [] sheep4pos, ref int [,] map)
        {
            //Variables 
            string sheepchosen;
            bool chosen_sheep = false;
            
            //Player sheep choice to play
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Player 2 Turn:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Witch sheep are you going to move?");
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
                    
                    default:
                        Console.WriteLine("That's not a valid option");
                        sheepchosen = Console.ReadLine();
                        break;
                }
            }
        }
        static int [] Sheepmovement(int [,] map, int [] pos)
        {
            Console.WriteLine($"The Sheep is  {pos[0]}, {pos[1]}");

            //Estas duas for vao dizer o caminho que ele pode fazer
            Console.WriteLine("Doable Movements :");

            for(int g =-1; g<2; g++)
            {
                if((pos[0]-1 > -1) && (pos[0]-1 < 8) && (pos[1]+g > -1) && (pos[1]+g < 8))
                {
                    if(g != 0)
                    {
                        if((map[pos[0]-1,pos[1]+g] != 2) && (map[pos[0]-1,pos[1]+g] != 1))
                        {
                            Console.WriteLine($"{pos[0]-1}, {pos[1]+g}");
                            map[pos[0]-1,pos[1]+g] = 3;
                        }
                    }
                }
            }

            
            //Com as escolhas anteriores, ele vai poder se mexer
            Console.WriteLine("Choose your destination (x and then y) :");

            //Vai perguntar isto ate ter uma boa resposta
            while (true)
            {
            Console.Write("x = ");
            string f_x = Console.ReadLine();
            Console.Write("y = ");
            string f_y = Console.ReadLine();
            int futur_x =int.Parse(f_x);
            int futur_y =int.Parse(f_y);
            if ((futur_x > -1) && (futur_x < 8) && (futur_y > -1) && (futur_y < 8) && (map[futur_x,futur_y] == 3))
            {
                pos[0] = futur_x;
                pos[1] = futur_y;
                break;
            }
            else
            {
                Console.WriteLine("Nao pode ir para ai, tenta otra vez");
            }
            }

            Console.WriteLine($"Agora a Sheep esta em {pos[0]}, {pos[1]}");

            return pos;
        }
    }
}
