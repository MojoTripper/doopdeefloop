using System;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class represents a Command the player can give.
    //
    // Important OOP characteristics of a Command:
    //
    // * It HAS a special command Key that uniquely identifies it, Response 
    //   text that gets printed when it executes, a Repeatable flag that 
    //   tells if it can be done multiple times, and an Outcome action that
    //   gets executed after it happens.

    // * It CAN DO things like Execute (meaning it runs) or it can hold the
    //   player in Suspense.
    //
    public class Command
    {
        //---------------------------------------------------------------------
        // This is a special method that sets up the Command when it is first
        // used.
        #region CONSTRUCTOR

        public Command (string key, string response)
        {
            Key = key;
            Response = response;
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists VERBS the Command CAN DO
        #region VERBS

        public void Execute ()
        {
            // Write the response for this command to the screen.
            Screen.Write (Response);

            // If there is an outcome to run, do that now!
            if (Outcome != null) Outcome();
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things the Command HAS.  We are going to make 
        // them all "public" so that the rest of the world can use them.
        #region PROPERTIES

        public string Key { get; private set; }
        public string Response { get; set; }
        public bool Repeatable { get; set; }
        public Action Outcome { get; set; }

        #endregion
    }
}
