using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CardGame {
    class Program {
        static void Main(string[] args) {
            //おまじない
            Console.OutputEncoding = Encoding.UTF8;

            //Deckをつくる
            var myDeck = new Deck();

            //引いたカードのList
            var Draws = new List<Card>();

            myDeck.Shuffle();

            //for (int i = 0; i < 54; i++)
            //{
            //    Draws.Add(myDeck.Draw());
            //    DrawMessage(Draws[i].GetSuit(), Draws[i].GetNumberStr(), i + 1);
            //}

            //作成したCountメソッドを使う:while
            //while (myDeck.Count() > 0) {
            //    Draws.Add(myDeck.Draw());
            //    DrawMessage(Draws.Last().GetSuit(), Draws.Last().GetNumberStr(), Draws.Count);
            //}

            //forなら
            const int DRAWNUM = 2;
            int deckMax = myDeck.Count();
            for (int i = 0; i < DRAWNUM; i++) {
                Draws.Add(myDeck.Draw());
                DrawMessage(Draws.Last(), Draws.Count);
            }

            //比較
            CompareMessage(Draws[0].Compare(Draws[1]));

            //終了時
            Console.WriteLine("Press Any Key...");
            Console.ReadKey();

        }

        static void DrawMessage(Card drawCard, int index) {
            string suit = drawCard.Suit.GetName();
            string number = drawCard.GetNumberStr();
            Console.WriteLine("あなたが{2}枚目に引いたカードは{0}の{1}です。", suit, number, index);
        }

        static void CompareMessage(int cResult) {
            if (cResult > 0) {
                Console.WriteLine("1枚目のカードが強いです。");
            } else if (cResult == 0) {
                Console.WriteLine("同値です。");
            } else {
                Console.WriteLine("2枚目のカードが強いです。");
            }
        }
    }
}