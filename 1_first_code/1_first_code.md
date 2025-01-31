# Write your first C# code

## How Does C# Work
- Programming languages like C# enable you to write instructions for the computer to carry out
- Languages have different syntax but similar concepts
- Syntax are the rules for writing code
- Compilers take human readable code and convert it to a different format that the CPU can understand and operate on

## Classes
- Classes have methods, or methods live inside of a class
- In order to use methods, you need to know what classes they are in
- A dot (or period) is the member access operator; it is how you access methods in a class (e.g. Console.WriteLine();)
- Methods have parentheses after it to pass in input (if needed)
- Semicolon is the end of statement operator; statements are complete instructions in C#; the semicolon tells the compiler you've finished entering the command

- Example code:
    ```csharp
    Console.WriteLine("Hello, World!);
    ```

## Challenge
- Write code the produces the following output using both ```Console.WriteLine()``` and ```Console.Write()``` in the solution.

    ```
    This is the first line.
    This is the second line.
    ```

- Solution

    ```csharp
    Console.WriteLine("This is the first line.");
    Console.Write("This is the ");
    Console.Write("second line.");
    ```
