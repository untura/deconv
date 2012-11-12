using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Convolution
{
    public class Convolution
    {
        double [,] filter;
        
        public Convolution(double[,] filter)
        {
            this.filter = filter;
        }

        public Convolution()
        {
            filter = new double[,]{
                                {1, 2, 1},
                                {2, 4, 2},
                                {1, 2, 1}
                                };
        }

        public double[,] Apply(double[,] image)
        {
            double[,] image_new;
            image_new = new double[image.GetLength(0),image.GetLength(1)];

            //double[,] image_exp;
            //image_exp = new double[image.GetLength(0) + 2 * filter.GetLength(0) / 2, image.GetLength(1) + 2 * filter.GetLength(1) / 2];

            //for (int i = 0; i < image_exp.GetLength(0); i++)
            //{
            //    for (int j = 0; j < image_exp.GetLength(1); j++)
            //    {
            //        if ((i < filter.GetLength(0) / 2) || (j < filter.GetLength(1) / 2))
            //            image_exp[i, j] = image[i, j]
            //    }
            //}

            for (int i = filter.GetLength(0) / 2; i < image.GetLength(0); i++)
                for (int j = filter.GetLength(1) / 2; j < image.GetLength(1); j++)
                    for (int k = 0; k < (filter.GetLength(0) - 1) / 2; k++)
                        for (int l = 0; l < (filter.GetLength(1) - 1) / 2; l++)
                        {
                            image_new[i, j] = filter[k, l] * image[i - filter.GetLength(0) / 2 + k, j - filter.GetLength(0) / 2 + l];    
                        }
            
            return image_new;
        }
    }
}
