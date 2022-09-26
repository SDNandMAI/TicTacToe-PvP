using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe_PvP.Players
{
    public class Player02 : IPlayer
    {
        public string Name { get; private set; }

        public bool Turn { get; set; }

        public bool Winner { get; set; } = false;

        public int WinCount { get; set; } = 0;

        public string Marker { get; private set; }

        public Player02()
        {
            this.Name = "Player02";
            this.Marker = "O";
        }
    }
}
