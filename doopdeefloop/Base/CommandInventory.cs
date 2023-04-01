using System.Collections.Generic;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This is just an Inventory class that has a Commander class, so you 
    // can do things like make the availability of certain commands depend 
    // on whether you have a particular thing in your inventory.
    //
    // Important OOP characteristics of a Commander:
    //
    // * It IS a KIND OF an Inventory
    //
    // * It HAS a list of commands that can be executed on the stuff in the
    //   inventory
    //
    // * It CAN DO things like Execute a command, check if this inventory 
    //   Has a particular command, and GetHelp when the player doesn't 
    //   know what to do.
    //
    public class CommandInventory<TKey, TItem> : Inventory<TKey, TItem>
        where TItem : class, IInventoryItem<TKey>
    {
        // This verb checks whether the given command is in our list.
        public bool Has (string command)
        {
            return Commands.Has(command);
        }

        // This verb executes the given command.
        public bool Execute(string command)
        {
            return Commands.Execute(command);
        }

        // This verb gets a list of the commands in our list.
        public List<string> GetHelp()
        {
            return Commands.GetHelp();
        }

        // Make this protected so that only classes that ARE a 
        // CommandInventory (e.g. that "derive" from it) can access this 
        // Commander object.
        protected Commander Commands = new Commander();
    }
}
