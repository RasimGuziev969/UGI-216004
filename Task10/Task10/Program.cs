using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sample = new double[] {
                1.866, 0.950, 2.976, 1.713, 0.464, 
                3.047, 1.022, 2.151, 1.283, 1.224, 
                0.890, 2.215, 0.733, 0.645, 1.984, 
                1.488, 0.733, 0.702, 2.722, 1.135
            };

            Console.WriteLine(GetMSD(sample));

            Console.ReadKey();
        }

        static double GetMSD(IEnumerable<double> sample)
        {
            var mean = sample.Average();
            return sample.Aggregate(
                0.0, 
                (s, x) => s + (x - mean) * (x - mean), 
                x => Math.Sqrt(x / (sample.Count() - 1))
                );
        }
    }
}
