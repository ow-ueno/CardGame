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
            Draws.Add(myDeck.draw());
            Console.WriteLine("あなたが{2}枚目に引いたカードは{0}の{1}です。",Draws[0].Suit,Draws[0].Number, 1);
            Draws.Add(myDeck.draw());
            Console.WriteLine("あなたが{2}枚目に引いたカードは{0}の{1}です。", Draws[1].Suit, Draws[1].Number, 2);

            myDeck.shuffle();
            Draws.Add(myDeck.draw());
            Console.WriteLine("あなたが{2}枚目に引いたカードは{0}の{1}です。", Draws[2].Suit, Draws[2].Number, 3);

            Console.WriteLine("Press Any Key...");
            Console.ReadKey();

        }
    }
}