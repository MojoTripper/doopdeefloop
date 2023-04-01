namespace doopdeefloop.Commands
{
    public class LieOnRug : Command
    {
        public LieOnRug()
            : base("lie on rug",
                   "Wow, this rug really ties the room together.")
        {
            Repeatable = true;
            Outcome = DoAction;
        }


        private void DoAction()
        {
            var monster = Castle.ThePlayer.CurrentRoom.Monsters.Get(MonsterType.BlackHole);
            if (monster != null)
            {
                monster.Attack();
            }

            monster = Castle.ThePlayer.CurrentRoom.Monsters.Get(MonsterType.RugPython);
            if (monster != null)
            {
                monster.Attack();
            }
        }
    }
}
