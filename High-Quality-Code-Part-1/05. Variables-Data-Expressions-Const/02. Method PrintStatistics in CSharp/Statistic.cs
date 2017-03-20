using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_PrintStatistics_in_CSharp
{
    class Statistic
    {
        
        public void PrintStatistics(double[] arr, int count)
        {
            double max = double.MinValue;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            PrintMax(max);
            
            double min = double.MaxValue;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            PrintMin(min);

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
            }
            PrintAvg(sum / count);
        }

        private void PrintAvg(double AverageSum)
        {
            throw new NotImplementedException();
        }

        private void PrintMin(double min)
        {
            throw new NotImplementedException();
        }

        private void PrintMax(double max)
        {
            throw new NotImplementedException();
        }
    }
}

