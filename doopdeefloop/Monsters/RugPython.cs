namespace doopdeefloop
{
    public class RugPython : Monster
    {
        public RugPython()
        {
            Type = MonsterType.RugPython;
            Name = "rare South American rug python";
            LiveDescription = "There is a long rug leading from the doorway to the throne.";
            DeadDescription = "There is a rolled-up rug-python that looks to have already eaten its fill.";
            Origin = RoomType.ThroneRoom;
            Commands.Add(new Commands.LieOnRug ());
        }

        public override void Attack()
        {
            if (!IsDead)
            {
                Screen.Suspense();
                Screen.Write("It turns out this rug isn't a rug at all, but rather it's a rare, South American rug python!");
                if (Castle.ThePlayer.Stuff.Has(ItemType.SaltyChicken))
                {
                    Screen.Suspense ("It rolls you up, and and as you're struggling to free yourself from its grip, the salty chicken falls out of your inventory and into its mouth!  This seems to appease it.  It munches down the salty chicken and lets you go.");
                    IsDead = true;
                }
                else
                {
                    Screen.Write("It rolls you up and squeezes you to death!");
                    Castle.ThePlayer.Die();
                }
            }
        }
    }
}
