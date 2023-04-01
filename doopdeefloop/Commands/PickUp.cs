namespace doopdeefloop.Commands
{
    public class PickUp : Command
    {
        public PickUp (Item item) : base ("pick up " + item.Name, "You pick up the " + item.Description)
        {
            actionItem = item;
            Repeatable = true;
            Outcome = DoAction;
        }

        private void DoAction ()
        {
            // Add the item to our inventory.
            Castle.ThePlayer.Stuff.Add(actionItem);

            // Remove the item from the room.
            Castle.ThePlayer.CurrentRoom.Inventory.Remove(actionItem);
        }

        private Item actionItem;
    }
}
