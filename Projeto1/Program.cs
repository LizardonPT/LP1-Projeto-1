using System;

namespace Projeto1
{
    class Program
    {
        static void Main(string[] args)
        {
            int [,] map = new int [8,8];
            int [] pos = new int [2];
            pos[0] = 0;
            pos[1] = 1;
            map[pos[0],pos[1]] = 1;
            while (true)
            {
            pos = Movement(map, pos);
            }
        }

        static int [] Movement(int [,] map, int [] pos)
        {
            //Diz aonde ele esta agora
            Console.WriteLine($"O wolf esta em {pos[0]}, {pos[1]}");

            //Estas duas for vao dizer o caminho que ele pode fazer
            Console.WriteLine("Doable Movements :");
            for(int h=-1; h<2; h++)
            {
                if(h != 0)
                {
                    for(int g =-1; g<2; g++)
                    {
                        if((pos[0]+h > -1) && (pos[0]+h < 8) && (pos[1]+g > -1) && (pos[1]+g < 8))
                        {
                            if(g != 0)
                            {
                                if(map[pos[0]+h,pos[1]+g] != 2)
                                {
                                    Console.WriteLine($"{pos[0]+h}, {pos[1]+g}");
                                    map[pos[0]+h,pos[1]+g] = 3;
                                }
                            }
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

            Console.WriteLine($"Agora o Wolf esta em {pos[0]}, {pos[1]}");

            return pos;
        }
    }
}
