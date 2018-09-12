using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_F1Racing
{
    /// <summary>
    /// Класс машины противника
    /// </summary>
    class EnemyCar : User
    {
        /// <summary>
        /// Конструктор по умолчанию для машины противника
        /// </summary>
        public EnemyCar()
        {
            _enemyCarPos = new Position(WIDTH / 2, HEIGHT - (HEIGHT - 1)); // Начальное положение машины противника
        }

        /// <summary>
        /// Помещает машину противника в игровое поле
        /// </summary>
        /// <param name="fieldSpace">Игровое поле</param>
        public override void CreateCar(Field fieldSpace)
        {
            fieldSpace.SetCell(_enemyCarPos.X, _enemyCarPos.Y, FieldItems.enemyCar);    // Отрисовка машины противника
        }

        /// <summary>
        /// Перемещает машину противника по игровому полю
        /// </summary>
        /// <param name="fieldSpace">Игровое поле</param>
        public void MoveEnemyCar(Field fieldSpace)
        {
            if (_enemyCarPos.Y <= 18)   // Если есть куда двигаться
            {
                _enemyCarPos.Y++;   // Увеличиваем координату Y

                fieldSpace.SetCell(_enemyCarPos.X, _enemyCarPos.Y, FieldItems.enemyCar); // Отрисовка машины противника в новом местоположении
                fieldSpace.SetCell(_enemyCarPos.X, _enemyCarPos.Y - 1, FieldItems.Road); // Закрашиваем старое положение машины противника
            }
            else
            {
                fieldSpace.SetCell(_enemyCarPos.X, _enemyCarPos.Y, FieldItems.Road);    // Закрашиваем старое положение машины противника

                _enemyCarPos.X = rand.Next(WIDTH - (WIDTH - 1), WIDTH - 1); // Рандомно спавним вражескую машину вверху поля
                _enemyCarPos.Y = 1; 

                SetCell(_enemyCarPos.Y, _enemyCarPos.X, FieldItems.enemyCar); // Отрисовка машины противника в новом местоположении
            }
        }

        #region Private

        private Position _enemyCarPos; // Позиция машины противника

        #endregion

        #region Public

        public static Random rand = new Random();

        #endregion

        #region Accessors

        public Position enemyCarPos
        {
            get
            {
                return _enemyCarPos;
            }            
        }

        #endregion
    }
}
