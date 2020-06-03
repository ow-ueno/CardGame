using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Card
    {
        public int Number { get; private set; }
        public string Suit { get; private set; }

        public Card(int number,string suit){
            this.Number = number;
            this.Suit = suit;
        }
    }
}
