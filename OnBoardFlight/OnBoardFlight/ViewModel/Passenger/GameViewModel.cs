using OnBoardFlight.Model;
using OnBoardFlight.ViewModel.Commands.Passenger.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private Game _game;

        public Game Game
        {
            get { return _game; }
            set { _game = value; RaisePropertyChanged("Board"); }
        }

        public NewGameCommand NewGame { get; set; }

        public ResetGameCommand ResetGame { get; set; }

        public PlayMoveCommand PlayMove { get; set; }

    public GameViewModel()
        {
            Game = new Game() { Board = new string[][] { new string[] { "", "", "" }, new string[] { "", "", "" }, new string[] { "", "", "" } } };
            ResetGameScore();
            NewGame = new NewGameCommand(this);
            ResetGame = new ResetGameCommand(this);
            PlayMove = new PlayMoveCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Play(string text)
        {
            int number = NumberTextToNumber(text);
            int row = number / 3;
            int col = number % 3;

            string symbol = Game.GetUserOnMoveSymbol();
            Game.Board[row][col] = symbol;
            Game.ChangeUserOnMove();
            return symbol;
        }

        // Setup start new game (who begins, who has wich symbol
        public void RandomFirstMoveNewGame()
        {
            Random random = new Random();
            int number = random.Next(1, 3);
            if(number == 1)
            {
                Game.UserOnMove = "You";
                Game.YouSymbol = "O";
                Game.NeigbourSymbol = "X";
            }
            else
            {
                Game.UserOnMove = "Neigbour";
                Game.NeigbourSymbol = "O";
                Game.YouSymbol = "X";
            }
            Game.Move = 0;
            ResetBoard();
        }

        // Create new game
        public void ResetGameScore()
        {
            Game.ScoreYou = 0;
            Game.ScoreNeigbour = 0;
            RandomFirstMoveNewGame();
        }

        // Convert button string to number
        private int NumberTextToNumber(string number)
        {
            switch (number)
            {
                case "One": 
                    return 0;
                case "Two":
                    return 1;
                case "Three":
                    return 2;
                case "Four":
                    return 3;
                case "Five":
                    return 4;
                case "Six":
                    return 5;
                case "Seven":
                    return 6;
                case "Eight":
                    return 7;
                case "Nine":
                    return 8;
                default:
                    return 0;
            }
        }

        // Check if there is a winner, if there is one, update score, reset board and return true
        public bool CheckWinner()
        {
            string[][] board = Game.Board;
            if(board[0][0] == board[1][1] && board[1][1] == board[2][2] && board[0][0] != "?" && board[1][1] != "?" && board[2][2] != "?")
            {
                Game.UpdateScoreWinner(board[1][1]);
                RandomFirstMoveNewGame();
                return true;
            }
            if (board[0][2] == board[1][1] && board[1][1] == board[2][0] && board[1][1] != "?" && board[0][2] != "?" && board[2][0] != "?")
            {
                Game.UpdateScoreWinner(board[1][1]);
                RandomFirstMoveNewGame();
                return true;
            }
            for (int i = 0; i < 3; i++){
                if(board[0][i] == board[1][i] && board[1][i] == board[2][i] && board[1][i] != "?" && board[0][i] != "?" && board[2][i] != "?")
                {
                    Game.UpdateScoreWinner(board[1][i]);
                    RandomFirstMoveNewGame();
                    return true;
                }
                if (board[i][0] == board[i][1] && board[i][1] == board[i][2] && board[i][1] != "?" && board[i][0] != "?" && board[i][2] != "?")
                {
                    Game.UpdateScoreWinner(board[i][1]);
                    RandomFirstMoveNewGame();
                    return true;
                }
            }
            return false;
        }

        private void ResetBoard()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Game.Board[i][j] = "?";
                }
            }
        }
    }
}