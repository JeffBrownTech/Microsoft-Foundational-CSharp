# Add decision logic to your code using `if`, `else`, and `else if` statements in C#

## Create Decision Logic
- Code branches - different execution paths based logic results
- Boolean Expression
  - Code that returns a Boolean value (True or False)
  - Can also be result of a method that returns the value true or false (string.Contains())
        ```csharp
        string message = "The quick brown fox jumps over the lazy dog.";
        bool result = message.Contains("dog");
        Console.WriteLine(result);
        
        if (message.Contains("fox"))
        {
            Console.WriteLine("What does the fox say?");
        }
        ```
        
- Operators: ==, >, <, >=, <=
- Can do compound conditions (or ||, and &&)

## Code blocks
- Collection of one or more lines of code defined by an opening and closing curly brace symbol { }
- Complete unit of code with a single purpose
- Code blocks can be nested within one another

    ```csharp    
    Random dice = new Random();
    int roll1 = dice.Next(1, 7);
    int roll2 = dice.Next(1, 7);
    int roll3 = dice.Next(1, 7);
    int total = roll1 + roll2 + roll3;
    
    Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");
    
    if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
    {
        Console.WriteLine("You rolled doubles! +2 bonus to total!");
        total += 2;
        Console.WriteLine($"New total: {total}");
    }
    if ((roll1 == roll2) && (roll2 == roll3)) 
    {
        Console.WriteLine("You rolled triples! +6 bonus to total!");
        total += 6;
    }
    if (total >= 15)
    {
        Console.WriteLine("You win!");
    }
    if (total < 15)
    {
        Console.WriteLine("Sorry, you lose.");
    }
    ```
    
- Update with nested if statements and prizes
    
    ```csharp
    Random dice = new Random();
    int roll1 = dice.Next(1, 7);
    int roll2 = dice.Next(1, 7);
    int roll3 = dice.Next(1, 7);
    int total = roll1 + roll2 + roll3;
    Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");
    if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
    {
        if ((roll1 == roll2) && (roll2 == roll3))
        {
            Console.WriteLine("You rolled triples!  +6 bonus to total!");
            total += 6;
        }
        else
        {
            Console.WriteLine("You rolled doubles!  +2 bonus to total!");
            total += 2;
        }
        Console.WriteLine($"New Total: {total}");
    }
    if (total >= 16) {
        Console.WriteLine("You won a new car!");
    }
    else if (total >= 10) {
        Console.WriteLine("You won a new laptop!");
    }
    else if (total == 7) {
        Console.WriteLine("You won a trip!");
    }
    else {
        Console.WriteLine("You won a kitten!");
    }
    ```
    
## Exercise: Subscription discount checker
- Display a renewal message when a user logs into the software system and is notified their subscription will soon end

    ```csharp
    Random random = new Random();
    int daysUntilExpiration = random.Next(12); //0 - 11
    int discountPercentage = 0;
    Console.WriteLine($"Days Until Expiration: {daysUntilExpiration}\n");
    
    if (daysUntilExpiration == 0)
    {
        Console.WriteLine("You subscription has expired.");
    }
    else if (daysUntilExpiration == 1)
    {
        discountPercentage = 20;
        Console.WriteLine("Your subscription expires within a day!");
    }
    else if (daysUntilExpiration <= 5)
    {
        discountPercentage = 10;
        Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
    }
    else if (daysUntilExpiration <= 10)
    {
        Console.WriteLine("Your subscription will expire soon. Renew now!");
    }
    
    if (discountPercentage > 0)
    {
        Console.WriteLine($"Renew now and save {discountPercentage}%!");
    }
    ```