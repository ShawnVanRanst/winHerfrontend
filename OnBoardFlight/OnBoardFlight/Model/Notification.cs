using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Notification
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _context;

        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }

        private bool _general;

        public bool General
        {
            get { return _general; }
            set { _general = value; }
        }

    }
}
