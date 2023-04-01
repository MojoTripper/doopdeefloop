using System.Collections.Generic;
using UntypedEnumerator = System.Collections.IEnumerator;
using UntypedEnumerable = System.Collections.IEnumerable;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class represents a thing that does commands, so we'll call it a 
    // Commander.
    //
    // Important OOP characteristics of a Commander:
    //
    // * It HAS a list of commands, and also a list of commands that we
    //   already did that we shouldn't be able to do again.
    //
    // * It CAN DO things like Execute a command, Get a command from its list, 
    //   Add a command to its list, Remove a command from its list, Reset the 
    //   list of things we already did, and PrintHelp when the player doesn't 
    //   know what to do.
    //
    public class Commander : IEnumerable<Command>
    {
        //---------------------------------------------------------------------
        // This is a special method that sets up the Commander when it is 
        // first used.
        #region CONSTRUCTOR

        public Commander ()
        {
            Commands = new Dictionary<string, Command>();
            ThingsYouAlreadyDid = new List<string>();
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things the Commander CAN DO
        #region VERBS

        // This verb executes, or runs, the command with the requested key
        public bool Execute (string key)
        {
            var success = false;

            // Check if we already did this and can't do it again
            if (ThingsYouAlreadyDid.Contains (key))
            {
                Screen.Write ("You already did that!  " + 
                              "You don't need to do it again.");
            }

            // If we didn't already do it, or if it is repeatable, go ahead 
            // and run the command!
            else
            {
                // First get it from our list of commands
                var c = Get (key);

                if (c != null)
                {
                    // Execute it!
                    c.Execute();

                    // If it's not a repeatable command, add it to our list of
                    // things we already did
                    if (!c.Repeatable) ThingsYouAlreadyDid.Add(c.Key);

                    success = true;
                }
            }

            // Report to the program whether we executed the command 
            // successfully!
            return success;
        }

        // This verb checks to see if the command with the given key is
        // in this commander's list.
        public bool Has (string key)
        {
            return Commands.ContainsKey(key);
        }

        // This verb gets the command with a given key.
        public Command Get (string key)
        {
            // Check if we have the command
            if (Has(key))
            {
                // If we do, return it to the caller
                return Commands[key];
            }

            // Otherwise, return the special "null" value to indicate that
            // we don't have the command.
            else return null;
        }

        // This verb adds a command to the Commander's list of commands.
        public void Add(Command c)
        {
            // Check if there is really a command to add.  If the caller
            // gave us the special "null" value, then there's no command
            // to add.
            if (c != null)
            {
                // Add the command to our list.
                Commands.Add(c.Key, c);
            }
        }

        // This verb removes a command to the Commander's list of commands.
        public void Remove (Command c)
        {
            // Check if there is really a command to remove.  If the caller
            // gave us the special "null" value, then there's no command
            // to remove.
            if (c != null)
            {
                // Remove the command from our list.
                Commands.Remove(c.Key);

                // Remove the command from the list of things we already did.
                ThingsYouAlreadyDid.Remove(c.Key);
            }
        }

        // This verb resets all the commands we already did, so we can do 
        // them again.
        public void Reset ()
        {
            // Just empty out the list of things we already did.
            ThingsYouAlreadyDid.Clear();
        }

        // This verb prints the list of available commands to the screen.
        public List<string> GetHelp ()
        {
            // Make a blank list for adding our commands.
            var help = new List<string>();

            // For every command in our list, add a description of it
            // to the list.
            foreach (string item in Commands.Keys)
            {
                help.Add(" *   " + item);
            }

            // Return the finished list to the caller.
            return help;
        }

        // This is a special verb that gets something called an "enumerator", 
        // which will help us list all the commands in the Commander.  This 
        // version of the verb gets what is called an "untyped" enumerator, 
        // meaning that, while it will let someone list commands, it won't  
        // tell them that they are Command objects.
        UntypedEnumerator UntypedEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return GetEnumerator();
        }

        // This version of the GetEnumerator verb gets what is called a 
        // "typed" enumerator, meaning that anyone who uses this to list the 
        // inventory contents can tell that the inventory contains Items, and 
        // not just generic "objects."
        public IEnumerator<Command> GetEnumerator()
        {
            return Commands.Values.GetEnumerator();
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things the Castle HAS.  We are going to make 
        // them all "private" so that the rest of the world can't see them. 
        //  It has to use our verbs instead.
        #region PROPERTIES

        private Dictionary<string, Command> Commands;
        private List<string> ThingsYouAlreadyDid;

        #endregion
    }
}
