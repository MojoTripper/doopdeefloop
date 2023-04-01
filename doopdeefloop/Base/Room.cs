using System.Text;
using System.Collections.Generic;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class represents a Room in the Castle.
    //
    // We're going to mark it "abstract" to indicate that it can't be created
    // on its own.  It's just a blank room that needs to be built up further
    // before it can be useful.
    //
    // In order to create rooms, we will create other classes that "derive"
    // from this Room class, meaning that they can be treated as things that
    // ARE Rooms, even though they are more specific (and useful) kinds of
    // rooms.
    public abstract class Room
    {
        //---------------------------------------------------------------------
        // This is a special method that sets up the Room when it is first
        // used.
        #region CONSTRUCTOR

        protected Room ()
        {
            // Set up our internal properties
            Commands = new Commander();
            Inventory = new RoomInventory();
            Monsters = new RoomMonsters();
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things or statuses Room HAS
        // We're going to mark these public so that the rest of the world 
        // can see and change them.
        #region PROPERTIES

        // This verb gets a description of the room.  Anyone can see it, 
        // but only this room or more specific kinds of rooms that derive
        // from this room class can change it.
        public string Description
        {
            get
            {
                // Make a StringBuilder object to make it easier and more
                // efficient to build a long string out of little ones.
                var sb = new StringBuilder();

                // Add the description of the room
                sb.Append(BaseDescription + " ");

                // Add the description of any monsters in this room.
                foreach (Monster m in Monsters)
                {
                    sb.Append(m.Description + " ");
                }

                // Return the string we built.
                return sb.ToString();
            }

            // Set the base description of the room.
            protected set { BaseDescription = value; }
        }

        // This property gets what type of room we are.  Anyone can look
        // at it, but only more specific kinds of items that derive from
        // this generic Room class can set it.
        public RoomType RoomType { get; protected set; }

        // This property gets the name of this room.  Anyone can look
        // at it, but only more specific kinds of items that derive from
        // this generic Item class can set it.
        public string Name { get; protected set; }

        // This property gets the Inventory of this room.  Anyone can look
        // at it, but only this Room class can set it.
        public RoomInventory Inventory { get; private set; }

        // This property gets the Monsters in this room.  Anyone can look
        // at it, but only this Room class can set it.
        public RoomMonsters Monsters { get; private set; }

        // This property gets the Commands of this room.  Only more specific
        // rooms derived from this room can look at it, and only this Room 
        // class can set it.
        protected Commander Commands { get; private set; }

        // This property gets the base description of this room, without
        // any monster descriptions added on.  Only this room class can
        // look at or change it.
        private string BaseDescription { get; set; }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things the Room CAN DO
        #region VERBS

        public bool Has (string command)
        {
            return (Commands.Has(command) || 
                    Inventory.Has(command) || 
                    Monsters.Has(command));
        }

        public bool Execute (string command)
        {
            return (Commands.Execute (command) || 
                    Inventory.Execute (command) || 
                    Monsters.Execute (command));
        }

        public List<string> GetHelp ()
        {
            var help = new List<string>();
            help.AddRange (Commands.GetHelp());
            help.AddRange (Inventory.GetHelp());
            help.AddRange (Monsters.GetHelp());
            return help;
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things the Player CAN DO.
        //
        // We're going to make these verbs special by marking them as 
        // "virtual."  That means that the different kinds of Monsters we're
        // going to define later can change what these verbs do depending on
        // their individual needs.
        #region VIRTUAL VERBS

        // This verb tells the room that the player is entering, and so
        // the room should do anything it needs to do when the player enters.
        public virtual void OnEnter ()
        {
            // Do nothing in a non-specific room
        }

        // This verb tells the room that the player is about to exit, and so
        // the room should do anything it needs to do when the player exits.
        public virtual void OnExit ()
        {
            // Do nothing in a non-specific room
        }

        // This verb tells the room that the player is doing stuff, and so
        // the room should do stuff, too, if it needs to.
        public virtual void OnDoStuff ()
        {
            // Do nothing in a non-specific room
        }

        // This verb is a kind of magic verb that converts a RoomType
        // to a room.  You can think of it like an automatic way to look
        // up a room in the castle when you know its type.
        public static implicit operator Room (RoomType type)
        {
            return Castle.Rooms[type];
        }

        #endregion
    }
}
