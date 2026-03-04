using System.Runtime.InteropServices;
using WarGame.Core;

GameEngine gameEngine = new GameEngine();
Deck deck = new Deck();
Console.WriteLine($"Deck has {deck.Cards.Count} cards.");
Console.WriteLine("How many Players are playing? (2-4)");
int countOfPlayers = int.Parse(Console.ReadLine());
gameEngine.StartGame(countOfPlayers);
//foreach (Player p in gameEngine.Players)
//{
//    foreach (KeyValuePair<string, Hand> h in p.PlayerHands.Hands)
//    {
//        foreach (Card c in h.Value.Cards)
//        {
//            Console.WriteLine($"{h.Key} has {c.Rank} of {c.Suit} and {p.PlayerHands.Hand.Cards.Count}");
//        }
//    }
//}
gameEngine.PlayRound();
Console.WriteLine("Press any key to play a round.");
foreach (Player p in gameEngine.Players)
{
    foreach (KeyValuePair<string, Card> h in p.PlayedCards.Cards)
    {
        Console.WriteLine($"{h.Key} has {h.Value}  {p.PlayerHands.Hand.Cards.Count}");
    }
}
Console.WriteLine($"The Winner of this round is {gameEngine.CheckWinner().Rank} of {gameEngine.CheckWinner().Suit}");

