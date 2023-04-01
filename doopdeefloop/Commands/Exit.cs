namespace doopdeefloop.Commands
{
    public class Exit : Command
    {
        public Exit (string direction, RoomType destination) 
            : base("go " + direction, "You head " + direction + " out of the room.")
        {
            Repeatable = true;
            destinationRoom = destination;
            Outcome = DoAction;
        }

        private void DoAction ()
        {
            Castle.ThePlayer.ExitToRoom = destinationRoom;
        }

        private RoomType destinationRoom;
    }
}
