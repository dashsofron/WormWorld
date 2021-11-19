using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WormsWorld.entity;
using WormsWorld.wormBehaviour;

namespace WormsWorld
{
    [TestClass]
    public class MoveTest
    {
        private const int Step = 1;
        private const int FoodQuality = 10;
        private const int Life = 10;
        private NextPositionGetter _nextPositionGetter = new(Step);
        private ActionPerformer actionPerformer = new();
        private NameGenerator nameGenerator = new();


        [TestMethod]
        public void MovingToEmptyPlaceTest()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position, Life);
            worms.Add(worm);
            actionPerformer.PerformAction(new Action(ActionType.Move, StepDirection.Up), _nextPositionGetter, nameGenerator,
                worm, worms, Life, null, FoodQuality);
            position.Y += 1;//тут была пометка про конструктор
            Assert.AreEqual(position, worm.Position);
        }

        [TestMethod]
        public void MovingToPlaceWithFoodTest()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position, Life);
            Dictionary<Position, int> food = new Dictionary<Position, int>();
            food.Add(new Position(0, 1), FoodQuality);
            worms.Add(worm);

            actionPerformer.PerformAction(new Action(ActionType.Move, StepDirection.Up), _nextPositionGetter, nameGenerator,
                worm, worms, Life, food, FoodQuality);
            position.Y += 1;
            Assert.AreEqual(position, worm.Position);
            Assert.AreEqual(2 * Life - 1, worm.LifeStrength);
        }

        [TestMethod]
        public void MovingToPlaceWithWormTest()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position, Life);
            Worm wormInNextPosition = new Worm(nameGenerator.GetNewName(), new Position(0, 1), Life);
            worms.Add(worm);
            worms.Add(wormInNextPosition);

            actionPerformer.PerformAction(new Action(ActionType.Move, StepDirection.Up), _nextPositionGetter, nameGenerator,
                worm, worms, Life, null, FoodQuality);
            Assert.AreEqual(position, worm.Position);
        }

        [TestMethod]
        public void NoActionTest()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position, Life);
            worms.Add(worm);
            actionPerformer.PerformAction(
                new Action(ActionType.NoAction, StepDirection.NoDirection), 
                _nextPositionGetter, nameGenerator,
                worm, worms, Life, null, FoodQuality
                );
            Assert.AreEqual(position, worm.Position);
        }
    }
}