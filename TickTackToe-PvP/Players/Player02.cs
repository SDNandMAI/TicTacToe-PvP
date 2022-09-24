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

        public Player02()
        {
            this.Name = "Player02";
        }
    }
}
