using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionBenchmark
{
    public class ReflectionBenchmarks
    {
        internal const int Iteration = 10000000;

        [Benchmark(Iteration = Iteration)]
        public void ActivatorCreateInstance()
        {
            var instance = Activator.CreateInstance<ReflectionBenchmarks>();
        }

        [Benchmark(Iteration = Iteration)]
        public void GetMethods()
        {
            var methods = typeof(ReflectionBenchmarks).GetMethods();
        }

        [Benchmark(Iteration = Iteration)]
        public void MethodInvoke()
        {
            var method = typeof(MethodBenchmark).GetMethod("Reflector");
            var instance = new MethodBenchmark();
            var result = method.Invoke(instance, new object[] { instance });
        }

        [Benchmark(Iteration = Iteration)]
        public void FieldGet()
        {
            var field = typeof(FieldBenchmark).GetField("age");
            var instance = new FieldBenchmark();
            instance.age = 22;
            var result = field.GetValue(instance);
        }

        [Benchmark(Iteration = Iteration)]
        public void FieldSet()
        {
            var field = typeof(FieldBenchmark).GetField("age");
            var instance = new FieldBenchmark();
            field.SetValue(instance, 22);
        }

        [Benchmark(Iteration = Iteration)]
        public void PropertyGet()
        {
            var property = typeof(PropertyBenchmark).GetProperty("Age");
            var instance = new PropertyBenchmark();
            instance.Age = 22;
            var result = property.GetValue(instance, null);
        }

        [Benchmark(Iteration = Iteration)]
        public void PropertySet()
        {
            var property = typeof(PropertyBenchmark).GetProperty("Age");
            var instance = new PropertyBenchmark();
            property.SetValue(instance, 22, null);
        }
    }

    public class MethodBenchmark
    {
        public object Reflector(object arg)
        {
            return arg;
        }
    }

    public class FieldBenchmark
    {
        public int age;
    }

    public class PropertyBenchmark
    {
        public int Age { get; set; }
    }
}