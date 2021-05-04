using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionDemo
{
    class ExampleWithOptions : IExampleWithOptions
    {
        public ExampleWithOptions(ExampleOptions options)
        {
            Options = options;
        }

        private readonly ExampleOptions Options;

        public void DoSomethingElse(string message)
        {
            for (var count = 0; count < Options.PrintCount; count++)
            {
                Console.WriteLine($"({count + 1}/{Options.PrintCount}){message}");
            }
        }
    }
}
