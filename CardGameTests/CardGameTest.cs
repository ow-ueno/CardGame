using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;

namespace CardGameTests
{
    [TestClass]
    public class CardGameTest
    {
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
        [TestMethod]
        public void PlayerHandOnePairTest() {
            //PlayerHandに格納されたOnePairを適切に検出する

        }
    }
}
