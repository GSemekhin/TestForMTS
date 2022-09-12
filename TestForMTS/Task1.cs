using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestForMTS
{
    internal class Task1
    {
        public Task1()
        {
            try
            {
                FailProcess();
            }
            catch { }

            Console.WriteLine("Failed to fail process!");
            Console.ReadKey();
        }

        static void FailProcess()
        {
            // Переполним стек
            FailProcess();

            // Просто закроем приложение
            Environment.Exit(0);

            // По-другому закроем приложение
            Environment.FailFast("oopsy");

            // Ещё я нагуглил вариант, что исключение в финалайзере приводит к
            // завершению программы. Однако мы не знаем, когда сборщик мусора
            // решит освободить ресурсы, поэтому этот способ не сработает
            TryToFail lastHope = new TryToFail();
            lastHope = null;

            // Есть нагугленные другие варианты, но я не смог их понять
            // и воспроизвести
        }
    }
    class TryToFail
    {
        string something;
        public TryToFail()
        {
            something = "god help me";
        }
        ~TryToFail()
        {
            throw new Exception("uraa");
        }
    }
}
