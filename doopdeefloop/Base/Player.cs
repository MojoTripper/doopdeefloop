using System;
using System.Collections.Generic;
using doopdeefloop.Commands;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class represents the person playing the game.
    //
    // Important OOP characteristics of an Item
    //
    // * It HAS things like a Name, and Inventory, a set of commands,
    //   an alive or dead status, and a blind status.
    //
    // * It CAN DO things like Enter a room, DoStuff in a room, go Blind 
    //   or Die.
    //
    public class Player
    {
        //---------------------------------------------------------------------
        // This is a special method that sets up the Player when it is first
        // used.
        #region CONSTRUCTOR

        public Player ()
        {
            // Set up our internal properties
            Stuff = new PlayerInventory ();
            PlayerCommander = new Commander();

            // Get the player's name
            Screen.Clear("");
            Name = Screen.Prompt ("What is thine name, brave adventurer?");
            Screen.Write ("Very well.  Thy name is " + Name + 
                          " , and so by " + Name + " shall you be known!");
            Screen.Suspense(6);

            // Add some commands to the player, so we can execute them 
            // anywhere in the castle.
            PlayerCommander.Add (new RubEyes());
            PlayerCommander.Add (new Explode ());
            PlayerCommander.Add (new LookAround ());
            PlayerCommander.Add (new Help());
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists VERBS the Player CAN DO
        #region VERBS
        
        // This verb has the player enter a room and do stuff in that room.
        public RoomType EnterRoom (RoomType room)
        {
            // Get the requested room from the castle
            CurrentRoom = Castle.Rooms [room];

            // Since we just entered, we don't know where we're going to exit
            // to yet
            ExitToRoom = null;

            // Let the player know we just entered a new room
            Screen.Write ("You enter the " + CurrentRoom.Name + ".");
            Screen.Suspense();

            // Look around as the first thing we do to describe the room
            PlayerCommander.Execute ("look around");

            // Let the room know that we entered it
            CurrentRoom.OnEnter ();

            // As long as we're not dead or exiting, do stuff in this room
            while (!IsDead && ExitToRoom == null)
            {
                // Do stuff
                DoStuff();

                // If that didn't kill us, let the room know we're doing 
                // stuff in it.
                if (!IsDead)
                {
                    CurrentRoom.OnDoStuff();
                }
            }

            // At this point, we're either dead or exiting
            if (!IsDead)
            {
                // If we're not dead, we must be exiting, so let the
                // room know we're leaving
                CurrentRoom.OnExit();
            }

            // Report which room we're exiting to
            return ExitToRoom.RoomType;
        }

        // This verb has the player do stuff wherever he or she is 
        // right now.
        public void DoStuff ()
        {
            // Get a command from the player
            var command = Screen.Prompt (Environment.NewLine + 
                "What would you like to do now? (Type \"help\" for help.)");

            // First try the command on the player
            if (PlayerCommander.Has (command))
            {
                PlayerCommander.Execute(command);
            }

            // Next, if we're not blind, try the command on the room  
            // and the inventory
            else if (IsBlind)
            {
                Screen.Write("You can't see well enough to do that!");
            }

            // If we can see, first try executing the command in the room
            else if (CurrentRoom.Has (command))
            {
                CurrentRoom.Execute(command);
            }

            // Next try executing the command on the player
            else if (Stuff.Has(command))
            {
                Stuff.Execute(command);
            }

            // If the command didn't succeed anywhere, it must be
            // a bad command.
            else
            {
                Screen.Write("I don't know how to do that.");
            }
        }

        // This verb creates a list of all the commands we can do 
        // right now
        public List<string> GetHelp()
        {
            // Prepare a blank list
            var help = new List<string>();

            // Add all the player commands to the list.
            help.AddRange(PlayerCommander.GetHelp());

            // Add all the inventory item commands to the list.
            help.AddRange(Stuff.GetHelp());

            // Return the list to the caller.
            return help;
        }

        // This verb blinds or unblinds us.  We can add a message to
        // tell the player what happened.
        public void Blind (bool blind_me, string message = "")
        {
            if (blind_me)
            {
                Screen.Suspense();
                Screen.Write("Oh no!  You've gone blind! " + message);
                Castle.ThePlayer.IsBlind = true;
            }
            else if (Castle.ThePlayer.IsBlind)
            {
                Screen.Suspense();
                Screen.Write("Suddenly you can see again! It's a miracle!");
                Castle.ThePlayer.IsBlind = false;
            }

        }

        // This verb makes us die.  Hopefully that doesn't happen too often.
        public void Die ()
        {
            Screen.Suspense();
            var answer = 
                Screen.Prompt ("Oh, dear.  It looks like you are dead.  " +
                               "Would you like to play again? (yes/no)");
            switch (answer)
            {
                case "yes":
                    Screen.Write ("Too bad!  You're dead!");
                    break;
                case "no":
                    Screen.Write ("Good, cause you're dead!");
                    break;
                default:
                    Screen.Write ("What? I can't hear you! You're dead!");
                    break;
            }

            IsDead = true;
            ExitToRoom = RoomType.EntranceFoyer;
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things or statuses Player HAS
        // We're going to mark these public so that the rest of the world 
        // can see and change them.
        #region PROPERTIES

        // The rest of the world can check this (get) to see if we are blind,
        // but only Player verbs can change it (private set).
        public bool IsBlind { get; private set; }

        // The rest of the world can check this (get) to see if we are dead,
        // but only Player verbs can change it (private set).
        public bool IsDead { get; private set; }

        // The rest of the world can check this (get) to see our name,
        // but only Player verbs can change it (private set).
        public string Name { get; private set; }

        // The rest of the world can check this (get) to see which room we 
        // are in, but only Player verbs can change it (private set).
        public Room CurrentRoom { get; private set; }

        // The rest of the world can check this (get) to see which room we 
        // are exiting to, or set it to make us exit.
        public Room ExitToRoom { get; set; }

        // The rest of the world can check, add and remove stuff from the
        // player's inventory, but only the player can create or destroy
        // the whole inventory itself.
        public  PlayerInventory Stuff { get; private set; }

        // Only this class can directly access the player's commands.
        private Commander PlayerCommander;

        #endregion
    }
}