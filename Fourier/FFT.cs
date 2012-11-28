using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Fourier
{
    public class FFT
    {
        private static Complex W(int K, int u, int x)
        {
            double arg = -2 * Math.PI * x * u / K;
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }

        /// <summary>
        /// Одномерное быстрое преобразование Фурье
        /// </summary>
        /// <param name="a">Входной массив</param>
        /// <returns>Массив с Фурье-образом исходного массива</returns>
        static public Complex[] FFT1D(double[] a)
        {
            int K = a.Length / 2;
            Complex[] F = new Complex[2 * K];
            Complex[] F_even = new Complex[2 * K];
            Complex[] F_odd  = new Complex[2 * K];

            for (int u = 0; u < K; u++)
                for (int x = 0; x < K; x++)
                {
                    F_even[u] += 1 / K * a[2 * x] * W(K, u, x);
                    F_odd[u]  += 1 / K * a[2 * x + 1] * W(K, u, x);
                }
            for (int u = 0; u < K; u++)
            {
                F[u]     = 1 / 2 * (F_even[u] + F_odd[u] * W(2 * K, u, 1));
                F[u + K] = 1 / 2 * (F_even[u] - F_odd[u] * W(2 * K, u, 1));
            }

            return F;
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
