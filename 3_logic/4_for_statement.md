# Iterate Through a Code Block Using the for Statement in C#

## for Statement
- Iterates through a code block a specific number of times, unlike the ```foreach``` which iterates for each item in a sequence of data like an array or collection
- ```for``` statement gives more controls over the iteration process by exposing the iteration condition
- Begin with ```for``` keyword followed by a set of parentheses
    - The parentheses contains the iteration conditions
    - The first part defines and intializes the iterator variable (```int i = 0```)
    - The second part defines the completion condition or when the for statement should stop or complete (```i < 10```)
    - The third part defines the action to take after each iteration, typically incrementing or decrementing the iterator variable (```i++```)
    - Finally, the code block contains code executed for each iteration. You can reference the current iteration using the iterator variable ```i```
    - The following example outputs the number 0 - 9

        ```csharp
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
        ```

- Use the ```break``` keyword to break out of an iteration

    ```csharp
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(i);
        if (i == 7) break;
    }
    ```

## Loop through array elements
- While ```foreach``` is good for looping through arrays, you can also use ```for```, especially if you need some control over the manner in which the iteration happens
- Use ```.Length()``` method to retrieve the size of the array (minus 1 since array elements begin at index 0)

    ```csharp
    string[] names = { "Alex", "Eddie", "David", "Michael" };
    for (int i = names.Length - 1; i >= 0; i--)
    {
        Console.WriteLine(names[i]);
    }
    ```

- For example, use a ```for``` statement to modify the array contents when encountering a specific value

    ```csharp
    string[] names = { "Alex", "Eddie", "David", "Michael" };
    for (int i = 0; i < names.Length; i++)
        if (names[i] == "David") { names[i] = "Sammy" };

    foreach (var name in names) Console.WriteLine(name);
    ```

## Exercise: FizzBuzz Challenge
- Output values from 1 to 100, one number per line, inside the code block of an iteration statement.
- When the current value is divisible by 3, print the term Fizz next to the number.
- When the current value is divisible by 5, print the term Buzz next to the number.
- When the current value is divisible by both 3 and 5, print the term FizzBuzz next to the number.

- Solution: [fizzbuzz](./solutions/fizzbuzz/Program.cs)
