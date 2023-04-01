using System.Collections.Generic;
using doopdeefloop.Rooms;
using System;
using System.Threading;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This class represents the Castle we will be adventuring in.
    //
    // Important OOP characteristics of a Castle:
    //
    // * It HAS a list of Rooms and a Player (that's you!)
    //
    // * It CAN DO things like adding rooms to itself.
    //
    public class Castle
    {
        //---------------------------------------------------------------------
        // This is a special method that sets up the castle when it is first
        // used.
        #region CONSTRUCTOR

        public Castle ()
        {
            Rooms = new Dictionary<RoomType, Room>();
            ThePlayer = new Player();
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things the Castle CAN DO
        #region VERBS

        // This VERB adds a room to the castle.
        public void AddRoom(Room r)
        {
            Rooms.Add (r.RoomType, r);
        }

        // This verb enters the castle at the specified room and starts 
        // the game.
        public void Enter (RoomType starting_room)
        {
            RoomType nextRoom = starting_room;
            while (!Castle.ThePlayer.IsDead)
            {
                nextRoom = Castle.ThePlayer.EnterRoom(nextRoom);
            }
            Screen.Write(Environment.NewLine + "Thanks for playing!");
            Thread.Sleep(5000);
        }

        #endregion

        //---------------------------------------------------------------------
        // This section contains the special verb Main, which is where our
        // program starts.
        #region MAIN

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            while (true)
            {
                Castle castle = new MyCastle();
            }
        }

        #endregion

        //---------------------------------------------------------------------
        // This section lists things the Castle HAS.  We are going to make them
        // all "public" so that the rest of the world can use them.
        #region PROPERTIES

        public static Dictionary<RoomType, Room> Rooms;
        public static Player ThePlayer;

        #endregion
    }
}
