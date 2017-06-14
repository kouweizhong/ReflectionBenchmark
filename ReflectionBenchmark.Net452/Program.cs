using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionBenchmark;

namespace ReflectionBenchmark.Net452
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
