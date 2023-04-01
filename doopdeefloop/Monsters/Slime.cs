namespace doopdeefloop
{
    public class Slime : Monster
    {
        public Slime()
        {
            Type = MonsterType.Slime;
            Name = "slime";
            LiveDescription = "There is a cute little googly-eyed slime sitting in the middle of the room.";
            DeadDescription = "There is a greasy spot that used to be a rather adorable little slime ... you monster!";
            Origin = RoomType.EntranceFoyer;
            Commands.Add(new Command("kick slime", "You kick the slime") { Repeatable = true, Outcome = Jiggle });
            Commands.Add(new Command("stomp slime", "You stomp the slime") { Repeatable = true, Outcome = Squish });
        }

        public void Jiggle ()
        {
            if (!IsDead)
            {
                Screen.Write("It jiggles harmlessly and lets out a little \"Squeee!\".");
            }
            else
            {
                Screen.Write("The greasy spot where the slime was doesn't seem to react much.");
            }
        }

        public void Squish ()
        {
            if (!IsDead)
            {
                Screen.Write("The slime splatters all over the bottom of your shoe.  Gross.");
                IsDead = true;
            }
            else
            {
                Screen.Write("The greasy spot isn't getting any squishier, but the bottom of your shoe sure is.");
            }
        }
    }
}
