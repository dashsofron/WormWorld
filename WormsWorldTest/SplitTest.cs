using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WormsWorld.entity;
using WormsWorld.wormBehaviour;

namespace WormsWorld
{
    [TestClass]
    public class SplitTest
    {
        private const int Step = 1;
        private const int FoodQuality = 10;
        private const int Life = 10;
        private NextPositionGetter _nextPositionGetter = new NextPositionGetter(Step);
        private ActionPerformer actionPerformer = new ActionPerformer();
        private NameGenerator nameGenerator = new NameGenerator();


        [TestMethod]
        public void SuccessSplitTest()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position, Life + 1);
            worms.Add(worm);
            actionPerformer.PerformAction(new Action(ActionType.Split, StepDirection.Up), _nextPositionGetter, nameGenerator,
                worm, worms, Life, null, FoodQuality);
            Assert.AreEqual(2, worms.Count);
            Assert.AreEqual(position, worms[0].Position);
            position.Y += 1;
            Assert.AreEqual(position, worms[1].Position);
        }

        [TestMethod]
        public void NotEnoughStrengthTest()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position, Life);
            worms.Add(worm);
            actionPerformer.PerformAction(new Action(ActionType.Split, StepDirection.Up), _nextPositionGetter, nameGenerator,
                worm, worms, Life, null, FoodQuality);
            Assert.AreEqual(1, worms.Count);
            Assert.AreEqual(position, worms[0].Position);
        }

        [TestMethod]
        public void NotEmptyPlace()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position, Life);
            Worm wormInNextPosition = new Worm(nameGenerator.GetNewName(), new Position(0, 1), Life);
            worms.Add(worm);
            worms.Add(wormInNextPosition);
            actionPerformer.PerformAction(new Action(ActionType.Split, StepDirection.Up), _nextPositionGetter, nameGenerator,
                worm, worms, Life, null, FoodQuality);
            Assert.AreEqual(2, worms.Count);
        }
    }
}