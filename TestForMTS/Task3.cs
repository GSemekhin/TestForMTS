using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForMTS
{
    internal static class Task3
    {


        /// <summary>
        /// <para> Отсчитать несколько элементов с конца </para>
        /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
        /// </summary> 
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="tailLength">Сколько элементов отсчитать с конца  (у последнего элемента tail = 0)</param>
        /// <returns></returns>
        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            IList<(T item, int? tail)> items = new List<(T item, int? tail)>();
            if (tailLength != null && tailLength > 0)
            {
                int i = 0;
                int? tailCounter = tailLength > enumerable.Count() ? enumerable.Count() - 1 : tailLength - 1;
                // Перебор значений 1 раз
                foreach (var item in enumerable)
                {
                    if (i < enumerable.Count() - tailLength)
                    {
                        items.Add((item, null));
                    }
                    else
                    {
                        items.Add((item, tailCounter));
                        tailCounter--;
                    }
                    i++;
                }
            }
            return items;
        }
    }
}
