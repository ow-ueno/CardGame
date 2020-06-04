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
            Assert.IsFalse(p.IsHasOnePair());

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
            Assert.IsTrue(p.IsHasOnePair());
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
            Assert.IsTrue(p.IsHasOnePair());
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
            //�����y�A���܂܂Ȃ�
            Assert.IsFalse(p.IsHasOnePair());

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
            Assert.IsFalse(p.IsHasOnePair());

        }

        //��������c�[�y�A�̃e�X�g
        //���C�����t���b�V��
        [TestMethod]
        public void PlayerHandTwoPairTest1() {

            var p = new Player();
            var list1 = new List<int> { 1, 13, 12, 11, 10 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }

            //�c�[�y�A���܂܂Ȃ�
            Assert.IsFalse(p.IsHasDoublePair());

        }

        //�c�[�y�A
        [TestMethod]
        public void PlayerHandTwoPairTest2() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 2, 2, 3 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }
            //�c�[�y�A���܂�
            Assert.IsTrue(p.IsHasDoublePair());
        }

        //�t���n�E�X
        [TestMethod]
        public void PlayerHandTwoPairTest3() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 1, 2, 2 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (int i in list1) {
                var c = new Card(i, list2[0]);
                list2.Remove(0);
                p.Cards.Add(c);
            }
            //�c�[�y�A���܂�
            Assert.IsTrue(p.IsHasDoublePair());
        }

        //�����y�A
        [TestMethod]
        public void PlayerHandTwoPairTest4() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 5, 6, 7 };
            foreach (int i in list1) {
                var c = new Card(i, Card.SuitType.spade);
                p.Cards.Add(c);
            }
            //�c�[�y�A���܂܂Ȃ�
            Assert.IsFalse(p.IsHasDoublePair());
        }

        //�X�g���[�g
        [TestMethod]
        public void PlayerHandTwoPairTest5() {

            var p = new Player();
            var list1 = new List<int> { 1, 2, 3, 4, 5 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.spade };
            foreach (int i in list1) {
                var c = new Card(i, list2[i - 1]);
                p.Cards.Add(c);
            }
            //�c�[�y�A���܂܂Ȃ�
            Assert.IsFalse(p.IsHasDoublePair());

        }

        //�Ԃ�
        [TestMethod]
        public void PlayerHandTwoPairTest6() {

            var p = new Player();
            var list1 = new List<int> { 1, 3, 5, 7, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.Remove(0);
                p.Cards.Add(c);
            }

            //�c�[�y�A���܂܂Ȃ�
            Assert.IsFalse(p.IsHasDoublePair());

        }

        //�X���[�J�[�h
        [TestMethod]
        public void PlayerHandTwoPairTest7() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 1, 7, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.Remove(0);
                p.Cards.Add(c);
            }

            //�c�[�y�A���܂܂Ȃ�
            Assert.IsFalse(p.IsHasDoublePair());

        }

        //�W���[�J�[�̓������X���[�J�[�h
        [TestMethod]
        public void PlayerHandTwoPairTest8() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 7, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart};
            foreach (Card.SuitType st in list2) {
                var c = new Card(1, st);
                p.Cards.Add(c);
            }
            var j = new Card(99, Card.SuitType.red);
            p.Cards.Add(j);

            //�c�[�y�A���܂�
            Assert.IsTrue(p.IsHasDoublePair());

        }

        //�t�H�[�J�[�h
        [TestMethod]
        public void PlayerHandTwoPairTest9() {

            var p = new Player();
            var list1 = new List<int> { 1, 1, 1, 1, 9 };
            var list2 = new List<Card.SuitType> { Card.SuitType.clover, Card.SuitType.diamond, Card.SuitType.heart, Card.SuitType.spade, Card.SuitType.clover };
            foreach (Card.SuitType st in list2) {
                var c = new Card(list1[0], st);
                list1.Remove(0);
                p.Cards.Add(c);
            }

            //�c�[�y�A���܂�
            Assert.IsTrue(p.IsHasDoublePair());

        }
    }
}
