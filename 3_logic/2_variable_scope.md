# Control Variable Scope and Logic Using Code Blocks in C#

## Variable Scope
- Code blocks define an execution path
- Code blocks also control or limit variable accessibility
- Variable scope refers to the portion of an application where a variable is accessible to other code in the application
- A locally scoped variable is only accessible inside of the code block where you define it
- The example below returns an error because ```value``` does not exist in the current context; it only exists in the ```if``` code block because that is where it is defined and given a value.

    ```csharp
    bool flag = true;
    
    if (flag)
    {
        int value = 10;
        Console.WriteLine($"Inside the code block: {value}");
    }
    
    Console.WriteLine($"Outside the code block: {value}");
    ```

- This example also errors as ```value``` does not have a value assigned to it yet to be used in the ```if``` code block

    ```csharp
    bool flag = true;
    int value;
    
    if (flag)
    {
        Console.WriteLine($"Inside the code block: {value}");
    }

    value = 10;
    Console.WriteLine($"Outside the code block: {value}");
    ```

- To resolve this, usually a good idea to initialize a variable with a value

    ```csharp
    bool flag = true;
    int value = 0;
    
    if (flag)
    {
        Console.WriteLine($"Inside the code block: {value}");
    }
    
    value = 10;
    Console.WriteLine($"Outside the code block: {value}");
    ```

## Compiler Code Interpretation
- C# compiler will analyze code in the editor and during the build process
- Consider these two examples

    ```csharp
    // Example 1
    bool flag = true;
    int value;
    
    if (flag)
    {
        value = 10;
        Console.WriteLine($"Inside the code block: {value}");
    }
    
    Console.WriteLine($"Outside the code block: {value}");
    ```
    
    ```csharp
    // Example 2
    int value;
    
    if (true)
    {
        value = 10;
        Console.WriteLine($"Inside the code block: {value}");
    }
    
    Console.WriteLine($"Outside the code block: {value}");
    ```

- In example 1, the compiler interprets the flag variable as being potentially assigned true or false
    - The compiler concludes that if the flag is false, then value will not be initialized for the second Console.WriteLine()
    - This results in an error during the build process
- In example 2, the if statement will always be executed because true is always true
    - This does not generate a build error

## Knowledge Check
- A developer writes some code that includes an if statement code block.
- They initialize one integer variable to a value of 5 above (outside) of the code block.
- They initialize a second integer variable to a value of 6 on the first line inside of the code block.
- The Boolean expression for the code block evaluates to true if the first integer variable has a value greater than 0.
- On the second line inside the code block, they assign the sum of the two values to the first variable.
- On the first line after the code block, they write code to display the value of the first integer.
- What is the result when the code statement used to display the first integer is executed?

    ```csharp
    int firstValue = 5;

    if (firstValue > 0)
    {
        int secondValue = 6;
        firstValue = firstValue + secondValue;
    }

    Console.WriteLine(firstValue);
    ```

- Answer: 11
- Since ```firstValue``` is initialized with a value, you do not have to worry about the ```if``` code block ever executing.

## Removing if statement code blocks
- If you realize you have only one line of code listed within the code blocks of an if-elseif-else statement, you can remove the curly braces of the code block and white space. Microsoft recommends that curly braces be used consistently for all of the code blocks of an if-elseif-else statement (either present or removed consistently).
- Only remove the curly braces of a code block when it makes the code more readable. It's always acceptable to include curly braces.
- Only remove the line feed if it makes the code more readable. Microsoft suggests that your code will be more readable when each statement is placed on its own code line.


    ```csharp
    string name = "steve";
    if (name == "bob") Console.WriteLine("Found Bob");
    else if (name == "steve") Console.WriteLine("Found Steve");
    else Console.WriteLine("Found Chuck");
    ```

## Exercise: Fix issues in the code
- Resolve issues in this code
- Should output:
    ```
    Set contains 42
    Total: 108
    ```

    ```csharp
    int[] numbers = { 4, 8, 15, 16, 23, 42 };

    foreach (int number in numbers)
    {
        int total;
        total += number;
        if (number == 42)
        {
           bool found = true;
        }
    }

    if (found) 
    {
        Console.WriteLine("Set contains 42");
    }

    Console.WriteLine($"Total: {total}");
    ```

- Solution
    - Initialize ```total``` and ```found``` outside the ```foreach``` block
    - Optional: Remove code blocks ```{ }``` from ```if``` statements

        ```csharp
        int[] numbers = { 4, 8, 15, 16, 23, 42 };
        int total = 0;
        bool found = false;

        foreach (int number in numbers)
        {
            total += number;
            if (number == 42)
            {
                found = true;
            }
        }

        if (found)
        {
            Console.WriteLine("Set contains 42");
        }

        Console.WriteLine($"Total: {total}");
        ```
