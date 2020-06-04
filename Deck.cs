using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    public class Deck
    {
        List<Card> Cards = new List<Card>();

        //数字カード
        const int MAXNUM = 13;
        const int SUIT = 4;
        //ジョーカー
        const int JOKERNUM = 99;
        //suitの名前
        List<Card.SuitType> CARDSUIT = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.heart, Card.SuitType.diamond, Card.SuitType.spade, Card.SuitType.red, Card.SuitType.black };

        public Deck()
        {
            for (int i = 0; i < SUIT; i++)
            {
                for (int j = 1; j <= MAXNUM; j++)
                {
                    //ただしいカードのつくりかた
                    //コンストラクタで初期値を設定することで、以後変更できないようにする
                    var TmpCard = new Card(j, CARDSUIT[i]);
                    Cards.Add(TmpCard);
                }
            }
            //ジョーカーを2枚追加
            var BlackJoker = new Card(JOKERNUM, CARDSUIT[5]);
            Cards.Add(BlackJoker);
            var RedJoker = new Card(JOKERNUM, CARDSUIT[4]);
            Cards.Add(RedJoker);
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(i => Guid.NewGuid()).ToList();

        }

        public Card Draw()
        {
            //defaultをnullに変更
            Card DrawCard = null;
            if (Cards.Count > 0)
            {
                //入れた順に取り出すように変更
                var index = Cards.Count - 1;
                DrawCard = Cards[index];
                Cards.RemoveAt(index);
            }
            return DrawCard;
        }

        public int Count()
        {
            return Cards.Count;
        }
    }
}
