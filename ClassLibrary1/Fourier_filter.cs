using System;
using System.Numerics;
using Fourier;

namespace Deconvolution
{
    public class Fourier_filter
    {
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

        static public double PSNR(double[,] im, double[,] im_deconv)
        {
            double MSE = 0;

            for (int i = 0; i < im.GetLength(0); i++)
                for (int j = 0; j < im.GetLength(1); j++)
                    MSE += Math.Pow(Math.Abs(im[i, j] - im_deconv[i, j]), 2);

            MSE = Math.Sqrt(MSE / (im.GetLength(0) * im.GetLength(1)));

            return 20 * Math.Log10(255 / MSE);
        }
    }
}
