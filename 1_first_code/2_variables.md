# Store and retrieve data using literal and variable values in C#

## Literal Values
- Literal value is a constant value that never changes
- Use single quotes to create a character (char) literal
    ```csharp
    Console.WriteLine('h');
    ```

- Use double quotes creates a string data type
    ```csharp
    Console.WriteLine("Hello");
    ```

- Integers do not require quotes
    ```csharp
    Console.WriteLine(123);
    ```

## Decimal Numbers
- 3 data types to represent decimal numbers (lowest to highest degrees of precision)
  - Float (0.25F) - ~6-9 digits of precision
  - Double (default)(no literal suffix required) - ~15-17 digits of precision
  - Decimal (12.9485M) - ~28-29 digits of precision

    ```csharp
    Console.WriteLine(0.25F);      // Floating point
    Console.WriteLine(2.625);      // Double (default)
    Console.WriteLine(12.39816m);  // Decimal
    ```

## Boolean
- Boolean (bool): True/False

## Enforcing Data Types
- Enforcing data types can prevent issues and software bugs
- Consider what data type your variable should be
  - While phone numbers and zip codes are numbers, you don't perform calculations on them
  - They should be stored as string variables since they are for "presentation, not calculation"

## Variables
- Variable is a container for storing a type of value in memory
- Every variable has a memory address associated with it
- Declare data type and variable name (```string firstName```);
- Conventions
  - Use camel casing
  - Start with a letter
  - Descriptive and meaningful
  - Avoid contractions or abbreviations
  - Don't include data type in variable name
- Assign a value using equal (=) sign (```firstName = "Bob";```)
- The above examples explicitly assign a data type to the variable
- However, you can do implicitly typed local variables
  - C# compiler can infer variable data type by its initialized value (```var message = "Hello world!"```)
- The ```var``` keyword has been widely adopted in C# in declaring variables instead of the actual data type name
  - Typically the variable data type is obvious from the variable initialization

## Challenge
- Store the following variables in variables
    ```
    Bob
    3
    34.4
    ```
- Display the following message using the variables:
    ```
    Hello, Bob! You have 3 messages in your inbox. The temperature is 34.4 celsius.
    ```

- Solution
  - Note that the solution to display the message is not typical. At this point in the lessions, string formatting has not been covered.

    ```csharp
    string name = "Bob";
    int messages = 3;
    decimal temperature = 34.4m;

    Console.Write("Hello, ");
    Console.Write(name);
    Console.Write("! You have ");
    Console.Write(messages);
    Console.Write(" messages in your inbox. The temperature is ");
    Console.Write(temperature);
    Console.Write(" celsius.");
    ```
