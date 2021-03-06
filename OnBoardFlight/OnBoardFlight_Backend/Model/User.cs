﻿using Microsoft.AspNetCore.Identity;
using OnBoardFlight.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight_Backend.Model
{
    public class User
    {

        #region Properties

        public int UserId{ get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Flight Flight{ get; set; }

        #endregion

        #region Constructors
        public User()
        {
        }

        public User(string login, Flight flight)
        {
            Login = login;
            Flight = flight;
        }

        #endregion
    }
}
