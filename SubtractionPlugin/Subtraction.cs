using PluginBase;

namespace SubtractionPlugin
{
    public class Subtraction : IOperation
    {
        public string Name => "Subtraction";
        public string Description => "Subtract two numbers.";
        public int Execute(int a, int b) => a - b;
    }
}
