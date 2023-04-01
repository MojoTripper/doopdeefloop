using doopdeefloop.Commands;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class represents an item you could pick up in the world.
    // In order to track it easily, we're going to use it with an Inventory,
    // and that's why we've declared that it IS A IInventoryItem by using
    // the : operator after its name.  We've also specified that we want to
    // use ItemType as the unknown type in the IInventoryItem interface.
    //
    // This will let us use something nice and generic like the Inventory
    // class to contain and keep track of our items.
    //
    // We're going to mark it "abstract" to indicate that it can't be created
    // on its own.  It's just a blank item that needs to be built up further
    // before it can be useful.
    //
    // In order to create items, we will create other classes that "derive"
    // from this Item class, meaning that they can be treated as things that
    // ARE Items, even though they are more specific (and useful) kinds of
    // items.
    //
    // Important OOP characteristics of an Item
    //
    // * It HAS things like a Type, a Name, a Description of what it is,
    //   an Origin to say where it came from, and a set of basic Commands 
    //   for doing stuff like using it, picking it up and dropping it.
    //
    public abstract class Item : IInventoryItem<ItemType>
    {
        //---------------------------------------------------------------------
        // This is a special method that sets up the Item when it is first
        // used.
        #region VERBS

        public void Initialize ()
        {
            if (!IsInitialized)
            {
                // Set up our internal properties
                PickUp = new PickUp(this);
                Drop = new Drop(this);

                IsInitialized = true;
            }
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things an Item HAS.  We are going to make them
        // all "public" so that the rest of the world can use them.
        #region PROPERTIES

        // This property gets what type of item we are.  Anyone can look
        // at it, but only more specific kinds of items that derive from
        // this generic Item class can set it.
        public ItemType Type { get; protected set; }

        // This property gets the name of this item.  Anyone can look
        // at it, but only more specific kinds of items that derive from
        // this generic Item class can set it.
        public string Name { get; protected set; }

        // This property gets the description of this item.  Anyone can look
        // at it, but only more specific kinds of items that derive from
        // this generic Item class can set it.
        public string Description { get; protected set; }

        // This property gets the room this item came from.  Anyone can look
        // at it, but only more specific kinds of items that derive from
        // this generic Item class can set it.
        public RoomType Origin { get; protected set; }

        // This property gets the command for using this item.  Anyone can 
        // look at it, but only more specific kinds of items that derive 
        // from this generic Item class can set it.
        public Command Use { get; protected set; }

        // This property gets the command for picking up this item.  Anyone  
        // can look at it, but only more specific kinds of items that derive 
        // from this generic Item class can set it.
        public Command PickUp { get; protected set; }

        // This property gets the command for dropping this item.  Anyone  
        // can look at it, but only more specific kinds of items that derive 
        // from this generic Item class can set it.
        public Command Drop { get; protected set; }

        // This property indicates whether the Item is initialized.  It can
        // only be seen or changed by this Item class.
        private bool IsInitialized { get; set; }

        #endregion
    }
}
