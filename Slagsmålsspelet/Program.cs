using System.ComponentModel;
using System.Drawing;

Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

Player player = new();  // Skapar en ny spelare

Utils.Login(player); // Körs Login metod och spelaren loggar in genom att ange ett användarnamn

bool startGame = true;

while (startGame) // Huvudloop för spelet
{
    Console.BackgroundColor = ConsoleColor.DarkGray;
    Console.ForegroundColor = ConsoleColor.Black;

    string choice = Utils.Menu(player); // Visar menyn och tar emot spelarens val

   

    if (choice == "shop") // Om spelaren väljer shop då körs shop metoden
    {
        Utils.Shop(player);
        continue; // Hoppar över resten av loopen och visar menyn igen
    }

    if (choice == "play") // Om spelaren väljer att spela en match då kör play mmenu metoden som tar spelaren till att välja level
    {
        Utils.PlayMenu(player);
    }

    Console.WriteLine("Type 'Return' To Continue");
    string menu = Console.ReadLine().ToLower();

    while (menu != "return")  // Loopar tills spelaren skriver rätt kommando
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