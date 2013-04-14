using System;
using System.Numerics;
using Fourier;

namespace Convolution
{
    public class Filter
    {
        /// <summary>
        /// Размытие изображения
        /// </summary>
        /// <param name="im">Изображение в дискретном виде</param>
        /// <param name="fil">Функция размытия точки</param>
        /// <returns></returns>
        static public double[,] Convolute(double[,] im, double[,] fil)
        {
            Complex[,] IM_F = FFT.FFT2D(im);
            Complex[,] fil_F = FFT.FFT2D(fil);
            Complex[,] G = new Complex[IM_F.GetLength(0), IM_F.GetLength(1)];

            for (int i = 0; i < IM_F.GetLength(0); i++)
                for (int j = 0; j < IM_F.GetLength(1); j++)
                    G[i, j] = IM_F[i, j] * fil_F[i, j];

            double[,] res = FFT.IFFT2D(G);

            return res;
        }

        /// <summary>
        /// Аддитивный шум с нормальным распределением
        /// </summary>
        /// <param name="bright_value"></param>
        /// <param name="average_bright"></param>
        /// <param name="mean_square"></param>
        /// <returns></returns>
        static public double Noise(double bright_value, double average_bright, double mean_square)
        {
            if ((average_bright == 0) && (mean_square == 0))
            {
                return 0;
            }
            
            double noise = 1 / Math.Sqrt(2 * Math.PI * mean_square) *
                Math.Exp((-(bright_value - average_bright) * (bright_value - average_bright)) /
                         (2 * mean_square * mean_square));

            return noise;
        }
    }
}
