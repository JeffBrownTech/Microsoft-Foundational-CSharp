# Write your first C# method

- Methods (or Functions) keep code structured, efficient, and readable
- Modular unit of code and a fundamental programming concept
- Designed to perform a specific task and contains code to execute that task
- Method name should clearly reflect its task

## Method Syntax
- Create a method signature
- Signature declares the method's return type, name, and input parameters
- Example:
  - Method name is ```SayHello```
  - Return type is ```void``` meaning it does not return any data
  - Input parameters are defined in parentheses ```()```
  - Code block ```{}``` define the method's actions
        ```csharp
        void SayHello();
        {
            Console.WriteLine("Hello World!");
        }
        ```
- Call the method like any other .NET Class method
    ```csharp
    SayHello();
    ```

- Not required to define a method before you call it
  - Common to define all methods at the end of a programming

- Calling a method means you pass execution control from the method caller to the method
- Control is returned after the method completes its execution

### Best practices
- Keep the name concise and make it clear what task the method performs
- Use Pascal case and generally don't start witha digit
- Parameter names should describe what kind of information the parameter represents
    ```csharp
    void ShowData(string a, int b, int c);
    void DisplayDate(string month, int day, int year);
    ```

## Exercise: Create your first method
- Create a method to display random numbers (0-99) in a single line
- Output should resemble:
    ```
    Generating random numbers:
    65 15 75 68 85
    ```

- Solution
    ```csharp
    Console.WriteLine("Generating random numbers:");
    DisplayRandomNumbers();

    void DisplayRandomNumbers()
    {
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"{random.Next(1, 100)} ");
        }

        Console.WriteLine();
    }
    ```

# Exercise: Create reusable methods
- Use methods to perform the same task instead of writing duplicate code
- Task
  - Program that tracks medication times across different zones
  - User enters their current time zone and their destination time zone
  - Medication schedule displays and adjusted for new time zone
- Example output:
    ```
    Enter current GMT
    -6
    Current Medicine Schedule:
    8:00 12:00 16:00 20:00 
    Enter new GMT
    +6
    New Medicine Schedule:
    20:00 0:00 4:00 8:00
    ```

- Identify duplicated code and write methods to replace it
    ```csharp
    using System;

    int[] times = {800, 1200, 1600, 2000};
    int diff = 0;

    Console.WriteLine("Enter current GMT");
    int currentGMT = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Current Medicine Schedule:");

    /* Format and display medicine times */
    foreach (int val in times)
    {
        string time = val.ToString();
        int len = time.Length;

        if (len >= 3)
        {
            time = time.Insert(len - 2, ":");
        }
        else if (len == 2)
        {
            time = time.Insert(0, "0:");
        }
        else
        {
            time = time.Insert(0, "0:0");
        }

        Console.Write($"{time} ");
    }

    Console.WriteLine();

    Console.WriteLine("Enter new GMT");
    int newGMT = Convert.ToInt32(Console.ReadLine());

    if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
    {
        Console.WriteLine("Invalid GMT");
    }
    else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0) 
    {
        diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));

        /* Adjust the times by adding the difference, keeping the value within 24 hours */
        for (int i = 0; i < times.Length; i++) 
        {
            times[i] = ((times[i] + diff)) % 2400;
        }
    } 
    else 
    {
        diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));

        /* Adjust the times by adding the difference, keeping the value within 24 hours */
        for (int i = 0; i < times.Length; i++) 
        {
            times[i] = ((times[i] + diff)) % 2400;
        }
    }

    Console.WriteLine("New Medicine Schedule:");

    /* Format and display medicine times */
    foreach (int val in times)
    {
        string time = val.ToString();
        int len = time.Length;

        if (len >= 3)
        {
            time = time.Insert(len - 2, ":");
        }
        else if (len == 2)
        {
            time = time.Insert(0, "0:");
        }
        else
        {
            time = time.Insert(0, "0:0");
        }

        Console.Write($"{time} ");
    }

    Console.WriteLine();
    ```

- Solution
    ```csharp
    using System;

    int[] times = { 800, 1200, 1600, 2000 };
    int diff = 0;

    Console.WriteLine("Enter current GMT");
    int currentGMT = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Current Medicine Schedule:");
    DisplayMedicineTimes();
    Console.WriteLine();

    Console.WriteLine("Enter new GMT");
    int newGMT = Convert.ToInt32(Console.ReadLine());

    if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
    {
        Console.WriteLine("Invalid GMT");
    }
    else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
    {
        diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
        AdjustTimes();
    }
    else
    {
        diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
        AdjustTimes();
    }

    Console.WriteLine("New Medicine Schedule:");
    DisplayMedicineTimes();
    Console.WriteLine();

    /* METHODS */
    void DisplayMedicineTimes()
    {
        /* Format and display medicine times */
        foreach (int val in times)
        {
            string time = val.ToString();
            int len = time.Length;

            if (len >= 3)
            {
                time = time.Insert(len - 2, ":");
            }
            else if (len == 2)
            {
                time = time.Insert(0, "0:");
            }
            else
            {
                time = time.Insert(0, "0:0");
            }

            Console.Write($"{time} ");
        }

    }

    void AdjustTimes()
    {
        /* Adjust the times by adding the difference, keeping the value within 24 hours */
        for (int i = 0; i < times.Length; i++)
        {
            times[i] = ((times[i] + diff)) % 2400;
        }
    }
    ```

## Exercise: Build code with methods
- Write a program that checks whether an IPv4 address is valid or Invalid
- Rules
  - A valid IPv4 address consists of four numbers separated by dots
  - Each number must not contain leading zeroes
  - Each number must range from 0 to 255
- Write methods to support this starter code logic:
    ```csharp
    string ipv4Input = "107.31.1.5";
    bool validLength = false;
    bool validZeroes = false;
    bool validRange = false;

    if (validLength && validZeroes && validRange) 
    {
        Console.WriteLine($"ip is a valid IPv4 address");
    } 
    else 
    {
        Console.WriteLine($"ip is an invalid IPv4 address");
    }
    ```

- Solution (**Note:** I would have preferred the methods return ```true``` or ```false``` but followed guidelines in the exercise material)
    ```csharp
    string[] ipv4Input = { "107.31.1.5", "255.0.0.255", "555..0.555", "255...255" };
    string[] address;
    bool validLength = false;
    bool validZeroes = false;
    bool validRange = false;

    foreach (string ip in ipv4Input)
    {
        address = ip.Split(".", StringSplitOptions.RemoveEmptyEntries);

        ValidateLength();
        ValidateRange();
        ValidateZeroes();

        if (validLength && validZeroes && validRange)
        {
            Console.WriteLine($"{ip} is a valid IPv4 address");
        }
        else
        {
            Console.WriteLine($"{ip} is an invalid IPv4 address");
        }
    }

    void ValidateLength()
    {
        validLength = address.Length == 4;
    }

    void ValidateZeroes()
    {
        foreach (string number in address)
        {
            if (number.Length > 1 && number.StartsWith("0"))
            {
                validZeroes = false;
                return;
            }

            validZeroes = true;
        }

    }

    void ValidateRange()
    {
        foreach (string number in address)
        {
            int value = int.Parse(number);
            if (value >= 0 && value <= 255)
            {
                validRange = true;
            }
        }
    }
    ```

## Exercise: Create a resuable method
- Create a ```tellFortune``` method to give a player their luck stat for the day
- Starter Code:
    ```csharp
    Random random = new Random();
    int luck = random.Next(100);

    string[] text = {"You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to"};
    string[] good = {"look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!"};
    string[] bad = {"fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life."};
    string[] neutral = {"appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature."};

    Console.WriteLine("A fortune teller whispers the following words:");
    string[] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));
    for (int i = 0; i < 4; i++) 
    {
    Console.Write($"{text[i]} {fortune[i]} ");
    }

    ```

- Solution:
    ```csharp
    Random random = new Random();
    int luck = random.Next(100);

    string[] text = { "You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to" };
    string[] good = { "look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!" };
    string[] bad = { "fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life." };
    string[] neutral = { "appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature." };

    TellFortune();

    void TellFortune()
    {
        Console.WriteLine("A fortune teller whispers the following words:");
        string[] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));
        for (int i = 0; i < 4; i++)
        {
            Console.Write($"{text[i]} {fortune[i]} ");
        }
    }
    ```