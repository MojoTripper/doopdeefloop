namespace doopdeefloop
{
    public class BlackHole : Monster
    {
        public BlackHole()
        {
            Type = MonsterType.BlackHole;
            Name = "black hole disguised as a rug";
            LiveDescription = "There is a big rug on the floor with a weird swirly pattern in it.  Seriously?  Another rug?  I guess at least this one isn't as boring as the others, though.";
            DeadDescription = "There is an interdimensional wormhole leading to the entrance foyer where a rug used to be.";
            Origin = RoomType.Gallery;

            Commands.Add(new Commands.LieOnRug ());
        }

        public override void Attack()
        {
            Screen.Suspense();
            if (IsDead)
            {
                Screen.Write("You fall through the black hole into the entrance foyer.");
                Castle.ThePlayer.ExitToRoom = RoomType.EntranceFoyer;
            }
            else
            {
                if (Castle.ThePlayer.Stuff.Has (ItemType.Amulet))
                {
                    Screen.Suspense ("The pattern in the rug underneath you swirls into a deadly black hole that threatens to suck you into another dimension.  But at the last second, the amulet sparkles and turns the black hole into a wormhole that deposits you unceremoniously on your behind in the entrance foyer.");
                    IsDead = true;
                    Castle.ThePlayer.ExitToRoom = RoomType.EntranceFoyer;
                }
                else
                {
                    Screen.Write("The pattern in the rug underneath you swirls into a deadly black hole that sucks you into another dimension.  A dimension without air.  You die.");
                    Castle.ThePlayer.Die();
                }
            }
        }
    }
}
