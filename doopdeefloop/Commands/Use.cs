namespace doopdeefloop.Commands
{
    public class Use : Command
    {
        public Use (string verb, Item item) 
            : base(verb + " the " + item.Name, "You " + verb + " the " + item.Description)
        {
            Repeatable = true;
        }
    }
}
