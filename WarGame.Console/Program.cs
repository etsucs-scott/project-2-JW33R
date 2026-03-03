using System.Runtime.InteropServices;
using WarGame.Core;

GameEngine gameEngine = new GameEngine();
Deck deck = new Deck();
Console.WriteLine($"Deck has {deck.Cards.Count} cards.");
Console.WriteLine("How many Players are playing? (2-4)");
int countOfPlayers = int.Parse(Console.ReadLine());
gameEngine.StartGame(countOfPlayers);
foreach (Player p in gameEngine.Players)
{
    foreach (Card c in p.PlayerHands.Hand.Cards)
    {
        Console.WriteLine($"Player has {c.Rank} of {c.Suit}");
    }
}
