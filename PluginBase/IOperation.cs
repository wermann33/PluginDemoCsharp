namespace PluginBase
{
    public interface IOperation
    {
        string Name { get; }
        string Description { get; }
        int Execute(int a, int b);
    }
}