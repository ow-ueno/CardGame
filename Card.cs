using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Card
    {
        public int Number { get; private set; }
        public string Suit { get; private set; }
        public int Power { get; private set; }

        public Card(int number, string suit)
        {
            this.Number = number;
            this.Suit = suit;
            switch (number)
            {
                case 1:
                    this.Power = 14;
                    break;
                default:
                    this.Power = number;
                    break;
            }
        }

        public string GetNumberStr()
        {
            string numberStr;

            switch (Number)
            {
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

        public string GetSuit()
        {
            string suitJpn;

            switch (Suit)
            {
                case "clover":
                    suitJpn = "クローバー";
                    break;
                case "heart":
                    suitJpn = "ハート";
                    break;
                case "diamond":
                    suitJpn = "ダイヤ";
                    break;
                case "spade":
                    suitJpn = "スペード";
                    break;
                case "red":
                    suitJpn = "赤";
                    break;
                default:
                    suitJpn = "黒";
                    break;
            }
            return suitJpn;
        }

        public int Compare(Card c)
        {
            return this.Power.CompareTo(c.Power);
        }

    }
}
