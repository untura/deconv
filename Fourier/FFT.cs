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
            Complex[] F_even = new Complex[K];
            Complex[] F_odd  = new Complex[K];

            for (int u = 0; u < K; u++)
                for (int x = 0; x < K; x++)
                {
                    F_even[u] += a[2 * x]     * W(K, u, x);
                    F_odd[u]  += a[2 * x + 1] * W(K, u, x);
                }
            for (int u = 0; u < K; u++)
            {
                F[u]     = 0.5 * (F_even[u] + F_odd[u] * W(2 * K, u, 1));
                F[u + K] = 0.5 * (F_even[u] - F_odd[u] * W(2 * K, u, 1));
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
                        F_even[i, j] += a[i, 2 * x]     * W(K_line, i, x);
                        F_odd[i, j]  += a[i, 2 * x + 1] * W(K_line, j, x);
                    }
                }

                for (int j = 0; j < K_line; j++)
                {
                    F[i, j]          = 0.5 * (F_even[i, j] + F_odd[i, j] * W(2 * K_line, j, 1));
                    F[i, j + K_line] = 0.5 * (F_even[i, j] - F_odd[i, j] * W(2 * K_line, j, 1));
                }
            }

            //Применение одномерного БПФ по столбцам
            for (int j = 0; j < 2 * K_col; j++)
            {
                for (int i = 0; i < 2 * K_line; i++)
                {
                    for (int x = 0; x < K_col; x++)
                    {
                        F_even[i, j] += F[2 * x,     j] * W(K_col, i, x);
                        F_odd[i, j]  += F[2 * x + 1, j] * W(K_col, i, x);
                    }
                }

                for (int i = 0; i < K_col; i++)
                {
                    F[i, j]         = 0.5 * (F_even[i, j] + F_odd[i, j] * W(2 * K_col, j, 1));
                    F[i + K_col, j] = 0.5 * (F_even[i, j] - F_odd[i, j] * W(2 * K_col, j, 1));
                }
            }

            return F;
        }

        /// <summary>
        /// Одномерное обратное быстрое преобразование Фурье
        /// </summary>
        /// <param name="A">Входной массив с Фурье-образом</param>
        /// <returns></returns>
        static public double[] IFFT1D(Complex[] A)
        {
            int K = A.Length / 2;
            Complex[] f = new Complex[2 * K];
            Complex[] f_even = new Complex[2 * K];
            Complex[] f_odd = new Complex[2 * K];

            for (int u = 0; u < K; u++)
                for (int x = 0; x < K; x++)
                {
                    f_even[u] += 1.0 / K * A[2 * x]     * W(K, -u, x);
                    f_odd[u]  += 1.0 / K * A[2 * x + 1] * W(K, -u, x);
                }
            for (int u = 0; u < K; u++)
            {
                f[u]     = (f_even[u] + f_odd[u] * W(2 * K, -u, 1));
                f[u + K] = (f_even[u] - f_odd[u] * W(2 * K, -u, 1));
            }

            double[] a = new double[2 * K];
            
            for (int i = 0; i < 2 * K; i++)
            {
                a[i] = f[i].Magnitude;
            }
            return a;
        }

        /// <summary>
        /// Двумерное обратное быстрое преобразование Фурье
        /// </summary>
        /// <param name="A">Входной массив с Фурье-образом</param>
        /// <returns></returns>
        static public double[,] IFFT2D(Complex[,] A)
        {
            int K_line = A.GetLength(1) / 2;
            int K_col = A.GetLength(0) / 2;

            Complex[,] f = new Complex[A.GetLength(0), A.GetLength(1)];
            Complex[,] f_even = new Complex[2 * K_line, 2 * K_col];
            Complex[,] f_odd = new Complex[2 * K_line, 2 * K_col];


            //Применение одномерного обратного БПФ по столбцам
            for (int j = 0; j < 2 * K_col; j++)
            {
                for (int i = 0; i < 2 * K_line; i++)
                    for (int x = 0; x < K_col; x++)
                    {
                        f_even[i, j] += 1.0 / K_col * A[2 * x, j] * W(K_col, -i, x);
                        f_odd[i, j] += 1.0 / K_col * A[2 * x + 1, j] * W(K_col, -i, x);
                    }
                
                for (int i = 0; i < K_col; i++)
                {
                    f[i, j] = (f_even[i, j] + f_odd[i, j] * W(2 * K_col, -j, 1));
                    f[i + K_col, j] = (f_even[i, j] - f_odd[i, j] * W(2 * K_col, -j, 1));
                }
            }

            //Применение одномерного обратного БПФ по строкам
            for (int i = 0; i < 2 * K_line; i++)
            {
                for (int j = 0; j < 2 * K_col; j++)
                    for (int x = 0; x < K_line; x++)
                    {
                        f_even[i, j] += 1.0 / K_line * f[i, 2 * x]     * W(K_line, -i, x);
                        f_odd[i, j]  += 1.0 / K_line * f[i, 2 * x + 1] * W(K_line, -j, x);
                    }
                
                for (int j = 0; j < K_line; j++)
                {
                    f[i, j]          = (f_even[i, j] + f_odd[i, j] * W(2 * K_line, -j, 1));
                    f[i, j + K_line] = (f_even[i, j] - f_odd[i, j] * W(2 * K_line, -j, 1));
                }
            }




            double[,] a = new double[2 * K_col, 2 * K_line];

            for (int i = 0; i < K_col; i++)
                for (int j = 0; j < 2 * K_line; j++)
                    a[i, j] = f[i, j].Magnitude;
            
            return a;
        }
    }
}
