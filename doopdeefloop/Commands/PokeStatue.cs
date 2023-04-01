using System;
using System.Collections.Generic;
using System.Linq;
namespace doopdeefloop.Commands
{
    public class PokeStatue : Command
    {
        public PokeStatue()
            : base ("poke statue", "You poke the demon dog statue in the eye.")
        {
            Repeatable = true;
            Outcome = DoAction;
        }

        public void DoAction()
        {
            Monster monster = Castle.ThePlayer.CurrentRoom.Monsters.Get(MonsterType.DemonDog);
            if (monster != null)
            {
                monster.Attack();
            }
        }
    }
}
