using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using WormsWorld.entity;
using WormsWorld.wormBehaviour;
using Action = WormsWorld.wormBehaviour.Action;

namespace WormsWorld
{
    public class Simulator
    {
        private ActionPerformer actionPerformer;
        private FoodGenerator foodGenerator;
        private NameGenerator nameGenerator;
        private WorldStateWriter stateWriter;
        private const int StepNum = 10;
        private const int StepSize = 1;
        private const int FoodSaturability = 10;
        private const int BaseLifeStrength = 10;

        public Simulator(ActionPerformer actionPerformer, FoodGenerator foodGenerator, NameGenerator nameGenerator,
            WorldStateWriter stateWriter)
        {
            this.actionPerformer = actionPerformer;
            this.foodGenerator = foodGenerator;
            this.nameGenerator = nameGenerator;
            this.stateWriter = stateWriter;
        }

        public void DoWork()
        {
            NextPositionGetter nextPositionGetter = new NextPositionGetter(StepSize);

            Dictionary<Position, int> food = new Dictionary<Position, int>();
            List<Worm> worms = new List<Worm>();
            worms.Add(new Worm(nameGenerator.GetNewName(), new Position(0, 0), BaseLifeStrength));
            string wormsStart = "";

            foreach (var worm in worms)
            {
                wormsStart += worm;
            }

            WriteStartState(wormsStart);

            for (int i = 0; i < StepNum; i++)
            {
                string foodBeforeStr = "";
                string foodAfterStr = "";
                string wormsStr = "";
                foreach (var kvp in food)
                {
                    food[kvp.Key]--;
                    foodBeforeStr += $"({kvp.Key.X.ToString()},{kvp.Key.Y.ToString()},{kvp.Value.ToString()}) ";
                    if (kvp.Value == 0)
                    {
                        food.Remove(kvp.Key);
                    }
                }

                Position newFoodPosition = foodGenerator.GetNewFoodPosition(food);
                food.Add(newFoodPosition, FoodSaturability);
                foodBeforeStr +=
                    $"({newFoodPosition.X.ToString()},{newFoodPosition.Y.ToString()},{food[newFoodPosition].ToString()}) ";

                foreach (var worm in new List<Worm>(worms))
                {
                    Action action = worm.GetNextAction(food, worms);
                    actionPerformer.PerformAction(action, nextPositionGetter, nameGenerator, worm, worms, BaseLifeStrength, food,
                        FoodSaturability);
                    if (worm.LifeStrength == 0)
                    {
                        worms.Remove(worm);
                    }

                    wormsStr += worm;
                }

                foreach (var kvp in food)
                {
                    foodAfterStr += $"({kvp.Key.X.ToString()},{kvp.Key.Y.ToString()},{kvp.Value.ToString()}) ";
                }

                WriteNewState(i, foodBeforeStr, foodAfterStr, wormsStr);
            }
        }


        private void WriteNewState(int stateNum, string foodBefore, string foodAfter, string worms)
        {
            stateWriter.WriteNewState($"step {stateNum.ToString()}");
            stateWriter.WriteNewState($"StartFood:[{foodBefore}]");
            stateWriter.WriteNewState($"Worms:[{worms}]");
            stateWriter.WriteNewState($"EndFood:[{foodAfter}]\n");
        }

        private void WriteStartState(string worms)
        {
            stateWriter.WriteNewState($"start state");
            stateWriter.WriteNewState($"Worms:[{worms}]\n");
        }
    }
}