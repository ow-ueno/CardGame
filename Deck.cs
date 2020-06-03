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
        const int SUITNUM = 4;
        List<string> CARDSUIT = new List<string> { "spade", "heart", "diamond", "clover", "red", "black" };

        public Deck()
        {
            for (int i = 0; i < SUITNUM; i++)
            {
                for (int j = 1; j <= MAXNUM; j++)
                {
                    //ただしいカードのつくりかた
                    var TmpCard = new Card(j, CARDSUIT[i]);
                    Cards.Add(TmpCard);
                }
            }
            //特殊なカードを2枚追加
            var RedJoker = new Card(14, CARDSUIT[4]);
            Cards.Add(RedJoker);
            var BlackJoker = new Card(14, CARDSUIT[5]);
            Cards.Add(BlackJoker);
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(i => Guid.NewGuid()).ToList();

        }

        public Card Draw()
        {
            var DrawCard = Cards[0];
            Cards.RemoveAt(0);
            return DrawCard;
        }
    }
}
