﻿using System;
using System.Collections.Generic;
using AIGame.AI;
using AIGame.CoreGame.Orders;

namespace AIGame.CoreGame
{
    public class Game
    {
        public int Turn;
        public int MaxTurn = 100;
        public Map Map;
        public List<Unit> Units;
        public bool GameEnded = false;

        public Game(IAiType blue, IAiType red,int xSize,int ySize,Random rnd)
        {
            Map = new Map(xSize, ySize, rnd);

            Units = new List<Unit>();

            Units.Add(new Unit("A", Side.Blue, blue.GetAi(), Map.GetValidStartPosition(Units)));
            Units.Add(new Unit("X", Side.Red, red.GetAi(), Map.GetValidStartPosition(Units)));
            Units.Add(new Unit("B", Side.Blue, blue.GetAi(), Map.GetValidStartPosition(Units)));
            Units.Add(new Unit("Y", Side.Red, red.GetAi(), Map.GetValidStartPosition(Units)));
        }
        public void PlayUntilEnd()
        {
            for (int i=0;i >MaxTurn;i++)
            {
                NextTurn();
                if (IsGameEnded())
                    break;

            }
        }

        private bool IsGameEnded()
        {

            //No more units

            //Only one type of units

            //Max turns

            return false;
        }

        public void NextTurn()
        {
            foreach(Unit unit in Units)
            {
                unit.UpdateSensor(Map);
                IOrder order = unit.GetOrder();
                if (order.IsValid(unit, Map))
                { 
                    order.Execute(unit, Map);
                }
            }
            Turn++;   
        }
        public void Render()
        {
            RenderBoard();
        }
        private void RenderBoard()
        {
            
            for (int x = 0; x <= Map.XSize; x++)
            {
                string line = "";    
                for (int y = 0; y <= Map.YSize; y++)
                {
                    line += RenderCoordinate(x, y);
                }
                Console.WriteLine(line);
            }
            Console.WriteLine("Turn:" + Turn);
        }
        private string RenderCoordinate(int x, int y)
        {
            foreach(Unit unit in Units)
            {
                if (unit.Coordinates.Equals( new Tuple<int, int>(x, y)))
                    return unit.Name;
            }
            return Map.Terrain[x, y].Render();
        }


    }
}
