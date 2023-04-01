using doopdeefloop.Commands;

namespace doopdeefloop.Rooms
{
    public class Gallery : Room
    {
        public Gallery()
        {
            Name = "gallery";
            Description = "You enter the gallery.  There are games all over and painting on every wall.";
            RoomType = RoomType.Gallery;

            Commands.Add(new LookAtLightBulb());
            Commands.Add(new StareAtWall());
            Commands.Add(new Exit ("east", RoomType.MainHall));

            Inventory.Add(new Mirror());

            Monsters.Add(new BlackHole());
            Monsters.Add(new EvilPainting());
        }
    }
}
