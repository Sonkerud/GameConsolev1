using System;
using System.Diagnostics;
using System.Threading;

namespace GameConsolev1._2
{
    class Program
    {
        static int lives = 3;
        static string name = "";
        static string[,] characterArr = new string[4, 50];
        static string[] enemyArr = new string[50];
        static Stopwatch clock = new System.Diagnostics.Stopwatch();
        static bool runGame = true;
        static string recordString = "";
        static string recordHolder = "";
        static int recordTime = 0;
        static int time;

        static void Main(string[] args)
        {
            while (runGame)
            {
                lives = 3;
                StartUp();
                RunGame();
            }
           
        }

        public static void StartUp()
        {
            Console.SetCursorPosition(1, 0);
            Console.Write("__________________________________________________");
            for (int row = 1; row < 10; row++)
            {
                Console.SetCursorPosition(0, row);
                Console.Write("|                                                  |");
            }
            Console.SetCursorPosition(1, 9);
            Console.Write("__________________________________________________|");
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("HoleDodger 2032 - 3rd Edition");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Who's Playing?");
            Console.SetCursorPosition(1, 3);
            name = Console.ReadLine();
            Console.SetCursorPosition(1, 4);
            Console.WriteLine($"Let's go {name} - Dodge the hole!" );
            Console.SetCursorPosition(1, 5);
            Console.WriteLine("Use space to jump. Hit Enter to play!");
            Console.ReadLine();
        }

        static void RunGame()
        {
            bool gameStillRunning = true;
            BuildMap();
            while (gameStillRunning)
            {
                clock.Start();

                for (int i = 0; i < enemyArr.Length -1; i++)
                {
                    BuildArrCharacter();
                    BuildEnemyArr();
                    Jump();
                    DrawEnemyArr(i);
                    Thread.Sleep(10);
                    if (enemyArr[25] == "  " && characterArr[0, 25] != " ")
                    {
                        lives--;
                        Console.SetCursorPosition(1, 1);
                        Console.WriteLine($"Lives: {lives}");
                        if (lives == 0)
                        {
                            time = clock.Elapsed.Seconds;
                            
                            Console.SetCursorPosition(1, 1);
                            Console.WriteLine($"Game Over {name}!           ");
                            Console.SetCursorPosition(1, 2);
                            Console.WriteLine($"You survived {clock.Elapsed.Seconds.ToString()} seconds!           ");
                            Console.SetCursorPosition(1, 3);
                            Console.WriteLine($"                                          ");
                         
                            if (time > recordTime)
                            {
                                recordTime = time;
                                recordHolder = name;
                            }
                            recordString = recordTime.ToString();
                            Console.SetCursorPosition(35, 1);
                            Console.Write($"Highscore: {recordTime} sec");
                            Console.SetCursorPosition(35, 2);
                            Console.Write($"By: {recordHolder}");
                            clock.Reset();
                            gameStillRunning = false;
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        }


                    }
                    Console.SetCursorPosition(1, 2);
                    Console.Write("Du har klarat dig i: " + clock.Elapsed.Seconds.ToString() + " sekunder!");
                  
                }
            }
        }
     
        static void BuildMap()
        {
            Console.SetCursorPosition(1, 0);
            Console.Write("__________________________________________________");
            for (int row = 1; row < 10; row++)
            {
                Console.SetCursorPosition(0, row);
                Console.Write("|                                                  |");
            }
            Console.SetCursorPosition(1, 9);
            Console.Write("__________________________________________________|");
            Console.SetCursorPosition(1, 1);
            Console.Write($"Lives: {lives}");
            Console.SetCursorPosition(35, 1);
            Console.Write($"Highscore: {recordHolder}");
            Console.SetCursorPosition(35, 2);
            Console.Write($"With {recordString} sec");



        }
        static void Jump()
        {
            if (!KeyPressMethod())
            {
                DrawCharacterArr();
            }
            else
            {
                DrawJumpingCharacterArr();
            }
        }
        static void BuildArrCharacter()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int x = 0; x < 50; x++)
                {
                    characterArr[i, x] = " ";
                }
            }

            characterArr[0, 25] = "∞";
            characterArr[1, 25] = "||";
            characterArr[2, 25] = "@@";
        }
        static void BuildEnemyArr()
        {
            for (int i = 0; i < enemyArr.Length-1; i++)
            {
                    enemyArr[i] = "#";
            }
        }
        static void DrawCharacterArr()
        {
           
            Console.SetCursorPosition(1, 5);
            for (int i = 0; i < characterArr.GetLength(1)-5; i++)
            {
                Console.Write(characterArr[0, i]);
            }
            Console.SetCursorPosition(1, 6);
            for (int i = 0; i < characterArr.GetLength(1)-5; i++)
            {
                Console.Write(characterArr[1, i]);
            }
            Console.SetCursorPosition(1, 7);
            for (int i = 0; i < characterArr.GetLength(1)-5; i++)
            {
                Console.Write(characterArr[2, i]);
            }

            for (int row = 3; row < 5; row++)
            {
                Console.SetCursorPosition(0, row);
                Console.Write("|                                                  |");
            }
        }
        static void DrawJumpingCharacterArr()
            {
            characterArr[0, 24] = " ";
            characterArr[0, 25] = " ";
            characterArr[0, 26] = " ";

            characterArr[1, 25] = "∞";
            characterArr[2, 25] = "||";
            characterArr[3, 25] = "@@";

            Console.SetCursorPosition(1, 3);
                for (int i = 0; i < characterArr.GetLength(1)-5; i++)
                {
                    Console.Write(characterArr[1, i]);
                }
                Console.SetCursorPosition(1, 4);
                for (int i = 0; i < characterArr.GetLength(1)-5; i++)
                {
                    Console.Write(characterArr[2, i]);
                }
                Console.SetCursorPosition(1, 5);
                for (int i = 0; i < characterArr.GetLength(1)-5; i++)
                {
                    Console.Write(characterArr[3, i]);
                }
            for (int row = 6; row < 9; row++)
            {
                Console.SetCursorPosition(0, row);
                Console.Write("|                                                  |");
            }
        }
        static bool KeyPressMethod()
            {
                if (Console.KeyAvailable)
                {
                    var isUp = Console.ReadKey().Key == ConsoleKey.Spacebar;
                    return isUp;
                }
                else
                {
                    return false;
                }
            }
        static void DrawEnemyArr(int nr)
        {
            enemyArr[nr] ="  ";
            Console.SetCursorPosition(1, 8);

            for (int i = 0; i < enemyArr.Length -1; i++)
            {
                Console.Write(enemyArr[i]);
            }
        }


        static void BuildJumpingCharacter()
        {
            Console.SetCursorPosition(1, 3);
            Console.Write("                                             ∞                                                       |");
            Console.SetCursorPosition(1, 4);
            Console.Write("                                             ||                                                      |");
            Console.SetCursorPosition(1, 5);
            Console.Write("                                             @@                                                      |");
            Console.SetCursorPosition(1, 6);
            Console.Write("                                                                                                     |");
            Console.SetCursorPosition(1, 7);
            Console.Write("                                                                                                     |");
        }
        static void BuildCharacter()
        {
            Console.SetCursorPosition(1, 3);
            Console.Write("                                                                                                     |");
            Console.SetCursorPosition(1, 4);
            Console.Write("                                                                                                     |");
            Console.SetCursorPosition(1, 5);
            Console.Write("                                             ∞                                                       |");
            Console.SetCursorPosition(1, 6);
            Console.Write("                                             ||                                                      |");
            Console.SetCursorPosition(1, 7);
            Console.Write("                                             @@                                                      |");
        }
    }
    }

