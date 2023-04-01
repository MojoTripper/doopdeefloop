//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class is a more specific KIND OF CommandInventory that we are 
    // going to use to keep track of the Items in a player's inventory.
    public class PlayerInventory : CommandInventory<ItemType, Item>
    {
        // This verb gives us a shortcut for adding an item from the current
        // room by type.
        public void Add (ItemType item_type)
        {
            // Find out which item we're picking up
            var item = Castle.ThePlayer.CurrentRoom.Inventory.Get(item_type);

            // Add the item to our inventory
            Add(item);
        }

        // We want to override the Add VERB in order to make sure that,
        // whenever an Item gets picked up, we add a Drop and Use command.
        public override void Add(Item item)
        {
            // Add the item to our inventory
            base.Add(item);

            // Add the item's commands so we can use it or drop it
            Commands.Add(item.Drop);
            Commands.Add(item.Use);
        }

        // We want to override the Remove VERB in order to make sure that,
        // whenever an Item gets dropped, we remove the Drop and Use commands.
        public override void Remove (Item item)
        {
            // Remove the item from our inventory
            base.Remove(item);

            // Remove the item's commands
            Commands.Remove(item.Drop);
            Commands.Remove(item.Use);
        }
    }
}
