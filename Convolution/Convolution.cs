using System;
using System.Numerics;
using Fourier;

namespace Convolution
{
    public class Filter
    {
        /// <summary>
        /// Возвращает функцию размытия точки в дискретном виде. Ядро размытия в виде круга
        /// </summary>
        /// <param name="R">Величина ядра размытия</param>
        /// <param name="line">Количество строк функции</param>
        /// <param name="column">Количество столбцов функции</param>
        /// <returns></returns>
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
        /// Возвращает маску пространственной фильтрации
        /// </summary>
        /// <param name="R"></param>
        /// <returns></returns>
        static public double[,] Mask(int R)
        {
            double[,] result = new double[2 * R, 2 * R];

            int x = 2 * R - 1;
            int y = R - 1;
            int dE = 3 - 2 * R;
            double H = 1 * Math.PI / (R * R);

            int x1, x2, y1, y2 = y;

            while (x > R / 2 - 1)
            {
                x1 = 2 * R - x - 1;
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
        /// Возвращает функцию размытия точки в дискретном виде. Ядро размытия в виде квадрата
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
        static public double[,] Blur(double[,] im, double[,] fil)
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

        static public double[,] Blur(double[,] im, double[,] fil_1, double[,] fil_2, double[,] map)
        {
            Complex[,] IM_F = FFT.FFT2D(im);
            Complex[,] fil_F_1 = FFT.FFT2D(fil_1);
            Complex[,] fil_F_2 = FFT.FFT2D(fil_2);
            Complex[,] G = new Complex[IM_F.GetLength(0), IM_F.GetLength(1)];

            for (int i = 0; i < IM_F.GetLength(0); i++)
                for (int j = 0; j < IM_F.GetLength(1); j++)
                {
                    if (map[i,j] == 0)
                        G[i, j] = IM_F[i, j] * fil_F_1[i, j];
                    else
                        G[i, j] = IM_F[i, j] * fil_F_2[i, j];
                }

            double[,] res = FFT.IFFT2D(G);

            return res;
        }

        /// <summary>
        /// Простраственная адаптивная свертка
        /// </summary>
        /// <param name="im">Изображение в дискретном виде</param>
        /// <param name="map">Карта</param>
        /// <returns></returns>
        static public double[,] Convolute(double[,] im, double[,] map)
        {
            double[,] fil_1 = Mask(3);
            double[,] fil_2 = Mask(15);

            double[,] result = new double[im.GetLength(0), im.GetLength(1)];

            for (int i = 0; i < im.GetLength(0); i++)
                for (int j = 0; j < im.GetLength(1); j++)
                {
                    if (map[i, j] < 150)
                    {
                        if ((i > fil_1.GetLength(0) / 2) && (j > fil_1.GetLength(1) / 2) 
                            && (i < im.GetLength(0) - fil_1.GetLength(0) / 2) && (j < im.GetLength(1) - fil_1.GetLength(1) / 2))
                            for (int k = 0; k < (fil_1.GetLength(0) - 1) / 2; k++)
                                for (int l = 0; l < (fil_1.GetLength(1) - 1) / 2; l++)
                                {
                                    result[i, j] = fil_1[k, l] * im[i - fil_1.GetLength(0) / 2 + k, j - fil_1.GetLength(0) / 2 + l];
                                }

                    }
                    else
                    {
                        if ((i > fil_2.GetLength(0) / 2) && (j > fil_2.GetLength(1) / 2)
                            && (i < im.GetLength(0) - fil_2.GetLength(0) / 2) && (j < im.GetLength(1) - fil_2.GetLength(1) / 2))
                            for (int k = 0; k < (fil_2.GetLength(0) - 1) / 2; k++)
                                for (int l = 0; l < (fil_2.GetLength(1) - 1) / 2; l++)
                                {
                                    result[i, j] = fil_2[k, l] * im[i - fil_2.GetLength(0) / 2 + k, j - fil_2.GetLength(0) / 2 + l];
                                }
                    }
                }

            return result;
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

        /// <summary>
        /// Возвращают карту, в соответствии с которой размывается изображение
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        static public double[,] Blur_map(int line, int column)
        {
            double[,] res = new double[line,column];

            for (int i = 0; i < line; i++)
                for (int j = 0; j < column; j++)
                    if (j < column / 2)
                        res[i, j] = 0;
                    else
                        res[i, j] = 1;

            return res;
        }
        
    }
}
