# Guided project - Debug and handle exceptions in a C# console application using Visual Studio Code
You're part of a team that's working on retail-support applications. The code that you're developing, the MakeChange method, manages the money till for a cash register application. Your application must meet the following specifications:

- A C# console application that simulates daily purchase transactions.
- The application calls the MakeChange method to manage the money till during transactions. MakeChange accepts cash payments and returns change.
- The calling application independently verifies the till balance after each transaction.
- A try-catch pattern is implemented to manage exceptions as follows:
  - Exceptions are used to report and handle any issue that prevents a transaction from completing successfully.
  - Exceptions are created and thrown in the MakeChange method.
  - Exceptions are caught and handled in the calling application.

An application that simulates transactions and calls the MakeChange method has already been developed. The Starter code project for this Guided project module includes a Program.cs file that includes the following code:
- Simulate transactions: the top-level statements configure application data and simulate a series of transactions using either a small testData array or a larger number of randomly generated transactions.
- Initialize the till: the LoadTillEachMorning method is used to configure the cash register till with a predefined number of bills in each denomination.
- Process transactions: the MakeChange method is used to manage the cash till during purchase transactions.
- Report till status: the LogTillStatus method is used to display the number of bills of each denomination currently in the till.
- Report till balance: the TillAmountSummary method is used display a message showing the amount of cash in the till.

**Note**: To keep the calculations simple, all item costs are whole numbers and include any tax or fee. This keeps the coding tasks focused on debugging and exception handling.

Your goal for this module is to verify that the application logic is working correctly, isolate and correct any logic bugs, and implement exception handling. To achieve this goal, you'll complete the following exercises:
1. Review and debug the existing application code.
2. Update the application to implement exception handling.

**Note**: This guided project included starter code that was updated through guided steps.

- Solution: [guided_retail_app/Program.cs](./solutions/guided_retail_app/Program.cs)