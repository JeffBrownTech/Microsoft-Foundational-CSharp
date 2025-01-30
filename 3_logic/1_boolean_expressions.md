# Evaluate Boolean Expression to Make Decisions in C#

## Expression
- Combination of values (literal or variable), operators, and methods that return a single value

    ```csharp
    // Comparisons evaluate to True or False
    if (myName == "Jeff") {}

    Console.WriteLine("a" == "a");
    Console.WriteLine("a" == "A");
    Console.WriteLine(1 == 2);

    string myValue = "a";
    Console.WriteLine(myValue == "a");   
    ```

- C# is case-senstive, this means you sometimes need to massage the input data prior to checking it

    ```csharp
    // Remove whitespace and convert to lowercase for comparison
    string value1 = " a";
    string value2 = "A ";
    Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());
    ```

- Using methods also return a Boolean value

    ```csharp
    string pangram = "The quick brown fox jumps over the lazy dog.";
    Console.WriteLine(pangram.Contains("fox"));  // True
    Console.WriteLine(pangram.Contains("cow"));  // False
    ```

## Logical Negation
- Unary negation operator (!) or "not operator"
- Reverse the evaulation of the operand

    ```csharp
    string pangram = "The quick brown fox jumps over the lazy dog.";

    // These two expressions create the same output (False)

    // The string pangram does contain "fox", left side of comparison equals True
    // Console.WriteLine(true == false);
    // True does not equal False. Entire expression evaluates to False.
    Console.WriteLine(pangram.Contains("fox") == false);    

    // The string pangram does contain "fox" = True, but negation operator ! returns the opposite (False)
    Console.WriteLine(!pangram.Contains("fox"));
    ```

- The ```!=``` is not logical negation; it is "not equal to"
    - These can produce the same output, but the second is a reverse of the expression
        ```
        x = 10
        y = 20
        x != y
        !(x == y)
        ```

## Condition Operator (Ternary Operator)
- Evaluates a Boolean expression and returns one of two results
- Simpler syntex to replace ```if/else``` statement

    ```<evaluate this condition> ? <if condition is true, return this value> : <if condition is false, return this value>```

    ```csharp
    /*
        Determines discount amount
        Purchase value greater than 1000 euros gets 100 euro discount
        Purchase amount 1000 euros or less gets 50 euro discount
    */
    int saleAmount = 1001;
    int discount = saleAmount > 1000 ? 100 : 50;
    Console.WriteLine($"Discount: {discount}");
    ```

## Exercise: Display results of a coin flip
```csharp
/*
    Display the result of a coin flip
    Use Random to generate a value
    Use conditional operator to display heads or tails
    Accomplish desired results in threes lines of code
*/
int coinFlip = new Random().Next(0, 2);
string result = coinFlip == 0 ? "heads" : "tails";
Console.WriteLine($"Coin Flip Result: {result}");
```

## Exercise: Boolean Expressions and Business Rules
```csharp
/*
    Implement business rules to output a message based on permission and level.
    Use the Contains() method to determine value for permissions variable.
    Admin > 55      Welcome, Super Admin user.
    Admin <= 55     Welcome, Admin user.
    Manager >= 20   Contact an Admin for access.
    Manager < 20    You do not have sufficient privileges.
    Neither         You do not have sufficient privileges.
*/

string permission = "Manager";
int level = 10;
if (permission.Contains("Admin")) {
    if (level > 55) {
        Console.WriteLine("Welcome, Super Admin user.");
    }
    else {
        Console.WriteLine("Welcome, Admin user.");
    }
}
else if (permission.Contains("Manager")) {
    if (level >= 20) {
        Console.WriteLine("Contact an Admin for access.");
    }
    else {
        Console.WriteLine("You do not have sufficient privileges.");
    }
}
else {
    Console.WriteLine("You do not have sufficient privileges.");
}
```
