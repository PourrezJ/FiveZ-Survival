using System;

namespace FiveZ.Chat
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Command : Attribute
    {
        public string Name { get; }

        public bool GreedyArg { get; }

        public string[] Aliases { get; }

        public Command(string name = null, bool greedyArg = false, string[] aliases = null)
        {
            Name = name;
            GreedyArg = greedyArg;
            Aliases = aliases;
        }
    }
}