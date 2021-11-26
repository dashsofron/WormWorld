using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WormsWorld.entity;
using WormsWorld.wormBehaviour;

namespace WormsWorld
{
    [TestClass]
    public class WormBehaviorTest
    {
        private NameGenerator nameGenerator = new();
        private const int Life = 10;

        [TestMethod]
        public void ClosestFoodUpLogic()
        {
            Dictionary<Position, int> food = new();
            List<Worm> worms = new List<Worm>();
            Worm worm = new Worm(nameGenerator.GetNewName(), new Position(0, 0), Life);
            worms.Add(worm);
            food[new Position(0, 1)] = 10;
            food[new Position(0, 2)] = 10;
            Action action = worm.GetNextAction(food, worms);
            Assert.AreEqual(ActionType.Move, action.ActionType);
            Assert.AreEqual(StepDirection.Up, action.Direction);
        }

        [TestMethod]
        public void ClosestFoodDownLogic()
        {
            Dictionary<Position, int> food = new();
            List<Worm> worms = new List<Worm>();
            Worm worm = new Worm(nameGenerator.GetNewName(), new Position(0, 0), Life);
            worms.Add(worm);
            food[new Position(0, -1)] = 10;
            food[new Position(0, 2)] = 10;
            Action action = worm.GetNextAction(food, worms);
            Assert.AreEqual(ActionType.Move, action.ActionType);
            Assert.AreEqual(StepDirection.Down, action.Direction);
        }

        [TestMethod]
        public void ClosestFoodRightLogic()
        {
            Dictionary<Position, int> food = new();
            List<Worm> worms = new List<Worm>();
            Worm worm = new Worm(nameGenerator.GetNewName(), new Position(0, 0), Life);
            worms.Add(worm);
            food[new Position(1, 0)] = 10;
            food[new Position(0, 2)] = 10;
            Action action = worm.GetNextAction(food, worms);
            Assert.AreEqual(ActionType.Move, action.ActionType);
            Assert.AreEqual(StepDirection.Right, action.Direction);
        }

        [TestMethod]
        public void ClosestFoodLeftLogic()
        {
            Dictionary<Position, int> food = new();
            List<Worm> worms = new List<Worm>();
            Worm worm = new Worm(nameGenerator.GetNewName(), new Position(0, 0), Life);
            worms.Add(worm);
            food[new Position(-1, 0)] = 10;
            food[new Position(0, 2)] = 10;
            Action action = worm.GetNextAction(food, worms);
            Assert.AreEqual(ActionType.Move, action.ActionType);
            Assert.AreEqual(StepDirection.Left, action.Direction);
        }


        [TestMethod]
        public void NoFoodLogic()
        {
            Dictionary<Position, int> food = new();
            List<Worm> worms = new List<Worm>();
            Worm worm = new Worm(nameGenerator.GetNewName(), new Position(0, 0), Life);
            worms.Add(worm);
            Action action = worm.GetNextAction(food, worms);
            Assert.AreEqual(ActionType.NoAction, action.ActionType);
            Assert.AreEqual(StepDirection.NoDirection, action.Direction);
        }
    }
}