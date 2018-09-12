using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_F1Racing
{
    /// <summary>
    /// Элементы, которыми заполняются ячейки игрового поля
    /// </summary>
    public enum FieldItems
    {
        Empty,
        Road,   // дорога, по кторой едет машина
        Wall,   // Ограждение вдоль дороги
        playerCar,    // Машина игрока
        enemyCar,     // Машина противника
    }
    /// <summary>
    /// Класс игрового поля
    /// </summary>
    class Field
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Field()
        {
            _cell = new FieldItems[HEIGHT, WIDTH];   // задаем размерность поля (массив ячеек cells)
        }

        /// <summary>
        /// Инициализация игрового поля
        /// </summary>
        /// <returns>Игровое поле</returns>
        public void CreateNewField()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (j == 0 || j == WIDTH - 1)
                        _cell[i, j] = FieldItems.Wall;
                    if (j != 0 && j != WIDTH - 1)
                        _cell[i, j] = FieldItems.Road;
                }
            }
            
        }

        #region Public

        public const byte WIDTH = 10;   // Ширина поля
        public const byte HEIGHT = 20;  // Высота поля               

        #endregion

        #region Private
                
        private FieldItems[,] _cell;     // Массив ячеек из которых состоит игровое поле
 
        #endregion

        #region Accessors

        public FieldItems GetCell(int x, int y) // Возвращает Cell по X,Y
        {
            return _cell[y, x];
        }

        public void SetCell(int x, int y, FieldItems cell)  // Устанавливает Cell по X,Y
        {
            _cell[y, x] = cell;
        }

        #endregion

    }
}
