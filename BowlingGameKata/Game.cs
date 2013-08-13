using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class BowlingGame
    {
        List<int> roll = new List<int>();
        int frameCount = 1;
        int turnCount = 0;
        int maxTurn = 2;

        public void Turn(int pins)
        {
            roll.Add(pins);

            if (turnCount == maxTurn)
            {
                if (frameCount < 10)
                {
                    frameCount++;
                    turnCount = 0;
                }
            }
            turnCount++;

            if (pins == 10)
            {
                turnCount = maxTurn;
            }
        }
        public int ScoreGame()
        {
            int turnIndex = 0;
            int scoreFrame = 0;
            for (int frame = 0; frame < frameCount; frame++)
            {
                
                try
                {
                    //strike case
                    if (roll[turnIndex] == 10)
                    {
                        scoreFrame += 10 + roll[turnIndex + 1] + roll[turnIndex + 2];
                        turnIndex++;
                    }
                    //spare case
                    else if (roll[turnIndex] + roll[turnIndex + 1] == 10)
                    {
                        scoreFrame += 10 + roll[turnIndex + 2];
                        turnIndex += 2;
                    }
                    //normal case
                    else //if (roll[turnIndex] + roll[turnIndex + 1] != 10)
                    {
                        scoreFrame += roll[turnIndex] + roll[turnIndex + 1];
                        turnIndex += 2;
                    }
                }
                catch { }
            }
            return scoreFrame;
        }
    }
}