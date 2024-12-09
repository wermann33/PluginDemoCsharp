namespace PluginHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pluginPath = "./Plugins"; 
            var plugins = PluginLoader.LoadPlugins(pluginPath);

            Console.WriteLine("Available Plugins:");
            foreach (var plugin in plugins)
            {
                Console.WriteLine($"{plugin.Name}: {plugin.Description}");
            }

            while (true)
            {
                Console.WriteLine("\nChoose an operation:");
                string operation = Console.ReadLine();

                var selectedPlugin = plugins.FirstOrDefault(p => p.Name.Equals(operation, StringComparison.OrdinalIgnoreCase));
                if (selectedPlugin != null)
                {
                    Console.WriteLine("Enter two numbers:");
                    int a = int.Parse(Console.ReadLine());
                    int b = int.Parse(Console.ReadLine());

                    int result = selectedPlugin.Execute(a, b);
                    Console.WriteLine($"Result: {result}");
                } else
                {
                    Console.WriteLine("Operation not found.");
                }
            }
        }
    }
}
