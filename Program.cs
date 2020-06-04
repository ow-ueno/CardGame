using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
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

            //作成したCountメソッドを使う
            while (myDeck.Count() > 0) {
                Draws.Add(myDeck.Draw());
                DrawMessage(Draws.Last().GetSuit(), Draws.Last().GetNumberStr(), Draws.Count);
            }

            //forなら
            //int deckMax = myDeck.Count();
            //for (int i = 0; i < deckMax; i++)
            //{
            //    Draws.Add(myDeck.Draw());
            //    DrawMessage(Draws.Last().GetSuit(), Draws.Last().GetNumberStr(), Draws.Count);
            //}


            //終了時
            Console.WriteLine("Press Any Key...");
            Console.ReadKey();

        }

        static void DrawMessage(string suit, string number, int cardindex)
        {
            Console.WriteLine("あなたが{2}枚目に引いたカードは{0}の{1}です。", suit, number, cardindex);
        }
    }
}