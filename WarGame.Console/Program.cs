using System.Runtime.InteropServices;
using WarGame.Cli;
using WarGame.Core;
ConsoleRender consoleRender = new ConsoleRender();

int round = 1;

Console.WriteLine("How many Players are playing? (2-4)");
int countOfPlayers = int.Parse(Console.ReadLine());
consoleRender.gameEngine.StartGame(countOfPlayers);
while (round < 10000 && consoleRender.gameEngine.EndGame() == true) 
{
    consoleRender.gameEngine.PlayRound();
    consoleRender.DisplayRoundCards(consoleRender.gameEngine.CountOfTies());
    consoleRender.DisplayPlayerCardCount();
    Console.WriteLine(consoleRender.gameEngine.PrintWinner(consoleRender.gameEngine.WinningCard));
    Console.ReadLine();
    round++;
}


