using System.ComponentModel;
using System.Drawing;

Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

Player player = new();

Console.WriteLine("Write your username for your fighter:");

while (player.username.Length < 3 || player.username.Length > 10)
{
    player.username = Console.ReadLine();
    if (player.username.Length < 3)
    {
        Console.Clear();
        Console.WriteLine("Write your username for your fighter:");
        Console.WriteLine("Username cannot be less then 3 words. Please try again.");
    }
    else if (player.username.Length > 10)
    {
        Console.Clear();
        Console.WriteLine("Write your username for your fighter:");
        Console.WriteLine("Username cannot have more than 10 words. Please try again.");
    }

}

string startGame = "yes";

while (startGame == "yes")
{
    Console.BackgroundColor = ConsoleColor.DarkGray;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.WriteLine($"Welcome {player.username}!");
    Console.WriteLine("Would you like to 'play' a match or visit the 'shop'? Type 'play' or 'shop'.");
    Console.WriteLine($"You have {player.coins} coins.");
    Console.WriteLine($"You have {player.hp} HP.");
    Console.WriteLine($"Your damage range: {player.MinDamage} - {player.MaxDamage}");
    Console.WriteLine("TYPE 'EXIT' TO CLOSE THE GAME");
    string choice = Console.ReadLine().ToLower();
    if (choice == "exit")
    {
        return;
    }

    while (choice != "play" && choice != "shop")
    {
        Console.Clear();
        Console.WriteLine($"Welcome {player.username}!");
        Console.WriteLine("Would you like to 'play' a match or visit the 'shop'? Type 'play' or 'shop'.");
        Console.WriteLine($"You have {player.coins} coins.");
        Console.WriteLine($"You have {player.hp} HP.");
        Console.WriteLine($"Your damage range: {player.MinDamage} - {player.MaxDamage}");
        Console.WriteLine("TYPE 'EXIT' TO CLOSE THE GAME");
        Console.WriteLine("Please type 'play' or 'shop'.");
        choice = Console.ReadLine().ToLower();
    }

    if (choice == "shop")
    {
        Utils.Shop(player);
        continue;
    }

    if (choice == "play")
    {
        // List is used instead of an array because if we want to add more enemies its easier and more effective to use a list
        List<Enemy> enemies = new List<Enemy>
        {
             new Enemy { name = "Mario", MaxDamage = 10, MinDamage = 2, hp = 100 },
             new Enemy { name = "Ironman", MaxDamage = 20, MinDamage = 5, hp = 150 },
             new Enemy { name = "Kratos", MaxDamage = 40, MinDamage = 10, hp = 200 }
        };

        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("Choose who you want to fight:");
        for (int i = 0; i < enemies.Count; i++)
        {
            Console.WriteLine($"Level {i + 1}: {enemies[i].name}");
        }
        Console.WriteLine("Choose between 1, 2, or 3");

        string level = Console.ReadLine().ToLower();

        while (level != "1" && level != "2" && level != "3")
        {
            Console.WriteLine("Choose between 1, 2, or 3"); 
            level = Console.ReadLine();
        }

        int enemyNum = int.Parse(level) - 1;
        Enemy currentEnemy = enemies[enemyNum]; // Get enemy from the list

        int[] coinRewards = { 15, 30, 50 }; // Rewards for levels 1, 2, 3
        int coinReward = coinRewards[enemyNum];
        int coinRewardLoss = 5;
        int coinRewardDraw = 10;

        Utils.Fight(player, currentEnemy, coinReward, coinRewardLoss, coinRewardDraw);
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