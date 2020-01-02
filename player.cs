using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class player
    {
        public List<Card> CardsInHand = new List<Card>();

        public int point;

        public int chips;

        public int bet;

        public bool bust;

        public bool stand;

        public int sum = 0;

        public void SetChips(int chips) 
        {
            this.chips = chips;
        }

        public void Bet(int chips)
        {
            this.chips -= chips;
            this.bet = chips;
        }


        public int CountPoint() 
        {
            sum = 0;
            foreach (Card card in CardsInHand) 
            {
                if (card.Rank == "Ace")
                {
                    Console.WriteLine("please choose Ace is 1 or 11 point");
                    int Ace = Convert.ToInt32(Console.ReadLine());
                    sum += Ace;
                }

                if (card.Rank == "Two")
                {
                    sum += 2;
                }

                if (card.Rank == "Three")
                {
                    sum += 3;
                }

                if (card.Rank == "Four")
                {
                    sum += 4;
                }

                if (card.Rank == "Five")
                {
                    sum += 5;
                }

                if (card.Rank == "Six")
                {
                    sum += 6;
                }

                if (card.Rank == "Seven")
                {
                    sum += 7;
                }

                if (card.Rank == "Eight")
                {
                    sum += 8;
                }

                if (card.Rank == "Nine")
                {
                    sum += 9;
                }

                if (card.Rank == "Ten")
                {
                    sum += 10;
                }

                if (card.Rank == "Jack")
                {
                    sum += 10;
                }

                if (card.Rank == "Queen")
                {
                    sum += 10;
                }

                if (card.Rank == "King")
                {
                    sum += 10;
                }
            }
            point = sum;
            return sum;
        }

        public bool isBust() 
        {
            if (sum > 21) 
            {
                bust = true;
            }
            return bust;
        }

        public void showCards() 
        {
            foreach (Card card in CardsInHand)
            {
                Console.WriteLine(card.Rank + " of " + card.Suit);
            }
        }


    }
}
