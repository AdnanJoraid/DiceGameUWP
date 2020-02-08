using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JoraidAdnan_cs_A1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DiceGame _diceGame = new DiceGame(); // instance of class DiceGame

        int Count; //var of type int that will count how many times the user clicked the roll button
        public MainPage()
        {
            // initializing the program/interface with thesee data
            this.InitializeComponent();
            RollButton.Content = "Roll (Player 1)";
            P1Score.Text = "Player One Score: 0";
            P2Score.Text = "Player Two Score: 0";
            TurnScore.Text = "Turn Score: 0";
            P1Jackpot.Text = $"Player 1 consecutive Jackpots count: 0";
            P2Jackpot.Text = $"Player 2 consecutive Jackpots count: 0";
            RollsLeft.Text = $"Rolls left: {(10 - Count)}";

        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> DiceValues = _diceGame.Roll();


            Count++; // counts how many times the user clicked the button roll 
            _diceGame.Counter = Count; // passing the count to the DiceGame class
            if (Count != 10) // if the count is not 10 -> if count is equal to 10 the game will be over
            {

                if (Count % 2 == 0) // if player one
                {
                    RollButton.Content = "Roll (Player 1)";
                    TurnScore.Text = $"Turn Score: {_diceGame.TurnPoints}";
                    P1Score.Text = $"Player One Score: {_diceGame.PlayerOneScore}";
                    P1Jackpot.Text = $"Player 1 consecutive Jackpots count: {_diceGame.PlayerOneJackpotCount}";
                    LeftDice.Text = DiceValues[0].ToString();
                    RightDice.Text = DiceValues[1].ToString();
                    RollsLeft.Text = $"Rolls left: {(10 - Count)}";

                    if (_diceGame.IsPlayerOneJackpot())
                    {
                        // display a message when player one gets two consecutive jackpots
                        MessageDialog GameOverMessage = new MessageDialog("Player One Got two consecutive jackpots!!!"); //game over message
                        GameOverMessage.ShowAsync(); // display the message ie. input


                    }
                    else if (_diceGame.PlayerOneGameOver())
                    {
                        // display a messaage when player one gets three consecutive jackpots -> game over
                        MessageDialog GameOverMessage = new MessageDialog("Game over. Player One Got three consecutive jackpots!!!"); //game over message
                        GameOverMessage.ShowAsync(); // display the message ie. input
                        EndGame(); // calling the method EndGame() which will reset the interfaces (dice, score, etc..) to normal

                    }

                }

                else if (Count % 2 == 1) // if player two turn
                {
                    RollButton.Content = "Roll (Player 2)";
                    TurnScore.Text = $"Turn Score: {_diceGame.TurnPoints}";
                    P2Score.Text = $"Player Two Score: {_diceGame.PlayerTwoScore}";
                    P2Jackpot.Text = $"Player 2 consecutive Jackpots count: {_diceGame.PlayerTwoJackpotCount}";
                    LeftDice.Text = DiceValues[0].ToString();
                    RightDice.Text = DiceValues[1].ToString();
                    RollsLeft.Text = $"Rolls left: {(10 - Count)}";

                    if (_diceGame.IsPlayerTwoJackpot()) //display jackpot message
                    {
                        MessageDialog GameOverMessage = new MessageDialog("Player Two Got two consecutive jackpots!!!"); //game over message
                        GameOverMessage.ShowAsync(); // display the message ie. input


                    }
                    else if (_diceGame.PlayerTwoGameOver()) //display gameover message due to getting three consecutive jackpots
                    {
                        MessageDialog GameOverMessage = new MessageDialog("Game over. Player Two Got three consecutive jackpots!!!"); //game over message
                        GameOverMessage.ShowAsync(); // display the message ie. input
                        _diceGame = new DiceGame();
                        EndGame();

                    }

                }

            }
            if (Count == 10) // if the count of rolling the dice is 10 -> end the game
            {
                EndGame();

            }




        }

        public void EndGame()
        {
            if (_diceGame.IsWinner()) // display the winner message
            {
                MessageDialog GameOverMessage = new MessageDialog($"Game Over. The Winner is Player One with the overall score {_diceGame.PlayerOneScore}");
                GameOverMessage.ShowAsync();
            }
            else if (!_diceGame.IsWinner() && !_diceGame.IsTie()) //displays a message if player two won 
            {
                MessageDialog GameOverMessage = new MessageDialog($"Game Over. The Winner is Player Two with the overall score {_diceGame.PlayerTwoScore}");
                GameOverMessage.ShowAsync();
            }
            else if (_diceGame.IsTie()) // displays the tie messsage
            {
                MessageDialog GameOverMessage = new MessageDialog($"Game Over. No winner 'TIE' Player one score is: {_diceGame.PlayerOneScore}, player two score is: {_diceGame.PlayerTwoScore}");
                GameOverMessage.ShowAsync();
            }

            _diceGame = new DiceGame(); //create a new instance for new data 
            Count = 0; // reset the counter to 0, so the user can restart the game. 

            LeftDice.Text = "1";
            RightDice.Text = "1";
            P1Score.Text = "Player One Score: 0";
            P2Score.Text = "Player Two Score: 0";
            RollButton.Content = "Roll (Player 1)";
            TurnScore.Text = "Turn Score: 0";
            P1Jackpot.Text = $"Player 1 consecutive Jackpots count: 0";
            P2Jackpot.Text = $"Player 2 consecutive Jackpots count: 0";
            RollsLeft.Text = $"Rolls left: {(10 - Count)}";
        }
    
    }
}
