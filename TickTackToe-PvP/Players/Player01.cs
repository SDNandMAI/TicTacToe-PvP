using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe_PvP.Players
{
    public class Player01 : IPlayer
    {
        public string Name { get; private set; }

        public bool Turn { get; set; }

        public bool Winner { get; set; }

        public Player01()
        {
            this.Name = "Player01";
        }
    }
}
