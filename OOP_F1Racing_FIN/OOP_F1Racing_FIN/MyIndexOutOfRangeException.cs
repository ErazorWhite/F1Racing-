using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_F1Racing
{
    /// <summary>
    /// Исключение выхода индекска за границы массива
    /// </summary>
    class MyIndexOutOfRangeException : Exception
    {
        public MyIndexOutOfRangeException()
        {

        }

        public MyIndexOutOfRangeException(string message)
            : base(message)
        {

        }

        public MyIndexOutOfRangeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
