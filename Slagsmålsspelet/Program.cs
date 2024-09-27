

int player1hp = 100;
int player2hp = 100; 

int enemyMaxDamage = 10;

string username;

Console.WriteLine("Write your username for your fighter:");
username = Console.ReadLine();

string player1 = username; 

Console.WriteLine("Choose who you want to figth:");
Console.WriteLine("Level 1:Mario");
Console.WriteLine("Level 2:Ironman");
Console.WriteLine("Level 3:Kratos");
Console.WriteLine("Choose between 1,2 or 3");

string player2 = Console.ReadLine().ToLower();

if (player2 == "1")
{
    player2 = "Mario";
}
else if (player2 == "2")
{
    player2 = "Ironman";
    enemyMaxDamage = 20;
}
else if (player2 == "3")
{
    player2 = "Kratos";
    enemyMaxDamage = 40;
}
// if (player2 != "1" &&  player2 != "2" && player2 != "3")
// {
//     Console.WriteLine("Choose between 1,2 or 3");
// }

while (player2 != "1" && player2 != "2" && player2 != "3")
{
    Console.WriteLine("Chose between 1, 2 Or 3");
    player2 = Console.ReadLine();

    if (player2 != "1" && player2 != "2" && player2 != "3")
    {
        Console.WriteLine("You have to chose between the options 1, 2 Or 3");
        player2 = Console.ReadLine();
    }
}

while (player1hp > 0 && player2hp > 0)
{
    Console.WriteLine("----------====NEW ROUND====----------");
    Console.WriteLine($"{player1}: {player1hp} {player2}: {player2hp}");


    int player1damage = Random.Shared.Next(20);
    player2hp -= player1damage; 
    
    int player2damage = Random.Shared.Next(enemyMaxDamage);
    player1hp -= player2damage;

    Console.WriteLine($"{player1} did {player1damage} damage to {player2}");
    Console.WriteLine($"{player2} did {player2damage} damage to {player1}");


    Console.ReadLine();
}
 Console.ReadLine();