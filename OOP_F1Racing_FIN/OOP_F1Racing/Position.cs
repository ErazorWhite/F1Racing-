using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_F1Racing
{
    /// <summary>
    /// Хранит в себе координаты машин
    /// </summary>
    class Position  // Позиция ячейки
    {
        private int _x; // Координата Х
        private int _y; // Координата Y

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Position() 
        {
            _x = 0;
            _y = 0;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public Position(int x, int y) 
        {
            _x = x;
            _y = y;
        }

        #region Properties (Аксесоры)

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        #endregion

    }
}
