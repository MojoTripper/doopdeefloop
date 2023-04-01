using System;
using System.Text;
using System.Threading;
using System.Linq;

//-----------------------------------------------------------------------------
namespace doopdeefloop
{
    // This is a simple class to make it more convenient to print messages to
    // the screen and ask for input from the player.
    public static class Screen
    {
        private static int Columns = 70;

        public static void Clear (string message)
        {
            Console.Clear();
            Write(message);
        }

        public static void Write (string message, bool format = true)
        {
            if (format)
            {
                var lines = message.Split(Environment.NewLine
                                                     .ToCharArray ())
                                   .Where (x => !string.IsNullOrWhiteSpace (x));
                var sb = new StringBuilder();
                foreach (string line in lines)
                {
                    sb.AppendLine (FormatString(line));
                }
                Console.WriteLine(sb.ToString () + Environment.NewLine);
            }
            else
            {
                Console.WriteLine(message);
            }
        }

        public static string Prompt (string message)
        {
            Write(message);
            Console.Write(">>>> ");
            return Console.ReadLine();
        }

        public static void Suspense(int count = 3)
        {
            for (int i = 0; i < count; ++i)
            {
                Thread.Sleep(500);
                Console.WriteLine(".");
            }
        }

        public static void Suspense(string message)
        {
            // Count the number of words in the message and do a suspense
            // count long enough to let a reasonably proficient player
            // read the words (where "reasonable" is uncomfortably close to
            // unreasonable for all values of reason.)
            var words = message.Split(' ');

            Screen.Write(message);

            var wait = words.Length * 50;
            for (int i = 0; i < 5; ++i)
            {
                Thread.Sleep(wait);
                Console.WriteLine(".");
            }
        }

        private static string FormatString (string message)
        {
            // Split up the lines into individual words
            var words = message.Split(' ');

            // Build the words into new lines of less than 80 characters
            // apiece
            var lines = words.Skip(1)
                             .Aggregate(words.Take(1).ToList(), (l, w) =>
            {
                if (l.Last().Length + w.Length >= Columns)
                    l.Add(w);
                else
                    l[l.Count - 1] += " " + w;
                return l;
            });

            // Return the collection of reformatted lines, joined together
            // by newlines.
            return string.Join(Environment.NewLine, lines.ToArray ());
        }
    }
}
