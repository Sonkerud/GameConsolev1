using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameConsole
{
    class Program
    {
      
        static string[,] arena = new string[10,50];
        static void Main(string[] args)
        {
            Test();
             //RunGame();
           // StatusUpdate();
        }
      

        static void RunGame()
        {
            
            while (true)
            {

                for (int i = 49; i >= 0; i--)
                {
                    BuildMap(i);

                    CharacterJump();

                    Console.Clear();
                    DrawMap();
                    Thread.Sleep(1);
                }
               
            }
        }

        static void CharacterJump()
        {
            if (!KeyPressMethod())
            {
                BuildCharacter();
            }
            else
            {
                BuildCharacterJump();
            }
          

        }

        static void BuildMap(int obj)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int x = 0; x < 50; x++)
                {
                    arena[i, x] = " ";
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int x = 0; x < 50; x++)
                {
                    arena[i, x] = "O";
                }
            }

            for (int i = 8; i < 10; i++)
            {
                for (int x = 0; x < 50; x++)
                {
                    arena[i, x] = "X";
                }
            }

            arena[7, obj] = "-";
            if (obj >0)
            {
                arena[7, obj - 1] = "-";
            }
            if (obj > 1)
            {
                arena[7, obj - 2] = "<";
            }
            

        }

        static void BuildCharacter()
        {
            arena[6, 24] = "O";
            arena[7, 23] = "#";
            arena[7, 24] = "#";
            arena[7, 25] = "#";
        }

        static void BuildCharacterJump()
        {
            arena[4, 24] = "O";
            arena[5, 23] = "#";
            arena[5, 24] = "#";
            arena[5, 25] = "#";
        }

        static void DrawMap()
        {
            for (int i = 0; i < arena.GetLength(0); i++)
            {
                for (int x = 0; x < arena.GetLength(1); x++)
                {
                    Console.Write(arena[i, x]);
                }
                Console.WriteLine();
            }
        }
        static bool KeyPressMethod() 
        {
            if (Console.KeyAvailable)
            {
                var isUp = Console.ReadKey().Key == ConsoleKey.UpArrow;
                return isUp;
            }
            else
            {
                return false;
            }
        }

        private static void StatusUpdate()
        {
            var whiteSpace = new StringBuilder();
            whiteSpace.Append(' ', 10);
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomWord = new string(Enumerable.Repeat(chars, random.Next(10)).Select(s => s[random.Next(s.Length)]).ToArray());
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                var sb = new StringBuilder();
                sb.AppendLine($"Program Status:{whiteSpace}");
                sb.AppendLine("-------------------------------");
                sb.AppendLine($"Last Updated: {DateTime.Now}{whiteSpace}");
                sb.AppendLine($"Random Word: {randomWord}{whiteSpace}");
                sb.AppendLine("-------------------------------");
                Console.Write(sb);
                Thread.Sleep(1);
            }
        }

        public static void Test()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("______________________________________________________________________________________________________");
            for (int row = 1; row < 10; row++)
            {
                Console.SetCursorPosition(0, row);
                Console.Write("|                                                                                                     |");
            }
            Console.SetCursorPosition(1, 9);
            Console.Write("_____________________________________________________________________________________________________");

            Console.SetCursorPosition(1, 8);
            Console.Write("=====================================================================================================");

           
            while (true)
            {
                Console.SetCursorPosition(1, 5);
                Console.Write("|                                            ∞                                                       |");
                Console.SetCursorPosition(1, 6);
                Console.Write("|                                            ||                                                      |");
                Console.SetCursorPosition(1, 7);
                Console.Write("|                                            @@                                                      |");


            }



            
        }
    }
}
