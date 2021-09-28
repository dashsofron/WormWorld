using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WormsWorld.entity;
using WormsWorld.wormBehaviour;
using Action = WormsWorld.wormBehaviour.Action;

namespace WormsWorld
{
    public class Simulator
    {
        private const int StepNum = 10;
        private const int Step = 1;
        private const int FoodQuality = 10;
        private const int Life = 10;

        static void Main(string[] args)
        {
            PositionGet positionGet = new PositionGet(Step);
            NameGenerator nameGenerator = new NameGenerator();

            Dictionary<Position, int> food = new Dictionary<Position, int>();
            List<Worm> worms = new List<Worm>();
            worms.Add(new Worm(nameGenerator.GetNewName(), new Position(0, 0), Step, Life));
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

                Position newFoodPosition = FoodGenerator.GetNewFoodPosition(food);
                food.Add(newFoodPosition, FoodQuality);
                foodBeforeStr +=
                    $"({newFoodPosition.X.ToString()},{newFoodPosition.Y.ToString()},{food[newFoodPosition].ToString()}) ";
                
                foreach (var worm in new List<Worm>(worms))
                {
                    TryToEat(worm, food);
                    Action action = worm.GetNextAction(food, worms);
                    PerformAction(action, positionGet, nameGenerator, worm, worms);
                    wormsStr += worm;
                    if (worm.Life == 0)
                    {
                        worms.Remove(worm);
                    }
                }

                foreach (var kvp in food)
                {
                    foodAfterStr += $"({kvp.Key.X.ToString()},{kvp.Key.Y.ToString()},{kvp.Value.ToString()}) ";
                }

                WriteNewState(i, foodBeforeStr, foodAfterStr, wormsStr);
            }
        }

        private static void TryToEat(Worm worm, Dictionary<Position, int> food)
        {
            if (food.ContainsKey(worm.Position))
            {
                worm.Life += FoodQuality;
                food.Remove(worm.Position);
            }
        }

        private static void PerformAction(
            Action action,
            PositionGet positionGet,
            NameGenerator nameGenerator,
            Worm worm,
            List<Worm> worms
        )
        {
            if (action.ActionType == ActionType.NoAction)
                return;
            Position newPosition = positionGet.GetNextPosition(worm.Position, action.Direction);
            if (PlaceIsEmpty(worms, worm.Position))
            {
                switch (action.ActionType)
                {
                    case ActionType.Move:
                        worm.Position = newPosition;
                        break;
                    case ActionType.Multiple:
                        if (worm.Life > Life)
                        {
                            worms.Add(new Worm(nameGenerator.GetNewName(), newPosition, Step, Life));
                            worm.Life -= Life;
                        }
                        break;
                    case ActionType.NoAction: break;
                }
            }

            worm.Life--;
        }

        private static void WriteNewState(int stateNum, string foodBefore, string foodAfter, string worms)
        {
            WorldStateWriter.WriteNewState($"step {stateNum.ToString()}");
            WorldStateWriter.WriteNewState($"StartFood:[{foodBefore}]");
            WorldStateWriter.WriteNewState($"Worms:[{worms}]");
            WorldStateWriter.WriteNewState($"EndFood:[{foodAfter}]\n");
        }

        private static void WriteStartState(string worms)
        {
            WorldStateWriter.WriteNewState($"start state");
            WorldStateWriter.WriteNewState($"Worms:[{worms}]\n");
        }

        private static Boolean PlaceIsEmpty(List<Worm> worms, Position position)
        {
            bool empty = false;
            foreach (var worm in worms)
            {
                if (worm.Position.Equals(position))
                {
                    empty = true;
                    break;
                }
            }

            return empty;
        }
    }
}