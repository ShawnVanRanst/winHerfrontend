using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.ViewModel.Passenger
{
    public class GameViewModel
    {
        public Game Game { get; set; }

        public GameViewModel()
        {
            CreateNewGame();
        }

        public string Play(string text)
        {
            int number = NumberTextToNumber(text);
            int row = number / 3;
            int col = number % 3;

            string symbol = Game.GetUserOnMoveSymbol();
            Game.Board[row, col] = symbol;
            Game.ChangeUserOnMove();
            return symbol;
        }

        private void RandomFirstMoveNewGame()
        {
            Random random = new Random();
            int number = random.Next(1, 2);
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
            Game.Board = new string[3,3];
        }

        private void CreateNewGame()
        {
            Game = new Game { ScoreNeigbour = 0, ScoreYou = 0 };
            RandomFirstMoveNewGame();
        }

        private int NumberTextToNumber(string number)
        {
            switch (number)
            {
                case "One": 
                    return 1;
                case "Two":
                    return 2;
                case "Three":
                    return 3;
                case "Four":
                    return 4;
                case "Five":
                    return 5;
                case "Six":
                    return 6;
                case "Seven":
                    return 7;
                case "Eight":
                    return 8;
                case "Nine":
                    return 9;
                default:
                    return 0;
            }
        }
    }
}
