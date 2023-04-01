using System;

namespace doopdeefloop.Commands
{
    public class StareAtPainting : Command
    {
        public StareAtPainting() : base("stare at painting", "You stare at the painting.")
        {
            Repeatable = true;
            Outcome = DoAction;
        }

        public void DoAction()
        {
            Monster monster = Castle.ThePlayer.CurrentRoom.Monsters.Get(MonsterType.EvilPainting);
            if (monster != null)
            {
                monster.Attack();
            }
        }
    }
}
