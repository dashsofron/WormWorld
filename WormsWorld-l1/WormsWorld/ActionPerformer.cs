using System;
using System.Collections.Generic;
using WormsWorld;
using WormsWorld.entity;
using WormsWorld.wormBehaviour;
using Action = WormsWorld.wormBehaviour.Action;

public class ActionPerformer
{
    public void PerformAction(
        Action action,
        PositionGet positionGet,
        NameGenerator nameGenerator,
        Worm worm,
        List<Worm> worms,
        int Step, // Step не используется
        int Life,
        Dictionary<Position, int> food,
        int FoodQuality // такое ощущение, что параметр отвечпет и за количество жизней прибавляемое к червяку и за срок годности еды
    )
    {
        TryToEat(worm, food, FoodQuality);
        Position newPosition = positionGet.GetNextPosition(worm.Position, action.Direction);
        if (PlaceIsEmpty(worms, newPosition))
        {
            switch (action.ActionType)
            {
                case ActionType.Move:
                    worm.Position = newPosition;
                    break;
                case ActionType.Split:
                    if (worm.LifeStrength > Life)
                    {
                        worms.Add(new Worm(nameGenerator.GetNewName(), newPosition, Life));
                    }

                    break;
                case ActionType.NoAction: break;
            }
        }

        worm.LifeStrength -= 1;
        TryToEat(worm, food, FoodQuality);
    }

    // параметр называется "качество еды", а 
    private static void TryToEat(Worm worm, Dictionary<Position, int> food, int FoodQuality)
    {
        if (food is null) return;
        if (food.ContainsKey(worm.Position))
        {
            worm.LifeStrength += FoodQuality;
            food.Remove(worm.Position);
        }
    }

    private static Boolean PlaceIsEmpty(List<Worm> worms, Position position)
    {
        foreach (var worm in worms)
        {
            if (worm.Position.Equals(position))
            {
                return false;
            }
        }

        return true;
    }
}