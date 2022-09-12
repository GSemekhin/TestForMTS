using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForMTS
{
    internal class Task5
    {
        public Task5()
        {
            TransformToElephant();
            Console.WriteLine("Муха");
            //... custom application code

        }
        // Запишем в консоль "Слон", а после просто перенаправим вывод в какой-то файл
        // 
        // Можно изменить метод вывода и убирать из него "Муха" и выводить в консоль,
        // но задание этого не требует
        static void TransformToElephant()
        {
            Console.WriteLine("Слон");
            Console.SetOut(new StreamWriter("расположение файла"));
        }
    }
}