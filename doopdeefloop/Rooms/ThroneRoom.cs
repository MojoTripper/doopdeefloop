using doopdeefloop.Commands;

namespace doopdeefloop.Rooms
{
    public class ThroneRoom : Room
    {
        public ThroneRoom()
        {
            Name = "throne room";
            Description = "This is a small room with a throne at the back and lots of paintings on the walls.";
            RoomType = RoomType.ThroneRoom;

            Commands.Add(new LookAtLightBulb());
            Commands.Add(new StareAtWall());
            Commands.Add(new Exit ("south", RoomType.MainHall));
            Commands.Add(new Command("sit on throne", " this is so comfy I could sleep on it"));
            Commands.Add(new Command("look at throne", "it's almost entirely made of gold, the only thing that isn't is the cushion"));

            Inventory.Add(new Staff());
            Inventory.Add(new Amulet());

            Monsters.Add(new RugPython());
        }
    }
}
