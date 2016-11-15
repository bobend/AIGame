﻿using System;

namespace AIGame.CoreGame.Orders
{
    public class Rotate : IOrder
    {
        public RotateDirection RotateDirection;

        public Rotate (RotateDirection rotateDirection)
        {
            RotateDirection = rotateDirection;
        }
        public OrderType Type()
        {
            return OrderType.Turn;
        }


        public void Execute(Unit unit, Map map)
        {
            int rotateInt;

            if (RotateDirection == RotateDirection.Left)
            { 
                rotateInt = -1;
            }
            else
            {
                rotateInt = 1;
            }

            int directionInt = unit.Facing.GetHashCode() + rotateInt;

            Direction direction;
            switch (directionInt)
            {
                case -1:
                    direction = Direction.East;
                    break;
                case 4:
                    direction = Direction.North;
                    break;
                default:
                    direction = (Direction) directionInt;
                    break;
            }
            unit.Facing = direction;
        }

        public bool IsValid(Unit unit, Map map)
        {
            return true;
        }
    }
}