using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForMTS
{
    internal class Task4
    {
        /// <summary>
        /// Возвращает отсортированный по возрастанию поток чисел
        /// </summary>
        /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
        /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
        /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
        /// <returns>Отсортированный по возрастанию поток чисел.</returns>
        public IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            // Создаём массив с количеством вхождений всех значений в потоке
            int[] values = new int[maxValue + 1];
            int currentValue = 0;

            // Считаем количество вхождений каждого значения в потоке
            foreach (int x in inputStream)
            {
                values[x] = values[x] + 1;

                // Проверяем, что в массиве не осталось элементов, которые меньше
                // текущего минимально допустимого числа, если есть - выдаём
                int minPossible = x - sortFactor;
                while (currentValue < minPossible)
                {
                    while ((values[currentValue] = values[currentValue] - 1) >= 0)
                        yield return currentValue;
                    currentValue++;
                }
            }

            // Выдаём значения, начиная со значения, на кором остановились
            // при переборе значений в потоке
            while (currentValue < values.Length)
            {
                while ((values[currentValue] = values[currentValue] - 1) >= 0)
                    yield return currentValue;
                currentValue++;
            }
        }

        // Мне кажется, это достаточно оптимальный алгоритм,
        // так как значения выдаются ещё до окончания полного перебора потока
        // Может быть можно более рационально хранить значения потока,
        // так как в худшем случае выделится память под 2000 элементов,
        // из которых уникальных будет только парочка
    }
}
