namespace doopdeefloop.Commands
{
    public class RubEyes : Command
    {
        public RubEyes() : base("rub eyes", "You rub your eyes.")
        {
            Repeatable = true;
            Outcome = DoAction;
        }

        private void DoAction ()
        {
            Castle.ThePlayer.Blind(false);
        }
    }
}
