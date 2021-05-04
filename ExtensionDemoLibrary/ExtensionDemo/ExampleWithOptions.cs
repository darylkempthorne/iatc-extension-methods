using System;

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
