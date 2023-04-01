namespace doopdeefloop
{
    public class DungeonTrap : Monster
    {
        public DungeonTrap()
        {
            Type = MonsterType.DungeonTrap;
            Name = "a dastardly device of dungeonesque doom!";
            LiveDescription = "Other than that, nothing seems to be out of the ordinary down here ... for a dungeon.";
            DeadDescription = "There is a spring-loaded bar door that has been wedged open with an iron rod.";
            Origin = RoomType.Dungeon;
        }

        public override void Attack()
        {
            if (!IsDead)
            {
                if (PercentileDice.RollUnder (20))
                {
                    Screen.Suspense();
                    if (Castle.ThePlayer.Stuff.Has (ItemType.Staff))
                    {
                        Screen.Suspense("The dungeon bars begin to slam shut behind you, but you manage to wedge your trust staff between them, saving yourself from being sealed in forever.  Whew!  That was close!");
                        IsDead = true;
                    }
                    else
                    {
                        Screen.Write ("The dungeon bars slam shut behind you, sealing you in forever!  You rot slowly over the course of several weeks.");
                        Castle.ThePlayer.Die();
                    }
                }
            }
        }
    }
}
