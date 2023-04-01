using System.Collections.Generic;
using System;

namespace doopdeefloop.Commands
{
    public class Help : Command
    {
        public Help() : base("help", "")
        {
            Repeatable = true;
            Outcome = DoAction;
        }

        private void DoAction ()
        {
            Screen.Write("You can do any of these things:");
            List<string> help = new List<string>();
            help.AddRange(Castle.ThePlayer.CurrentRoom.GetHelp());
            help.AddRange(Castle.ThePlayer.GetHelp());
            help.Sort();
            Screen.Write(string.Join(Environment.NewLine, help.ToArray()) + 
                         Environment.NewLine, false);
        }
    }
}
