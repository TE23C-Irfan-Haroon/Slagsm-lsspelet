using System.ComponentModel;
using System.Drawing;

Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

Player player = new();

Utils.Login(player);

string startGame = "yes";

while (startGame == "yes")
{
    Console.BackgroundColor = ConsoleColor.DarkGray;
    Console.ForegroundColor = ConsoleColor.Black;

    string choice = Utils.Menu(player);

   

    if (choice == "shop")
    {
        Utils.Shop(player);
        continue;
    }

    if (choice == "play")
    {
        Utils.PlayMenu(player);
    }

    Console.WriteLine("Type 'Return' To Continue");
    string menu = Console.ReadLine().ToLower();

    while (menu != "return")
    {
        menu = Console.ReadLine().ToLower();
        if (menu != "return")
        {
            Console.WriteLine("type return");
        }
    }
    if (menu == "return")
    {
        Console.Clear();
    }

}

Console.Clear();
Console.WriteLine("Thank you for playing");

Console.ReadLine();