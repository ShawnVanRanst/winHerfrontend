using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace OnBoardFlight.Model
{
    public class Game : INotifyPropertyChanged
    {
        private int _scoreYou;

        public int ScoreYou
        {
            get { return _scoreYou; }
            set { _scoreYou = value; RaisePropertyChanged("ScoreYou"); }
        }

        private int _scoreNeigbour;

        public int ScoreNeigbour
        {
            get { return _scoreNeigbour; }
            set { _scoreNeigbour = value; RaisePropertyChanged("ScoreNeigbour"); }
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

        private string[][] _board;

        public string[][] Board
        {
            get { return _board; }
            set { _board = value; RaisePropertyChanged("Board"); }
        }

        private string _userOnMove;

        public string UserOnMove
        {
            get { return _userOnMove; }
            set { _userOnMove = value; RaisePropertyChanged("UserOnMove"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public void UpdateScoreWinner(string symbol)
        {
            if(YouSymbol == symbol)
            {
                ScoreYou++;
            }
            else
            {
                ScoreNeigbour++;
            }
        }
    }
}
