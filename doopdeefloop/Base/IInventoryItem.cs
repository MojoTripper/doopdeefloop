//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This is an *interface* for an inventory item.  It is like a contract
    // that tells other parts of the program what classes that "implement" 
    // or use this contract are able to do.
    //
    // In OOP, we say that a class that implements an interface shows the
    // IS A relationship, so that a class that implements this interface
    // can be treated by other parts of the program as if 
    // it IS A IInventoryItem interface.
    //
    // This interface is also "generic."  The <TKey> bit says that we don't 
    // know ahead of time what kind of Type we're going to use.  It's up to 
    // the implementing class to decide that.
    public interface IInventoryItem<TKey>
    {
        // This VERB makes sure the item is set up right.
        void Initialize();

        // This PROPERTY indicates what type the inventory item HAS.
        TKey Type { get; }

        // This PROPERTY indicates the description the inventory item HAS.
        string Description { get; }
    }
}
