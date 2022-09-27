using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe_PvP.Players
{
    public class Player01 : IPlayer
    {
        public string Name { get; private set; }

        public bool Turn { get; set; } = true;

        public bool Winner { get; set; } = false;

        public int WinCount {get; set; } = 0;

        public string Marker { get; private set; }

        public Player01()
        {
            this.Name = "Player01";
            this.Marker = "X";
        }
    }
}
