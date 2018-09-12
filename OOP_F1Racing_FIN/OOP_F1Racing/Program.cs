using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP_F1Racing
{
    /// <summary>
    /// Класс контроллер
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "OOP_F1Racing";
            Console.CursorVisible = false;
            UserAction action = UserAction.NoAction;    // Действие пользователя

            Field fieldSpace = new Field();             // Экземпляр класса Field
            fieldSpace.CreateNewField();                // Поле заполнено элементами Road и Wall

            PlayerCar player = new PlayerCar();         // Экземпляр класса PlayerCar
            player.CreateCar(fieldSpace);               // На поле появилась машина игрока playerCar

            player.gameIsOver += GameOverHandler;       // Подписка на событие методом-обработчиком GameOverHandler

            EnemyCar bot = new EnemyCar();              // Экземпляр класса EnemyCar
            bot.CreateCar(fieldSpace);                  // На поле появилась машина противника enemyCar

            do
            {
                View.ShowModel(fieldSpace);             // Отобразить модель игрового поля

                bot.MoveEnemyCar(fieldSpace);           // Перемещение (респаун) бота
                
                if (Console.KeyAvailable)               // Если была нажата клавиша
                {
                    action = View.GetUserAction();      // Получаем UserAction
                }

                switch (action)                         
                {
                    case UserAction.Left:
                        player.MoveCar(-1, 0, fieldSpace);
                        break;

                    case UserAction.Right:
                        player.MoveCar(+1, 0, fieldSpace);
                        break;

                    case UserAction.Top:
                        player.MoveCar(0, -1, fieldSpace);
                        break;

                    case UserAction.Bottom:
                        try
                        {
                            player.MoveCar(0, +1, fieldSpace);
                        }
                        catch (MyIndexOutOfRangeException)
                        {
                            Console.WriteLine("IndexOutOfRangeExeption");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Exception");
                        }
                        
                        break;

                    default:
                        break;
                }

                if (action == UserAction.Exit)  // Выход по ESC
                {
                    Console.SetCursorPosition(Field.WIDTH + 5, Field.HEIGHT - (Field.HEIGHT - 5));
                    Console.WriteLine("Good bye!");
                    break;
                }

                action = UserAction.NoAction;

                Console.SetCursorPosition(Field.WIDTH + 5, Field.HEIGHT - (Field.HEIGHT - 6));
                Console.WriteLine("Score: {0}", player.PlayerScore());  // Вывод счета игрока

                if (player.CheckGameOver(bot.enemyCarPos))  // Проверка столкновения машин (конец игры)
                {
                    break;
                }

                View.ShowModel(fieldSpace); // Отрисовка игрового поля

                Thread.Sleep(100);

            }
            while (true);

            Console.ReadKey();



        }
        /// <summary>
        /// Метод-обработчик события gameIsOver
        /// </summary>
        /// <param name="sender">объект, инициирующий наступление события</param>
        /// <param name="args">информация о наступившем событии</param>
        public static void GameOverHandler(object sender, EventArgs args)
        {
            Console.SetCursorPosition(Field.WIDTH + 5, Field.HEIGHT - (Field.HEIGHT - 5));
            Console.WriteLine("GAME OVER");
        }
    }
}
