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
            return null;
        }
    }
}
