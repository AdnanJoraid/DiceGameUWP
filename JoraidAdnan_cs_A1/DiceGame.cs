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
        public int PlayerOneJackpotCount;
        public int PlayerTwoJackpotCount;
        List<int> PlayerOneJack = new List<int>();
        List<int> PlayerTwoJack = new List<int>();


        
        public List<int> Roll()
        {
            // Creating a list that generate random numbers between 1 and 7
            Random random = new Random();
            List<int> DiceValues = new List<int>();
            for (int RandomDice = 0; RandomDice < 2; RandomDice++)
                DiceValues.Add(random.Next(1, 7));

            GameCalculations(DiceValues);
            return DiceValues;
        }

        // A bool method to check if player one tied with player two
        public bool IsTie()
        {
            return PlayerOneScore == PlayerTwoScore;
        }

        // method that return true if player one won and false otherwise
        public bool IsWinner()
        {
            return PlayerOneScore > PlayerTwoScore;
        }

        // contains the game calculations
        public void GameCalculations(List<int> DiceValues)
        {
            //if left dice is == right dice and they are equal to 6

            if (DiceValues[0] == DiceValues[1] && DiceValues[0] == 6)
            {
                // if the player count is even -> meaning that its player one turn
                if (Counter % 2 == 0)
                {
                    // adds one to a list that will check if there is a jackpot
                    PlayerOneJack.Add(1);

                    if (IsPlayerOneJackpot()) // if player one got double jackpot
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
                else // if the player count is odd -> meaning that it is player two turn
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

            else if (DiceValues[0] == DiceValues[1] && DiceValues[0] != 6) // if the dices are equal to each other but not equal to 6
            {
                if (Counter % 2 == 0) //p1
                {
                    PlayerOneJack.Add(0);
                    TurnPoints = DiceValues[0] * 10;
                    PlayerOneScore += TurnPoints;
                }
                else //p2
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
            if (!PlayerOneGameOver()) // checks if the user did not get triple jackpots -> which will result in ending the game
            {
                if (PlayerOneJack.Count > 1) //if the list length is more than one
                {
                    // if the first last index is equal to the second last index and they are equal to 6 -> double jackpot
                    return PlayerOneJack[PlayerOneJack.Count - 1] == PlayerOneJack[PlayerOneJack.Count - 2] && PlayerOneJack[PlayerOneJack.Count - 1] == 1;

                }

            }
            return false;

        }

        public bool IsPlayerTwoJackpot()
        {
            if (!PlayerTwoGameOver()) // same as the method above but for player two
            {
                if (PlayerTwoJack.Count > 1)
                {

                    return PlayerTwoJack[PlayerTwoJack.Count - 1] == PlayerTwoJack[PlayerTwoJack.Count - 2] && PlayerTwoJack[PlayerTwoJack.Count - 1] == 1;

                }

            }
            return false;
        }



        public bool PlayerOneGameOver() // meathod that checks if the game is over
        {
            if (PlayerOneJack.Count > 2) // if the list length is more than two
            {
                // if the first last index equal to the second last index which is also equal to the third last index -> triple jackpot and the player wins
                return PlayerOneJack[PlayerOneJack.Count - 1] == PlayerOneJack[PlayerOneJack.Count - 2] && PlayerOneJack[PlayerOneJack.Count - 2] == PlayerOneJack[PlayerOneJack.Count - 3] && PlayerOneJack[PlayerOneJack.Count - 1] == 1;
            }
            return false;
        }



        public bool PlayerTwoGameOver()
        {
            if (PlayerTwoJack.Count > 2)
            {
                // if the first last index equal to the second last index which is also equal to the third last index -> triple jackpot and the player wins
                return PlayerTwoJack[PlayerTwoJack.Count - 1] == PlayerTwoJack[PlayerTwoJack.Count - 2] && PlayerTwoJack[PlayerTwoJack.Count - 2] == PlayerTwoJack[PlayerTwoJack.Count - 3] && PlayerTwoJack[PlayerTwoJack.Count - 1] == 1;
            }
            return false;
        }


    }
}
