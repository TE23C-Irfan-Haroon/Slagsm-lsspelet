
using System.Threading.Tasks.Dataflow;

public class Utils
{
    public static void Attack(Player attacker, Enemy defender, bool strongAttack)
    {
        // Metod för spelarens attack
        if (strongAttack)
        {
            if (Random.Shared.Next(2) != 0) // 50% chans att träffa
            {
                int damage = Random.Shared.Next(attacker.MinDamage + 8, attacker.MaxDamage + 11);
                defender.hp -= damage;
                Console.WriteLine($"{attacker.username} did {damage} damage to {defender.name}");
            }
            else
            {
                Console.WriteLine($"{attacker.username} missed the attack");
            }
        }
        else
        {
            if (Random.Shared.Next(5) != 0)  // 80% chans att träffa
            {
                int damage = Random.Shared.Next(attacker.MinDamage, attacker.MaxDamage + 1);
                defender.hp -= damage;
                Console.WriteLine($"{attacker.username} did {damage} damage to {defender.name}");
            }
            else
            {
                Console.WriteLine($"{attacker.username} missed the attack");
            }
        }
    }

    public static void Attack(Enemy attacker, Player defender, bool strongAttack)
    {
        // Metod för enemies attack 
        if (Random.Shared.Next(5) != 0) // 80% chans att träffa
        {
            int damage = Random.Shared.Next(attacker.MinDamage, attacker.MaxDamage + 1);
            defender.hp -= damage;
            Console.WriteLine($"{attacker.name} did {damage} damage to {defender.username}");
        }
        else
        {
            Console.WriteLine($"{attacker.name} missed the attack");
        }

    }

    public static void FightRound(Player player, Enemy enemy)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();

         // En ny runda i striden startas
        Console.WriteLine("----------==== NEW ROUND ====----------");
        Console.WriteLine($"{player.username} HP: {player.hp} | {enemy.name} HP: {enemy.hp}");
        Console.WriteLine($"{player.username} MaxDamage: {player.MaxDamage} | {enemy.name} MaxDamage: {enemy.MaxDamage}");
        
        // Spelaren väljer attack
        Console.WriteLine("Choose your attack: 1) High chance to hit, lower damage OR 2) Low chance to hit, higher damage");
        string attackChoice = Console.ReadLine();

        while (attackChoice != "1" && attackChoice != "2")
        {
            Console.WriteLine("Choose between 1 or 2");
            attackChoice = Console.ReadLine();
        }

        bool strongAttack;
        if (attackChoice == "2")
        {
            strongAttack = true;
        }
        else
        {
            strongAttack = false;
        }

         // Spelaren attackerar först
        Attack(player, enemy, strongAttack);

        // Fienden attackerar om den fortfarande lever
        if (enemy.hp > 0)
        {
            Attack(enemy, player, false);
        }

        Console.ReadLine();
    }


    public static bool Fight(Player player, Enemy currentEnemy, int coinReward, int coinRewardLoss, int coinRewardDraw)
    {
        // fight mellan spelaren och fiende
        Console.Clear();

        while (player.hp > 0 && currentEnemy.hp > 0)
        {
            FightRound(player, currentEnemy);
        }

        Console.WriteLine("------==== FIGHT IS OVER ====------");
        bool won = false; 

        // Avgör resultatet av striden
        if (player.hp <= 0 && currentEnemy.hp <= 0)
        {
            Console.WriteLine("Round Drawn");
            player.coins += coinRewardDraw;
            Console.WriteLine($"You earned {coinRewardDraw} coins! You now have {player.coins} coins.");
        }
        else if (player.hp <= 0)
        {
            Console.WriteLine($"{currentEnemy.name} WON!");
            player.coins += coinRewardLoss;
            Console.WriteLine($"You earned {coinRewardLoss} coins! You now have {player.coins} coins.");
        }
        else
        {
            Console.WriteLine($"{player.username} WON!");
            player.coins += coinReward;
            Console.WriteLine($"You earned {coinReward} coins! You now have {player.coins} coins.");
            won = true;
        }

        player.hp = player.MaxHP; // Återställ spelarens HP
        return won;
    }


    public static void Login(Player player)
    {
        // Spelaren skriver in sitt användarnamn
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
    }

    public static string Menu(Player player)
    {
        // Huvudmenyn
        string choice = "";
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

            if (choice == "exit")
            {
                return "";
            }
        }

        return choice;

    }

    public static void PlayMenu(Player player)
    {
        // Spelaren väljer en fiende att slåss mot
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

        bool won = Utils.Fight(player, currentEnemy, coinReward, coinRewardLoss, coinRewardDraw);

        if (won == true)
        {
            Console.WriteLine("CONGRATS YOU WON");
        }
    }

 public static void Shop(Player player)
    {
        // shop där man kan köpa uppgraderingar
        while (true)
        {
            int shopChoice = Utils.ShopMenu(player);

            if (shopChoice == 1)
            {
               Utils.ShopHp(player);
            }
            else if (shopChoice == 2)
            {
                Utils.ShopMaxDamage(player);
            }
            else if (shopChoice == 3)
            {
               Utils.ShopMinDamage(player);
            }

            if (shopChoice == 4)
            {
                break;
            }

        }
    }
    public static int ShopMenu(Player player)
    {
        // Menyn för shopen
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
        Console.WriteLine("Welcome to the Shop!");
        Console.WriteLine($"You have {player.coins} coins.");
        Console.WriteLine("1. Upgrade Armor (Increase HP by 20)  Cost: 15 coins");
        Console.WriteLine("2. Upgrade Sword Damage (Increase MaxDamage by 10)  Cost: 20 coins");
        Console.WriteLine("3. Upgrade Sword Reliablity (Increase MinDamage by 2)  Cost: 5 coins");
        Console.WriteLine("4. Exit Shop");
        Console.WriteLine("Choose an option: 1, 2, 3, or 4");

        int shopChoice;
        while (!int.TryParse(Console.ReadLine(), out shopChoice) || shopChoice < 1 || shopChoice > 4)
        {
            Console.WriteLine("Invalid input. Please Choose a valid option");
        }

        return shopChoice;
    }

public static void ShopHp(Player player)
{
    // Metod för att uppgradera spelarens HP om de har tillräckligt med mynt
   if (player.coins >= 15)
                {
                    player.hp += 20;
                    player.MaxHP = player.hp;
                    player.coins -= 15;
                    Console.WriteLine($"Your HP is now {player.hp}/{player.MaxHP}. You have {player.coins} coins left.");
                }
                else
                {
                    Console.WriteLine("You don't have enough coins for this purchase.");
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
}
public static void ShopMaxDamage(Player player)
{
    // Metod för att uppgradera spelarens maxDamage om de har tillräckligt med mynt
  if (player.coins >= 20)
                {
                    player.MaxDamage += 10;
                    player.coins -= 20;
                    Console.WriteLine($"Your maximum damage is now {player.MaxDamage}. You have {player.coins} coins left.");
                }
                else
                {
                    Console.WriteLine("You don't have enough coins for this purchase.");
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
}

public static void ShopMinDamage(Player player)
{
    // Metod för att uppgradera spelarens minDamage om de har tillräckligt med mynt
   if (player.coins >= 5)
                {
                    player.MinDamage += 2;
                    player.coins -= 5;
                    Console.WriteLine($"Your minimum damage is now {player.MinDamage}. You have {player.coins} coins left.");
                }
                else
                {
                    Console.WriteLine("You don't have enough coins for this purchase.");
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
}
}

