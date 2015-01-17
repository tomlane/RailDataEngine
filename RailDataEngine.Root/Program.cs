using System;

namespace RailDataEngine.Root
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerBuilder.Build();

            Console.WriteLine("Rail data engine started.");
            Console.ReadKey();
        }
    }
}
