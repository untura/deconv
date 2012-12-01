using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fourier;
using System.Numerics;

namespace deconv
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] a = { { 12, 13, 17, 45 }, { 23, 7, 8, 10 }, { 12, 13, 17, 45 }, { 23, 7, 8, 10 } };
            Complex[,] F;

            F = FFT.FFT2D(a);

            double[,] f = FFT.IFFT2D(F);

            //foreach (int item in f)
            //{
            //    Console.WriteLine(f[item]);
            //}
        }
    }
}
