using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();

        int gradePercentage = int.Parse(grade);
        string letterGrade;

        if(gradePercentage>= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        Console.WriteLine($"Your grade is: {letterGrade}");
        
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations.  You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't be discouraged! Keep trying, and you'll do better next time.");
        }

    }
}