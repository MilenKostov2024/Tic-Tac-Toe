using System;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Мрежата на играта (играното поле)
            // Използваме масив от низове, където всеки индекс представлява клетка на мрежата
            string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool isPlayer1Turn = true; // Показва дали е ред на играч 1 или играч 2
            int numTurns = 0; // Броя на ходовете, които са направени до момента

            // Цикъл, който продължава докато няма победител и не са направени 9 хода
            while (CheckVictory() && numTurns != 9)
            {
                // Извеждаме състоянието на игралното поле
                PrintGrid();

                // Показваме кой е реда на играча
                if (isPlayer1Turn)
                    Console.WriteLine("Player 1 turn!");
                else
                    Console.WriteLine("Player 2 turn!");

                // Четем избора на играча
                string choice = Console.ReadLine();

                // Проверяваме дали избраната клетка е валидна и не е вече заета
                if (grid.Contains(choice) && choice != "X" && choice != "0")
                {
                    int gridIndex = Convert.ToInt32(choice) - 1;

                    // Въз основа на това чий е реда, поставяме "X" или "0" в съответната клетка
                    if (isPlayer1Turn)
                        grid[gridIndex] = "X";
                    else
                        grid[gridIndex] = "0";

                    // Увеличаваме броя на ходовете
                    numTurns++;
                }
                // Превключваме реда на играча
                isPlayer1Turn = !isPlayer1Turn;
            }
            // Ако функцията CheckVictory() върне true, значи има победител
            if (CheckVictory())            
                Console.WriteLine("You win!"); // Победа!
            else
                Console.WriteLine("Tie!"); // Равенство!

            // Функция, която проверява дали има победител
            bool CheckVictory()
            {
                // Проверка за три поредни символа по редове
                bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
                bool row2 = grid[3] == grid[4] && grid[4] == grid[5];
                bool row3 = grid[6] == grid[7] && grid[7] == grid[8];

                // Проверка за три поредни символа по колони
                bool col1 = grid[0] == grid[3] && grid[3] == grid[6];
                bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
                bool col3 = grid[2] == grid[5] && grid[5] == grid[8];

                // Проверка за три поредни символа по диагонали
                bool diagDown = grid[0] == grid[4] && grid[4] == grid[8];
                bool diagUp = grid[6] == grid[4] && grid[4] == grid[2];

                // Ако има поне една победителна комбинация, връща true
                return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp;
            }
            // Функция за отпечатване на игралното поле в конзолата
            void PrintGrid()
            {
                string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                // Цикъл, който извежда редовете на мрежата
                for (int i = 0; i < 3; i++)
                {
                    // Вътрешен цикъл, който извежда стойностите на всяка клетка от реда
                    for (int j = 0; j < 3; j++)
                    {
                        // Печатаме стойността на клетката, разделена с вертикална черта
                        Console.Write(grid[i * 3 + j] + "|");
                    }
                    Console.WriteLine();
                    // Печатаме разделител между редовете
                    Console.WriteLine("------");
                }

            }
        }
    }
}
