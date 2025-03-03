Random random = new Random();

Console.WriteLine("Would you like to play? (Y/N)");
if (ShouldPlay())
{
    PlayGame();
}

void PlayGame()
{
    var play = true;

    while (play)
    {
        var target = random.Next(1, 5);
        var roll = random.Next(1, 6);

        Console.WriteLine($"Roll a number greater than {target} to win!");
        Console.WriteLine($"You rolled a {roll}");
        Console.WriteLine(WinOrLose(target, roll));
        Console.WriteLine("\nPlay again? (Y/N)");

        play = ShouldPlay();
    }
}

bool ShouldPlay()
{
    string? answer;
    bool response = false;
    bool validResponse = false;

    do
    {
        answer = Console.ReadLine();
        if (answer != null)
        {
            answer = answer.ToUpper().Trim();
            switch (answer)
            {
                case "Y":
                    validResponse = true;
                    response = true;
                    break;

                case "N":
                    validResponse = true;
                    break;

                default:
                    Console.WriteLine("Invalid response, try again (Y/N)");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid response, try again (Y/N)");
        }
    } while (validResponse == false);

    return response;
}

string WinOrLose(int target, int roll)
{
    string response = "";
    if (roll > target)
    {
        response = "You won! 🥳";
    }
    else if (roll < target)
    {
        response = "You lost! ☹️";
    }
    else
    {
        response = "It's a tie! 🤷";
    }

    return response;
}
