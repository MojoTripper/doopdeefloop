using doopdeefloop.Commands;

namespace doopdeefloop.Rooms
{
    public class Kitchen : Room
    {
        public Kitchen()
        {
            Name = "kitchen";
            Description = "You enter a kitchen.  There is a dirty sink and a broken refrigerator.";
            RoomType = RoomType.Kitchen;

            Commands.Add(new LookAtLightBulb());
            Commands.Add(new StareAtWall());
            Commands.Add(new LieOnRug());
            Commands.Add(new Exit("west", RoomType.MainHall));

            Inventory.Add(new GlassOfWater());
            Inventory.Add(new Spoon());
            Inventory.Add(new SaltyChicken());
        }
    }
}
