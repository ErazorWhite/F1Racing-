using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_F1Racing
{
    /// <summary>
    /// Базовый класс для бота и игрока
    /// </summary>
    abstract class User : Field
    {
        /// <summary>
        /// Функция помещает машину в игровое поле
        /// </summary>
        /// <param name="fieldSpace">Игровое поле</param>
        abstract public void CreateCar(Field fieldSpace);

    }
}
