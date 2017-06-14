using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionBenchmark.Net461
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Initialize();

            BenchmarkRunner.Run<ReflectionBenchmarks>();

            Console.ReadKey();
        }
    }
}
