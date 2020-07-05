namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpeter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpeter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string args = Console.ReadLine();
                try
                {
                    string result = this.commandInterpeter.Read(args);
                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
