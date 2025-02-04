// initialize variables - graded assignments 
int examAssignments = 5;
int[] sophiaScores = [90, 86, 87, 98, 100, 94, 90];
int[] andrewScores = [92, 89, 81, 96, 90, 89];
int[] emmaScores = [90, 85, 87, 98, 68, 89, 89, 89];
int[] loganScores = [90, 95, 87, 88, 96, 96];
int[] jeffScores = [80, 90, 92, 73, 96, 90];
string[] studentNames = ["Sophia", "Andrew", "Emma", "Logan", "Jeff"];
int[] studentScores = new int[examAssignments];

Console.WriteLine("Student\t\tGrade\n");

foreach (string name in studentNames)
{
    int studentScoreSum = 0;
    decimal studentAverage = 0;
    string studentLetterGrade = "";
    int gradedAssignments = 0;

    // Assign studentScores based on student
    if (name == "Sophia")
    {
        studentScores = sophiaScores;
    }
    else if (name == "Emma")
    {
        studentScores = emmaScores;
    }
    else if (name == "Logan")
    {
        studentScores = loganScores;
    }
    else if (name == "Andrew")
    {
        studentScores = andrewScores;
    }
    else if (name == "Jeff")
    {
        studentScores = jeffScores;
    }
    // Sum student scores
    foreach (int score in studentScores)
    {
        gradedAssignments++;
        if (gradedAssignments <= examAssignments)
        {
            studentScoreSum += score;
        }
        else
        {
            studentScoreSum += score / 10;
        }
    }
    // Calculate student average
    studentAverage = (decimal)studentScoreSum / examAssignments;
    // Determine letter grade
    if (studentAverage >= 97)
        studentLetterGrade = "A+";
    else if (studentAverage >= 93)
        studentLetterGrade = "A";
    else if (studentAverage >= 90)
        studentLetterGrade = "A-";
    else if (studentAverage >= 87)
        studentLetterGrade = "B+";
    else if (studentAverage >= 83)
        studentLetterGrade = "B";
    else if (studentAverage >= 80)
        studentLetterGrade = "B-";
    else if (studentAverage >= 77)
        studentLetterGrade = "C+";
    else if (studentAverage >= 73)
        studentLetterGrade = "C";
    else if (studentAverage >= 70)
        studentLetterGrade = "C-";
    else if (studentAverage >= 67)
        studentLetterGrade = "D+";
    else if (studentAverage >= 63)
        studentLetterGrade = "D";
    else if (studentAverage >= 60)
        studentLetterGrade = "D-";
    else
        studentLetterGrade = "F";
    Console.WriteLine($"{name}:\t\t{studentAverage}\t{studentLetterGrade}");
}

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();
