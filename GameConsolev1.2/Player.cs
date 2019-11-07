using System;
using System.Collections.Generic;
using System.Text;

namespace GameConsolev1._2
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }


        public override string ToString()
        {
            return String.Format("Name: {0}  Score: {1}", this.Name, this.Score);
        }

    }
}
