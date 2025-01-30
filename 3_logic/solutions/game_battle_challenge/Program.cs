/*
    - You must use either the do-while statement or the while statement as an outer game loop.
    - The hero and the monster start with 10 health points.
    - All attacks are a value between 1 and 10.
    - The hero attacks first.
    - Print the amount of health the monster lost and their remaining health.
    - If the monster's health is greater than 0, it can attack the hero.
    - Print the amount of health the hero lost and their remaining health.
    - Continue this sequence of attacking until either the monster's health or hero's health is zero or less.
    - Print the winner.
*/

Random random = new Random();
int heroHealth = 10;
int monsterHealth = 10;
int round = 1;

while (heroHealth > 0 && monsterHealth > 0)
{
    Console.WriteLine($"\nROUND {round}");
    Console.WriteLine("---------------------------------------------");

    int heroAttack = random.Next(1, 11);
    monsterHealth -= heroAttack;
    Console.WriteLine($"The hero strikes the monster for {heroAttack} damage! (Monster: {monsterHealth})");    

    if (monsterHealth > 0)
    {
        int monsterAttack = random.Next(1, 11);
        heroHealth -= monsterAttack;
        Console.WriteLine($"The monster attacks the hero for {monsterAttack} damage! (Hero: {heroHealth})");
    }
    round++;
}

Console.WriteLine(heroHealth > monsterHealth
    ? "\n🎉 Hooray! The hero has slain the monster!"
    : "\n☠️  Oh no! The monster has killed the hero!");
