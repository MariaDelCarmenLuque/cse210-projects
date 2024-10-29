using System;

class Program
{
    static void Main(string[] args)
    {
       Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");
    //    Console.WriteLine(assignment1.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("Samuel Bennett","Multiplication", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary()); 
        Console.WriteLine(mathAssignment.GetHomeworkList());

    }
}