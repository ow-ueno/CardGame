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
        const int JOKERNUM = 14;
        //suitの名前
        List<string> CARDSUIT = new List<string> { "spade", "heart", "diamond", "clover", "red", "black" };

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
            var RedJoker = new Card(JOKERNUM, CARDSUIT[4]);
            Cards.Add(RedJoker);
            var BlackJoker = new Card(JOKERNUM, CARDSUIT[5]);
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

        public int Count()
        {
            return Cards.Count;
        }
    }
}
