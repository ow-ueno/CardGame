using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame {
    public class Player {
        public List<Card> Cards = new List<Card>();

        //Listの中身を判定する
        public bool IsHasPair() {
            if (Cards.Count < 2) return false;
            for (int i = 0; i < Cards.Count; i++) {
                //jokerは無条件
                //ここ多分99をそのまま使わないほうがいい
                if (Cards[i].Number == 99) return true;
                //古典
                //List.使って書けない？
                for (int j = i + 1; j < Cards.Count; j++) {
                    if (Cards[i].Number.Equals(Cards[j].Number)) return true;
                }
//                Cards.Find(c => c.Number == )
            }
            return false;
        }


    }
}
