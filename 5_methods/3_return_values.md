# Create C# methods that return values

## Understand Return Type Syntax
- Methods can perform operations and also return values
- Include the return type in the method signature (before the method name)
- Using ```void``` means the method only performs operations and doesn't return a value
- Can return a variable or the result of an operation

    ```csharp
    // Return a variable example
    double GetDiscountedPrice(int itemIndex)
    {
        double result = items[itemIndex] * (1 - discounts[itemIndex]);
        return result;
    }

        // Return operation result
        double GetDiscountedPrice(int itemIndex)
    {
        return result = items[itemIndex] * (1 - discounts[itemIndex]);
    }
    ```

- Return a boolean value
    ```csharp
    bool TotalMeetsMinimum()
    {
        return total >= minimumSpend;
    }
    ```

- Full example
    ```csharp
    double total = 0;
    double minimumSpend = 30.00;

    double[] items = {15.97, 3.50, 12.25, 22.99, 10.98};
    double[] discounts = {0.30, 0.00, 0.10, 0.20, 0.50};

    for (int i = 0; i < items.Length; i++)
    {
        total += GetDiscountedPrice(i);
    }

    if (TotalMeetsMinimum())
    {
        total -= 5.00;
    }

    Console.WriteLine($"Total: ${FormatDecimal(total)}");

    double GetDiscountedPrice(int itemIndex)
    {
        double result = items[itemIndex] * (1 - discounts[itemIndex]);
        return result;
    }

    bool TotalMeetsMinimum()
    {
        return total >= minimumSpend;
    }

    string FormatDecimal(double input)
    {
        return input.ToString().Substring(0, 5);
    }
    ```

## Return Numbers from Methods
- Perform casting to return the correct number data type when needed
    ```csharp
    double usd = 23.73;
    int vnd = UsdToVnd(usd);

    Console.WriteLine($"${usd} USD = ${vnd} VND");
    Console.WriteLine($"${vnd} VND = ${VndToUsd(vnd)} USD");

    int UsdToVnd(double usd) 
    {
        int rate = 23500;
        return (int) (rate * usd);
    }

    double VndToUsd(int vnd)
    {
        double rate = 23500;
        return vnd / rate;
    }
    ```

## Return Strings from Methods
- Write a method to reverse a string without using ```String.Reverse```.
    ```csharp
    Console.WriteLine(ReverseWord("cucumber"));
    Console.WriteLine(ReverseWord("pineapple"));
    Console.WriteLine(ReverseWord("marshmallow"));

    string ReverseWord(string word) 
    {
        string result = "";
        for (int i = word.Length - 1; i >= 0; i--)
        {
            result += word[i];
        }

        return result;
    }
    ```

- Reverse words in a sentence maintaining their position in the sentence
- Use the ```ReverseWord``` method created previously
- Methods can call other methods
    ```csharp
    string input = "there are snakes at the zoo";
    Console.WriteLine(input);
    Console.WriteLine(ReverseSentence(input));


    string ReverseSentence(string input)
    {
        string result = "";
        string[] words = input.Split(" ");

        foreach (string word in words)
        {
            result += ReverseWord(word) + " ";
        }

        return result;
    }

    string ReverseWord(string word)
    {
        string result = "";
        for (int i = word.Length - 1; i >= 0; i--)
        {
            result += word[i];
        }

        return result;
    }
    ```

## Return Booleans from Methods
- Methods that return ```bool``` values can be called to evaluate data input anywhere (```if``` statements, variable declarations, etc.)
    ```csharp
    bool IsPalindrome(string word)
    {
        int start = 0;
        int end = word.Length - 1;

        while (start < end)
        {
            if (word[start] != word[end])
            {
                return false;
            }
            start++;
            end--;
        }

        return true;
    }
    ```

## Return Arrays from Methods
```csharp
int[] TwoCoins(int[] coins, int target) 
{
    for (int curr = 0; curr < coins.Length; curr++) 
    {
        for (int next = curr + 1; next < coins.Length; next++) 
        {
            return new int[]{curr, next};
        }
    }

    return  new int[0];
}
```

## Exercise: Game
- Make the game playable by creating correct methods and proper parameters and return types
- Game should select a target number that is a random number between one and 5 (inclusive)
- Player rolls a six-sided dice
- Player must roll a number greater than the target number
- At the end of each round, player should be asked if they would like to play again
- In the code that you start with, there are two unavailable methods referenced:
  - ```ShouldPlay```: This method should retrieve user input and determine if the user wants to play again
  - ```WinOrLose```: This method should determine if the player has won or lost
- There are also two uninitialized variables:
  - ```target```: The random target number between 1 and 5
  - ```roll```: The result of a random six-sided die roll
- Starter code:
    ```csharp
    Random random = new Random();

    Console.WriteLine("Would you like to play? (Y/N)");
    if (ShouldPlay()) 
    {
        PlayGame();
    }

    void PlayGame() 
    {
        var play = true;

        while (play) 
        {
            var target;
            var roll;

            Console.WriteLine($"Roll a number greater than {target} to win!");
            Console.WriteLine($"You rolled a {roll}");
            Console.WriteLine(WinOrLose());
            Console.WriteLine("\nPlay again? (Y/N)");

            play = ShouldPlay();
        }
    }
    ```

- [Solution](./solutions/exercise_dice_game/Program.cs)