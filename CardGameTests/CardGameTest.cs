using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;
using System.Collections.Generic;

namespace CardGameTests {
    [TestClass]
    public class CardGameTest {
        [TestMethod]
        public void CardCompareTest() {
            //��r

            //���炩���ߎw�肵���J�[�h��ϐ��ɓ���Ă���
            var c1 = new Card(1, Card.SuitType.spade);
            var c2 = new Card(2, Card.SuitType.clover);
            //���ꂼ��̎�荇�킹�ɑ΂���int�������Ӑ}�����ʂ肩���`�F�b�N����
            Assert.AreEqual(c1.Compare(c2), 1);
            Assert.AreEqual(c2.Compare(c1), -1);
            Assert.AreEqual(c1.Compare(c1), 0);
        }

        [TestMethod]
        public void DeckDrawTest() {
            //�f�b�L����J�[�h������

            //�f�b�L�p��
            var d = new Deck();
            //�����Ă��Ȃ��̂ň�ԍŌ�ɓ��ꂽ�J�[�h
            var c1 = d.Draw();
            //�Ōォ��2���ڂɓ��ꂽ�J�[�h
            var c2 = d.Draw();
            //�Ō�ɓ��ꂽ�J�[�h�͐ԃW���[�J�[
            var ex1 = new Card(99, Card.SuitType.red);
            //���̑O�͍��W���[�J�[
            var ex2 = new Card(99, Card.SuitType.black);

            //AreEqual�͂ǂ����Equals�ɋL�q�������Ƃ��Q�Ƃ��Ȃ��͗l�Ȃ̂ŁA
            //            Assert.AreEqual(c1,ex1);
            //            Assert.AreEqual(c2,ex2);
            //Equals��True�ɂȂ��Ă��邩���m���߂�
            Assert.IsTrue(c1.Equals(ex1));
            Assert.IsTrue(c2.Equals(ex2));
        }

        [TestMethod]
        public void DeckCountTest() {
            //�f�b�L�̖����𐔂���

            //�p�ӂ������_��54������
            var d = new Deck();
            //1������
            d.Draw();
            //�c��̖������K�؂����m���߂�
            Assert.AreEqual(d.Count(), 53);

        }

        //PlayerHand�Ɋi�[���ꂽOnePair��K�؂Ɍ��o����
        [TestMethod]
        public void PlayerHandOnePairTest1() {

            var p = new Player();
            var list1 = new List<int> { 1, 13, 12, 11, 10 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }

            //�����y�A���܂܂Ȃ�
            Assert.IsFalse(p.IsHasPair());

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

            //�����y�A���܂�
            Assert.IsTrue(p.IsHasPair());
        }

        [TestMethod]
        public void PlayerHandOnePairTest3() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 5, 6, 7 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }
            //�����y�A���܂�
            Assert.IsTrue(p.IsHasPair());
        }

        [TestMethod]
        public void PlayerHandOnePairTest4() {

            var p = new Player();
            var list1 = new List<int> { 1, 2, 3, 4, 5 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.spade };
            foreach (int i in list1) {
                var c = new Card(i, list2[i]);
                p.Cards.Add(c);
            }
            //�����y�A���܂܂Ȃ�
            Assert.IsFalse(p.IsHasPair());

        }

        [TestMethod]
        public void PlayerHandOnePairTest5() {

            var p = new Player();
            var list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }
            //�����y�A���܂܂Ȃ�
            Assert.IsFalse(p.IsHasPair());

        }


    }
}
