using doopdeefloop.Commands;

namespace doopdeefloop.Rooms
{
    public class MainHallRoom : Room
    {
        public MainHallRoom ()
        {
            Name = "main hall";
            Description = "You enter a normal hallway with doors all around.  There is a staircase in the middle leading down into the darkness.  There is a long rug running down the length of the hallway.  It looks kinda worn.";
            RoomType = RoomType.MainHall;

            Commands.Add(new LookAtLightBulb());
            Commands.Add(new StareAtWall());
            Commands.Add(new LieOnRug());
            Commands.Add(new Exit ("south", RoomType.EntranceFoyer));
            Commands.Add(new Exit("north", RoomType.ThroneRoom));
            Commands.Add(new Exit("east", RoomType.Kitchen));
            Commands.Add(new Exit("west", RoomType.Gallery));
            Commands.Add(new Exit("down", RoomType.Dungeon));

            Monsters.Add(new FireDemon());
        }
    }
}
