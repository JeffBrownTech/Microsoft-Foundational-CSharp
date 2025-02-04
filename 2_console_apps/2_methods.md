# Call methods from the .NET Class Library using C#

## .NET Libraries
- .NET Runtime: Hosts and manages code as it executes on the computer
- .NET Class Library
  - Prewritten collection of coding resources to use in applications
  - Organized collection of programming resources
  - Thousands of classes (properties and methods)
    - Classes are containers for methods
  - Includes things like Console for working with console applications
    - Includes methods like ```Write()```, ```WriteLine()```, ```ReadLine()```
  - Classes and methods allow building specific type of application
    - Native desktop app, database, etc.
  - C# data types are also made available through classes
    - String class has methods like ```ToUpper``` and ```ToLower```
- Stateful vs Stateless methods
  - State - condition of the execution environment at a specific moment in time, such as all the values stored in memory
  - Stateless methods
    - Or Static Methods
    - Work without referencing or changing any values already stored in memory
    - ```Console.WriteLine()```
  - Stateful Methods
    - Or Instance Methods
    - Rely on values stored in memory by previous code, or modify application by updating values or storing new values in memory
    - Keep track of state in fields or variable defined on the class
    - Each new class instance gets its own copy of those fields to store state
  - A single class can support both stateful and stateless methods
- Creating an instance of a class
  - Object - an instance of a class
  - Create new instances using the new operator
        ```Random dice = new Random();```
        
        Or
        
        ```Random dice = new();```
        
  - New operator does several things:
    - Requests memory address large enough to store a new object based on the class (Random)
    - Creates the object and stores it at the memory address
    - Returns the memory address so that it can be saved in the dice object
  - When calling the ```.Next()``` method on the dice object, the method uses the state stored in the dice object to generate a random number
- If you can access a method from a class without creating an instance, then it is stateless; otherwise you'll just get a compilation error.
- Void methods - methods that complete their action and do not return a value
- Method Parameters and Arguments
  - Arguments - values passed to a method to complete the task
  - Method uses arguments to assign values to parameters defined in the method's signature
  - Method Signature - definition of the number of parameters a method will accept and the data type of each parameter
  - An overloaded method is a method with multiple method signatures
    - These provide different ways to call the method or provide different data types
    - Example: ```Console.WriteLine()``` can accept strings, ints, or nothing at all

## Exercise
- Use documentation or Intellisense to find a method in the ```System.Math``` class that returns the larger of two numbers
    
    ```csharp
    int firstValue = 500;
    int secondValue = 600;
    int largerValue = Math.Max(firstValue, secondValue);
        
    Console.WriteLine(largerValue);
    ```