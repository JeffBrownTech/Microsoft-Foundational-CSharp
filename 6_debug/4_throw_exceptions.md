# Create and throw exceptions in C# console applications

- Exceptions can be thrown by your code when an issue or error condition is encountered
- Exception objects that describe an error are created and then thrown with the ```throw``` keyword
- When an exception is thrown by your code, the runtime searches for the nearest ```catch``` clause that can handle the exception.

## Examine how to create and throw exceptions in C#
- .NET provides exceptions classes that derive from the ```System.Exception``` base class
- Developer can also customize exception objects with application specific information by assigning property values
- Common exception types you might use when creating an exception:
  - ```ArgumentException``` or ```ArgumentNullException```: Use these exception types when a method or constructor is called with an invalid argument value or null reference.
  - ```InvalidOperationException```: Use this exception type when the operating conditions of a method don't support the successful completion of a particular method call.
  - ```NotSupportedException```: Use this exception type when an operation or feature is not supported.
  - ```IOException```: Use this exception type when an input/output operation fails.
  - ```FormatException```: Use this exception type when the format of a string or data is incorrect.
- Use the ```new``` keyword to create an instance of an exception
    ```ArgumentException invalidArgumentException = new ArgumentException();```

- The following code creates an exception object names ```invalidArgumentException``` with a custom ```Message``` property, then throws the exception:
    ```csharp
    ArgumentException invalidArgumentException = new ArgumentException("ArgumentException: The 'GraphData' method received data outside the expected range.");
    throw invalidArgumentException;
    ```

    **Note**: The ```Message``` property of an exception is readonly. A custom ```message``` property must be set when instantiating the object.

- Can also create an exception object directly within a ```throw``` statement:
    ```csharp
    throw new FormatException("FormatException: Calculations in process XYZ have been cancelled due to invalid data format.");
    ```

- Some considerations to keep in mind when throwing an exception include:
  - The ```Message``` property should explain the reason for the exception. However, information that's sensitive, or that represents a security concern shouldn't be put in the message text.
  - The ```StackTrace``` property is often used to track the origin of the exception. This string property contains the name of the methods on the current call stack, together with the file name and line number in each method that's associated with the exception. A ```StackTrace``` object is created automatically by the common language runtime (CLR) from the point of the ```throw``` statement. Exceptions must be thrown from the point where the stack trace should begin.

  ### When to throw an exception
  - Methods should throw an exception whenever they can't complete their intended purpose
  - Example
    ```csharp
    string[][] userEnteredValues = new string[][]
    {
            new string[] { "1", "two", "3"},
            new string[] { "0", "1", "2"}
    };

    foreach (string[] userEntries in userEnteredValues)
    {
        try
        {
            BusinessProcess1(userEntries);
        }
        catch (Exception ex)
        {
            if (ex.StackTrace.Contains("BusinessProcess1") && (ex is FormatException))
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void BusinessProcess1(string[] userEntries)
    {
        int valueEntered;

        foreach (string userValue in userEntries)
        {
            try
            {
                valueEntered = int.Parse(userValue);

                // completes required calculations based on userValue
                // ...
            }
            catch (FormatException)
            {
                FormatException invalidFormatException = new FormatException("FormatException: User input values in 'BusinessProcess1' must be valid integers");
                throw invalidFormatException;
            }
        }
    }
    ```

### Re-throwing exceptions
- ```throw``` can be used to re-throw an exception from inside a ```catch``` block
- In this case, ```throw``` does not take an exception operand
    ```csharp
    catch (Exception ex)
    {
        // handle or partially handle the exception
        // ...

        // re-throw the original exception object for further handling down the call stack
        throw;
    }
    ```

- You can also create a new exception object that wraps the original exception and pass the original exception as an argument to the constructor of a new exception object
    ```csharp
    catch (Exception ex)
    {
        // handle or partially handle the exception
        // ...

        // create a new exception object that wraps the original exception
        throw new ApplicationException("An error occurred", ex);
    }
    ```

 - Updated example
   - The ```BusinessProcess1``` method has been updated to include additional details. ```BusinessProcess1``` now encounters two issues and must generate exceptions for each issue.
  - The top-level statements have been updated. Top-level statements now call the ```OperatingProcedure1``` method. ```OperatingProcedure1``` calls ```BusinessProcess1``` within a ```try``` code block.
  - The ```OperatingProcedure1``` method is able to handle one of the exception types and partially handle the other. Once the partially handled exception is processed, ```OperatingProcedure1``` must re-throw the original exception.

    ```csharp
    try
    {
        OperatingProcedure1();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Exiting application.");
    }

    static void OperatingProcedure1()
    {
        string[][] userEnteredValues = new string[][]
        {
            new string[] { "1", "two", "3"},
            new string[] { "0", "1", "2"}
        };

        foreach(string[] userEntries in userEnteredValues)
        {
            try
            {
                BusinessProcess1(userEntries);
            }
            catch (Exception ex)
            {
                if (ex.StackTrace.Contains("BusinessProcess1"))
                {
                    if (ex is FormatException)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Corrective action taken in OperatingProcedure1");
                    }
                    else if (ex is DivideByZeroException)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Partial correction in OperatingProcedure1 - further action required");

                        // re-throw the original exception
                        throw;
                    }
                    else
                    {
                        // create a new exception object that wraps the original exception
                        throw new ApplicationException("An error occurred - ", ex);
                    }
                }
            }

        }
    }

    static void BusinessProcess1(string[] userEntries)
    {
        int valueEntered;

        foreach (string userValue in userEntries)
        {
            try
            {
                valueEntered = int.Parse(userValue);

                checked
                {
                    int calculatedValue = 4 / valueEntered;
                }
            }
            catch (FormatException)
            {
                FormatException invalidFormatException = new FormatException("FormatException: User input values in 'BusinessProcess1' must be valid integers");
                throw invalidFormatException;
            }
            catch (DivideByZeroException)
            {
                DivideByZeroException unexpectedDivideByZeroException = new DivideByZeroException("DivideByZeroException: Calculation in 'BusinessProcess1' encountered an unexpected divide by zero");
                throw unexpectedDivideByZeroException;

            }
        }
    }
    ```

### Things to avoid when throwing exceptions
- Don't use exceptions to change the flow of a program as part of ordinary execution. Use exceptions to report and handle error conditions.
- Exceptions shouldn't be returned as a return value or parameter instead of being thrown.
- Don't throw ```System.Exception```, ```System.SystemException```, ```System.NullReferenceException```, or ```System.IndexOutOfRangeException``` intentionally from your own source code.
- Don't create exceptions that can be thrown in debug mode but not release mode. To identify runtime errors during the development phase, use ```Debug.Assert``` instead.

## Exercise - Create and throw an exception
- Start with a sample application that includes a potential error condition inside a called method
- Your updated method will ```throw``` an exception when it detects the issue
- The exception will be handled in a ```catch``` block of the code that calls the method. The result is an application that provides a better user experience

- Solution:
    ```csharp
    // Prompt the user for the lower and upper bounds
    Console.Write("Enter the lower bound: ");
    int lowerBound = int.Parse(Console.ReadLine());

    Console.Write("Enter the upper bound: ");
    int upperBound = int.Parse(Console.ReadLine());

    decimal averageValue = 0;
    bool exit = false;

    do
    {
        try
        {
            // Calculate the sum of the even numbers between the bounds
            averageValue = AverageOfEvenNumbers(lowerBound, upperBound);

            // Display the value returned by AverageOfEvenNumbers in the console
            Console.WriteLine($"The average of even numbers between {lowerBound} and {upperBound} is {averageValue}.");

            exit = true;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("An error has occurred.");
            Console.WriteLine(ex.Message);
            Console.WriteLine($"The upper bound must be greater than {lowerBound}");
            Console.Write($"Enter a new upper bound (or enter Exit to quit): ");
            string? userResponse = Console.ReadLine();
            if (userResponse.ToLower().Contains("exit"))
            {
                exit = true;
            }
            else
            {
                upperBound = int.Parse(userResponse);
            }
        }
    } while (exit == false);

    // Wait for user input
    Console.ReadLine();

    static decimal AverageOfEvenNumbers(int lowerBound, int upperBound)
    {
        if (lowerBound >= upperBound)
        {
            throw new ArgumentOutOfRangeException("upperBound", "ArgumentOutOfRangeException: upper bound must be greater than lower bound.");
        }

        int sum = 0;
        int count = 0;
        decimal average = 0;

        for (int i = lowerBound; i <= upperBound; i++)
        {
            if (i % 2 == 0)
            {
                sum += i;
                count++;
            }
        }

        average = (decimal)sum / count;

        return average;
    }
    ```

## Exercise - Complete a challenge activity for creating and throwing exceptions
- Start with a sample application that uses a series of method calls to process data
- The top-level statements create an array of user input values and call a method named ```Workflow1```
- ```Workflow1``` represents a high-level workflow that loops through the array and passes user input values to a method named ```Process1```
- ```Process1``` uses the user input data to calculate a value.
- Currently, when ```Process1``` encounters an issue or error, it returns a string describing the issue rather than throwing an exception
- Your challenge is to implement exception handling in the sample application.

- Starting sample application:
    ```csharp
    string[][] userEnteredValues = new string[][]
    {
                new string[] { "1", "2", "3"},
                new string[] { "1", "two", "3"},
                new string[] { "0", "1", "2"}
    };

    string overallStatusMessage = "";

    overallStatusMessage = Workflow1(userEnteredValues);

    if (overallStatusMessage == "operating procedure complete")
    {
        Console.WriteLine("'Workflow1' completed successfully.");
    }
    else
    {
        Console.WriteLine("An error occurred during 'Workflow1'.");
        Console.WriteLine(overallStatusMessage);
    }

    static string Workflow1(string[][] userEnteredValues)
    {
        string operationStatusMessage = "good";
        string processStatusMessage = "";

        foreach (string[] userEntries in userEnteredValues)
        {
            processStatusMessage = Process1(userEntries);

            if (processStatusMessage == "process complete")
            {
                Console.WriteLine("'Process1' completed successfully.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("'Process1' encountered an issue, process aborted.");
                Console.WriteLine(processStatusMessage);
                Console.WriteLine();
                operationStatusMessage = processStatusMessage;
            }
        }

        if (operationStatusMessage == "good")
        {
            operationStatusMessage = "operating procedure complete";
        }

        return operationStatusMessage;
    }

    static string Process1(String[] userEntries)
    {
        string processStatus = "clean";
        string returnMessage = "";
        int valueEntered;

        foreach (string userValue in userEntries)
        {
            bool integerFormat = int.TryParse(userValue, out valueEntered);

            if (integerFormat == true)
            {
                if (valueEntered != 0)
                {
                    checked
                    {
                        int calculatedValue = 4 / valueEntered;
                    }
                }
                else
                {
                    returnMessage = "Invalid data. User input values must be non-zero values.";
                    processStatus = "error";
                }
            }
            else
            {
                returnMessage = "Invalid data. User input values must be valid integers.";
                processStatus = "error";
            }
        }

        if (processStatus == "clean")
        {
            returnMessage = "process complete";
        }

        return returnMessage;
    }
    ```

- Requirements:
  - All methods must be converted from ```static string``` methods to ```static void``` methods.
  - The ```Process1``` method must throw exceptions for each type of issue encountered.
  - The ```Workflow1``` method must catch and handle the ```FormatException``` exceptions.
  - The top-level statements must catch and handle the ```DivideByZeroException``` exceptions.
  - The ```Message``` property of the exception must be used to notify the user of the issue.

- Completed solution must print the following messages to the console:
    ```
    'Process1' completed successfully.

    'Process1' encountered an issue, process aborted.
    Invalid data. User input values must be valid integers.

    An error occurred during 'Workflow1'.
    Invalid data. User input values must be non-zero values.
    ```

- Solution: [challenge_throw_exceptions\Program.cs](./solutions/challenge_throw_exceptions/Program.cs)