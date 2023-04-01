using System;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // Here is a simple class to roll dice.  You just tell it what number
    // you want to roll under, out of 100, and it tells you succeeded or 
    // failed.
    public class PercentileDice
    {
        // This VERB rolls a 100-sided die and checks to see if the result is
        // lower than the value we ask for.
        public static bool RollUnder (int value)
        {
            return rng.Next () % 100 < value;
        }

        // We need a random number generator to roll our dice
        private static Random rng = new Random();
    }
}
