using System.ComponentModel;
using System.Drawing;
Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();

Player player = new();

Console.WriteLine("Write your username for your fighter:");
player.username = Console.ReadLine();


while (player.username.Length < 3 || player.username.Length > 10)
{
    player.username = Console.ReadLine();
    if (player.username.Length < 3)
    {
        Console.WriteLine("Username cannot be less then 3 words. Please try again.");
    }
    if (player.username.Length > 10)
    {
        Console.WriteLine("Username cannot have more than 10 words. Please try again.");
        player.username = Console.ReadLine();
    }
}

string playagain = "yes";

while (playagain == "yes")
{

    int enemyHP = 100;
    int enemyMaxDamage = 10;
    int enemyMinDamage = 2;


    
    Console.BackgroundColor = ConsoleColor.DarkGray;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.WriteLine($"Welcome {player.username}!");
    Console.WriteLine("Would you like to 'play' a match or visit the 'shop'? Type 'play' or 'shop'.");
    Console.WriteLine($"You have {player.coins} coins.");
    Console.WriteLine($"You have {player.hp} HP.");
    Console.WriteLine($"Your damage range: {player.MinDamage} - {player.MaxDamage}");
    Console.WriteLine("TYPE 'EXIST' TO CLOSE THE GAME");
    string choice = Console.ReadLine().ToLower();

    if (choice == "exist")
    {
        return;
    }

    while (choice != "play" && choice != "shop")
    {
        Console.WriteLine("Please type 'play' or 'shop'.");
        choice = Console.ReadLine().ToLower();
    }

    if (choice == "shop")
    {
        while (true)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Welcome to the Shop!");
            Console.WriteLine($"You have {player.coins} coins.");
            Console.WriteLine("1. Upgrade Armor (Increase HP by 20)  Cost: 15 coins");
            Console.WriteLine("2. Upgrade Weapon (Increase MaxDamage by 10)  Cost: 20 coins");
            Console.WriteLine("3. Increase Minimum Damage by 2  Cost: 5 coins");
            Console.WriteLine("4. Exit Shop");
            Console.WriteLine("Choose an option: 1, 2, 3, or 4");
            string shopChoice = Console.ReadLine();

            if (shopChoice == "1")
            {
                if (player.coins >= 15)
                {
                    player.hp += 20;
                    player.MaxHP = player.hp;
                    player.coins -= 15;
                    Console.WriteLine($"Your HP is now {player.hp}/{player.MaxHP}. You have {player.coins} coins left.");
                }
                else
                {
                    Console.WriteLine("Not enough coins.");
                }
            }
            else if (shopChoice == "2")
            {
                if (player.coins >= 20)
                {
                    player.MaxDamage += 10;
                    player.coins -= 20;
                    Console.WriteLine($"Your maximum damage is now {player.MaxDamage}. You have {player.coins} coins left.");
                }
                else
                {
                    Console.WriteLine("Not enough coins.");
                }
            }
            else if (shopChoice == "3")
            {
                if (player.coins >= 5)
                {
                    player.MinDamage += 2;
                    player.coins -= 5;
                    Console.WriteLine($"Your minimum damage is now {player.MinDamage}. You have {player.coins} coins left.");
                }
                else
                {
                    Console.WriteLine("Not enough coins.");
                }
            }
            else if (shopChoice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please choose a valid option.");
            }
            shopChoice = Console.ReadLine();

        }
        continue;
    }

    if (choice == "play")
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("Choose who you want to figth:");
        Console.WriteLine("Level 1:Mario");
        Console.WriteLine("Level 2:Ironman");
        Console.WriteLine("Level 3:Kratos");
        Console.WriteLine("Choose between 1,2 or 3");

        string enemy = Console.ReadLine().ToLower();


        while (enemy != "1" && enemy != "2" && enemy != "3")
        {
            Console.WriteLine("Chose between 1, 2 Or 3");
            enemy = Console.ReadLine();

            if (enemy != "1" && enemy != "2" && enemy != "3")
            {
                Console.WriteLine("You have to chose between the options 1, 2 Or 3");
                enemy = Console.ReadLine();
            }
        }

        int coinReward = 0;
        int coinRewardLoss = 5;
        int coinRewardDraw = 10;


        if (enemy == "1")
        {
            enemy = "Mario";
            coinReward = 15;
        }
        else if (enemy == "2")
        {
            enemy = "Ironman";
            enemyMaxDamage = 20;
            enemyMinDamage = 5;
            enemyHP = 150;
            coinReward = 30;
        }
        else if (enemy == "3")
        {
            enemy = "Kratos";
            enemyMaxDamage = 40;
            enemyMinDamage = 10;
            enemyHP = 200;
            coinReward = 50;
        }

        Console.Clear();

        while (player.hp > 0 && enemyHP > 0)
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("----------====NEW ROUND====----------");
            Console.WriteLine($"{player.username} HP: {player.hp} {enemy} HP: {enemyHP}");
            Console.WriteLine($"{player.username} MaxDamage: {player.MaxDamage} {enemy} MaxDamage: {enemyMaxDamage}");


            Console.WriteLine("Choose your attack: 1) High chance to hit, lower damage OR 2) Low chance to hit, higher damage");
            string attackChoice = Console.ReadLine();

            while (attackChoice != "1" && attackChoice != "2")
            {
                Console.WriteLine("Chose between 1 or 2");
                attackChoice = Console.ReadLine();

                if (attackChoice != "1" && attackChoice != "2")
                {
                    Console.WriteLine("You have to chose between the options 1 or 2");
                    attackChoice = Console.ReadLine();
                }
            }

            if (attackChoice == "1")
            {

                int player1Attack = Random.Shared.Next(5);
                if (player1Attack == 0)
                {
                    Console.WriteLine($"{player.username} missed the attack");
                }
                else
                {
                    int player1damage = Random.Shared.Next(player.MinDamage, player.MaxDamage + 1);
                    enemyHP -= player1damage;
                    Console.WriteLine($"{player.username} did {player1damage} damage to {enemy}");
                }

            }

            else if (attackChoice == "2")
            {

                int player1Attack = Random.Shared.Next(2);
                if (player1Attack == 0)
                {
                    Console.WriteLine($"{player.username} missed the attack");
                }
                else
                {
                    int player1damage = Random.Shared.Next(player.MinDamage + 8, player.MaxDamage + 11);
                    enemyHP -= player1damage;
                    Console.WriteLine($"{player.username} did {player1damage} damage to {enemy}");
                }


            }

            int enemyAttack = Random.Shared.Next(4);
            if (enemyAttack == 0)
            {
                Console.WriteLine($"{enemy} missed the attack");
                Console.ReadLine();
            }
            else
            {
                int enemyDamage = Random.Shared.Next(enemyMinDamage, enemyMaxDamage + 1);
                player.hp -= enemyDamage;
                Console.Write($"{enemy} did {enemyDamage} damage to {player.username}");
                Console.ReadLine();
            }
            Console.Clear();

        }

        Console.WriteLine("------====FIGHT IS OVER====------");

        if (player.hp <= 0 && enemyHP <= 0)
        {
            Console.WriteLine("Round Drawn");
            player.coins += coinRewardDraw;
            Console.WriteLine($"You earned {coinRewardDraw} coins! You now have {player.coins} coins.");
        }
        else if (player.hp <= 0)
        {
            Console.WriteLine($"{enemy} WON!");
            player.coins += coinRewardLoss;
            Console.WriteLine($"You earned {coinRewardLoss} coins! You now have {player.coins} coins.");
        }
        else
        {
            Console.WriteLine($"{player.username} WON!");
            player.coins += coinReward;
            Console.WriteLine($"You earned {coinReward} coins! You now have {player.coins} coins.");
        }

        player.hp = player.MaxHP;
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




    // Console.WriteLine("Do you want to play again? 'Yes' or 'No'");
    // playagain = Console.ReadLine().ToLower();

    // while (playagain != "yes" && playagain != "no")
    // {
    // playagain = Console.ReadLine().ToLower();
    // if (playagain != "yes" && playagain != "no")
    // {
    //     Console.WriteLine("'Yes' or 'No'");
    // }

    // }

    // if (playagain == "yes")
    // {
    //     Console.Clear();
    // }

}

Console.Clear();
Console.WriteLine("Thank you for playing");

Console.ReadLine();