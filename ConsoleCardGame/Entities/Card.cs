using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCardGame.Entities
{
    public class Card
    {
        public string suit { get; }
        public string sign { get; }
        public bool isGived { get; set; }
        public bool isClosed { get; set; }
        public Card(string suit, string sign) { this.sign = sign; this.suit = suit; isGived = false; isClosed = false; }
    }
}
