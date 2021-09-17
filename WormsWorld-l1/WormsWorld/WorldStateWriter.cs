using System;
using System.IO;

namespace WormsWorld
{
    public class WorldStateWriter
    {
        private const string fileName = "Worms_1.txt";

        public static void writeNewState(string info)
        {
            Console.Write(info);
            using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, fileName),
                true, System.Text.Encoding.Default))
            {
                sw.WriteAsync(info);
            }
        }
    }
}