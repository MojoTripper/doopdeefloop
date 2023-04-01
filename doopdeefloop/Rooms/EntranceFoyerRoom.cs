using doopdeefloop.Commands;

namespace doopdeefloop.Rooms
{
    public class EntranceFoyerRoom : Room
    {
        public EntranceFoyerRoom ()
        {
            Name = "entrance foyer";
            Description = "It is a big room.  There is a big rug in the middle of the room and a single light bulb hanging from the ceiling.";
            RoomType = RoomType.EntranceFoyer;

            Commands.Add(new LookAtLightBulb());
            Commands.Add(new StareAtWall());
            Commands.Add(new LieOnRug());
            Commands.Add(new Exit ("north", RoomType.MainHall));

            Inventory.Add(new Rock());

            Monsters.Add(new DemonDog());
            Monsters.Add(new Slime());
        }
    }
}
