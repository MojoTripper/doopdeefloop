namespace doopdeefloop.Commands
{
    public class Explode : Command
    {
        public Explode() 
            :  base("explode", "You light your hair on fire.  Seconds later, you explode like a sack of dynamite.")
        {
            Repeatable = true;
            Outcome = DoAction;
        }

        private void DoAction ()
        {
            Castle.ThePlayer.Die ();
        }
    }
}
