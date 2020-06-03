using System;
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

            //とりあえず1枚引いてみる
            Card firstDraw = myDeck.draw();

            Console.WriteLine("あなたが最初に引いたカードは{0}の{1}です。",firstDraw.Suit, firstDraw.Number);

            Console.WriteLine("Press Any Key...");
            Console.ReadKey();

        }
    }
}