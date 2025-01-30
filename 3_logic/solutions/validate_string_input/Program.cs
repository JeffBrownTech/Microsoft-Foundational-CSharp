/*
    Your solution must include either a do-while or while iteration.

    Before the iteration block: your solution must use a Console.WriteLine() statement to prompt the user for one of three role names: Administrator, Manager, or User.

    Inside the iteration block:
        Your solution must use a Console.ReadLine() statement to obtain input from the user.
        Your solution must ensure that the value entered matches one of the three role options.
        Your solution should use the Trim() method on the input value to ignore leading and trailing space characters.
        Your solution should use the ToLower() method on the input value to ignore case.
        If the value entered isn't a match for one of the role options, your code must use a Console.WriteLine() statement to prompt the user for a valid entry.
    
    Below (after) the iteration code block: Your solution must use a Console.WriteLine() statement to inform the user that their input value has been accepted.
*/

bool validRole = false;
string? response;
string[] allRoles = ["Administrator", "Manager", "User"];

do
{
    Console.WriteLine("Enter your role name (Administrator, Manager, or User):");
    response = Console.ReadLine();

    foreach (string role in allRoles)
    {
        if (response.Trim().ToLower() == role.ToLower())
        {
            validRole = true;
            break;
        }
    }

    if (validRole == false) { Console.WriteLine($"The role name that you entered, \"{response}\" is not valid."); }
} while (validRole == false);

Console.WriteLine($"Your input value ({response}) has been accepted!");