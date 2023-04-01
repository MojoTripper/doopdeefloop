namespace doopdeefloop
{
    public class EvilPainting : Monster
    {
        public EvilPainting()
        {
            Type = MonsterType.EvilPainting;
            Name = "evil painting";
            LiveDescription = "There is one painting whose eyes seem to follow you as you move around.";
            DeadDescription = "There is one painting that is all melted and blackened, as though somebody once set fire to it.";
            Origin = RoomType.Gallery;

            Commands.Add(Stare);
        }

        public override void Attack()
        {
            if (!IsDead)
            {
                ++lookCount;
                if (lookCount > 2)
                {
                    Screen.Suspense();
                    if (Castle.ThePlayer.Stuff.Has (ItemType.Mirror))
                    {
                        Screen.Suspense ("The painting has has enough of your shenanigans.  It bellows \"Are you lookin' at me?!\" and proceeds to TRY to melt your face off with its heat vision!  But, thinking fast, you hold up you mirror, and the painting gets melted instead!");
                        IsDead = true;
                    }
                    else
                    {
                        Screen.Write("The painting has has enough of your shenanigans.  It bellows \"Are you lookin' at me?!\" and proceeds to melt your face off with its heat vision!");
                        Castle.ThePlayer.Die();
                    }
                    lookCount = 0;
                }
                else
                {
                    Screen.Write("The painting stares back.");
                }
            }
            else
            {
                Screen.Write("It looks a little melted and blackened.");
            }
        }

        private Commands.StareAtPainting Stare = new Commands.StareAtPainting();
        private int lookCount = 0;
    }
}
