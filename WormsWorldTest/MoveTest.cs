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
        private PositionGet positionGet = new(Step);
        private ActionPerformer actionPerformer = new ();
        private NameGenerator nameGenerator = new ();


        // тоже непонятное название,
        // как понимаю из теста он проверяет, что червяк сдвигается на 1 позицию вверх
        // если Action.Up и клетка пуста   
        [TestMethod]
        public void EmptyPlaceTest()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position,  Life);
            worms.Add(worm);
            actionPerformer.PerformAction(new Action(ActionType.Move, StepDirection.Up), positionGet, nameGenerator,
                worm, worms, Step, Life, null, FoodQuality);
            // можно сразу задать значение (0, 1) в конструкторе 
            position.Y += 1;
            Assert.AreEqual(position, worm.Position);
        }

        [TestMethod]
        public void FoodPlaceTest()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position, Life);
            Dictionary<Position, int> food = new Dictionary<Position, int>();
            food.Add(new Position(0, 1), FoodQuality);
            worms.Add(worm);

            actionPerformer.PerformAction(new Action(ActionType.Move, StepDirection.Up), positionGet, nameGenerator,
                worm, worms, Step, Life, food, FoodQuality);
            position.Y += 1;
            Assert.AreEqual(position, worm.Position);
            Assert.AreEqual(2 * Life - 1, worm.LifeStrength);
        }

        [TestMethod]
        public void WormPlaceTest()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position,  Life);
            Worm wormInNextPosition = new Worm(nameGenerator.GetNewName(), new Position(0, 1),  Life);
            worms.Add(worm);
            worms.Add(wormInNextPosition);

            actionPerformer.PerformAction(new Action(ActionType.Move, StepDirection.Up), positionGet, nameGenerator,
                worm, worms, Step, Life, null, FoodQuality);
            Assert.AreEqual(position, worm.Position);
        }
        
        
        // тест проходит, но в нем ошибка position.Y += 1;
        // в тесте червяк передвигается хотя должен остаться в позиции (0, 0)
        // что выявляет серьёзную ошибку в коде (Можно двигать червяка без его ведома).
        [TestMethod]
        public void NoActionTest()
        {
            List<Worm> worms = new List<Worm>();
            Position position = new Position(0, 0);
            Worm worm = new Worm(nameGenerator.GetNewName(), position,  Life);
            worms.Add(worm);
            actionPerformer.PerformAction(new Action(ActionType.NoAction, StepDirection.NoDirection), positionGet, nameGenerator,
                worm, worms, Step, Life, null, FoodQuality);
            position.Y += 1;
            Assert.AreEqual(position, worm.Position);
        }
    }
}