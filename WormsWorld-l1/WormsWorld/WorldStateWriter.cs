using System;
using System.IO;

namespace WormsWorld
{
    public class WorldStateWriter
    {
        private const string FileName = "Worms_1.txt";

        public static void WriteNewState(string info)
        {
            Console.WriteLine(info);
            using var sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, FileName),
                true, System.Text.Encoding.Default);
            sw.WriteLineAsync(info);
        }
    }
}