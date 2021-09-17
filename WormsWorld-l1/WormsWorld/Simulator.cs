using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WormsWorld
{
    public class Simulator
    {
        private const int StepNum = 100;
        private const int step = 1;

        static void Main(string[] args)
        {
            List<Worm> _worms = new List<Worm>();
            _worms.Add(new Worm("first", new Position(0, 0), step));


            for (int i = 0; i < StepNum; i++)
            {
                string step_out = string.Format("step {0}\nWorms:[", i);

                for (int j = 0; j < _worms.Count; j++)
                {
                    _worms[j].SetNextPosition();
                    if (j != 0)
                        step_out += ',';
                    step_out += _worms[j];
                }

                step_out += "]\n";
                WorldStateWriter.writeNewState(step_out);
            }
        }
    }
}