using System;
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

            for (int i = 0; i < 54; i++) { 
                Draws.Add(myDeck.Draw());
                DrawMessage(Draws[i].GetSuit(), Draws[i].GetNumberStr(),i + 1);
            }

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