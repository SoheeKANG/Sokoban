using System;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo inputKey;
            // inputKey = Console.ReadKey(true);


            #region test while


            /*
            int posX = 5;
            int posY = 5;
            int blockX = 10;
            int blockY = 15;

            string player = "P";
            string block = "B";

            while (true)
            {
                Console.Clear();

                Console.SetCursorPosition(blockX, blockY);
                Console.Write(block);
                Console.SetCursorPosition(posX, posY);
                Console.Write(player);

                inputKey = Console.ReadKey(true);

                if (inputKey.Key == ConsoleKey.UpArrow)
                    posY = ((posY - 1) == blockY && (posX == blockX)) ? posY : posY - 1;

                if(inputKey.Key == ConsoleKey.DownArrow)
                    posY = ((posY + 1) == blockY && (posX == blockX)) ? posY : posY + 1;

                if(inputKey.Key == ConsoleKey.LeftArrow)
                    posX = ((posX - 1) == blockX && (posY == blockY)) ? posX : posX - 1;

                if(inputKey.Key == ConsoleKey.RightArrow)
                    posX = ((posX + 1) == blockX && (posY == blockY)) ? posX : posX + 1;

                if(posX >= 25 || posY >= 25)
                {
                    Console.Write("test 끝");
                    break;
                }
            }

            */

            #endregion


            /*
            string[,] map = new string[,] {
            { "B", "B", "B", "B", "B", "B", "B", "B", "B", "B" },
            { "B", "B", " ", "B", "B", "B", "B", " ", " ", "B" },
            { "B", "B", "A", "B", " ", " ", " ", " ", " ", "B" },
            { "B", "B", " ", "B", " ", " ", "B", "B", " ", "B" },
            { "B", "B", " ", "B", "B", " ", "B", "B", " ", "B" },
            { "B", " ", " ", "B", "B", " ", "B", "B", " ", "B" },
            { "B", " ", " ", " ", " ", " ", "B", "B", " ", "B" },
            { "B", "B", "B", "B", " ", " ", "B", "B", "G", "B" },
            { "B", "B", "B", "B", "B", "B", "B", "B", "B", "B" }

            };

            */

            string[] baseMap =  { "BBBBBBBBBB",
                              "BBPBBBB  B",
                              "BBAB     B",
                              "BB B  BB B",
                              "BB BB BB B",
                              "B  BB BB B",
                              "B     BB B",
                              "BBBB  BBGB",
                              "BBBBBBBBBB"};

            int curX = 1;
            int curY = 2;
            bool flag = true;

            char[][] map = new char[9][];

            for(int i = 0; i < baseMap.Length; i++)
            {
                map[i] = baseMap[i].ToCharArray();
            }

            while (flag)
            {
                if (map[curX][curY] == 'G')
                    flag = false;

                Console.Clear();

                /*
                for(int i = 0; i < map.GetLength(0); i++)
                {
                    for(int j = 0; j < map.GetLength(i); j++)
                    {
                        Console.Write(map[i][j]);
                    }
                    Console.WriteLine();
                } */

                for(int i = 0; i < map.Length; i++)
                {
                    foreach(var j in map[i])
                    {
                        Console.Write(j);
                    }
                    Console.WriteLine();
                }

                Console.SetCursorPosition(curY, curX);
                inputKey = Console.ReadKey(true);

                switch (inputKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (map[curX][curY - 1] == ' ')
                        {
                            map[curX][curY] = ' ';
                            map[curX][curY - 1] = ' ';
                            curY--;
                        }
                        else
                        {
                            if (map[curX][curY - 1] == 'A' && map[curX][curY - 2] == ' ')
                            {
                                map[curX][curY] = ' ';
                                map[curX][curY - 1] = 'P';
                                map[curX][curY - 2] = ' ';
                                curY--;
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[curX][curY + 1] == ' ')
                        {
                            map[curX][curY] = ' ';
                            map[curX][curY + 1] = 'P';
                            curY++;
                        }
                        else
                        {
                            if (map[curX][curY + 1] == 'A' && map[curX][curY + 2] == ' ')
                            {
                                map[curX][curY] = ' ';
                                map[curX][curY + 1] = 'P';
                                map[curX][curY + 2] = 'A';
                                curY++;
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (map[curX - 1][curY] == ' ')
                        {
                            map[curX][curY] = ' ';
                            map[curX - 1][curY] = 'P';
                            curX--;
                        }
                        else
                        {
                            if (map[curX - 1][curY] == 'A' && map[curX - 2][curY] == ' ')
                            {
                                map[curX][curY] = ' ';
                                map[curX - 1][curY] = 'P';
                                map[curX - 2][curY] = 'A';
                                curX--;
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[curX + 1][curY] == ' ')
                        {
                            map[curX + 1][curY] = ' ';
                            map[curX + 1][curY] = 'P';
                            curX++;
                        }
                        else
                        {
                            if (map[curX + 1][curY] == 'A' && map[curX + 2][curY] == ' ')
                            {
                                map[curX][curY] = ' ';
                                map[curX + 1][curY] = 'P';
                                map[curX + 2][curY] = 'A';
                                curX++;
                            }
                        }
                         break;
                }
            }


        }
    }
}