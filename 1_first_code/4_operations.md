## Perform basic operations on numbers in C#

- Plus sign with two integers adds them
    ```csharp
    int firstNumber = 12;
    int secondNumber = 7;
    Console.WriteLine(firstNumber + secondNumber);
    ```
    
- When combining strings and integers in WriteLine, C# implicitly converts the int to string
    ```csharp
    string firstName = "Bob";
    int widgetsSold = 7;
    Console.WriteLine(firstName + " sold " + widgetsSold + " widgets.");
    
    string firstName = "Bob";
    int widgetsSold = 7;
    Console.WriteLine(firstName + " sold " + widgetsSold + 7 + " widgets.");
    ```
        
- Use parenthesis to clarify intention to the compiler
    ```csharp
    string firstName = "Bob";
    int widgetsSold = 7;
    Console.WriteLine(firstName + " sold " + (widgetsSold + 7) + " widgets.");
    ```
        
- Using decimal data
    ```csharp
    // Division operator gives quotient
    Console.WriteLine("Quotient: " + (7 / 5));
    
    // Modulus operator gives the remainer of integer division
    Console.WriteLine("Remainder: " +  (7 % 5));
    
    // Specify decimal division
    decimal decimalQuotient = 7.0m / 5;
    Console.WriteLine($"Decimal quotient: {decimalQuotient}");
    ```
        
- Order of operations: PEMDAS
- Increment and decrement
    ```csharp
    int value = 0;     // value is now 0.
    value = value + 5; // value is now 5.
    value += 5;        // value is now 10.
    
    int value = 0;     // value is now 0.
    value = value + 1; // value is now 1.
    value++;           // value is now 2.
    ```
        
## Challenge: Celsius Conversion
- Use a formula to convert a temperature from degrees Fahrenheit to Celsius. You'll print the result in a formatted message to the user

- Solution:
    ```csharp
    int fahrenheit = 94;
    decimal celsius = (fahrenheit - 32m) * (5m / 9m);
    Console.Write($"The temperatur is {celsius} Celsius.");
    ```
