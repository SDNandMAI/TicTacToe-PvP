using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe_PvP.Players
{
    public interface IPlayer
    {
        public string Name { get; }
        public bool Turn { get; set; }
        public bool Winner { get; set; }
        public string Marker { get; }

        public int WinCount { get; set; }
    }
}
