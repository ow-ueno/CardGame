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
        public bool IsHasOnePair() {
            if (Cards.Count < 2) return false;
            var tmpCards = new List<Card>(Cards);
            return JudgePair(tmpCards) > 0 ? true : false;
        }

        //Listの中身を判定する
        //2.ツーペア
        public bool IsHasDoublePair() {
            if (Cards.Count < 4) return false;
            int hasPair = 0;
            var tmpCards = new List<Card>(Cards);
            for (int i = 0; i < 2; i++) if (JudgePair(tmpCards) > 0) hasPair++;
            return hasPair >= 2;
        }

        //Listの中身を判定する
        //3.スリーカード
        public bool IsHasTrio() {
            if (Cards.Count < 3) return false;
            var tmpCards = new List<Card>(Cards);
            //先にジョーカーの枚数を数える
            int hasJoker = Cards.FindAll(c => c.Number == JOKERNUM).Count;
            int necesarrySame = 3 - hasJoker;
            for (int i = 0; i < Cards.Count; i++) if ((Cards.FindAll(c => c.Number == Cards[i].Number).Count) >= necesarrySame) return true;

            return false;
        }

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

    }
}
