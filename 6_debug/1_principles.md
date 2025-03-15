# Review the principles of code debugging and exception handling

## Getting Started
- Build errors occur during the application build process
- Error that occur during the application runtime (when the application is running) are referred to as exceptions
- Exception handling is the process to manage runtime exceptions within the code

### Software Testing Categories
- Functional
  - Unit testing
  - Integration testing
  - System testing
  - Acceptance testing
- Nonfunctional
  - Security testing
  - Performance testing
  - Usability testing
  - Compatibility testing

- Some level of testing is expected before a developer hands off their work

### Debugging
- Process that developers use to isolate an issue and identify how to fix it

### Recap
- Testing, debugging, and exception handling are all important tasks for software developers.
- Testing can be categorized into functional and nonfunctional testing, and developers are expected to perform some level of testing.
- Code debugging is the process of isolating issues and identifying ways to fix them, and it's a developer responsibility.
- Exception handling is the process of managing errors that occur during runtime, and developers are responsible for handling exceptions by using "try" and "catch" statements in their code.

## Examine the Code Debugger Approach to Debugging Code
- A debugger is a software rool used to observe and control the execution flow of the program with an analytical approach
- Help isolate the cause of a bug and resolve it
- Debuggers allow watching the program run, following execution one line at a time
- Debuggers should:
  - Control program execution by pausing the program and running it step-by-step, allowing you to see what code is executed and how it affects your program's state
  - Observe the program state, such as variable values and function parameters at any point during code execution

### Recap
- Code debugging is a crucial skill in the software development process that every developer learns.
- The best approach to debugging your applications is to use a debugger, not rereading your code five times or adding ```Console.WriteLine()``` statements throughout your code.
- Debuggers enable you to pause your application, step through your code line-by-line, and observe the state of variables and function parameters.

## Examine Exceptions and How Exceptions are Used
- Errors at runtime are called exceptions
- Exceptions are thrown by code that encounters an error and are caught by code that can correct the error
- Exceptions are represented by classes derived from ```Exception```
- Each class identifies that type of exception and contains properties that have details about the exception

### Throw and Catch Exceptions
- Exceptions are created by the .NET runtime when an error occurs in the code (thrown)
- You can write code to catch an exception that's been thrown
- The code that catches the exception can be used to complete a corrective action, hopefully mitigate the situation
- You are writing code to protect the application when an error occurs