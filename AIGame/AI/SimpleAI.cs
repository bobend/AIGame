﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIGame.CoreGame;
using AIGame.CoreGame.Orders;

namespace AIGame.AI
{
    public class SimpleAiType : iAiType
    {
        public iAI GetAi()
        {
            return new SimpleAI();
        }
    }
    public class SimpleAI:iAI
    {
        public Sensor Sensor;
        public iOrder GetOrder(Sensor sensor,Unit unit)
        {
            Sensor = sensor;
            Move move = new Move();
            return move;
        }
        
    }

}
