using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class CabinCrew: User
    {
        #region Properties
        
        #endregion

        #region Constructors

        public CabinCrew()
        {

        }

        public CabinCrew(string login, string password)
        {
            Login = login;
            Pass = password;
        }
        #endregion
    }
}