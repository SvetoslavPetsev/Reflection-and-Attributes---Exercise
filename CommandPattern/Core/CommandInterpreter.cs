namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";
        public CommandInterpreter()
        {
        }
        public string Read(string args)
        {
            string[] commands = args
                .Split(" ", System.StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string cmdName = commands[0] + COMMAND_POSTFIX;
            string[] cmdArgs = commands
                .Skip(1)
                .ToArray();

            Assembly assemble = Assembly.GetCallingAssembly();
            Type type = assemble
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == cmdName.ToLower());
            if (type == null)
            {
                throw new ArgumentException("Invalid command type!");
            }
            ICommand cmdInstance = (ICommand)Activator.CreateInstance(type);
            string result = cmdInstance.Execute(cmdArgs);

            return result;
        }
    }
}
