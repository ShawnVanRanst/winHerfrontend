using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Game
    {
        private int _scoreYou;

        public int ScoreYou
        {
            get { return _scoreYou; }
            set { _scoreYou = value; }
        }

        private int _scoreNeigbour;

        public int ScoreNeigbour
        {
            get { return _scoreNeigbour; }
            set { _scoreNeigbour = value; }
        }

        private string _youSymbol;

        public string YouSymbol
        {
            get { return _youSymbol; }
            set { _youSymbol = value; }
        }

        private string _neigbourSymbol;

        public string NeigbourSymbol
        {
            get { return _neigbourSymbol; }
            set { _neigbourSymbol = value; }
        }

        private int _move;

        public int Move
        {
            get { return _move; }
            set { _move = value; }
        }

        private string[,] _board;

        public string[,] Board
        {
            get { return _board; }
            set { _board = value; }
        }

        private string _userOnMove;

        public string UserOnMove
        {
            get { return _userOnMove; }
            set { _userOnMove = value; }
        }

        public string GetUserOnMoveSymbol()
        {
            if(UserOnMove == "You")
            {
                return YouSymbol;
            }
            else
            {
                return NeigbourSymbol;
            }
        }

        public void ChangeUserOnMove()
        {
            if (UserOnMove == "You")
            {
                UserOnMove = "Neigbour";
            }
            else
            {
                UserOnMove = "You";
            }
        }
    }
}
