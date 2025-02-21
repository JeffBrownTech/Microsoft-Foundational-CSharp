# Format alphanumeric data for presentation in C#

## Composite Formatting
- Uses numbered placeholders within a string
- At run time, everything inside the braces is resolved to a value that is also passed in based on their position
- Uses built-in method ```Format()``` on the ```string``` data type keyword
    ```csharp
    string first = "Hello";
    string second = "World";
    string result = string.Format("{0} {1}!", first, second);
    Console.WriteLine(result);
    ```
- Data types and variables of a given data type have built-in "helper methods" to make certain tasks easy.
- The literal string ```"{0} {1}!"``` forms a template, parts of which are replaced at run time.
- The token ```{0}``` is replaced by the first argument after the string template, in other words, the value of the variable ```first```.
- The token ```{1}``` is replaced by the second argument after the string template, in other words, the value of the variable ```second```.
- Can also repeat tokens multiple times
    ```Console.WriteLine("{0} {0} {0}!", first, second);```

## String Interpolation
- Simplified composite formatting
- Instead of numbered tokens, use variable names in curly braces
- Must prefix the string with ```$```
    ```csharp
    string first = "Hello";
    string second = "World";
    Console.WriteLine($"{first} {second}!");
    Console.WriteLine($"{second} {first}!");
    Console.WriteLine($"{first} {first} {first}!");
    ```

## Formatting Currency
- Composite formatting and string interpolation can be used to format values for display given a specific language and culture
- ```:C``` is used to present ```price``` and ```discount``` variables as currency
    ```csharp
    decimal price = 123.45m;
    int discount = 50;
    Console.WriteLine($"Price: {price:C} (Save {discount:C})");
    ```

- The currency formatting feature is dependent on the local computer setting for *culture* or the country/region and language of the end user
- *Culture code* is a five character string that computers use to identify the location and language of the end user (e.g. ```en-US```, ```fr-FR```)

## Formatting Numbers
- Format numbers for readability by including commas to delineate thousands, millions, billions, and so on
- The ```N``` numeric format specifier makes numbers more readable
    ```csharp
    decimal measurement = 123456.78912m;
    Console.WriteLine($"Measurement: {measurement:N} units");
    ```

    Outputs:
    ```Measurement: 123,456.79 units```

- Add more decimal precision by adding a number to the ```N``` specifier
    ```csharp
    decimal measurement = 123456.78912m;
    Console.WriteLine($"Measurement: {measurement:N4} units");
    ```

## Formatting Percentages
- Use the ```P``` format specifier to format percentages and round to 2 decimal places (or add a number for more precision)
    ```csharp
    decimal tax = .36785m;
    Console.WriteLine($"Tax rate: {tax:P2}");
    ```

## Combine Formatting Approaches
- Combine composite formatting with currency specifiers
- Then perform concatenation and calculate the discount percentage
    ```csharp
    decimal price = 67.55m;
    decimal salePrice = 59.99m;

    string yourDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price. ", (price - salePrice), price);

    yourDiscount += $"A discount of {((price - salePrice)/price):P2}!"; //inserted
    Console.WriteLine(yourDiscount);
    ```

## Recap
- You can use composite formatting or string interpolation to format strings.
- With composite formatting, you use a string template containing one or more replacement tokens in the form ```{0}```. You also supply a list of arguments that are matched with the replacement tokens based on their order. Composite formatting works when using ```string.Format()``` or ```Console.WriteLine()```.
- With string interpolation, you use a string template containing the variable names you want replaced surrounded by curly braces. Use the ```$``` directive before the string template to indicate you want the string to be interpolated.
- Format currency using a ```:C``` specifier.
- Format numbers using a ```:N``` specifier. Control the precision (number of values after the decimal point) using a number after the :N like {myNumber:N3}.
- Format percentages using the ```:P``` format specifier.
- Formatting currency and numbers depend on the end user's culture, a five character code that includes the user's country/region and language (per the settings on their computer).

## Exercise - Explore String Interpolation
- Create the code to print a recipt for a customer purchasing shares of an investment product
- Starter code:
    ```csharp
    int invoiceNumber = 1201;
    decimal productShares = 25.4568m;
    decimal subtotal = 2750.00m;
    decimal taxPercentage = .15825m;
    decimal total = 3185.19m;

    Console.WriteLine($"Invoice Number: {invoiceNumber}");
    ```

- Display the product shares with one thousandth of a share (0.001) precision
- Display the subtotal to charge the customer formatted as currency
- Display tax charged on the sale formatted as percentage
- Display total amount due formatted as currency

- Solution:
    ```csharp
    int invoiceNumber = 1201;
    decimal productShares = 25.4568m;
    decimal subtotal = 2750.00m;
    decimal taxPercentage = .15825m;
    decimal total = 3185.19m;

    Console.WriteLine($"Invoice Number: {invoiceNumber}");
    Console.WriteLine($"  Product Shares: {productShares:N3}");
    Console.WriteLine($"    Subtotal: {subtotal:C}");
    Console.WriteLine($"      Tax: {taxPercentage:P}");
    Console.WriteLine($"  Total: {total:C}");
    ```

## Padding and Alignment
- Methods that add blank spaces for formatting purposes (```PadLeft()```, ```PadRight()```)
- Methods that compare two strings or facilitate comparison (```Trim()```, ```TrimStart()```, ```TrimEnd()```, ```GetHashcode()```, the ```Length``` property)
- Methods that help you determine what's inside of a string, or even retrieve just a part of the string (```Contains()```, ```StartsWith()```, ```EndsWith()```, ```Substring()```)
- Methods that change the content of the string by replacing, inserting, or removing parts (```Replace()```, ```Insert()```, ```Remove()```)
- Methods that turn a string into an array of strings or characters (```Split()```, ```ToCharArray()```)
- You can overload some methods, meaning there is another version of the method with different or extra arguments
- E.g., ```PadLeft()``` can accept a character to fill in the extra padding instead of a space
    ```csharp
    Console.WriteLine(input.PadLeft(12, '-'));
    Console.WriteLine(input.PadRight(12, '-'));
    ```

## Exercise: Apply String Interpolation to a Form Letter
- Merge personalized information about the customer to a form letter
- Use new formatting techniques and padding/alignment methods
- [Solution](./solutions/form_letter/Program.cs)