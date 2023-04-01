using System.Collections.Generic;
using System.Text;
using System;
using UntypedEnumerator = System.Collections.IEnumerator;
using UntypedEnumerable = System.Collections.IEnumerable;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class represents an Inventory that holds the Items we might find
    // in the game world. It's like a bag that holds stuff.
    //
    // Important OOP characteristics of an Inventory:
    //
    // * An Inventory HAS a list of the items inside it.
    //
    // * An Inventory IS enumerable (meaning we can go through the stuff 
    //   inside it one thing at a time.
    //
    // * An Inventory CAN DO things like adding and removing items, getting
    //   items that are inside it, or checking to see if an item exists or
    //   if there is anything in the inventory at all.
    //
    public class Inventory<TKey, TItem> : IEnumerable<TItem>
        where TItem : class, IInventoryItem<TKey>
    {
        //---------------------------------------------------------------------
        // This is a special method that sets up the Inventory when it is 
        // first used.
        #region CONSTRUCTOR

        public Inventory ()
        {
            Contents = new Dictionary<TKey, TItem>();
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things the Inventory CAN DO
        #region VERBS

        // This VERB tells the world whether this inventory has a particular 
        // item.
        public bool Has (TKey t)
        {
            return Contents.ContainsKey(t);
        }

        // This VERB gets an item in the inventory, if it exists.
        public TItem Get (TKey t)
        {
            return Has(t) ? Contents[t] : null;
        }

        // This VERB adds an item to the inventory.
        public virtual void Add (TItem item)
        {
            // Make sure we don't try to add an item twice!
            if (!Contents.ContainsKey(item.Type))
            {
                // Initialize the item
                item.Initialize();

                // Add the item to our inventory.
                Contents.Add(item.Type, item);
            }
        }

        // This VERB removes an item from the inventory.
        public virtual void Remove (TItem item)
        {
            // If there is an item to remove, remove it
            if (item != null)
            {
                Contents.Remove(item.Type);
            }
        }

        // This VERB removes an item of a given type from the inventory.
        public virtual TItem Remove(TKey t)
        {
            // Get the item to remove
            var item = Get (t);

            // Remove the item
            Remove(item);

            // Return the removed item to the caller
            return item;
        }

        // This is a special verb that lets you look up an item in
        // the inventory in the same way you would "index" into an Array.
        // It's a nice shortcut to have, so you can say things like 
        // Inventory [item] instead of Inventory.Get (item);
        public TItem this[TKey key]
        {
            get
            {
                return Get (key);
            }
        }

        // This is a special verb that gets something called an "enumerator", 
        // which will help us list all the items in the inventory.  This 
        // version of the verb gets what is called an "untyped" enumerator, 
        // meaning that, while it will let someone list the inventory 
        // contents, it won't  tell them what type of things are in the 
        // inventory (i.e. they don't know that they are Items, only that 
        // they are "objects."
        UntypedEnumerator UntypedEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return GetEnumerator();
        }

        // This version of the GetEnumerator verb gets what is called a 
        // "typed" enumerator, meaning that anyone who uses this to list the 
        // inventory contents can tell that the inventory contains Items, and 
        // not just generic "objects."
        public IEnumerator<TItem> GetEnumerator()
        {
            return Contents.Values.GetEnumerator();
        }
        
        #endregion

        //---------------------------------------------------------------------
        // This section lists things the Inventory HAS.
        #region PROPERTIES
        
        // This property tells the world whether this inventory is empty.
        public bool IsEmpty
        {
            get { return Contents.Count < 1; }
        }

        // This property gives the world a description of all the things
        // in this inventory.
        public string ListOfContents
        {
            get
            {
                var sb = new StringBuilder();
                foreach (TItem item in Contents.Values)
                {
                    sb.Append ("   * A " + 
                               item.Description + 
                               Environment.NewLine);
                }
                return sb.ToString();
            }
        }

        // This is where the inventory puts its stuff.  It is declared 
        // private, so only the verbs and of the Inventory can see and 
        // change it.
        private Dictionary<TKey, TItem> Contents;

        #endregion
    }
}
