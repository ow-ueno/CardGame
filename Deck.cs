using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    public class Deck
    {
        List<Card> Cards = new List<Card>();

        const int MAXNUM = 13;
        List<string> CARDSUIT = new List<string> { "spade", "heart", "diamond", "clover" };

        public Deck()
        {
            for (int i = 1; i <= MAXNUM; i++)
            {
                for (int j = 0; j < CARDSUIT.Count; j++)
                {
                    var TmpCard = new Card()
                    {
                        Number = i,
                        Suit = CARDSUIT[j]
                    };
                    Cards.Add(TmpCard);
                }
            }
        }
        public void shuffle()
        {
            Cards = Cards.OrderBy(i => Guid.NewGuid()).ToList();

        }

        public Card draw()
        {
            var DrawCard = Cards[0];
            Cards.RemoveAt(0);
            return DrawCard;
        }
    }
}
