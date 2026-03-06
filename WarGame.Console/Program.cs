using System.Runtime.InteropServices;
using WarGame.Cli;
using WarGame.Core;
ConsoleRender consoleRender = new ConsoleRender();

int round = 1;

Console.WriteLine("How many Players are playing? (2-4)");
int countOfPlayers = int.Parse(Console.ReadLine());
consoleRender.gameEngine.StartGame(countOfPlayers);
while (round < 10000) 
{
    consoleRender.gameEngine.PlayRound();
    consoleRender.DisplayRoundCards(countOfPlayers);
    Console.WriteLine($"The Winner of this round is {consoleRender.gameEngine.CheckWinner().Rank} of {consoleRender.gameEngine.CheckWinner().Suit}");
    Console.ReadLine();
}


