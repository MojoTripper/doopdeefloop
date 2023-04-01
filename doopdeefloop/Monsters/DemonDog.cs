namespace doopdeefloop
{
    public class DemonDog : Monster
    {
        public DemonDog ()
        {
            Type = MonsterType.DemonDog;
            Name = "demon dog";
            LiveDescription = "There is a creepy statue of a demon dog next to the door.";
            DeadDescription = "There is a statue of a demon dog with a wooden spoon wedged hilariously in its jaws.";
            Origin = RoomType.EntranceFoyer;
            Commands.Add(new Commands.PokeStatue());
            Commands.Add(LookCommand);
        }

        public override void Attack ()
        {
            if (IsDead)
            {
                Screen.Write("The statue just glares at you helplessly, rendered quite harmless by the wooden spoon wedged in its jaws.");
            }
            else if (PercentileDice.RollUnder (40))
            {
                Screen.Suspense();
                if (Castle.ThePlayer.Stuff.Has (ItemType.Spoon))
                {
                    Castle.ThePlayer.Stuff.Remove(ItemType.Spoon);
                    Screen.Suspense ("The statue comes to life and tries to bite your face off, but at the last second you wedge the wooden spoon into its snapping jaws!");
                    IsDead = true;
                    LookCommand.Response = "It's trying to avoid eye contact.  It looks humiliated!";
                }
                else
                {
                    Screen.Write("The statue comes to life and bites your face off!");
                    Castle.ThePlayer.Die();
                }
            }
        }

        private Command LookCommand = new Command("look at statue", "I think it's looking back at me.") { Repeatable = true };
    }
}
