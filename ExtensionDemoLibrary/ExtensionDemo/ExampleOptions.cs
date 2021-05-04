using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionDemo
{
    public class ExampleOptions
    {
        internal static ExampleOptions Default { get; } = new ExampleOptions
        {
            PrintCount = 5
        };

        public int PrintCount { get; set; }
    }
}
