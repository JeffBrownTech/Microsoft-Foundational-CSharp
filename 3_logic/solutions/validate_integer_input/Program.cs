/*
    - Your solution must include either a do-while or while iteration.
    - Before the iteration block: your solution must use a Console.WriteLine() statement to prompt the user for an integer value between 5 and 10.
    - Inside the iteration block:
        - Your solution must use a Console.ReadLine() statement to obtain input from the user.
        - Your solution must ensure that the input is a valid representation of an integer.
        - If the integer value isn't between 5 and 10, your code must use a Console.WriteLine() statement to prompt the user for an integer value between 5 and 10.
        - Your solution must ensure that the integer value is between 5 and 10 before exiting the iteration.
    Below (after) the iteration code block: your solution must use a Console.WriteLine() statement to inform the user that their input value has been accepted.
*/

string? response;
int numericResponse = 0;
bool validNumber = false;
bool validInput = false;

Console.WriteLine("Enter an integer between 5 and 10:");

do
{
    response = Console.ReadLine();
    validNumber = int.TryParse(response, out numericResponse);
    
    if (validNumber && numericResponse > 5 && numericResponse < 10) { validInput = true; }
    else { Console.WriteLine("Invalid input! Enter an integer between 5 and 10:"); }
} while (validInput == false);

Console.WriteLine("Your input value has been accepted!");