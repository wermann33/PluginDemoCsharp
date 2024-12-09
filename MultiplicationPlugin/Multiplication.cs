using PluginBase;

namespace MultiplicationPlugin
{
    [Plugin("Multiplication")] // For attribute-based search
    public class Multiplication : IOperation
    {
        public string Name => "Multiplication";
        public string Description => "Multiplies two numbers.";
        public int Execute(int a, int b) => a * b;
    }
}
