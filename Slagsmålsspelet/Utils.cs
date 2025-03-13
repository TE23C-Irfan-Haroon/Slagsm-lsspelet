
public class Utils
{
    public static void Shop(Player player)
    {
        while (true)
        {
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

            if (shopChoice == 1)
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
                    Console.WriteLine("You don't have enough coins for this purchase.");
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine(); // Väntar på input så spelaren ser texten
            }
            else if (shopChoice == 2)
            {
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
                Console.ReadLine(); // Väntar på input så spelaren ser texten
            }
            else if (shopChoice == 3)
            {
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

            if (shopChoice == 4)
            {
                break;
            }

        }
    }


    public static void Attack(Player attacker, Enemy defender, bool strongAttack) 
    {
          // Metod för spelarens attack
        if (strongAttack)
        {
            if (Random.Shared.Next(2) != 0)
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
            if (Random.Shared.Next(5) != 0)
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
        if (Random.Shared.Next(5) != 0)
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
        Console.WriteLine("----------==== NEW ROUND ====----------");
        Console.WriteLine($"{player.username} HP: {player.hp} | {enemy.name} HP: {enemy.hp}");
        Console.WriteLine($"{player.username} MaxDamage: {player.MaxDamage} | {enemy.name} MaxDamage: {enemy.MaxDamage}");

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

        Attack(player, enemy, strongAttack);

        if (enemy.hp > 0)
        {
            Attack(enemy, player, false);
        }

        Console.ReadLine();
    }


    public static void Fight(Player player, Enemy currentEnemy, int coinReward, int coinRewardLoss, int coinRewardDraw)
    {
        Console.Clear();

        while (player.hp > 0 && currentEnemy.hp > 0)
        {
            FightRound(player, currentEnemy);
        }

        Console.WriteLine("------==== FIGHT IS OVER ====------");

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
        }

        player.hp = player.MaxHP;
    }

}
