# Modify the content of strings using built-in string data type methods in C#

## IndexOf() and Substring() Helper Methods
- ```IndexOf()``` method locates the position of one or more characters string inside a larger string
- ```Substring()``` methods returns part of the larger string that follows the character positions specified
  - This method needs the starting position and the number of characters, or length, to retrieve
  - Calculate the length in a temporary variable called ```length``` and pass it with the ```openingPosition``` value to retrieve the string inside of the parenthesis
  - The ```Substring()``` method starting position is inclusion, so you need to add ` to ```openingPosition``` to exclude the parenthesis

    ```csharp
    string message = "Find what is (inside the parentheses)";

    int openingPosition = message.IndexOf('(');
    int closingPosition = message.IndexOf(')');

    openingPosition += 1; //Skips over the opening parenthesis character

    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));
    ```

    ```csharp
    string message = "What is the value <span>between the tags</span>?";

    int openingPosition = message.IndexOf("<span>");
    int closingPosition = message.IndexOf("</span>");

    openingPosition += 6;
    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));
    ```

### Avoid Magic Values
- Hardcoded strings like ```"<span>"``` in the previous example are known as "magic strings" and hardcoded numberic values like ```6``` are known as "magic numbers"
- These "Magic" values are undesirable for many reasons and you should try to avoid them
  - For example, what if ```<span>``` was misspelled or was included in the string multiple times
  - If you change ```<span>``` to ```<div>``` but don't change ```6``` to ```5``` then the code produces undesirable results
- Examine new code below
  - Use of ```const``` to declare a constant, meaning the variable value can never change
  - If the value of ```openSpan``` changes to ```<div>```, then the code uses the ```Length``` property to calculate the correct ```openingPosition```
    ```csharp
    string message = "What is the value <span>between the tags</span>?";

    const string openSpan = "<span>";
    const string closeSpan = "</span>";

    int openingPosition = message.IndexOf(openSpan);
    int closingPosition = message.IndexOf(closeSpan);

    openingPosition += openSpan.Length;
    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));
    ```

### Recap
- ```IndexOf()``` gives you the first position of a character or string inside of another string.
- ```IndexOf()``` returns ```-1``` if it can't find a match.
- ```Substring()``` returns just the specified portion of a string, using a starting position and optional length.
- There's often more than one way to solve a problem. You used two separate techniques to find all instances of a given character or string.
- Avoid hardcoded magic values. Instead, define a ```const``` variable. A constant variable's value can't be changed after initialization.

## IndexOf() and LastIndexOf() Helper Methods
- Methods used to find positions of characters and substrings within a given string
- The ```.IndexOf()``` method returns the index of the first occurrence of a specified character or substring within a given string
- The method `.LastIndexOf()` returns the index position of the last occurrence of a character or string within a given string
- Both the `Indexof()` and ```LastIndexOf()``` methods return ```-1``` if the character or string is not found

    ```csharp
    string message = "hello there!";

    int first_h = message.IndexOf('h');
    int last_h = message.LastIndexOf('h');

    Console.WriteLine($"For the message: '{message}', the first 'h' is at position {first_h} and the last 'h' is at position {last_h}.");
    ```

    Output: ```For the message: 'hello there!', the first 'h' is at position 0 and the last 'h' is at position 7.```

- Find the content inside the last set of parenthesis
    ```csharp
    string message = "(What if) I am (only interested) in the last (set of parentheses)?";
    int openingPosition = message.LastIndexOf('(');

    openingPosition += 1;
    int closingPosition = message.LastIndexOf(')');
    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));
    ```

### Retrieve all instances of substrings inside parentheses
  - ```message``` contains threes sets of parentheses and need to extract any text inside of the parentheses
  - Use a ```while``` statement to iterate through the string

    ```csharp
    string message = "(What if) there are (more than) one (set of parentheses)?";
    while (true)
    {
        int openingPosition = message.IndexOf('(');
        if (openingPosition == -1) break;

        openingPosition += 1;
        int closingPosition = message.IndexOf(')');
        int length = closingPosition - openingPosition;
        Console.WriteLine(message.Substring(openingPosition, length));

        // Note the overload of the Substring to return only the remaining 
        // unprocessed message:
        message = message.Substring(closingPosition + 1);
    }
    ```

- Checking if ```openingPosition == -1``` means no matching index was found, so there is nothing further to process in the string
- The last line of code does not use a length input parameter in ```Substring()```
  - This returns every character after the starting position, in this case, the remainder of the unprocessed string

### Different types of symbol sets with IndexOfAny()
- Reports the index of the first occurrence of any character in a supplied array of characters
- Returns ```-1``` if all characters in the array of characters are not found

    ```csharp
    string message = "Hello, world!";
    char[] charsToFind = { 'a', 'e', 'i' };

    int index = message.IndexOfAny(charsToFind);

    Console.WriteLine($"Found '{message[index]}' in '{message}' at index: {index}.");
    ```

- Find matching closing symbol based on the opening symbol
    ```csharp
    string message = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";
    Console.WriteLine(message);

    // The IndexOfAny() helper method requires a char array of characters. 
    // You want to look for:

    char[] openSymbols = { '[', '{', '(' };

    // You'll use a slightly different technique for iterating through 
    // the characters in the string. This time, use the closing 
    // position of the previous iteration as the starting index for the 
    //next open symbol. So, you need to initialize the closingPosition 
    // variable to zero:

    int closingPosition = 0;

    while (true)
    {
        int openingPosition = message.IndexOfAny(openSymbols, closingPosition);

        if (openingPosition == -1) break;

        // Determines what symbol it found using Substring()
        string currentSymbol = message.Substring(openingPosition, 1);

        // Now  find the matching closing symbol
        // Initializes to empty char literal
        char matchingSymbol = ' ';

        switch (currentSymbol)
        {
            case "[":
                matchingSymbol = ']';
                break;
            case "{":
                matchingSymbol = '}';
                break;
            case "(":
                matchingSymbol = ')';
                break;
        }

        // To find the closingPosition, use an overload of the IndexOf method to specify 
        // that the search for the matchingSymbol should start at the openingPosition in the string. 

        openingPosition += 1;
        closingPosition = message.IndexOf(matchingSymbol, openingPosition);

        // Finally, use the techniques you've already learned to display the sub-string:

        int length = closingPosition - openingPosition;
        Console.WriteLine(message.Substring(openingPosition, length));
    }
    ```

### Recap
- ```LastIndexOf()``` returns the last position of a character or string inside of another string.
- ```IndexOfAny()``` returns the first position of an array of ``char`` that occurs inside of another string.

## Remove() and Replace() Methods

### Remove()
- Removes characters from a string
- Requires a standard and consistent position of the characters in the string to remove
- Example: Remove the customer's name from this string
    ```csharp
    string data = "12345John Smith          5000  3  ";
    string updatedData = data.Remove(5, 20);
    Console.WriteLine(updatedData);
    ```

### Replace()
- Replaces characters in a string
- Replaces **every instance** of the given characters, not just the first or last instance
    ```csharp
    string message = "This--is--ex-amp-le--da-ta";
    message = message.Replace("--", " ");
    message = message.Replace("-", "");
    Console.WriteLine(message);
    ```

### Recap
- The ```Remove()``` method works like the ```Substring()``` method, except that it deletes the specified characters in the string.
- The ```Replace()``` method swaps all instances of a string with a new string.

## Exercise: Extract, Replace, and Remove Data from an Input String
- Work with a string that contains a fragment of HTML
- Extract data from the fragement, replace some of the contents, and remove other parts to achieve desired output
  - Set the quantity variable to the value obtained by extracting the text between the <span> and </span> tags.
  - Set the output variable to the value of input, then remove the <div> and </div> tags.
  - Replace the HTML character ™ (&trade;) with ® (&reg;) in the output variable.
- Starter code:
    ```csharp
    const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

    string quantity = "";
    string output = "";

    // Your work here

    Console.WriteLine(quantity);
    Console.WriteLine(output);
    ```

- Desired output:
    ```
    Quantity: 5000
    Output: <h2>Widgets &reg;</h2><span>5000</span>
    ```

- [Solution](./solutions/string_manipulation/Program.cs)