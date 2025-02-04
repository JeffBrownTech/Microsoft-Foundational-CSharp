// initialize variables - graded assignments 
int examAssignments = 5;
int[] sophiaScores = [90, 86, 87, 98, 100, 94, 90];
int[] andrewScores = [92, 89, 81, 96, 90, 89];
int[] emmaScores = [90, 85, 87, 98, 68, 89, 89, 89];
int[] loganScores = [90, 95, 87, 88, 96, 96];
string[] studentNames = ["Sophia", "Andrew", "Emma", "Logan"];
int[] studentScores = new int[examAssignments];

Console.WriteLine("Student\t\tExam Score\tOverall\tGrade\tExtra Credit\n");

foreach (string name in studentNames)
{
    int studentScoreSum = 0;
    int extraCreditScoreSum = 0;
    decimal extraCreditPoints = 0;
    decimal studentAverage = 0;
    decimal extraCreditAverage = 0;
    decimal studentAverageWithExtraCredit = 0;
    string studentLetterGrade = "";
    int gradedAssignments = 0;
    int gradedExtraCreditAssignments = 0;

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
            gradedExtraCreditAssignments++;
            extraCreditScoreSum += score;
        }
    }
    
    // Calculate student average before extra credit
    studentAverage = (decimal)studentScoreSum / examAssignments;
    
    // Calculate extra credit
    extraCreditAverage = (decimal)(extraCreditScoreSum) / gradedExtraCreditAssignments;
    extraCreditPoints = ((decimal)extraCreditScoreSum / 10) / examAssignments;
    
    // Calculate average with extra credit
    studentAverageWithExtraCredit = (decimal)studentAverage + extraCreditPoints;
    
    // Determine letter grade
    if (studentAverageWithExtraCredit >= 97)
        studentLetterGrade = "A+";
    else if (studentAverageWithExtraCredit >= 93)
        studentLetterGrade = "A";
    else if (studentAverageWithExtraCredit >= 90)
        studentLetterGrade = "A-";
    else if (studentAverageWithExtraCredit >= 87)
        studentLetterGrade = "B+";
    else if (studentAverageWithExtraCredit >= 83)
        studentLetterGrade = "B";
    else if (studentAverageWithExtraCredit >= 80)
        studentLetterGrade = "B-";
    else if (studentAverageWithExtraCredit >= 77)
        studentLetterGrade = "C+";
    else if (studentAverageWithExtraCredit >= 73)
        studentLetterGrade = "C";
    else if (studentAverageWithExtraCredit >= 70)
        studentLetterGrade = "C-";
    else if (studentAverageWithExtraCredit >= 67)
        studentLetterGrade = "D+";
    else if (studentAverageWithExtraCredit >= 63)
        studentLetterGrade = "D";
    else if (studentAverageWithExtraCredit >= 60)
        studentLetterGrade = "D-";
    else
        studentLetterGrade = "F";
    
    Console.WriteLine($"{name}\t\t{studentAverage}\t\t{studentAverageWithExtraCredit}\t{studentLetterGrade}\t{extraCreditAverage} ({extraCreditPoints} pts)");
}
