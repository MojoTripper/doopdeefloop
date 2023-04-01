namespace doopdeefloop
{
    public class Staff : Item
    {
        public Staff ()
        {
            Type = ItemType.Staff;
            Name = "staff";
            Description = "long iron staff";
            Origin = RoomType.ThroneRoom;
        }
    }
}
