namespace doopdeefloop
{
    public class Rock : Item
    {
        public Rock()
        {
            Type = ItemType.Rock;
            Name = "rock";
            Description = "lumpy old rock";
            Origin = RoomType.EntranceFoyer;
            Use = new Commands.Use("throw", this) { Outcome = Throw };
        }

        public void Throw ()
        {
            // Remove the item from our inventory
            Item rock = Castle.ThePlayer.Stuff.Remove(ItemType.Rock);

            // Add the item to the room
            Castle.ThePlayer.CurrentRoom.Inventory.Add(rock);

            if (Castle.ThePlayer.CurrentRoom.RoomType == RoomType.EntranceFoyer)
            {
                Screen.Suspense();
                Screen.Write("It ricochets off the nose of a demon dog statue");
                Screen.Suspense();
                if (PercentileDice.RollUnder(20))
                {
                    Screen.Write("The statue comes to life and bites your face off!");
                    Castle.ThePlayer.Die();
                }
                else
                {
                    Screen.Write("The statue twitches!");
                }
            }
            else
            {
                Screen.Write("It clatters away into the darkness!");
            }
        }
    }
}
