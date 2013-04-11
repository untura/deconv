using System;
using System.Numerics;
using Fourier;

namespace Deconvolution
{
    public class Fourier_filter
    {
        /// <summary>
        /// Инверсный фильтр
        /// </summary>
        /// <param name="fil">Функция размытия точки</param>
        /// <param name="im_conv">Искаженное изображение</param>
        /// <returns></returns>
        static public double[,] Inverse(double[,] fil, double[,] im_conv)
        {
            Complex[,] H = FFT.FFT2D(fil);
            Complex[,] G = FFT.FFT2D(im_conv);

            Complex[,] im_deconv_F = new Complex[im_conv.GetLength(0), im_conv.GetLength(1)];

            for (int i = 0; i < im_conv.GetLength(0); i++)
                for (int j = 0; j < im_conv.GetLength(1); j++)
                    im_deconv_F[i, j] = G[i, j] / H[i, j];

            double[,] res = FFT.IFFT2D(im_deconv_F);

            return res;
        }

        /// <summary>
        /// Фильтр Винера
        /// </summary>
        /// <param name="fil">Функция размытия точки</param>
        /// <param name="im_conv">Искаженное изображение</param>
        /// <param name="Kons">Отношение сигнал/шум</param>
        /// <returns></returns>
        static public double[,] Wiener (double[,] fil, double[,] im_conv, double Kons)
        {
            Complex[,] H = FFT.FFT2D(fil);
            Complex[,] G = FFT.FFT2D(im_conv);

            Complex[,] im_deconv_F = new Complex[im_conv.GetLength(0), im_conv.GetLength(1)];

            for (int i = 0; i < im_conv.GetLength(0); i++)
                for (int j = 0; j < im_conv.GetLength(1); j++)
                    im_deconv_F[i, j] = ((1.0 / H[i, j]) * (H[i, j].Magnitude * H[i, j].Magnitude) / 
                                                       (H[i, j].Magnitude * H[i, j].Magnitude + Kons)) * G[i, j];

            double[,] res = FFT.IFFT2D(im_deconv_F);
            
            return res;
        }

        /// <summary>
        /// Вычисление оценочной величины PSNR
        /// </summary>
        /// <param name="im_conv">Искаженное изображение</param>
        /// <param name="im_deconv">Восстановленное изображение</param>
        /// <returns></returns>
        static public double PSNR(double[,] im_conv, double[,] im_deconv)
        {
            double MSE = 0;

            for (int i = 0; i < im_conv.GetLength(0); i++)
                for (int j = 0; j < im_conv.GetLength(1); j++)
                    MSE += Math.Pow(Math.Abs(im_conv[i, j] - im_deconv[i, j]), 2);

            MSE = Math.Sqrt(MSE / (im_conv.GetLength(0) * im_conv.GetLength(1)));

            return 20 * Math.Log10(255 / MSE);
        }
    }
}
