using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;
using System.Collections.Generic;

namespace CardGameTests {
    [TestClass]
    public class CardGameTest {
        [TestMethod]
        public void CardCompareTest() {
            //比較

            //あらかじめ指定したカードを変数に入れておく
            var c1 = new Card(1, Card.SuitType.spade);
            var c2 = new Card(2, Card.SuitType.clover);
            //それぞれの取り合わせに対するint応答が意図した通りかをチェックする
            Assert.AreEqual(c1.Compare(c2), 1);
            Assert.AreEqual(c2.Compare(c1), -1);
            Assert.AreEqual(c1.Compare(c1), 0);
        }

        [TestMethod]
        public void DeckDrawTest() {
            //デッキからカードを引く

            //デッキ用意
            var d = new Deck();
            //混ぜていないので一番最後に入れたカード
            var c1 = d.Draw();
            //最後から2枚目に入れたカード
            var c2 = d.Draw();
            //最後に入れたカードは赤ジョーカー
            var ex1 = new Card(99, Card.SuitType.red);
            //その前は黒ジョーカー
            var ex2 = new Card(99, Card.SuitType.black);

            //AreEqualはどうやらEqualsに記述したことを参照しない模様なので、
            //            Assert.AreEqual(c1,ex1);
            //            Assert.AreEqual(c2,ex2);
            //EqualsがTrueになっているかを確かめる
            Assert.IsTrue(c1.Equals(ex1));
            Assert.IsTrue(c2.Equals(ex2));
        }

        [TestMethod]
        public void DeckCountTest() {
            //デッキの枚数を数える

            //用意した時点で54枚入る
            var d = new Deck();
            //1枚引く
            d.Draw();
            //残りの枚数が適切かを確かめる
            Assert.AreEqual(d.Count(), 53);

        }

        //PlayerHandに格納されたOnePairを適切に検出する
        [TestMethod]
        public void PlayerHandOnePairTest1() {

            var p = new Player();
            var list1 = new List<int> { 1, 13, 12, 11, 10 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }

            //ワンペアを含まない
            Assert.AreEqual(p.IsHasOnePair(), 0);

        }

        [TestMethod]
        public void PlayerHandOnePairTest2() {

            var p = new Player();
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade };
            foreach (Card.SuitType st in list2) {
                var c = new Card(1, st);
                p.Cards.Add(c);
            }
            var j = new Card(99, Card.SuitType.red);
            p.Cards.Add(j);

            //1のワンペアを含む
            Assert.AreEqual(p.IsHasOnePair(), 1);
        }

        [TestMethod]
        public void PlayerHandOnePairTest3() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 5, 6, 7 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }
            //1のワンペアを含む
            Assert.AreEqual(p.IsHasOnePair(), 1);
        }

        [TestMethod]
        public void PlayerHandOnePairTest4() {

            var p = new Player();
            var list1 = new List<int> { 1, 2, 3, 4, 5 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.spade };
            foreach (int i in list1) {
                var c = new Card(i, list2[i - 1]);
                p.Cards.Add(c);
            }
            //ワンペアを含まない
            Assert.AreEqual(p.IsHasOnePair(), 0);

        }

        [TestMethod]
        public void PlayerHandOnePairTest5() {

            var p = new Player();
            var list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }

            //ワンペアを含まない
            Assert.AreEqual(p.IsHasOnePair(), 0);

        }

        //ここからツーペアのテスト
        //ロイヤルフラッシュ
        [TestMethod]
        public void PlayerHandTwoPairTest1() {

            var p = new Player();
            var list1 = new List<int> { 1, 13, 12, 11, 10 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }

            //null
            Assert.IsNull(p.IsHasDoublePair());

        }

        //ツーペア
        [TestMethod]
        public void PlayerHandTwoPairTest2() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 2, 2, 3 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }
            //1と2のツーペア
            var expected = new List<int> { 1, 2 };
            var actual = p.IsHasDoublePair();
            CollectionAssert.AreEqual(expected, actual);
        }

        //フルハウス
        [TestMethod]
        public void PlayerHandTwoPairTest3() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 1, 2, 2 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (int i in list1) {
                var c = new Card(i, list2[0]);
                list2.RemoveAt(0);
                p.Cards.Add(c);
            }
            //1と2のツーペア
            var expected = new List<int> { 1, 2 };
            var actual = p.IsHasDoublePair();
            CollectionAssert.AreEqual(expected, actual);
        }

        //ワンペア
        [TestMethod]
        public void PlayerHandTwoPairTest4() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 5, 6, 7 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }

            //null
            Assert.IsNull(p.IsHasDoublePair());

        }

        //ストレート
        [TestMethod]
        public void PlayerHandTwoPairTest5() {

            var p = new Player();
            var list1 = new List<int> { 1, 2, 3, 4, 5 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.spade };
            foreach (int i in list1) {
                var c = new Card(i, list2[i - 1]);
                p.Cards.Add(c);
            }

            //null
            Assert.IsNull(p.IsHasDoublePair());

        }

        //ぶた
        [TestMethod]
        public void PlayerHandTwoPairTest6() {

            var p = new Player();
            var list1 = new List<int> { 1, 3, 5, 7, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.RemoveAt(0);
                p.Cards.Add(c);
            }

            //null
            Assert.IsNull(p.IsHasDoublePair());

        }

        //スリーカード
        [TestMethod]
        public void PlayerHandTwoPairTest7() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 1, 7, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.RemoveAt(0);
                p.Cards.Add(c);
            }

            //null
            Assert.IsNull(p.IsHasDoublePair());

        }

        //ジョーカーの入ったスリーカード
        [TestMethod]
        public void PlayerHandTwoPairTest8() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 7, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart };
            foreach (Card.SuitType st in list2) {
                var c = new Card(1, st);
                p.Cards.Add(c);
            }
            var j = new Card(99, Card.SuitType.red);
            p.Cards.Add(j);

            //99と1のツーペア
            var expected = new List<int> { 1, 99 };
            var actual = p.IsHasDoublePair();
            CollectionAssert.AreEqual(expected, actual);

        }

        //フォーカード
        [TestMethod]
        public void PlayerHandTwoPairTest9() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 1, 1, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.RemoveAt(0);
                p.Cards.Add(c);
            }

            //1と1のツーペア
            var expected = new List<int> { 1, 1 };
            var actual = p.IsHasDoublePair();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PlayerHandThreeCardTest1() {
            var p = new Player();
            var list1 = new List<int> { 1, 1, 1, 7, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.RemoveAt(0);
                p.Cards.Add(c);
            }
            Assert.AreEqual(p.IsHasTrio(), 1);
        }

        [TestMethod]
        public void PlayerHandStraightTest1() {
            var p = new Player();
            var list1 = new List<int> { 3, 4, 5, 6, 7 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.RemoveAt(0);
                p.Cards.Add(c);
            }
            Assert.AreEqual(p.IsHasStraight(), 3);
        }

        [TestMethod]
        public void PlayerHandFlushTest1() {
            var p = new Player();
            var list1 = new List<int> { 1, 3, 5, 7, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.clover, Card.SuitType.clover, Card.SuitType.clover, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.RemoveAt(0);
                p.Cards.Add(c);
            }
            Assert.AreEqual(p.IsHasFlush(), Card.SuitType.clover);
        }

        [TestMethod]
        public void PlayerHandFourCardTest1() {
            var p = new Player();
            var list1 = new List<int> { 1, 1, 1, 1, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.RemoveAt(0);
                p.Cards.Add(c);
            }
            Assert.AreEqual(p.IsHasQuartet(), 1);
        }

        [TestMethod]
        public void PlayerHandStraightFlushTest1() {
            var p = new Player();
            var list1 = new List<int> { 3, 4, 5, 6, 7 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.clover, Card.SuitType.clover, Card.SuitType.clover, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.RemoveAt(0);
                p.Cards.Add(c);
            }
            Assert.AreEqual(p.IsHasStraightFlush(), 3);
        }

        [TestMethod]
        public void PlayerHandFiveCardTest1() {
            var p = new Player();
            var list1 = new List<int> { 1, 1, 1, 1, 99 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.black };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.RemoveAt(0);
                p.Cards.Add(c);
            }
            Assert.AreEqual(p.IsHasQuintet(), 1);
        }

        [TestMethod]
        public void PlayerHandRoyalFlushTest1() {
            var p = new Player();
            var list1 = new List<int> { 10, 11, 12, 13, 1 };
            var list2 = new List<Card.SuitType> { Card.SuitType.spade, Card.SuitType.spade, Card.SuitType.spade, Card.SuitType.spade, Card.SuitType.spade };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.RemoveAt(0);
                p.Cards.Add(c);
            }
            Assert.AreEqual(p.IsHasRoyalFlush(), 10);
        }

    }
}
