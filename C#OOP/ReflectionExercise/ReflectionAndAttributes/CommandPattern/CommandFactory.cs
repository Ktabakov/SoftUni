using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace CommandPattern
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(s => s.Name == $"{commandType}Command");

            if (type == null)
            {
                throw new ArgumentException($"{commandType} is invalid command type");
            }

            var instance = (ICommand)Activator.CreateInstance(type);
            return instance;
        }
    }
}
