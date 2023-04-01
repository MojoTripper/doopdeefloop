namespace doopdeefloop
{
    public class GlassOfWater : Item
    {
        public GlassOfWater()
        {
            Type = ItemType.GlassOfWater;
            Name = "dirty water";
            Description = "glass full of dirty water";
            Origin = RoomType.Kitchen;
            Use = new Commands.Use("drink", this) { Outcome = Drink };
        }

        public void Drink ()
        {
            Screen.Suspense();
            Screen.Write("Aw!  Gross!  You actually drank it?!  I didn't think you'd actually drink it!  Aw, man ... what a barbarian!  Who even drinks dirty water?  Predictably, you die of dirty water poisoning.");
            Castle.ThePlayer.Die();
        }
    }
}
