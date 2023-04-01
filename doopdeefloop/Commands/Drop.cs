namespace doopdeefloop.Commands
{
    public class Drop : Command
    {
        public Drop (Item item) : base("drop " + item.Name, "You drop the " + item.Description)
        {
            actionItem = item;
            Repeatable = true;
            Outcome = DoAction;
        }

        private void DoAction()
        {
            // Remove the item from our inventory
            Castle.ThePlayer.Stuff.Remove(actionItem);

            // Add the item to the room
            Castle.ThePlayer.CurrentRoom.Inventory.Add(actionItem);
        }

        private Item actionItem;
    }
}
