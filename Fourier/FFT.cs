using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Fourier
{
    public class FFT
    {
        /// <summary>
        /// Одномерное быстрое преобразование Фурье
        /// </summary>
        /// <param name="a">Входной массив</param>
        /// <returns>Массив с Фурье-образом исходного массива</returns>
        static public Complex[] FFT1D(double[] a)
        {
            return null;
        }

        /// <summary>
        /// Двумерное быстрое преобразование Фурье
        /// </summary>
        /// <param name="a">Входной массив</param>
        /// <returns>Массив с Фурье-образом исходного массива</returns>
        /// <remarks>Вычисляется как одномерные по каждой строке и столбцу</remarks>
        static public Complex[,] FFT2D(double[,] a)
        {
            return null;
        }
    }
}
