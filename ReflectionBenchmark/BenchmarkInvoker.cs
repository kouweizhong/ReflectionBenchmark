using System;
using System.Linq;
using System.Reflection;
using ReflectionBenchmark.Net4;

namespace ReflectionBenchmark
{
    internal class BenchmarkInvoker
    {
        private readonly Func<object, object[], object> _invoker;
        private readonly string _name;
        private readonly int _iteration;
        private readonly static object[] Args = new object[0];

        internal BenchmarkInvoker(MethodInfo benchmark)
        {
            var benchmarkAttribute = (BenchmarkAttribute)benchmark.GetCustomAttributes(typeof(BenchmarkAttribute), false).First();
            _name = string.IsNullOrEmpty(benchmarkAttribute.Name) ? benchmark.Name : benchmarkAttribute.Name;
            _iteration = benchmarkAttribute.Iteration <= 0 ? 10000 : benchmarkAttribute.Iteration;
            _invoker = new MethodReflector(benchmark).CreateMethodInvoker();
        }

        public void Invoke(object instance)
        {
            CodeTimer.Time(_name, _iteration, () =>
            {
                _invoker(instance, Args);
            });
        }
    }
}