﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIGame.AI;
using AIGame.CoreGame;

namespace AIGame.League
{
    public class League
    {
        private int gamesPerMatchUp=10000;
        private int redPoints = 0;
        private int bluePoints = 0;

        public void RunSingleMatchUp()
        {
            Random rnd = new Random(Environment.TickCount);

            IAiType blueAiType = new DoNothingAIType();
            blueAiType.SetRandomGenerator(rnd);
            IAiType redAiType = new SimpleAiType();
            redAiType.SetRandomGenerator(rnd);

            DateTime starTime = DateTime.Now;
            Console.Clear();
            Console.WriteLine("Running");
            for (int i = 0; i < gamesPerMatchUp; i++)
            {
                Game game = new Game(blueAiType, redAiType, 10, 10, rnd); ;

                game.PlayUntilEnd();

                UpdateScore(game);

                if(i % 1000 ==0)
                    Console.Write(".");
            }
            TimeSpan CalculationTime = DateTime.Now.Subtract(starTime);
            Console.WriteLine("Match ups: {0} Calculation time milliseconds:{1}", gamesPerMatchUp, CalculationTime.TotalMilliseconds);
            Console.WriteLine("Score results {2}(blue):{3} {0}(red):{1}", redAiType.Name,redPoints, blueAiType.Name,bluePoints);
            Console.ReadKey();
        }

        private void UpdateScore(Game game)
        {
            switch (game.GameResult)
            {
                case GameResult.RedWin:
                    redPoints += 2;
                    break;
                case GameResult.BlueWin:
                    bluePoints += 2;
                    break;
                case GameResult.Tie:
                    redPoints += 1;
                    bluePoints += 1;
                    break;
                default:
                    throw new Exception("Unknown result");
            }
        }
    }
}
