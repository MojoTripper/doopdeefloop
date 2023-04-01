namespace doopdeefloop.Commands
{
    public class LookAround : Command
    {
        public LookAround () : base("look around", "You look around you.")
        {
            Repeatable = true;
            Outcome = DoAction;
        }

        public void DoAction ()
        {
            if (!Castle.ThePlayer.IsBlind)
            {
                Screen.Clear ("You are in the " + Castle.ThePlayer.CurrentRoom.Name + ".");
                Screen.Write(Castle.ThePlayer.CurrentRoom.Description);
                string stuff = Castle.ThePlayer.CurrentRoom.Inventory.ListOfContents;
                if (stuff.Length > 0)
                {
                    Screen.Write("You see several things lying around: ");
                    Screen.Write(stuff);
                }
                else
                {
                    Screen.Write("You see nothing lying around.");
                }
            }
            else
            {
                Screen.Write("You see ... huh?  Wha?  Nothing?!  OMGosh!  You're BLIND!");
            }
        }
    }
}
