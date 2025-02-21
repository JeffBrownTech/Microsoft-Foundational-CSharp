# Convert data types using casting and conversion techniques in C#

- Sometimes necessary to change values from one data type to another
- Example: performing mathematical operation using string data
- There are multiple techniques to perform a data type conversion. The technique you choose depends on your answer to two important questions:
  - Is it possible, depending on the value, that attempting to change the value's data type would throw an exception at run time?
  - Is it possible, depending on the value, that attempting to change the value's data type would result in a loss of information?

## Exercise: Explore Data Type Casting and Conversion
- The following code results in an error as the compiler cannot implicitly convert the type ```string``` to ```int```
    ```csharp
    int first = 2;
    string second = "4";
    int result = first + second;
    Console.WriteLine(result);
    ```

- However, changing ```result``` to a string data type does work because C# compiler will implicitly convert ```int``` to ```string```
    ```csharp
    int first = 2;
    string second = "4";
    string result = first + second;
    Console.WriteLine(result);
    ```

- However, this outputs ```24``` as the answer, not ```6``` because it combines the characters ```2``` and ```4```. But why?

### Compiler Makes Safe Conversions
- Compiler sees problems in the making
- Trying to convert a string like ```"hello"``` to a number causes an exception, so the compiler will not perform an implicit conversion
- However, converting ```int``` to ```string``` is a safer operation, so the compiler will do it
- If you need to change a value from the original data type to a new data type, must perform a **data conversion**
- Conversion techniques:
  - Helper method on the data type
  - Helper method on the variable
  - Use the ```Convert``` class' methods

- Consider this code:
    ```csharp
    int myInt = 3;
    Console.WriteLine($"int: {myInt}");

    decimal myDecimal = myInt;
    Console.WriteLine($"decimal: {myDecimal}");
    ```

    - Since ```int``` fit inside of ```decimal```, the compiler performs the conversion
    - This is a *widening conversion* as you are taking a value from a data type that holds *less* information to a data type that holds *more* information
    - In a widening conversion, you can rely on **implicit conversion**

- Perform a cast
  - Use the casting operator ```()``` to surround a data type to cast to
  - Place it next to the variable you want to convert (e.g. ```(int)myDecimal```)
  - The decimal value has more precision after the decimal point than an integer
  - By casting, you're telling the C# compiler that you undestand you will lose precision and are fine with it
  - This is an explicit conversion or a **narrowing conversion**
    ```csharp
    decimal myDecimal = 3.14m;
    Console.WriteLine($"decimal: {myDecimal}");

    int myInt = (int)myDecimal;
    Console.WriteLine($"int: {myInt}");
    ```

- Perform experiments to see if casting will lose precision
    ```csharp
    decimal myDecimal = 1.23456789m;
    float myFloat = (float)myDecimal;

    Console.WriteLine($"Decimal: {myDecimal}");
    Console.WriteLine($"Float  : {myFloat}");
    ```

## Data Conversions
- Three techniques to change from one data type to another:
  - Use a helper method on the variable
  - Use a helper method on the data type
  - Use the ```Convert``` class' methods

### String to a Number
- Use ```ToString()```
    ```csharp
    int first = 5;
    int second = 7;
    string message = first.ToString() + second.ToString();
    Console.WriteLine(message);  // Outputs 57
    ```

### Convert string to int using Parse()
- Most numeric data types have a ```Parse()``` method to convert a string into a given data type
- Example: Convert two strings to ints
    ```csharp
    string first = "5";
    string second = "7";
    int sum = int.Parse(first) + int.Parse(second);
    Console.WriteLine(sum);
    ```
- If either variable cannot be converted, results in a runtime error
- Better to use ```TryParse()```

### Convert class
- Convert class has many helper methods to convert a value from one type into another
- Example: Convert two strings to integers
    ```csharp
    string value1 = "5";
    string value2 = "7";
    int result = Convert.ToInt32(value1) * Convert.ToInt32(value2);
    Console.WriteLine(result);
    ```
- Why to ```Int32()``` and not ```ToInt()```?
  - ```System.Int32``` is the name of the underlying data type in the .NET Class Library that C# programming language maps to the keyword ```int```
  - ```Convert``` is a part of the .NET Class Library, it's called by its full name and not the C# alias
  - The .NET Class Library defines multiple data types that are used across multiple languages
- ```Convert``` class is best for converting fractional numbers into whole numbers because it does rounding better
    ```csharp
    int value = (int)1.5m; // casting truncates
    Console.WriteLine(value);

    int value2 = Convert.ToInt32(1.5m); // converting rounds up
    Console.WriteLine(value2);
    ```

### Recap
- Prevent a runtime error while performing a data conversion
- Perform an explicit cast to tell the compiler you understand the risk of losing data
- Rely on the compiler to perform an implicit cast when performing an expanding conversion
- Use the () cast operator and the data type to perform a cast (for example, (int)myDecimal)
- Use the Convert class when you want to perform a narrowing conversion, but want to perform rounding, not a truncation of information

## Exercise - TryParse() Method
- The result of ```TryParse()``` is a boolean value
- Methods with an ```out``` parameter must use that keyword to store the resulting value
    ```csharp
    string value = "102";
    int result = 0;
    if (int.TryParse(value, out result))
    {
        Console.WriteLine($"Measurement: {result}");
    }
    else
    {
        Console.WriteLine("Unable to report the measurement.");
    }

    if (result > 0)
        Console.WriteLine($"Measurement (w/ offset): {50 + result}");
    ```

## Challenge: Combine String Array Values as strings and as integers
- Examine each item in this array
- If the item is a string, concatenate it to form a message
- If the item is numeric, then add it to the total
- Final output should look like this:
    ```
    Message: ABCDEF
    Total: 68.3
    ```
- Solution:
    ```csharp
    string[] values = { "12.3", "45", "ABC", "11", "DEF" };
    decimal total = 0m;
    string message = "";


    foreach (var value in values)
    {
        if (decimal.TryParse(value, out decimal result))
        {
            total += result;
        }
        else
        {
            message += value;
        }
    }

    Console.WriteLine($"Message: {message}");
    Console.WriteLine($"Total: {total}");
    ```

## Exercise: Output math operations as specific number types
- Starting with this code, replace the code comments with your own code to solve the challenge:
    ```csharp
    int value1 = 11;
    decimal value2 = 6.2m;
    float value3 = 4.3f;

    // Your code here to set result1
    // Hint: You need to round the result to nearest integer (don't just truncate)
    Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

    // Your code here to set result2
    Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

    // Your code here to set result3
    Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");
    ```
- Output should be:
    ```
    Divide value1 by value2, display the result as an int: 2
    Divide value2 by value3, display the result as a decimal: 1.4418604651162790697674418605
    Divide value3 by value1, display the result as a float: 0.3909091
    ```

- Solution:
    ```csharp
    int value1 = 11;
    decimal value2 = 6.2m;
    float value3 = 4.3f;

    // Your code here to set result1
    // Hint: You need to round the result to nearest integer (don't just truncate)
    int result1 = Convert.ToInt32(value1 / value2);
    Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

    // Your code here to set result2
    decimal result2 = value2 / (decimal)value3;
    Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

    // Your code here to set result3
    float result3 = value3 / value1;
    Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");
    ```