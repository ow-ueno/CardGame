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
            var pairNum = JudgePair(tmpCards);
            return pairNum > 0 ? pairNum : 0;
        }

        //2.ツーペア
        public List<int> IsHasDoublePair() {
            if (Cards.Count < 4) return null;
            var tmpCards = new List<Card>(Cards);
            var pairNums = new List<int>();
            for (int i = 0; i < 2; i++) {
                var pairNum = JudgePair(tmpCards);
                if (pairNum > 0) pairNums.Add(pairNum);
            }
            return pairNums.Count >= 2 ? pairNums : null;
        }

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

        //4.ストレート
        public int IsHasStraight() {
            //未実装
            return 0;
        }

        //5.フラッシュ
        public int IsHasFlush() {
            //未実装
            return 0;
        }

        //6.フルハウス
        //厳密にはint,intを返すべきな気もするが
        public List<int> IsHasFullHouse() {
            //未実装
            //スリーカード+ワンペア
            return null;
        }

        //7.フォーカード
        public int IsHasQuartet() {
            //未実装
            return 0;
        }

        //8.ストレートフラッシュ
        public int IsHasStraightFlush() {
            //未実装
            //ストレート+フラッシュ
            return 0;
        }

        //9.ファイブカード
        public int IsHasQuintet() {
            //未実装
            return 0;
        }

        //10.ロイヤルフラッシュ
        public int IsHasRoyalFlush() {
            //未実装
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

        //ストレートの判定
        //ストレート、ストレートフラッシュ、ロイヤルフラッシュで使用
        //「5枚の階段の成立」、一番小さい数字を返す(3,4,5,6,7なら3、戻り値は0-10)
        public int JudgeStraight(List<Card> judge) {
            //未実装
            //スリーカードの実装から移す
            return 0;
        }

        //フラッシュの判定
        //フラッシュ、ストレートフラッシュ、ロイヤルフラッシュで使用
        //「ジョーカー以外全てのSuitが同じ」
        public Card.SuitType JudgeFlush(List<Card> judge) {
            //未実装
            //スリーカードの実装から移す
            return 0;
        }



        //フォーカードの判定、フォーカードで使用
        public int JudgeQuartet(List<Card> judge) {
            //未実装
            return 0;
        }

        //ファイブカードの判定、ファイブカードで使用
        public int JudgeQuintet(List<Card> judge) {
            //未実装
            return 0;
        }



    }
}
