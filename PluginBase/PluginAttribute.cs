namespace PluginBase
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginAttribute(string name) : Attribute
    {
        public string Name { get; } = name;
    }
}