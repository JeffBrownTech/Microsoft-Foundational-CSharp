# Store and iterate through sequences of data using Arrays and the foreach statement in C#

## Arrays
- Store multiple values of the same type in a single variable
- Collection of individual data elements accessible through a single variable name
- Zero-based numeric index
- Define and populate values
    ```csharp
    string[] fraudulentOrderIDs = new string[3];
    
    fraudulentOrderIDs[0] = "A123";
    fraudulentOrderIDs[1] = "B456";
    fraudulentOrderIDs[2] = "C789";
    
    Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
    Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
    Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");
    ```
        
- Declare array with populated values
    ```csharp
    string[] fraudulentOrderIDs = [ "A123", "B456", "C789" ];
    ```
        
- Access array properties
    ```csharp
    Console.WriteLine($"There are {fraudulentOrderIDs.Length} fraudulent orders to process.");
    ```

## foreach Statement
- Loop through an array
    ```csharp
    string[] names = { "Rowena", "Robin", "Bao" };
    foreach (string name in names)
    {
        Console.WriteLine(name);
    }
    ```
        
- Sum the values of an array
    ```csharp
    int[] inventory = { 200, 450, 700, 175, 250 };
    int sum = 0;
    foreach (int items in inventory)
    {
        sum += items;
    }
    
    Console.WriteLine($"We have {sum} items in inventory.");
    ```

## Exercise
- Orders that start with the letter "B" encounter fraud at a rate 25 times greater than the normal rate
- Write new code that outputs the Order ID of new orders where the Order ID starts with the letter "B".

    ```csharp
    string[] orderIDs = ["B123","C234","A345","C15","B177","G3003","C235","B179"];
    foreach (string order in orderIDs) {
        if (order.StartsWith("B")) {
            Console.WriteLine(order);
        }
    }
    ```