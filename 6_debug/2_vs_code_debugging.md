# Implement the Visual Studio Code debugging tools for C#

Visual Studio Code includes several user interface features that will help you to configure, start, and manage debug sessions:
- Configure and launch the debugger: The Run menu and RUN AND DEBUG view can both be used to configure and launch debug sessions.
- Examine application state: The RUN AND DEBUG view includes a robust interface that exposes various aspects of your application state during a debug session.
- Runtime execution control: The Debug toolbar provides high-level runtime controls during code execution.

- The Visual Studio Code user interface can be used to configure, start, and manage debug sessions. The launch.json file contains the launch configurations for your application.
- The Run menu provides easy access to common run and debug commands grouped into six sections.
- The RUN AND DEBUG view provides access to runtime tools, including the Run and Debug controls panel. The sections of the RUN AND DEBUG view are VARIABLES, WATCH, CALL STACK, and BREAKPOINTS.
- The Debug toolbar provides execution controls while your application is running such as pause/continue, step over, step into, step out, restart and stop.
- The DEBUG CONSOLE is used to display messages from the debugger. The DEBUG CONSOLE can also display console output from your application.

## Exercise: Run Code in the Debug Environment
- Configure VS Code the Build and Debug Assets
  - On the View menu, select Command Palette.
  - In the command palette, enter ```.net: g``` and then select ```.NET: Generate Assets for Build and Debug```.
  - This creates a ```.vscode``` file folder with ```launch.json``` and ```task.json``` files

## Exercise: Examine Breakpoint Configuration Options
- Breakspoints are used to specify where code execution pauses
- Visual Studio Code provides several ways to configure breakpoints in your code. For example:
  - Code Editor: You can set a breakpoint in the Visual Studio Code Editor by clicking in the column to the left of a line number.
  - Run menu: You can toggle a breakpoint on/off from the Run menu. The current code line in the Editor specifies where the Toggle Breakpoint action is applied.
- When a breakpoint is set, a red circle is displayed to the left of the line number in the Editor. When you run your code in the debugger, execution pauses at the breakpoint.
- Conditional breakpoints only trigger when a specified condition is met (e.g. ```numItems``` is greater than 5)
- 'Hit Count' breakpoing can be used to specify the number of times that a breakpoint must be encountered before it will 'break' execution
- 'Logpoint' is a variable of breakpoint in that it does not "break" into the debugger but instead logs a message to the console
  - Useful for injecting logging while debugging in situations where the application cannot be paused or stopped

- Use a breakpoint at line 14 (```if (name == "Sophia")```) to examine the program execution and determine why Andrew's message is displayed when it shouldn't be
  - Use ```Step Into``` and ```Step Out``` and observe their behavior
    ```csharp
    /* 
    This code uses a names array and corresponding methods to display
    greeting messages
    */

    string[] names = new string[] { "Sophia", "Andrew", "AllGreetings" };

    string messageText = "";

    foreach (string name in names)
    {
        if (name == "Sophia")
            messageText = SophiaMessage();
        else if (name == "Andrew")
            messageText = AndrewMessage();
        else if (name == "AllGreetings")
            messageText = SophiaMessage();
            messageText = messageText + "\n\r" + AndrewMessage();

        Console.WriteLine(messageText + "\n\r");
    }

    bool pauseCode = true;
    while (pauseCode == true);

    static string SophiaMessage()
    {
        return "Hello, my name is Sophia.";
    }

    static string AndrewMessage()
    {
        return "Hi, my name is Andrew. Good to meet you.";
    }
    ```

### Recap
- Visual Studio Code enables setting breakpoints in the code editor or from the Run menu. Breakpoint code lines are marked with a red dot to the left of the line number.
- Breakpoints can be removed or disabled using the same options used to set them. Bulk operations that affect all breakpoints are available on the Run menu.
- Conditional breakpoints can be used to pause execution when a specified condition is met or when a 'hit count' is reached.
- Logpoints can be used to log information to the terminal without pausing execution or inserting code.

## Examine the Launch Configurations File

- ```launch.json``` files configures the debugger
- The default one created by VS Code is usually sufficient for debugging but customization is allowed

### Attributes of a launch configuration
- Can contain one or more launch configurations in the ```configurations``` list
- Each configuration supports different debugging scenarios
- Mandatory attributes
  - ```name```: the reader-friendly name assigned to the launch configuration
  - ```type```: type of debugger to use for the launch configuration; ```codeclr``` specifies debugger for .NET5+
  - ```request```: request type for the launch configuration (```launch``` and ```attach```)

- Other attributes
  - ```preLaunchTask```: task to run before debugging; task can be found in the ```tasks.json``` file; a prelaunch task of ```build``` runs a ```dotnet build``` command before launching the application
  - ```program```: path of the application dll or .NET Core host executable to launch; typically ```${workspaceFolder}/bin/Debug/<target-framework>/<project-name.dll>```
  - ```cwd```: specifies working directory of the target process
  - ```args```: arguments to pass to the program at launch
  - ```console```: type of console used when the application is launched
    - ```internalConsole```: default; corresponds to the DEBUG CONSOLE panel; doesn't support console input (```Console.ReadLine()```)
    - ```integratedTerminal```: corresponds to the OUTPUT panel
    - ```externalTerminal```: corresponds to an external terminal windows
  - ```stopAtEntry```: (```true``` | ```false```) stop at the entry point of the target

### Accommodate multiple applications
- If you have more than one launchable project, modify the ```launch.json``` file manually
- Example: You have a coding project that includes several console applications
  - The root project folder is **SpecialProjects**
  - The two applications are **Project123** and **Project456**
  - Note how the ```.vscode``` folder is associated with the workspace folder, not the individual project folders
    ```
    Special Projects
    |__.vscode
    |__Project123
    |__Project456
    ```

- Example ```launch.json``` file to include configurations for both the applications
  - Notice that the ```name```, ```preLaunchTask```, and ```program``` fields are all configured for a specific application
    ```json
    "version": "0.2.0",
    "configurations": [
        {
            "name": "Launch Project123",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "buildProject123",
            "program": "${workspaceFolder}/Project123/bin/Debug/net7.0/Project123.dll",
            "args": [],
            "cwd": "${workspaceFolder}/Project123",
            "console": "internalConsole",
            "stopAtEntry": false
        },
        {
            "name": "Launch Project456",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "buildProject456",
            "program": "${workspaceFolder}/Project456/bin/Debug/net7.0/Project456.dll",
            "args": [],
            "cwd": "${workspaceFolder}/Project456",
            "console": "internalConsole",
            "stopAtEntry": false
        }
    ]
    ```
- Example ```tasks.json``` file with build tasks specified to each application
  - The build task ensures that any saved edits are compiled and represented in the corresponding .dll file attached to the debugger
    ```json
    "version": "2.0.0",
    "tasks": [
        {
            "label": "buildProject123",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "${workspaceFolder}/Project123/Project123.csproj",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        },
        {
            "label": "buildProject456",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "${workspaceFolder}/Project456/Project456.csproj",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        }
    ]
    ```

### Recap
- Launch configurations are used to specify attributes such as ```name```, ```type```, ```request```, ```preLaunchTask```, ```program```, and ```console```.
- Developers can edit a launch configuration to accommodate project requirements.

## Conditional Breakpoints
- Configure a breakpoint that only triggers if a condition is met
- Example: configuring a breakpoint in a ```for``` loop for a specific item(s)

## Exercise:
- Enter a breakpoint on line 9 (```result = Process1(products, i)```)
- Start debugging, then use Step Into until ```i = 3```; stop debugging
- Edit the breakpoint to include a conditional statement
  ```products[i,1] == "new";

- Start debugging again
- Notice the program execution continues until condition is met and the value of ```i```
- Use Step Into to see when the debugging stops again
- Stop debugging
    ```csharp
    int productCount = 2000;
    string[,] products = new string[productCount, 2];

    LoadProducts(products, productCount);

    for (int i = 0; i < productCount; i++)
    {
        string result;
        result = Process1(products, i);

        if (result != "obsolete")
        {
            result = Process2(products, i);
        }
    }

    bool pauseCode = true;
    while (pauseCode == true) ;

    static void LoadProducts(string[,] products, int productCount)
    {
        Random rand = new Random();

        for (int i = 0; i < productCount; i++)
        {
            int num1 = rand.Next(1, 10000) + 10000;
            int num2 = rand.Next(1, 101);

            string prodID = num1.ToString();

            if (num2 < 91)
            {
                products[i, 1] = "existing";
            }
            else if (num2 == 91)
            {
                products[i, 1] = "new";
                prodID = prodID + "-n";
            }
            else
            {
                products[i, 1] = "obsolete";
                prodID = prodID + "-0";
            }

            products[i, 0] = prodID;
        }
    }

    static string Process1(string[,] products, int item)
    {
        Console.WriteLine($"Process1 message - working on {products[item, 1]} product");

        return products[item, 1];
    }

    static string Process2(string[,] products, int item)
    {
        Console.WriteLine($"Process2 message - working on product ID #: {products[item, 0]}");
        if (products[item, 1] == "new")
            Process3(products, item);

        return "continue";
    }

    static void Process3(string[,] products, int item)
    {
        Console.WriteLine($"Process3 message - processing product information for 'new' product");
    }
    ```

### Recap
- Use a standard breakpoint to pause an application each time a breakpoint is encountered.
- Use a conditional breakpoint to pause an application when a Boolean expression evaluates to ```true```.

## Monitor Variables and Execution Flow
- The RUN AND DEBUG view provides an easy way to monitor variables and expressions, observe execution flow, and managed breakpoint during the debug process

### VARIABLES section
- Organizes variables by scope
- The ```Locals``` scope displays variables in the current scope (the current method)
- Can also change value of a variable at runtime by double-clicking the variable name and entering a new value

### WATCH Section
- Use the **Add Expression** button to enter a variable name or an expression to watch
- Can also right-click a variable in the VARIABLES section and select ```Add to watch```
- All expressions in the WATCH section will be updated automatically as your code runs

### CALL STACK Section
- A call layer is added to the application's call stack each time the code enters a method from another method
- This represents the trail of method calls
- Useful when trying to find the source location for an exception or WATCH expression
- The stack trace lists the name and origin of every method that was called leading up to the exception

### BREAKPOINTS Section
- Displays current breakpoint settings and used to enable or disable specific breakpoints during a debug session

### Exercise: Monitor Variables
- The program incorrectly outputs the answer for the sum of numbers in the array depending on the starting number
- Add a breakpoint on line 31
- Use the VARIABLES section to follow the value of ```sum``` in the ```SumValues``` method
- Implement a fix
    ```csharp
    string? readResult;
    int startIndex = 0;
    bool goodEntry = false;

    int[] numbers = { 1, 2, 3, 4, 5 };

    // Display the array to the console.
    Console.Clear();
    Console.Write("\n\rThe 'numbers' array contains: { ");
    foreach (int number in numbers)
    {
        Console.Write($"{number} ");
    }

    // To calculate a sum of array elements, 
    //  prompt the user for the starting element number.
    Console.WriteLine($"}}\n\r\n\rTo sum values 'n' through 5, enter a value for 'n':");
    while (goodEntry == false)
    {
        readResult = Console.ReadLine();
        goodEntry = int.TryParse(readResult, out startIndex);

        if (startIndex > 5)
        {
            goodEntry = false;
            Console.WriteLine("\n\rEnter an integer value between 1 and 5");
        }
    }

    // Display the sum and then pause.
    Console.WriteLine($"\n\rThe sum of numbers {startIndex} through {numbers.Length} is: {SumValues(numbers, startIndex)}");

    Console.WriteLine("press Enter to exit");
    readResult = Console.ReadLine();

    // This method returns the sum of elements n through 5
    static int SumValues(int[] numbers, int n)
    {
        int sum = 0;
        for (int i = n; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    ```

### Exercise: Monitor Watch Expressions
- Suppose you're working on an application that performs numeric calculations on a data set
- You believe that your code produces unreliable results when the ratio between two numeric variables is greater than 5
- You can use the WATCH section to monitor the calculated ratio
- Set a breakpoint on the final code line
- Set the following WATCH expression: ```num2 / num1 > 5```
- Run a debugging sessions until the WATCH expression evaluates to ```true```

    ```csharp
    bool exit = false;
    var rand = new Random();
    int num1 = 5;
    int num2 = 5;

    do
    {
        num1 = rand.Next(1, 11);
        num2 = num1 + rand.Next(1, 51);

    } while (exit == false);
    ```

### Exercise: Modify Variable Value
- Notice in the previous code that the code will never exit out of the ```do``` loop because ```exit``` will never be ```true```
- Debug the program again, and change the variable ```exit``` to true
- Watch the program now exit

### Recap
- Monitor variable state using the VARIABLES section of the RUN AND DEBUG view.
- Track an expression across time or different methods using the WATCH section of the RUN AND DEBUG view.
- Use the CALL STACK section of the RUN AND DEBUG view to find the source location of an exception or a WATCH expression.
- Use the VARIABLES section to change a variable's assigned value at runtime.

## Exercise: Complete a Challenge Activity Using the Debugger
- You're provided with a code sample that isn't producing the expected result
- You need to use breakpoints and the VARIABLES section of the RUN AND DEBUG view to help you figure out the issues.

    ```csharp
    /*  
    This code instantiates a value and then calls the ChangeValue method
    to update the value. The code then prints the updated value to the console.
    */
    int x = 5;

    ChangeValue(x);

    Console.WriteLine(x);

    void ChangeValue(int value) 
    {
        value = 10;
    }
    ```

- Solution 1: Change method return type and set equal to return value (this matched the suggested solution)
    ```csharp
    int x = 5;

    x = ChangeValue(x);

    Console.WriteLine(x);

    int ChangeValue(int value) 
    {
        value = 10;
        return value;
    }
    ```

- Solution 2: Changes global variable via method (probably not best practice)
    ```csharp
    int x = 5;

    ChangeValue();

    Console.WriteLine(x);

    void ChangeValue() 
    {
        x = 10;
    }
    ```