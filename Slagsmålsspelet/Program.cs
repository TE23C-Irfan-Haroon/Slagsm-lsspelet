using System.ComponentModel;

string username = "";


Console.WriteLine("Write your username for your fighter:");

while (username.Length < 3 || username.Length > 10)
{
    username = Console.ReadLine();
    if (username.Length < 3)
    {
        Console.WriteLine("Username cannot be less then 3 words. Please try again.");
    }
    if (username.Length > 10)
    {
        Console.WriteLine("Username cannot have more than 10 words. Please try again.");
        username = Console.ReadLine();
    }
}

string player1 = username;
int player1hp = 100;
int player1MaxHP = 100;
int player1MaxDamage = 10;
int player1MinDamage = 2;
int coins = 0;

string playagain = "yes";

while (playagain == "yes")
{

    int enemyHP = 100;
    int enemyMaxDamage = 10;
    int enemyMinDamage = 2; 

    Console.Clear();
    Console.WriteLine($"Welcome {username}!");
    Console.WriteLine("Would you like to 'play' a match or visit the 'shop'? Type 'play' or 'shop'.");
    Console.WriteLine($"You have {coins} coins.");
    Console.WriteLine($"You have {player1hp} HP.");
    Console.WriteLine($"Your damage range: {player1MinDamage} - {player1MaxDamage}"); 
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
            Console.Clear();
            Console.WriteLine("Welcome to the Shop!");
            Console.WriteLine($"You have {coins} coins.");
            Console.WriteLine("1. Upgrade Armor (Increase HP by 20)  Cost: 15 coins");
            Console.WriteLine("2. Upgrade Weapon (Increase MaxDamage by 10)  Cost: 20 coins");
            Console.WriteLine("3. Increase Minimum Damage by 2  Cost: 5 coins");
            Console.WriteLine("4. Exit Shop");
            Console.WriteLine("Choose an option: 1, 2, 3, or 4");
            string shopChoice = Console.ReadLine();

            if (shopChoice == "1")
            {
                if (coins >= 15)
                {
                    player1MaxHP += 20;
                    player1hp = player1MaxHP;
                    coins -= 15;
                    Console.WriteLine($"Your HP is now {player1hp}/{player1MaxHP}. You have {coins} coins left.");
                }
                else
                {
                    Console.WriteLine("Not enough coins.");
                }
            }
            else if (shopChoice == "2")
            {
                if (coins >= 20)
                {
                    player1MaxDamage += 10;
                    coins -= 20;
                    Console.WriteLine($"Your maximum damage is now {player1MaxDamage}. You have {coins} coins left.");
                }
                else
                {
                    Console.WriteLine("Not enough coins.");
                }
            }
             else if (shopChoice == "3")
            {
                if (coins >= 5)
                {
                    player1MinDamage += 2;
                    coins -= 5;
                    Console.WriteLine($"Your minimum damage is now {player1MinDamage}. You have {coins} coins left.");
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
        
        while (player1hp > 0 && enemyHP > 0)
        {
            Console.WriteLine("----------====NEW ROUND====----------");
            Console.WriteLine($"{player1} HP: {player1hp} {enemy} HP: {enemyHP}");
            Console.WriteLine($"{player1} MaxDamage: {player1MaxDamage} {enemy} MaxDamage: {enemyMaxDamage}");


            // Slumpa ett tal 0-4
            // Om talet är 0: MISS
            // Annars:

            int player1Attack = Random.Shared.Next(4);
            if (player1Attack == 0)
            {
                Console.WriteLine($"{player1} missed the attack");
            }
            else 
            {
                int player1damage = Random.Shared.Next(player1MinDamage, player1MaxDamage + 1);
                enemyHP -= player1damage;
                 Console.WriteLine($"{player1} did {player1damage} damage to {enemy}");
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
                 player1hp -= enemyDamage;
                 Console.Write($"{enemy} did {enemyDamage} damage to {player1}");
                 Console.ReadLine();
            }
        
        }

        Console.WriteLine("------====FIGHT IS OVER====------");

        if (player1hp <= 0 && enemyHP <= 0)
        {
            Console.WriteLine("Round Drawn");
            coins += coinRewardDraw;
            Console.WriteLine($"You earned {coinRewardDraw} coins! You now have {coins} coins.");
        }
        else if (player1hp <= 0)
        {
            Console.WriteLine($"{enemy} WON!");
            coins += coinRewardLoss;
            Console.WriteLine($"You earned {coinRewardLoss} coins! You now have {coins} coins.");
        }
        else
        {
            Console.WriteLine($"{player1} WON!");
            coins += coinReward;
            Console.WriteLine($"You earned {coinReward} coins! You now have {coins} coins.");
        }

        player1hp = player1MaxHP;
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