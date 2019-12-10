using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardFlight.Model
{
    public class Orderline
    {

        public int Number { get; set; }

        public Product Product{ get; set; }

        public double TotalPrice { get; set; }
    }
}
