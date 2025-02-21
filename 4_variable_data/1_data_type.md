# Choose the correct data type in your C# code

## Data and Data Types
- Data is a value stored in memory as a series of bits (0 or 1)
- 8 bits make a byte
- Represent 256 different combinations with just 8 bits when using binary (base-2) numeral system
- 192 as binary is 11000011 or 128 + 64 + 2 + 1 = 195
- Using a system like ASCII allows using single bytes to represent upper and lowercase letters, numbers, tabs, backspaces
  - For example, ```a``` is equivalent to decimal value ```97``` in the ASCII table, then use binary representation to store in memory
- Data types define how much memory to save for a value

## Value vs. Reference Types
- Reference type variables store references in their data (object), or point to data values stored somewhere else
- Value type variables directly contain their data

## Simple Value Types
- Predefined types provided by C# as keywords
- These keywords are aliases or nicknames for predefined types defined in the .NET Class Library
- For example, ```int``` is an alias for ```System.Int32```

## Exercise - Discover Integral Types
- Two subcategories of integral types
  - Signed - uses bytes to represent an equal number of positive and negative numbers
    -  Examples:
        ```csharp
        Console.WriteLine("Signed integral types:");

        Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
        Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
        Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
        Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");
        ```

        Output
        ```
        Signed integral types:
        sbyte  : -128 to 127
        short  : -32768 to 32767
        int    : -2147483648 to 2147483647
        long   : -9223372036854775808 to 9223372036854775807
        ```

  - Unsigned - uses bytes to represent only positive numbers
    - Examples:
        ```csharp
        Console.WriteLine("");
        Console.WriteLine("Unsigned integral types:");

        Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
        Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
        Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
        Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");
        ```

        Output
        ```
        byte   : 0 to 255
        ushort : 0 to 65535
        uint   : 0 to 4294967295
        ulong  : 0 to 18446744073709551615
        ```

## Floating-Point Types
- Represents numbers to the right of the decimal place
- Floating-point types have digits of precision, or number of places after the decimal point
- Values are also stored differently and impact accuracy of the value
  - ```float``` and ```double``` values are stored in binary (base 2)
  - ```decimal``` is stored in a decimal (base 10)
  - Performing math on binary floating-point values can produce unexpected results if you're used to decimal math
  - Binary floating-point math is an approximation of the real value
  - ```float``` and ```double``` are useful because large numbers can be stored using a small memory footprint
  - ```float``` and ```double``` should only be used when approximation is useful
  - More precise answers require using ```decimal```, like financial applications
- Viewing MinValue and MinMax for each signed float type
    ```csharp
    Console.WriteLine("Floating point types:");
    Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
    Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
    Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
    ```

    Output
    ```
    Floating point types:
    float  : -3.4028235E+38 to 3.4028235E+38 (with ~6-9 digits of precision)
    double : -1.7976931348623157E+308 to 1.7976931348623157E+308 (with ~15-17 digits of precision)
    decimal: -79228162514264337593543950335 to 79228162514264337593543950335 (with 28-29 digits of precision)
    ```
- ```float``` and ```double``` use different notation than used by ```decimal``` to represent largest and smallest possible values
  - Uses "E notation" meaning "times 10 raised to the power of"
  - ```5E+2``` is equal to 500 because ```5 * 10^2``` or ```5 x 10^2```

## Recap
- A floating-point type is a simple value data type that can hold fractional numbers.
- Choosing the right floating-point type for your application requires you to consider more than just the maximum and minimum values that it can hold. You must also consider how many values can be preserved after the decimal, how the numbers are stored, and how their internal storage affects the outcome of math operations.
- Floating-point values can sometimes be represented using "E notation" when the numbers grow especially large.
- There's a fundamental difference in how the compiler and runtime handle ```decimal``` as opposed to ```float``` or ```double```, especially when determining how much accuracy is necessary from math operations.

## Exercise - Discover Reference Types
- Reference types include arrays, classes, and strings
- Generally treated differently from value types regarding how they are stored when the application executes
- A value type variable stores its values directly in an area of storage called the *stack*
  - The stack is memory allocated to the code that is currently running on the CPU (aka stack frame or activation frame)
  - When the stack frame has finished, the values in the stack are removed

- A reference type variable stores it values in a separate memory region called the *heap*
  - The heap is a memory area that is shared across many applications running on the operating system at the same time
  - The .NET Runtime works with the OS to determine what memory addresses are available and requets an address to store the value
  - .NET runtime stored the value and returns the memory address to the variable
  - When code uses the variable, the .NET Runtime looks up the variable memory address and retrieves the value there

- When declaring variables, if the variable does not have a value yet, it's not pointing to a memory address address. This is a *null reference*.
    ```csharp
    int[] data;
    ```

### int Reference Type Variable
- The ```new``` keyword informs .NET Runtime to create an instance of ```int```array and work with the operating system to store the array sized for three int values in memory
- ```new``` keyword use to create an instance of a ```class``` allocates memory in the ```Heap```
- .NET Runtime compiles and returns a memory address of the ```int``` array and the memory address is stored in the variable data
- Array elements default to value ```0``` because that is ```int``` default value
    ```csharp
    int[] data;
    data = new int[3];
    ```

- The above two lines of code can be shortened to a single line of code to declare the variable and create a new instance of the ```int``` array.
    ```csharp
    int[] data = new int[3];
    ```

### C# String Data Type
- The ```string``` data type is also a reference type
- Not required to use ```new``` operator as designers of C# don't require this to make it convenient
    ```csharp
    string myString = "Hello World!";
    Console.WriteLine(myString);
    ```

### Value and Reference Types Examples
- Review the following Value Type (int) example code:
    ```csharp
    int val_A = 2;
    int val_B = val_A;
    val_B = 5;

    Console.WriteLine("--Value Types--");
    Console.WriteLine($"val_A: {val_A}");
    Console.WriteLine($"val_B: {val_B}");
    ```

- Should see this output:
    ```
    --Value Types--
    val_A: 2
    val_B: 5
    ```

- When ```val_B = val_A``` is executed, the value of ```val_A``` is copied and stored in ```val_B```. So, when ```val_B``` is changed, ```val_A``` remains unaffected.

- Review the following Reference Type (array) example code:
    ```csharp
    int[] ref_A= new int[1];
    ref_A[0] = 2;
    int[] ref_B = ref_A;
    ref_B[0] = 5;

    Console.WriteLine("--Reference Types--");
    Console.WriteLine($"ref_A[0]: {ref_A[0]}");
    Console.WriteLine($"ref_B[0]: {ref_B[0]}");
    ```

- Should see this output:
    ```csharp
    --Reference Types--
    ref_A[0]: 5
    ref_B[0]: 5
    ```

- ```ref_A``` and ```ref_B``` end up pointing to the same memory location. When ```ref_B``` is changed, this action also changes ```ref_A``` because they both point to the same memory location

- Value types can hold smaller values and are stored in the stack. Reference types can hold large values, and a new instance of a reference type is created using the new operator. Reference type variables hold a reference (the memory address) to the actual value stored in the heap.
- Reference types include arrays, strings, and classes.

## Choose the Right Data Type
- Numeric data has 11 different options for data type
- Choice of data type set the boundaries for the size of the data you might store in the variable
- For example, storing a number between 1 and 10,000
  - Probably wouldn't choose ```byte``` or ```sbyte``` as their ranges are too lowercase
  - ```int```, ```long```, ```uint```, and ```long``` store more data than is necessary
  - ```float```, ```double```, and ```decimal``` can be ignored if you are not storing fractional values
  - ```short``` and ```ushort``` are viable
  - Use ```ushort``` if you don't need negative values (0 to 65,535)

  - Also look at input and output data types of library functions
    - ```System.TimeSpan``` and ```System.DateTime``` classes use ```double``` and ```int```
    - Makes sense to use those when declaring variable instead of casting back and forth between data types

- If working with a database, consider how the data is stored and how much data is stored
  - Choosing a larger data type might impact the amount of database storage

- When in doubt, stick with the basics
  - ```int``` for most whole numbers
  - ```decimal``` for numbers representing money
  - ```bool``` for true or false values
  - ```string``` for alphanumeric value
- Complex situations
  - ```byte```: working with encoded data that comes from other computer systems or using different character sets.
  - ```double```: working with geometric or scientific purposes. double is used frequently when building games involving motion.
  - ```System.DateTime``` for a specific date and time value.
  - ```System.TimeSpan``` for a span of years / months / days / hours / minutes / seconds / milliseconds.