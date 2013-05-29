using System;
using System.Numerics;
using Fourier;

namespace Convolution
{
    public class Filter
    {
        static public double[,] PSF_circle(int R, int line, int column)
        {
            double[,] result = new double[line, column];

            double H = 1 * Math.PI / (R * R);

            int x = line / 2 + R - 1;
            int y = column / 2 - 1;
            int dE = 3 - 2 * R;

            int x1, x2, y1, y2 = y;

            while (x > line / 2 - 1)
            {
                x1 = line - x - 1;
                x2 = x;
                y1 = y;
                
                for (int i = x1; i < x2; i++)
                    result[i, y1] = H;

                y2++;

                for (int i = x1; i < x2; i++)
                    result[i, y2] = H;

                if (dE > 0)
                    x--;

                if (dE > 0)
                    dE += 4 * (y - x) + 10;
                else
                    dE += 4 * y + 6;
            }


            return result;
        }
        
        
        /// <summary>
        /// Возвращает функцию размытия точки в дискретном виде
        /// </summary>
        /// <param name="R">Величина ядра размытия</param>
        /// <param name="line">Количество строк функции</param>
        /// <param name="column">Количество столбцов функции</param>
        /// <returns></returns>
        static public double[,] PSF(int R, int line, int column)
        {
            double[,] psf = new double[line, column];
            
            for (int i = line / 2 - R / 2; i <= line / 2 + R / 2; i++)
                for (int j = column / 2 - R / 2; j <= column / 2 + R / 2; j++)
                    psf[i, j] = 1 * Math.PI / (R * R);

            return psf;
        }
        
        
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
