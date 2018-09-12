using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_F1Racing
{
    /// <summary>
    /// Действия пользователя
    /// </summary>
    public enum UserAction
    {
        NoAction,
        Left,
        Right,
        Exit,
        Top,
        Bottom
    }
    /// <summary>
    /// Отвечает за пользовательский интерфейс
    /// </summary>
    class View
    {
        /// <summary>
        /// Отрисовка игрового поля и элементов на нем
        /// </summary>
        /// <param name="Field">Игровое поле</param>
        public static void ShowModel(Field fieldSpace)
        {
            char symbol; // Элемент, который заполняет ячейки игрового поля
            
            for (int i = 0; i < Field.HEIGHT; i++)
            {
                for (int j = 0; j < Field.WIDTH; j++)
                {
                    Console.SetCursorPosition(j, i);
                    switch (fieldSpace.GetCell(j, i)) 
                    {
                        case FieldItems.Road:
                            Console.ForegroundColor = ConsoleColor.Black;
                            symbol = ' ';
                            break;
                        case FieldItems.Wall:
                            Console.ForegroundColor = ConsoleColor.Green;
                            symbol = '░';
                            break;
                        case FieldItems.playerCar:
                            Console.ForegroundColor = ConsoleColor.Red;
                            symbol = '█';
                            break;
                        case FieldItems.enemyCar:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            symbol = '█';
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            symbol = ' ';
                            break;

                    }
                    Console.Write(symbol);
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Возвращает последнее действие пользователя
        /// </summary>
        /// <returns>Действие пользователя</returns>
        public static UserAction GetUserAction()
        {
            UserAction action = UserAction.NoAction;
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    action = UserAction.Left;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    action = UserAction.Right;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    action = UserAction.Top;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    action = UserAction.Bottom;
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.NumPad0:
                    action = UserAction.Exit;
                    break;
            }

            return action;
        }
    }
}

