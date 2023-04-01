namespace doopdeefloop.Commands
{
    public class LookAtLightBulb : Command
    {
        public LookAtLightBulb ()
            : base ("look at light bulb", "Ow, that hurts my eyes!")
        {
            Repeatable = true;
            Outcome = DoAction;
        }

        public void DoAction()
        {
            ++lookCount;
            if (lookCount > 2)
            {
                Castle.ThePlayer.Blind (true, "Didn't your mother ever warn you about looking at bright light bulbs?");
                lookCount = 0;
            }
        }

        private int lookCount = 0;
    }
}
