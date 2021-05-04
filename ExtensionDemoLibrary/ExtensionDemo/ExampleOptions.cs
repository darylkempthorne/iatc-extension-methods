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
