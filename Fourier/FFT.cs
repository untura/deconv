﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Fourier
{
    public class FFT
    {
        /// <summary>
        /// Вычисление экспоненты
        /// </summary>
        /// <param name="K"></param>
        /// <param name="u"></param>
        /// <param name="x"></param>
        /// <returns>Возвращает комплексное число</returns>
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
            int K_line = a.GetLength(1) / 2;
            int K_col = a.GetLength(0) / 2;

            Complex[,] F = new Complex[a.GetLength(0),a.GetLength(1)];
            Complex[,] F_even = new Complex[2 * K_line, 2 * K_col];
            Complex[,] F_odd = new Complex[2 * K_line, 2 * K_col];
            
            //Применение одномерного БПФ по строкам
            for (int i = 0; i < 2 * K_line; i++)
            {
                for (int j = 0; j < 2 * K_col; j++)
                {
                    for (int x = 0; x < K_line; x++)
                    {
                        F_even[i, j] += 1 / K_line * a[i, 2 * x]     * W(K_line, i, x);
                        F_odd[i, j]  += 1 / K_line * a[i, 2 * x + 1] * W(K_line, j, x);
                    }
                }

                for (int j = 0; j < K_line; j++)
                {
                    F[i, j]          = 1 / 2 * (F_even[i, j] + F_odd[i, j] * W(2 * K_line, j, 1));
                    F[i, j + K_line] = 1 / 2 * (F_even[i, j] - F_odd[i, j] * W(2 * K_line, j, 1));
                }
            }

            //Применение одномерного БПФ по столбцам
            for (int j = 0; j < 2 * K_col; j++)
            {
                for (int i = 0; i < 2 * K_line; i++)
                {
                    for (int x = 0; x < K_col; x++)
                    {
                        F_even[i, j] += 1 / K_col * a[2 * x,     j] * W(K_col, i, x);
                        F_odd[i, j]  += 1 / K_col * a[2 * x + 1, j] * W(K_col, i, x);
                    }
                }

                for (int i = 0; i < K_col; i++)
                {
                    F[i, j]         = 1 / 2 * (F_even[i, j] + F_odd[i, j] * W(2 * K_col, j, 1));
                    F[i + K_col, j] = 1 / 2 * (F_even[i, j] - F_odd[i, j] * W(2 * K_col, j, 1));
                }
            }

            return F;
        }
    }
}
