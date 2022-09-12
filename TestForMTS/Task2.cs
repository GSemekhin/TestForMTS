using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForMTS
{
    internal class Task2
    {
        static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

        public Task2()
        {
            int someValue1 = 15;
            int someValue2 = 110;

            string result = new Number(someValue1) + someValue2.ToString(_ifp);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        class Number
        {
            readonly int _number;

            public Number(int number)
            {
                _number = number;
            }

            // Переопределил оператор сложения для нужных типов
            public static string operator +(Number n1, string n2)
            {
                return (n1._number + int.Parse(n2)).ToString();
            }
        }

    }

}
