using System;
using doopdeefloop.Commands;

namespace doopdeefloop.Rooms
{
    public class Dungeon : Room
    {
        public Dungeon()
        {
            Name = "dungeon";
            Description = "You enter a dank dungeon.  There is a staircase leading up to the main hall.  There is a rug at the bottom of the stairs.  Really?  A rug down here?  Somebody really must have liked rugs.";
            RoomType = RoomType.Dungeon;

            Commands.Add(new LookAtLightBulb());
            Commands.Add(new StareAtWall());
            Commands.Add(new LieOnRug());
            Commands.Add(new Exit ("up", RoomType.MainHall));

            Monsters.Add(TrapDoor);
        }

        public override void OnEnter ()
        {
            TrapDoor.Attack ();
        }

        public override void OnDoStuff()
        {
            TrapDoor.Attack();
        }

        public override void OnExit()
        {
            TrapDoor.Attack();
        }

        private DungeonTrap TrapDoor = new DungeonTrap();

    }
}
