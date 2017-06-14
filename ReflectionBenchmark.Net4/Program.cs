using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReflectionBenchmark.Net4
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
