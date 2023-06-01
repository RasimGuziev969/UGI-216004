using PhotoEnhancer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestLighteningParameters((v, p) => p.SetValues(v), 500000);
            TestLighteningParameters((v, p) => p.Coefficient = v[0], 500000);

            Console.ReadKey();
        }

        static void TestLighteningParameters(Action<double[], LighteningParameters> action, int n)
        {
            var values = new double[] { 1 };
            var pareters = new LighteningParameters();

            action(values, pareters);

            var watch = new Stopwatch();
            watch.Start();

            for(var i = 0; i < n; i++)
                action(values, pareters);

            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds *  1000.0 / n);
        }
    }
}
