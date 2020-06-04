using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame {
    public class Card {
        public int Number { get; private set; }
        public SuitType Suit { get; private set; }
        public int Power { get; private set; }
        public enum SuitType {
            clover = 1,
            heart = 2,
            diamond = 3,
            spade = 4,
            black = 10,
            red = 20,
        }

        public Card(int number, SuitType suit) {
            this.Number = number;
            this.Suit = suit;
            //powerの設定
            switch (number) {
                case 1:
                    this.Power = 14;
                    break;
                default:
                    this.Power = number;
                    break;
            }
            Power *= 100;
            Power += (int)Suit;
        }

        public string GetNumberStr() {
            string numberStr;

            switch (Number) {
                case 1:
                    numberStr = "エース";
                    break;
                case 11:
                    numberStr = "ジャック";
                    break;
                case 12:
                    numberStr = "クイーン";
                    break;
                case 13:
                    numberStr = "キング";
                    break;
                case 99:
                    numberStr = "ジョーカー";
                    break;
                default:
                    numberStr = Number.ToString();
                    break;
            }

            return numberStr;
        }

        public int Compare(Card c) {
            return this.Power.CompareTo(c.Power);
        }

        public bool Equals(Card c) {
            bool isSumNum = this.Number == c.Number ? true : false;
            bool isSumSuit = this.Suit == c.Suit ? true : false;
            return isSumNum && isSumSuit ? true : false;
        }

    }

    public static partial class EnumExtend {
        public static string GetName(this Card.SuitType param) {
            var str = "";
            switch (param) {
                case Card.SuitType.clover:
                    str = "クローバー";
                    break;
                case Card.SuitType.heart:
                    str = "ハート";
                    break;
                case Card.SuitType.diamond:
                    str = "ダイヤ";
                    break;
                case Card.SuitType.spade:
                    str = "スペード";
                    break;
                case Card.SuitType.black:
                    str = "黒";
                    break;
                case Card.SuitType.red:
                    str = "赤";
                    break;
                default:
                    str = "エラー";
                    break;
            }
            return str;
        }
        public static string GetMark(this Card.SuitType param) {
            var str = "";
            switch (param) {
                case Card.SuitType.clover:
                    str = "♧";
                    break;
                case Card.SuitType.heart:
                    str = "♡";
                    break;
                case Card.SuitType.diamond:
                    str = "♢";
                    break;
                case Card.SuitType.spade:
                    str = "♤";
                    break;
                case Card.SuitType.black:
                    str = "黒";
                    break;
                case Card.SuitType.red:
                    str = "赤";
                    break;
                default:
                    str = "!?";
                    break;
            }
            return str;
        }

    }

}
