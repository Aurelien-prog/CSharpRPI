using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
{
    internal class Card
    {
        public Value value;
        public Suit suit;
        public bool darkside = true;

        public Card(Value value, Suit suit)
        {
            this.value = value;
            this.suit = suit;
        }
    }
}