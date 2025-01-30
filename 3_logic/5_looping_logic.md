# Add Looping Logic to Your Code Using the do-while and while Statements in C#

## Do-While Statement
- Execute a code block while a specific Boolean expression eavluates to true
- ```do-while``` loops exeutes at least once
- "Do" this thing "while" this thing evaluates to ```true```

    ```csharp
    do
    {
        // code
    } while (true)
    ```

- Example: Keep generating random numbers between 1 and 10 until you get 7

    ```csharp
    Random random = new Random();
    int current = 0;

    do
    {
        current = random.Next(1, 11);
        Console.WriteLine(current);
    } while (current != 7);
    ```csharp

## While Statement
- Execute a code block but first evaluate or check a condition first
- A ```while``` statement may never execute a block of code
- "While" this thing evaluates to ```true```, do something

    ```csharp
    while (true)
    {
        // code
    }
    ```

- Example: Only execute the code when a random number is greater than some value

    ```csharp
    Random random = new Random();
    int current = random.Next(1, 11);

    while (current >= 3)
    {
        Console.WriteLine(current);
        current = random.Next(1, 11);
    }

    Console.WriteLine($"Last number: {current}");
    ```

## Continue Statement
- Allows continuing to the next iteration without processing the remaining code block

    ```csharp
    Random random = new Random();
    int current = random.Next(1, 11);

    do
    {
        current = random.Next(1, 11);

        if (current >= 8) continue;

        Console.WriteLine(current);
    } while (current != 7);
    ```

## Exercise: Game Battle Challenge
- [Microsoft Solution](https://learn.microsoft.com/en-us/training/modules/csharp-do-while/4-solution)
- [My Solution](./solutions/game_battle_challenge/Program.cs)

## Challenge: Validate Integer Input
- [Microsoft Solution](https://learn.microsoft.com/en-us/training/modules/csharp-do-while/6-review-solution-differentiate-while-do-statements)
- [My Solution](./solutions/validate_integer_input/Program.cs)

## Challenge: Validate String Input
- [Microsoft Solution](https://learn.microsoft.com/en-us/training/modules/csharp-do-while/6-review-solution-differentiate-while-do-statements)
- [My Solution](./solutions/validate_string_input/Program.cs)

## Challenge: Process String Array
- [Microsoft Solution](https://learn.microsoft.com/en-us/training/modules/csharp-do-while/6-review-solution-differentiate-while-do-statements)
- [My Solution](./solutions/process_string_array/Program.cs)