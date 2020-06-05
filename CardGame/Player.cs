using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame {
    public class Player {
        public List<Card> Cards = new List<Card>();
        const int JOKERNUM = 99;
        //判定用

        //Listの中身を判定する
        //1.ワンペア
        public int IsHasOnePair() {
            if (Cards.Count < 2) return 0;
            var tmpCards = new List<Card>(Cards);
            return JudgePair(tmpCards) > 0 ? JudgePair(tmpCards) : 0;
        }

        //Listの中身を判定する
        //2.ツーペア
        public List<int> IsHasDoublePair() {
            if (Cards.Count < 4) return null;
            int hasPair = 0;
            var tmpCards = new List<Card>(Cards);
            var pairNum = new List<int>();
            for (int i = 0; i < 2; i++) {
                if (JudgePair(tmpCards) > 0) pairNum.Add(JudgePair(tmpCards));
            }
            return hasPair >= 2 ? pairNum : null;
        }

        //Listの中身を判定する
        //3.スリーカード
        public int IsHasTrio() {
            if (Cards.Count < 3) return 0;
            var tmpCards = new List<Card>(Cards);
            //先にジョーカーの枚数を数える
            int hasJoker = tmpCards.FindAll(c => c.Number == JOKERNUM).Count;
            int necesarrySame = 3 - hasJoker;
            for (int i = 0; i < tmpCards.Count; i++) {
                if ((tmpCards.FindAll(c => c.Number == tmpCards[i].Number).Count) >= necesarrySame) return tmpCards[i].Number;
            }
            return 0;
        }

        //ペアの判定
        //ワンペア、ツーペア、フルハウスで使用
        public int JudgePair(List<Card> judge) {
            for (int i = 0; i < judge.Count; i++) {
                //jokerは無条件
                if (judge[i].Number == JOKERNUM) {
                    judge.RemoveAt(i);
                    return JOKERNUM;
                }
                //judge内のカードを前から、一致があるか探索しあったら2枚リムーブ
                int num = judge[i].Number;
                List<Card> remove = judge.FindAll(c => c.Number == num);
                if (remove.Count >= 2) {
                    for (int remCount = 0; remCount < 2; remCount++) {
                        judge.Remove(remove[remCount]);
                    }
                    return num;
                }
            }
            return 0;
        }

        //スリーカードの判定
        //スリーカード、フルハウスで使用
        public int JudgeTrio(List<Card> judge) {
            //未実装
            //スリーカードの実装から移す
            return 0;
        }


    }
}
