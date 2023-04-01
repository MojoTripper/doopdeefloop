//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class is a more specific KIND OF CommandInventory that we are 
    // going to use to keep track of the Items in a room.
    public class RoomInventory : CommandInventory<ItemType, Item>
    {
        // We want to override the Add VERB in order to make sure that,
        // whenever an Item gets added to a room, so does the PickUp 
        // command that will let the player pick up that item.
        public override void Add(Item item)
        {
            base.Add(item);
            Commands.Add(item.PickUp);
        }

        // We want to override the Remove VERB in order to make sure that,
        // whenever an Item gets removed from a room, so does the PickUp 
        // command that would have let the player pick up that item.
        public override void Remove (Item item)
        {
            base.Remove(item);
            Commands.Remove(item.PickUp);
        }
    }
}
