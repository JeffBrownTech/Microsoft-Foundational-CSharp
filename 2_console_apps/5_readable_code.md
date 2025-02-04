# Create readable code with conventions, whitespace, and comments in C#

## Variable Naming Rules
- Alphanumeric characters and underscore
- No special characters (like #, -, $)
- Begin with alphabetical letter or an underscore
- Must not be a C# keyword (e.g. string, float)
- Case sensitive

## Conventions
- Camel casing (thisIsCamelCasing)
- Descriptive and meaningful
- One or more keywords appended together, no contractions or shortenings
- Do not include data type in the name

# Code Comments
- Single line //
- Multi line /* */
- Used to say something when the code cannot

## Whitespace
- Spaces produced by the space bar, tab key, or new line when pressing enter
- C# compiler ignores whitespace
    ```csharp
    // Example 1:
    Console
    .
    WriteLine
    (
        "Hello Example 1!"
    )
    ;
        
    // Example 2:
    string firstWord="Hello";string lastWord="Example 2";Console.WriteLine(firstWord+" "+lastWord+"!");
    ```

## Exercise
- Improve this code based on recommendations

  ```csharp   
    string str = "The quick brown fox jumps over the lazy dog.";
    // convert the message into a char array
    char[] charMessage = str.ToCharArray();
    // Reverse the chars
    Array.Reverse(charMessage);
    int x = 0;
    // count the o's
    foreach (char i in charMessage) { if (i == 'o') { x++; } }
    // convert it back to a string
    string new_message = new String(charMessage);
    // print it out
    Console.WriteLine(new_message);
    Console.WriteLine($"'o' appears {x} times.");
    ```
    
- Solution:
    
    ```csharp
    /*
        This code reverses a message and counts the number of times
        a specific letter occurs in the message. It then outputs the results
        to the console.
    */
    string originalMessage = "The quick brown fox jumps over the lazy dog.";
    char[] messageLetters = originalMessage.ToCharArray();
    Array.Reverse(messageLetters);
    int letterCount = 0;
    
    foreach (char letter in messageLetters) {
        if (letter == 'o') {
            letterCount++;
        }
    }
    
    string newMessage = new String(messageLetters);
    
    Console.WriteLine(newMessage);
    Console.WriteLine($"'o' appears {letterCount} times.");
    ```