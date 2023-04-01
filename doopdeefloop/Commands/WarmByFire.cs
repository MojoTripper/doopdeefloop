using System;

namespace doopdeefloop.Commands
{
    public class WarmByFire : Command
    {
        public WarmByFire() : base("get warm by fire", "This fire makes the room super cozy!")
        {
            Repeatable = true;
            Outcome = DoAction;
        }

        private void DoAction()
        {
            Monster monster = Castle.ThePlayer.CurrentRoom.Monsters.Get(MonsterType.FireDemon);
            if (monster != null)
            {
                monster.Attack();
            }
        }
    }
}
