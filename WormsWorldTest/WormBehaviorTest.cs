using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WormsWorld.entity;
using WormsWorld.wormBehaviour;

namespace WormsWorld
{
    [TestClass]

    public class WormBehaviorTest
    {
        private NameGenerator nameGenerator = new ();
        private const int Life = 10;

        [TestMethod]
        public void ClosestFoodLogic()
        {
            Dictionary<Position, int> food = new ();
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position,  Life);
            worms.Add(worm);
            food[new Position(0, 1)] = 10;
            food[new Position(0, 2)] = 10;
            food[new Position(1, 2)] = 10;
            food[new Position(2, 2)] = 10;
            Action action = worm.GetNextAction(food, worms);
            Assert.AreEqual(ActionType.Move, action.ActionType);
            Assert.AreEqual(StepDirection.Up, action.Direction);

        }
        
        
        [TestMethod]
        public void NoFoodLogic()
        {
            Dictionary<Position, int> food = new ();
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position,  Life);
            worms.Add(worm);
            Action action = worm.GetNextAction(food, worms);
            Assert.AreEqual(ActionType.NoAction, action.ActionType);
            Assert.AreEqual(StepDirection.NoDirection, action.Direction);
        }
    }
}