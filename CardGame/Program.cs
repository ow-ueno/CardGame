using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CardGame {
    class Program {
        static void Main(string[] args) {

            //おまじない
            Console.OutputEncoding = Encoding.UTF8;

            //現在の処理：5枚引いてOnePair、TwoPair、ThreeOfAKindが含まれるか
            //ゲームを20回繰り返す
            for (int i = 0; i < 100; i++) CheckFiveCard();

            //終了時
            Console.WriteLine("Press Any Key...");
            Console.ReadKey();

        }

        static void AllDraw() {
            //Deckをつくってまぜる
            var myDeck = new Deck();
            myDeck.Shuffle();

            //引いたカードを保管する
            var Draws = new List<Card>();

            //while版
            while (myDeck.Count() > 0) {
                Draws.Add(myDeck.Draw());
                DrawMessage(Draws.Last(), Draws.Count);
            }
        }

        static void CompareTwoCard() {
            //Deckをつくってまぜる
            var myDeck = new Deck();
            myDeck.Shuffle();

            //引いたカードを保管する
            var Draws = new List<Card>();

            for (int i = 0; i < 2; i++) {
                Draws.Add(myDeck.Draw());
                DrawMessage(Draws[i], i + 1);
            }

            //for
            const int DRAWNUM = 2;
            for (int i = 0; i < DRAWNUM; i++) {
                Draws.Add(myDeck.Draw());
                DrawMessage(Draws.Last(), Draws.Count);
            }

            //比較
            CompareMessage(Draws[0].Compare(Draws[1]));

        }

        static void CheckFiveCard() {

            //Deckをつくってまぜる
            var myDeck = new Deck();
            myDeck.Shuffle();
            var player = new Player();

            const int DRAWNUM = 5;
            for (int i = 0; i < DRAWNUM; i++) {
                player.Cards.Add(myDeck.Draw());
                DrawMessageLight(player.Cards.Last(), player.Cards.Count);
            }
            DrawLine();

            //Pair判定と出力
            HasPairMessage(player.IsHasOnePair());

            //twoPair判定と出力
            HasTwoPairMessage(player.IsHasDoublePair());

            //threeOfAKind判定と出力
            HasThreeCardMessage(player.IsHasTrio());

        }

        static void DrawMessage(Card drawCard, int index) {
            string suit = drawCard.Suit.GetName();
            string number = drawCard.GetNumberStr();
            Console.WriteLine("あなたが{2}枚目に引いたカードは{0}の{1}です。", suit, number, index);
        }
        static void DrawMessageLight(Card drawCard, int index) {
            string mark = drawCard.Suit.GetMark();
            int number = drawCard.Number;
            Console.Write("[{0}{1:00}],", mark, number);
        }
        static void DrawLine() {
            Console.WriteLine();
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

        static void HasPairMessage(bool isHas) {
            if (isHas) {
                Console.WriteLine("ペアがあります。");
            } else {
                Console.WriteLine("ペアがありません。");
            }
        }

        static void HasTwoPairMessage(bool isHas) {
            if (isHas) {
                Console.WriteLine("ツーペアです。");
            } else {
                Console.WriteLine("ツーペアではありません。");
            }
        }

        static void HasThreeCardMessage(bool isHas) {
            if (isHas) {
                Console.WriteLine("スリーカードがあります。");
            } else {
                Console.WriteLine("スリーカードではありません。");
            }
        }

    }
}