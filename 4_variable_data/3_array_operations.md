# Perform Operations on Arrays using Helper Methods in C#
https://www.freecodecamp.org/learn/foundational-c-sharp-with-microsoft/work-with-variable-data-in-c-sharp-console-applications/perform-operations-on-arrays-using-helpers-methods-in-c-sharp

https://learn.microsoft.com/en-us/training/modules/csharp-arrays-operations/

- The ```Array``` class contains methods used to manipulate content, arrangement, and size of an array

## Exercise: Discover Sort() and Reverse()
 - Review the following code in the use of ```Sort()``` and ```Discover()``` on the array

    ```csharp
    string[] pallets = [ "B14", "A11", "B12", "A13" ];

    Console.WriteLine("Sorted...");
    Array.Sort(pallets);
    foreach (var pallet in pallets)
    {
        Console.WriteLine($"-- {pallet}");
    }

    Console.WriteLine("");
    Console.WriteLine("Reversed...");
    Array.Reverse(pallets);
    foreach (var pallet in pallets)
    {
        Console.WriteLine($"-- {pallet}");
    }
    ```

- The output should be:
    ```
    Sorted...
    -- A11
    -- A13
    -- B12
    -- B14

    Reversed...
    -- B14
    -- B12
    -- A13
    -- A11
    ```

## Exercise: Explore Clear() and Resize()
### Clear()
- ```Clear()``` allows eliminating the contents of specific elements in the array, replacing them with the array's default value
- For example, clearing an element in a ```string``` array replaces the value with ```null```; ``int``` is ```0``` (zero)
- ```Resize()``` adds or removes elements from the array
- Examine the code below:
    ```csharp
    string[] pallets = [ "B14", "A11", "B12", "A13" ];
    Console.WriteLine("");

    Array.Clear(pallets, 0, 2);
    Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
    foreach (var pallet in pallets)
    {
        Console.WriteLine($"-- {pallet}");
    }
    ```

  - ```Array.Clear(pallets, 0, 2)``` clears the values stored in the array starting at index ```0``` and clearing ```2``` elements
  - Changes output to this:
    ```csharp
    Clearing 2 ... count: 4
    -- 
    -- 
    -- B12
    -- A13
    ```

### Empty String versus null
- When using ```Array.Clear()```, the elements that are cleared no longer reference a string in memory
- The element points to nothing at all
- The C# compiler will convert null values to an empty string for presentation purposes
- If you tried to call a string helper method on a cleared element, (like ```ToLower()```), the compiler throws an exception

### Resize()
- Review the updated code for resizing the ```pallet``` array
    ```csharp
    string[] pallets =  ["B14", "A11", "B12", "A13" ];
    Console.WriteLine("");

    Array.Clear(pallets, 0, 2);
    Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
    foreach (var pallet in pallets)
    {
        Console.WriteLine($"-- {pallet}");
    }

    Console.WriteLine("");
    Array.Resize(ref pallets, 6);
    Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

    pallets[4] = "C01";
    pallets[5] = "C02";

    foreach (var pallet in pallets)
    {
        Console.WriteLine($"-- {pallet}");
    }
    ```

- ```Array.Resize(ref pallets, 6);``` passes the array by reference using the ```ref``` keyword and increases the array to 6 elements
- Can also remove elements through resizing (```Array.Resize(ref pallets, 3);```)

### Can you remove null elements from an array?
- If the ```Array.Resize()``` method doesn't remove empty elements from an array, is there another helper method that does the job automatically?
- No. The best way to empty elements from an array would be to count the number of non-null elements by iterating through each item and increment a variable (a counter)
- Next, you would create a second array that is the size of the counter variable
- Finally, you would loop through each element in the original array and copy non-null values into the new array.

## Exercise: Discovery Split() and Join()
- Use ```ToCharArray()``` to reverse a ```string```
- The following example turns a string into an array of ```char``` type
- Each letter of the string becomes an element in the array
    ```csharp
    string value = "abc123";
    char[] valueArray = value.ToCharArray();
    ```
- Continue by reversing the array, then using the ```Write``` method to combine them back into a single output
- The ```new``` keyword create a new instance of a ```string``` object; when dealing with character arrays, it's need to explicitly instantiate a new string object
    ```csharp
    string value = "abc123";
    char[] valueArray = value.ToCharArray();
    Array.Reverse(valueArray);
    string result = new string(valueArray);
    Console.WriteLine(result);
    ```

### Join()
- Separate each item in an array using a specific delimiter (like a comma)
- Review the code below:
    ```csharp
    string value = "abc123";
    char[] valueArray = value.ToCharArray();
    Array.Reverse(valueArray);
    // string result = new string(valueArray);
    string result = String.Join(",", valueArray);
    Console.WriteLine(result);
    ```

- This should output: ```3,2,1,c,b,a```

### Split()
- Creates an array of strings using a delimiter
    ```csharp
    string[] items = result.Split(',');
    foreach (string item in items)
    {
        Console.WriteLine(item);
    }
    ```

## Exercise: Reverse words in a sentence
- Write the code necessary to reverse the letters of each word in place and display the result
    ```string pangram = "The quick brown fox jumps over the lazy dog";```

- Solution: [Reverse Sentence](./solutions/reverse_sentence/Program.cs)

## Exercise: Parsing for Correct Data Format
- Parse individual "Order IDs" and output them sorted and tagged as "Error" if they are not exactly four characters in length
    ```string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";```

- Output should match this:
    ```
    A345
    B123
    B177
    B179
    C15     - Error
    C234
    C235
    G3003   - Error
    ```

- Solution: [Data Parse](./solutions/parse_data/Program.cs)