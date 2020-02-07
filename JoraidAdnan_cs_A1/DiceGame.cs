using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoraidAdnan_cs_A1
{
    class DiceGame
    {
        public int PlayerOneScore;
        public int PlayerTwoScore;
        public int TurnPoints;
        public int Counter;
        public bool IsJackpot;
        public int PlayerOneJackpotCount;
        public int PlayerTwoJackpotCount;
        List<int> PlayerOneJack = new List<int>();
        List<int> PlayerTwoJack = new List<int>();


        public List<int> Roll()
        {

            Random random = new Random();
            List<int> DiceValues = new List<int>();
            for (int RandomDice = 0; RandomDice < 2; RandomDice++)
                DiceValues.Add(random.Next(1, 7));

            GameCalculations(DiceValues);
            return DiceValues;
        }

        public bool IsTie()
        {
            return PlayerOneScore == PlayerTwoScore;
        }

        public bool IsWinner()
        {
            return PlayerOneScore > PlayerTwoScore;
        }

        public void GameCalculations(List<int> DiceValues)
        {

            if (DiceValues[0] == DiceValues[1] && DiceValues[0] == 6)
            {

                if (Counter % 2 == 0)
                {

                    PlayerOneJack.Add(1);

                    if (IsPlayerOneJackpot())
                    {
                        PlayerOneJackpotCount += 1;
                        TurnPoints = 200;
                        PlayerOneScore += TurnPoints;
                    }
                    else
                    {
                        TurnPoints = 100;
                        PlayerOneScore += TurnPoints;
                    }

                }
                else
                {

                    PlayerTwoJack.Add(1);

                    if (IsPlayerTwoJackpot())
                    {
                        PlayerTwoJackpotCount += 1;
                        TurnPoints = 200;
                        PlayerTwoScore += TurnPoints;
                    }
                    else
                    {
                        TurnPoints = 100;
                        PlayerTwoScore += TurnPoints;
                    }

                }
            }

            else if (DiceValues[0] == DiceValues[1] && DiceValues[0] != 6)
            {
                if (Counter % 2 == 0)
                {
                    PlayerOneJack.Add(0);
                    TurnPoints = DiceValues[0] * 10;
                    PlayerOneScore += TurnPoints;
                }
                else
                {
                    PlayerTwoJack.Add(0);
                    TurnPoints = DiceValues[0] * 10;
                    PlayerTwoScore += TurnPoints;
                }

            }
            else
            {
                TurnPoints = 0;
            }

        }

        public bool IsPlayerOneJackpot()
        {
            if (!PlayerOneGameOver())
            {
                if (PlayerOneJack.Count > 1)
                {

                    return PlayerOneJack[PlayerOneJack.Count - 1] == PlayerOneJack[PlayerOneJack.Count - 2] && PlayerOneJack[PlayerOneJack.Count - 1] == 1;

                }

            }
            return false;

        }

        public bool IsPlayerTwoJackpot()
        {
            if (!PlayerTwoGameOver())
            {
                if (PlayerTwoJack.Count > 1)
                {

                    return PlayerTwoJack[PlayerTwoJack.Count - 1] == PlayerTwoJack[PlayerTwoJack.Count - 2] && PlayerTwoJack[PlayerTwoJack.Count - 1] == 1;

                }

            }
            return false;
        }



        public bool PlayerOneGameOver()
        {
            if (PlayerOneJack.Count > 2)
            {
                return PlayerOneJack[PlayerOneJack.Count - 1] == PlayerOneJack[PlayerOneJack.Count - 2] && PlayerOneJack[PlayerOneJack.Count - 2] == PlayerOneJack[PlayerOneJack.Count - 3] && PlayerOneJack[PlayerOneJack.Count - 1] == 1;
            }
            return false;
        }



        public bool PlayerTwoGameOver()
        {
            if (PlayerTwoJack.Count > 2)
            {
                return PlayerTwoJack[PlayerTwoJack.Count - 1] == PlayerTwoJack[PlayerTwoJack.Count - 2] && PlayerTwoJack[PlayerTwoJack.Count - 2] == PlayerTwoJack[PlayerTwoJack.Count - 3] && PlayerTwoJack[PlayerTwoJack.Count - 1] == 1;
            }
            return false;
        }


    }
}
