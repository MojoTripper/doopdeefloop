//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class is a more specific KIND OF CommandInventory that we are 
    // going to use to keep track of the Monsters in a room.
    public class RoomMonsters : CommandInventory<MonsterType, Monster>
    {
        // We want to override the Add VERB to make sure that, any time a 
        // Monster is added to a room, all its actions are added to that
        // room as well.
        public override void Add (Monster monster)
        {
            base.Add(monster);

            foreach (Command c in monster.Commands)
            {
                Commands.Add(c);
            }
        }

        // We want to override the Remove VERB to make sure that, any time a 
        // Monster is removed from a room, all its actions are removed from 
        // that room as well.
        public override void Remove(Monster monster)
        {
            base.Remove(monster);

            foreach (Command c in monster.Commands)
            {
                Commands.Remove(c);
            }
        }
    }
}
