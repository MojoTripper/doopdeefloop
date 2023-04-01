namespace doopdeefloop
{
    public class FireDemon : Monster
    {
        public FireDemon()
        {
            Type = MonsterType.FireDemon;
            Name = "a fire demon";
            LiveDescription = "There is a fireplace in the north-east corner, in which a warm, cozy-looking fire is crackling invitingly.";
            DeadDescription = "There is a fireplace in the north-east corner, in which a pile of wet logs sit, steaming slightly.";
            Origin = RoomType.MainHall;
            Commands.Add(new Commands.WarmByFire ());
        }

        public override void Attack()
        {
            Screen.Suspense();
            if (!IsDead)
            {
                if (Castle.ThePlayer.Stuff.Has (ItemType.GlassOfWater))
                {
                    Castle.ThePlayer.Stuff.Remove(ItemType.GlassOfWater);
                    Screen.Suspense ("A fire demon rises from the flames and jump at you! Thinking quickly, you put him out by throwing the glass of dirty water on him. Whew! That was close!");
                    IsDead = true;
                }
                else
                {
                    Screen.Write("A fire demon rises from the flames and lights your hair on fire!  You forget to stop, drop and roll, and consequently you die.  Let that be a lesson to you kids.  Don't mess around with fire, and always remember to stop, drop and roll.");
                    Castle.ThePlayer.Die();
                }
            }
            else
            {
                Screen.Write("This fireplace isn't very warm or cozy without a fire.");
            }
        }
    }
}
