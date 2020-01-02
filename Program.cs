using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Programming Assignment 2 solution
    /// </summary>
    class Program
    {
        /// <summary>
        /// Deals 2 cards to players and displays cards for players
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            GameLogic();

            Console.ReadKey();
        }

        public static void GameLogic() 
        {
            // print welcome message
            Console.WriteLine("welcome");
            // create and shuffle a deck
            Deck deck = new Deck();
            deck.Shuffle();
            Console.WriteLine("Shuffle finishied!");
            // deal 2 cards each to  players
            player dealer = new player();
            Console.WriteLine("dealer,please buy your chips");
            dealer.SetChips(Convert.ToInt32(Console.ReadLine()));

            player player1 = new player();
            Console.WriteLine("player,please buy your chips");
            player1.SetChips(Convert.ToInt32(Console.ReadLine()));
            //player player2 = new player();
            //player player3 = new player();
            Console.WriteLine("player1, please bet");
            player1.Bet(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Dealing the cards!");
            dealer.CardsInHand.Add(deck.TakeTopCard());
            player1.CardsInHand.Add(deck.TakeTopCard());
            //player2.CardsInHand.Add(deck.TakeTopCard());
            //player3.CardsInHand.Add(deck.TakeTopCard());

            dealer.CardsInHand.Add(deck.TakeTopCard());
            player1.CardsInHand.Add(deck.TakeTopCard());
            //player2.CardsInHand.Add(deck.TakeTopCard());
            //player3.CardsInHand.Add(deck.TakeTopCard());
            // flip all the cards over
            foreach (Card card in dealer.CardsInHand)
            {
                card.FlipOver();
            }
            foreach (Card card in player1.CardsInHand)
            {
                card.FlipOver();
            }

            //foreach (Card card in player2.CardsInHand)
            //{
            //    card.FlipOver();
            //}

            //foreach (Card card in player3.CardsInHand)
            //{
            //    card.FlipOver();
            //}
            Console.WriteLine("flip all the cards over");
            // print the first card for dealer
            Console.WriteLine("Dealer card:");
            Console.WriteLine(dealer.CardsInHand[0].Rank + " of " + dealer.CardsInHand[0].Suit);

            // print the cards for player 1
            Console.WriteLine("player1 cards in hand:");
            player1.showCards();
            player1.CountPoint();
            Console.WriteLine("player1 point is {0}", player1.point);

            //// print the cards for player 2
            //Console.WriteLine("player2 cards in hand:");
            //player2.showCards();

            //// print the cards for player 3
            //Console.WriteLine("player3 cards in hand:");
            //player3.showCards();

            while (!player1.bust)
            {
                Console.WriteLine("do you need to hit cards?   yes/no");
                string input = Console.ReadLine();

                if (input == "no")
                {
                    break;
                }
                else if (input == "yes")
                {
                    player1.CardsInHand.Add(deck.TakeTopCard());
                    player1.CardsInHand[player1.CardsInHand.Count() - 1].FlipOver();
                    player1.showCards();
                    player1.CountPoint();
                    Console.WriteLine("player1 point is {0}", player1.point);
                    Console.WriteLine("Bust is {0}", player1.isBust());
                }
            }

            if (player1.isBust())
            {
                Console.WriteLine("dealer takes your {0} chips", player1.bet);
                return;
            }

            
            Console.WriteLine("dealer cards in hand:");
            dealer.showCards();
            dealer.CountPoint();
            Console.WriteLine("dealer point is {0}", dealer.point);
            while (!dealer.bust)
            {
                Console.WriteLine("do you need to hit cards?   yes/no");
                string input = Console.ReadLine();

                if (input == "no")
                {
                    break;
                }
                else if (input == "yes")
                {
                    dealer.CardsInHand.Add(deck.TakeTopCard());
                    dealer.CardsInHand[dealer.CardsInHand.Count() - 1].FlipOver();
                    dealer.showCards();
                    dealer.CountPoint();
                    Console.WriteLine("Bust is {0}", dealer.isBust());
                }
            }

            if (dealer.isBust() && !player1.isBust())
            {
                Console.WriteLine("palyer1 takes your chips");
                player1.chips += 2 * player1.bet;
                Console.WriteLine("player1 win {0} chips", player1.bet);
                dealer.chips -= player1.bet;
                Console.WriteLine("dealer lose {0} chips", player1.bet);
                return;
            }

            if (dealer.point == player1.point)
            {
                Console.WriteLine("push! everyone take their chips back");
                player1.chips +=  player1.bet;
                return;
            }

            if (dealer.point > player1.point)
            {
                Console.WriteLine("dealer takes your chips");
                dealer.chips += player1.bet;
                Console.WriteLine("dealer win {0} chips", player1.bet);
                Console.WriteLine("player1 lose {0} chips", player1.bet);
                return;
            }

            if (dealer.point < player1.point)
            {
                Console.WriteLine("player1 takes all your chips");
                player1.chips += 2 * player1.bet;
                Console.WriteLine("player1 win {0} chips", player1.bet);
                dealer.chips -= player1.bet;
                Console.WriteLine("dealer lose {0} chips", player1.bet);
                return;
            }

        }
    }
}
