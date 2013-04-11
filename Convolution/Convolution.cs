using System;
using System.Numerics;
using Fourier;

namespace Convolution
{
    public class Filter
    {
        double [,] filter;
        double div;
        
        public Filter(string filter)
        {
            switch (filter)
            {
                case "Gauss":
                    this.filter = new double[,]{
                                {1, 2, 1},
                                {2, 4, 2},
                                {1, 2, 1}
                                };
                    div = 16;
                    break;
                case "Sharpen":
                    this.filter = new double[,] {
                                {0, -1, 0},
                                {-1, 5, -1},
                                {0, -1, 0}
                                };
                    div = 1;
                    break;
                case "Emboss":
                    this.filter = new double[,]{
                                {-2, -1, 0},
                                {-1, 1, 0},
                                {0, 1, 2}
                                };
                    div = 1;
                    break;
            }
        }

        public Filter()
        {
            filter = new double[,]{
                                {1, 2, 1},
                                {2, 4, 2},
                                {1, 2, 1}
                                };
            div = 16;
        }

        public double[,] Apply(double[,] image)
        {
            double[,] image_new;
            image_new = new double[image.GetLength(0),image.GetLength(1)];

            for (int i = filter.GetLength(0) / 2; i < image.GetLength(0); i++)
                for (int j = filter.GetLength(1) / 2; j < image.GetLength(1); j++)
                    for (int k = 0; k < (filter.GetLength(0) - 1) / 2; k++)
                        for (int l = 0; l < (filter.GetLength(1) - 1) / 2; l++)
                        {
                            image_new[i, j] = filter[k, l] * image[i - filter.GetLength(0) / 2 + k, j - filter.GetLength(0) / 2 + l] / div;    
                        }
            
            return image_new;
        }

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

        static public double Noise(double bright_value, double average_bright, double mean_square)
        {
            double noise = 1 / Math.Sqrt(2 * Math.PI * mean_square) *
                Math.Exp((-(bright_value - average_bright) * (bright_value - average_bright)) /
                         (2 * mean_square * mean_square));

            return noise;
        }
    }
}
