using System.Runtime.InteropServices;
using WarGame.Cli;
using WarGame.Core;
ConsoleRender consoleRender = new ConsoleRender();

int round = 1;
int roundCap = 10000;

Console.WriteLine("How many Players are playing? (2-4)");
int countOfPlayers = int.Parse(Console.ReadLine());
consoleRender.GameEngine.StartGame(countOfPlayers);
Console.Clear();
while (round < roundCap && consoleRender.GameEngine.EndGame() == true) 
{
    consoleRender.GameEngine.PlayRound();
    Console.WriteLine($"Round {round}");
    Console.WriteLine("---------------------------");
    consoleRender.DisplayRoundCards();
    Console.WriteLine("---------------------------");
    Console.WriteLine("Ties:");
    consoleRender.DisplayTiedCard();
    Console.WriteLine("\n---------------------------");
    consoleRender.DisplayPlayerCardCount();
    Console.WriteLine($"\n{consoleRender.GameEngine.PrintWinner(consoleRender.GameEngine.WinningCard)}");
    Console.ReadLine();
    round++;
    Console.Clear();
    consoleRender.DisplayFinalCard(round, roundCap);
}
Thread.Sleep( 1000 );



