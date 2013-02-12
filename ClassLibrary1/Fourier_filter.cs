using System;
using System.Numerics;
using Fourier;

namespace Deconvolution
{
    public class Fourier_filter
    {
        
        static public double[,] Wiener (double[,] fil, double[,] im, double Kons)
        {
            Complex[,] IM_F = FFT.FFT2D(im);
            Complex[,] H = FFT.FFT2D(fil);
            Complex[,] G = new Complex[IM_F.GetLength(0), IM_F.GetLength(1)];

            for (int i = 0; i < IM_F.GetLength(0); i++)
                for (int j = 0; j < IM_F.GetLength(1); j++)
                    G[i, j] = IM_F[i, j] * H[i, j];

            Complex[,] im_conv_F = new Complex[IM_F.GetLength(0), IM_F.GetLength(1)];

            for (int i = 0; i < IM_F.GetLength(0); i++)
                for (int j = 0; j < IM_F.GetLength(1); j++)
                    im_conv_F[i, j] = ((1.0 / H[i, j]) * (H[i, j].Magnitude * H[i, j].Magnitude) / 
                                                       (H[i, j].Magnitude * H[i, j].Magnitude + Kons)) * G[i, j];

            double[,] res = FFT.IFFT2D(im_conv_F);

            return res;
        }
    }
}
