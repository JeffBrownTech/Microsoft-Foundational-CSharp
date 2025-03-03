# Create C# methods with parameters

## Use Parameters in Methods
- Passing parameters to methods allows you to perform the method's tasks with different input values
- Provides information for the method to use
- 'Parameter' and 'argument' are used interchangeably
  - Parameter refers to the variable in the method signature
  - Argument is the value passed when calling the method
- Parameter definition includes the data type
  - Do not have to declare variable twice since the method signature defines the name and type

- Example: ```CountTo``` accepts an integer parameters named ```max```
    ```csharp
    CountTo(5);

	void CountTo(int max) 
	{
		for (int i = 0; i < max; i++)
		{
			Console.Write($"{i}, ");
		}
	}
    ```

### Exercise: Adjust Times to Different Time Zone
```csharp
int[] schedule = { 800, 1200, 1600, 2000 };

DisplayAdjustedTimes(schedule, 6, -6);

void DisplayAdjustedTimes(int[] times, int currentGMT, int newGMT)
{
    int diff = 0;
    if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
    {
        Console.WriteLine("Invalid GMT");
    }
    else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
    {
        diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
    }
    else
    {
        diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
    }

    for (int i = 0; i < times.Length; i++)
    {
        int newTime = ((times[i] + diff)) % 2400;
        Console.WriteLine($"{times[i]} -> {newTime}");
    }
}
```

### Exercise: Understand Method Scope
- Each code block has its own scope
- Variables declared inside a method, or any code block, are only accessible within that code block/region
- Global Variables
  - Variables declared outside of any code block (top-level statements)
  - Not restricted to any scope and can be used anywhere throughout the program
  - Can be used for different methods that need to access the same data

- Example
    ```csharp
    string[] students = {"Jenna", "Ayesha", "Carlos", "Viktor"};

    DisplayStudents(students);
    DisplayStudents(new string[] {"Robert","Vanya"});

    void DisplayStudents(string[] students) 
    {
        foreach (string student in students) 
        {
            Console.Write($"{student}, ");
        }
        Console.WriteLine();
    }
    ```

    Output:
    ```
    Jenna, Ayesha, Carlos, Viktor, 
    Robert, Vanya,
    ```
- The method parameter ```student``` takes precedence over the global ``student``` array

### Recap
- Variables declared inside of a method are only accessible to that method.
- Variables declared in top-level statements are accessible throughout the program.
- Methods don't have access to variables defined within different methods.
- Methods can call other methods.

## Exercise: Value and Reference Type Parameters
- Variables are value type and reference type, which describes how the variables store their values
  - Value types store their values directly: ```int```, ```bool```, ```float```, ```double```, and ```char```
  - Reference types store a memory address where their value is stored: ```string```, ```array```, objects (e.g. ```Random```)
    - **Note:** ```string``` is a reference type but is immutable; methods and operators that modify strings result in a new stirng object being returned
- Interaction with method arguments
  - Value type variables have their values copied into the method
    - Each variable has its own copy of the value, and the original variable is not modified
  - Reference type variables have their memory address passed into the method
    - Operations on the variable affect the value that is referenced by the other
- Test pass by value
    ```csharp
    int a = 3;
    int b = 4;
    int c = 0;

    Multiply(a, b, c);
    Console.WriteLine($"global statement: {a} x {b} = {c}");

    void Multiply(int a, int b, int c) 
    {
        c = a * b;
        Console.WriteLine($"inside Multiply method: {a} x {b} = {c}");
    }
    ```

    Output:
    ```
    inside Multiply method: 3 x 4 = 12
    global statement: 3 x 4 = 0
    ```

- Test pass by reference
    ```csharp
    int[] array = {1, 2, 3, 4, 5};

    PrintArray(array);
    Clear(array);
    PrintArray(array);

    void PrintArray(int[] array) 
    {
        foreach (int a in array) 
        {
            Console.Write($"{a} ");
        }
        Console.WriteLine();
    }

    void Clear(int[] array) 
    {
        for (int i = 0; i < array.Length; i++) 
        {
            array[i] = 0;
        }
    }
    ```

    Output:
    ```
    1 2 3 4 5 
    0 0 0 0 0
    ```

- Test with strings
  - This ```SetHealth``` method has its own variable ```status``` defined, so the global version value is not changed
    ```csharp
    string status = "Healthy";

    Console.WriteLine($"Start: {status}");
    SetHealth(status, false);
    Console.WriteLine($"End: {status}");

    void SetHealth(string status, bool isHealthy) 
    {
        status = (isHealthy ? "Healthy" : "Unhealthy");
        Console.WriteLine($"Middle: {status}");
    }
    ```

    Output:
    ```
    Start: Healthy
    Middle: Unhealthy
    End: Healthy
    ```

  - This method example does not have a local ```status``` defined, so the global value is modified
    ```csharp
    string status = "Healthy";

    Console.WriteLine($"Start: {status}");
    SetHealth(false);
    Console.WriteLine($"End: {status}");

    void SetHealth(bool isHealthy) 
    {
        status = (isHealthy ? "Healthy" : "Unhealthy");
        Console.WriteLine($"Middle: {status}");
    }
    ```

    Output:
    ```
    Start: Healthy
    Middle: Unhealthy
    End: Unhealthy
    ```

### Recap
- Variables can be categorized as value types and reference types.
- Value types directly contain values, and reference types store the address of the value.
- Methods using value type arguments create their own copy of the values.
- Methods that perform changes on an array parameter affect the original input array.
- String is an immutable reference type.
- Methods that perform changes on a string parameter don't affect the original string.

## Methods with Optional Parameters

### Named parameters
- Allow you to specify the value for a parameter using its name rather than position
    ```csharp
    RSVP(name: "Linh", partySize: 2, allergies: "none", inviteOnly: false);
    ```  

### Optional parameters
- Allow you to omit those arguments when calling the method
- A parameter is optional when it has a default value(e.g. ```partySize```, ```allergies```, and ```inviteOnly```)
    ```csharp
    void RSVP(string name, int partySize = 1, string allergies = "none", bool inviteOnly = true)
    ```

### Recap
- Parameters are made optional by setting a default value in the method signature.
- Named arguments are specified with the parameter name, followed by a colon and the argument value.
- When combining named and positional arguments, you must use the correct order of parameters.

## Exercise: Display Email Addresses
- Create a method that displays the correct email address for both internal and external employees
- Should include an optional parameter for the domain name of external employees
- Employee email address consists of their usernam and company domain name
  - Username is first two characters of first name, then last name
  - Internal employee domain is "contoso.com"

- Starter code:
    ```csharp
    string[,] corporate = 
    {
        {"Robert", "Bavin"}, {"Simon", "Bright"},
        {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
        {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
    };

    string[,] external = 
    {
        {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
        {"Shay", "Lawrence"}, {"Daren", "Valdes"}
    };

    string externalDomain = "hayworth.com";

    for (int i = 0; i < corporate.GetLength(0); i++) 
    {
        // display internal email addresses
    }

    for (int i = 0; i < external.GetLength(0); i++) 
    {
        // display external email addresses
    }

- Output:
    ```
    robavin@contoso.com
    sibright@contoso.com
    kisinclair@contoso.com
    aakamath@contoso.com
    sadelucchi@contoso.com
    siali@contoso.com
    viashton@hayworth.com
    codysart@hayworth.com
    shlawrence@hayworth.com
    davaldes@hayworth.com
    ```

- [Solution](./solutions/display_emails/Program.cs)