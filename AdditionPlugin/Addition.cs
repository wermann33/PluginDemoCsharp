using PluginBase;

namespace AdditionPlugin
{
    [Plugin("Addition")] // For attribute-based search
    public class Addition : IOperation
    {
        public string Name => "Addition";
        public string Description => "Adds two numbers.";
        public int Execute(int a, int b) => a + b;
    }
}
