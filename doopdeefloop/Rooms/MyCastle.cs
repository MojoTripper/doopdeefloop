using System.Collections.Generic;
using doopdeefloop.Rooms;
using System;
using System.Threading;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class represents our castle.
    public class MyCastle : Castle
    {
        public MyCastle ()
        {
            AddRoom(new EntranceFoyerRoom());
            AddRoom(new MainHallRoom());
            AddRoom(new ThroneRoom());
            AddRoom(new Dungeon());
            AddRoom(new Kitchen());
            AddRoom(new Gallery());

            Enter(RoomType.EntranceFoyer);
        }
    }
}
