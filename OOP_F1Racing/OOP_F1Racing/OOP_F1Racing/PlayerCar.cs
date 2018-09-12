using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_F1Racing
{
    /// <summary>
    /// Делегат для события, срабатывающего когда игра проиграна
    /// </summary>
    /// <param name="sender">объект, инициирующий наступление события</param>
    /// <param name="args">информация о наступившем событии</param>
    delegate void GameOver(object sender, EventArgs args);

    /// <summary>
    /// Класс машины игрока
    /// </summary>
    class PlayerCar : User
    {

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PlayerCar()
        {
            _playerCarPos = new Position(WIDTH / 2, HEIGHT - 1); // Задает начальные координаты машины игрока
            _playerScore = 0;   // Игровой счет
        }

        /// <summary>
        /// Помещает машину игрока в игровое поле
        /// </summary>
        /// <param name="fieldSpace">Игровое поле</param>
        public override void CreateCar(Field fieldSpace) // Перегруженная функция
        {
            fieldSpace.SetCell(_playerCarPos.X, _playerCarPos.Y, FieldItems.playerCar); // Помещаем машину в поле
        }

        /// <summary>
        /// Перемещает машину игрока по игровому полю
        /// </summary>
        /// <param name="dx">Х</param>
        /// <param name="dy">Y</param>
        /// <param name="fieldSpace">Игровое поле</param>
        public void MoveCar(int dx, int dy, Field fieldSpace)
        {
            if ((fieldSpace.GetCell(_playerCarPos.X + dx, _playerCarPos.Y + dy)) != FieldItems.Wall // Если есть куда двигаться
               && _playerCarPos.Y + dy != HEIGHT - 1
               && _playerCarPos.Y + dy != HEIGHT - HEIGHT)
            {
                fieldSpace.SetCell(_playerCarPos.X, _playerCarPos.Y, FieldItems.Road);  // Предыдущую позицию закрашиваем

                _playerCarPos.X += dx;  // Меняем координату Х
                _playerCarPos.Y += dy;  // Меняем координату Y

                fieldSpace.SetCell(_playerCarPos.X, _playerCarPos.Y, FieldItems.playerCar); // Отрисовываем текущую позицию машины игрока
            }
        }

        /// <summary>
        /// Проверка столкновения машин
        /// </summary>
        /// <param name="enemyCarPos">Позиция машины противника</param>
        /// <returns>Столкновение машин</returns>
        public bool CheckGameOver(Position enemyCarPos)
        {
            if (_playerCarPos.X == enemyCarPos.X    // true если машины столкнулись
                && _playerCarPos.Y == enemyCarPos.Y)
            {
                OnGameOver(); // Событие срабатывает при столкновении машин
                return true;
            }
            return false;
        }

        /// <summary>
        /// Игровой счет
        /// </summary>
        /// <returns>Score</returns>
        public int PlayerScore()
        {
            return _playerScore++;
        }

        #region Private

        private Position _playerCarPos; //  Позиция машины игрока
        private int _playerScore;   // Счет игрока

        /// <summary>
        /// Определяем вспомогательный метод для инициации (запуска) цепочки методов-обработчиков
        /// </summary>
        /// <param name="enemyCarPos">Позиция вражеской машины</param>
        private void OnGameOver()
        {
            {
                _gameOverDelegate(this, new EventArgs());
            }
        }
        #endregion

        #region Properties

        public Position playerCarPos
        {
            get
            {
                return _playerCarPos;
            }
        }

        public int playerScore
        {
            get
            {
                return _playerScore;
            }
            set
            {
                _playerScore = value;
            }
        }

        #endregion

        /// <summary>
        /// "Внешний интерфейс" для добавления методов-обработчиков
        /// </summary>
        public event GameOver gameIsOver
        {
            add
            {
                _gameOverDelegate += value;
            }
            remove
            {
                _gameOverDelegate -= value;
            }
        }

        /// <summary>
        /// добавляем поле-делегат, хранящий адреса обработчиков события
        /// </summary>
        GameOver _gameOverDelegate = null;
    }
}
