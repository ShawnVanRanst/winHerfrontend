using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model.Helper
{
    public class CabinCrewLogin : GeneralLogin, INotifyPropertyChanged
    {
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged("Password"); }
        }
    }
}
