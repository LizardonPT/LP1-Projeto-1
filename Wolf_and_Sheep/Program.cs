using System;

namespace Wolf_and_Sheep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string wolfpos;
            bool chosen_map = false;
            
            //Map creation

            int [,] map = new int [8,8];
            
            //Wolf and Sheep initial position (1=Wolf, 2=Sheep)

            //Wolf initial position
            Console.WriteLine("Choose Wolf position");
            Console.WriteLine("(A2, A4, A6 or A8)");
            wolfpos = Console.ReadLine();
            while(chosen_map != true)
            {
                switch (wolfpos)
                {
                    case "A2":
                        map[0,1] = 1;
                        chosen_map = true;
                        break;
                    
                    case "A4":
                        map[0,3] = 1;
                        chosen_map = true;
                        break;
                    
                    case "A6":
                        map[0,5] = 1;
                        chosen_map = true;
                        break;
                    
                    case "A8":
                        map[0,7] = 1;
                        chosen_map = true;
                        break;
                    
                    default:
                        Console.WriteLine("That's not a valid starting position, please insert one of the options");
                        wolfpos = Console.ReadLine();
                        break;
                }
            }
            
            //Sheep initial position
            for(int i=0; i<7; i+=2)
            {
                map[7,i] = 2;
            }
            
        }
    }
}
