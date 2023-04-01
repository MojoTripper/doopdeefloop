using System.Collections.Generic;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class represents a monster or a trap.  Since monsters will live 
    // in rooms like items, we can go ahead and use the Inventory class to 
    // keep track of them, too!  So, to do that, we're going to specify with 
    // the : operator here that a Monster IS A kind of IInventoryItem -- in 
    // this case, one that uses a MonsterType as its Type.
    //
    // We're going to mark it "abstract" to indicate that it can't be created
    // on its own.  It's just a nameless that needs to be fleshed out more
    // before it can be really scary.
    //
    // In order to create monsters, we will create other classes that 
    // "derive" from this Monster class, meaning that they can be treated as 
    // things that ARE Monsters, even though they are more specific (and 
    // useful) kinds of monsters.
    //
    // Important OOP characteristics of an Item
    //
    // * It HAS things like a Type, a Name, a Description of what it is,
    //   an Origin to say where it came from, a state of alive or dead,
    //   and a set of Commands for doing stuff with it.
    //
    // * It CAN DO things like Attack the player.
    //
    public abstract class Monster : IInventoryItem<MonsterType>
    {
        //---------------------------------------------------------------------
        // This is a special method that sets up the Monster when it is first
        // used.
        #region CONSTRUCTOR

        protected Monster ()
        {
            IsDead = false;
            Commands = new Commander ();
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things an Item CAN DO.
        //
        // We're going to make these verbs special by marking them as 
        // "virtual."  That means that the different kinds of Monsters we're
        // going to define later can change what these verbs do depending on
        // their individual needs.
        #region VERBS

        // This VERB makes sure the item is set up right.
        public virtual void Initialize()
        {
            // We don't have anything to do here for a generic monster,
            // but maybe more specific kinds of monsters will need it.
        }

        // This verb makes the monster do something.
        public virtual void Attack()
        {
            // We don't have anything to do here for a generic monster,
            // but maybe more specific kinds of monsters will need it.
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things a Monster HAS.  We are going to make them
        // all "public" so that the rest of the world can use them.
        #region PROPERTIES
        
        // This property gets what type of monster we are.  Anyone can look
        // at it, but only more specific kinds of monsters that derive from
        // this generic Monster class can set it.
        public MonsterType Type { get; protected set; }

        // This property gets the name of this monster.  Anyone can look
        // at it, but only more specific kinds of monsters that derive from
        // this generic Monster class can set it.
        public string Name { get; protected set; }

        // This property gets the description of this monters.
        public string Description
        {
            get
            {
                // We should change our description based on whether we're
                // alive or dead!
                if (IsDead) return DeadDescription;
                else return LiveDescription;
            }
        }

        // This property gets which room this monster comes from.  Anyone can
        // look at it, but only more specific kinds of monsters that derive 
        // from this generic Monster class can set it.
        public RoomType Origin { get; protected set; }

        // This property gets or sets whether this monster is dead.  Anyone
        // can see or change it.
        public bool IsDead { get; set; }

        // This property gets the "live" description of this monster.  Only
        // this monster or classes that derive from it can get or set it.
        protected string LiveDescription { get; set;}

        // This property gets the "dead" description of this monster.  Only
        // this monster or classes that derive from it can get or set it.
        protected string DeadDescription { get; set; }
        
        // This property provides a list of commands for this monster.
        // Anyone can see or change it, but only this class can set it.
        public Commander Commands { get; private set; }

        #endregion
    }
}
