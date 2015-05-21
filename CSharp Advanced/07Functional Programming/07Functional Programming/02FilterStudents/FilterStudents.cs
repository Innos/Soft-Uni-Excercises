namespace LinqExercise
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class LinqExercise
    {
        public static void Main()
        {
            const string FilePath = @"../../Students-data.txt";

            List<Student> students = new List<Student>();
            using (var reader = new StreamReader(FilePath))
            {
                string firstLine = reader.ReadLine();
                string data;
                while ((data = reader.ReadLine()) != null)
                {
                    
                    string[] tokens = data.Split();

                    int id = int.Parse(tokens[0]);
                    string firstName = tokens[1];
                    string lastName = tokens[2];
                    string email = tokens[3];
                    string gender = tokens[4];
                    string studentType = tokens[5];
                    int examResult = int.Parse(tokens[6]);
                    int homeworksSent = int.Parse(tokens[7]);
                    int homeworksEvaluated = int.Parse(tokens[8]);
                    double teamworkScore = double.Parse(tokens[9]);
                    int attendancesCount = int.Parse(tokens[10]);
                    double bonus = double.Parse(tokens[11]);

                    students.Add(new Student(
                        id,
                        firstName,
                        lastName,
                        email,
                        gender,
                        studentType,
                        examResult,
                        homeworksSent,
                        homeworksEvaluated,
                        teamworkScore,
                        attendancesCount,
                        bonus));
                }

            }
            

            //Gender query
            //var males =
            //    from student in students
            //    where student.Gender == "Male"
            //    select new{student.FirstName, student.LastName, student.Gender};

            //foreach (var student in males)
            //{
            //    Console.WriteLine("{0} {1} - {2}", student.FirstName, student.LastName, student.Gender);
            //}

            //name A query
            //var namesWithA =
            //    from student in students
            //    where student.FirstName.First() == 'A'
            //    select new { student.FirstName, student.LastName };

            //foreach (var student in namesWithA)
            //{
            //    Console.WriteLine("{0} {1}",student.FirstName, student.LastName);
            //}

            //Score greater or equal to 350 and type "Online" query
            //var highscorers =
            //    from student in students
            //    where student.ExamResult >= 350 && 
            //    student.StudentType == "Online"
            //    select new { student.FirstName, student.LastName, student.StudentType, student.ExamResult };

            //foreach (var student in highscorers)
            //{
            //    Console.WriteLine("{0} {1} ({2}) - {3}", student.FirstName, student.LastName, student.StudentType, student.ExamResult);
            //}

            //Online students with higher or equal than 300 score ordered by descending order query
            //var orderedOnlineHighscorers =
            //    from student in students
            //    where student.ExamResult >= 300 &&
            //    student.StudentType == "Online"
            //    orderby student.ExamResult descending
            //    select new { student.FirstName, student.LastName, student.StudentType, student.ExamResult };

            //foreach (var student in orderedOnlineHighscorers)
            //{
            //    Console.WriteLine("{0} {1} ({2}) - {3}", student.FirstName, student.LastName, student.StudentType, student.ExamResult);
            //}

            //Students without homework in alphabetical order query
            //var studentsWithoutHomework =
            //    from student in students
            //    where student.HomeworksSent == 0
            //    orderby student.FirstName,
            //    student.LastName ascending
            //    select new { student.FirstName, student.LastName, student.HomeworksSent };

            //foreach (var student in studentsWithoutHomework)
            //{
            //    Console.WriteLine("{0} {1} ({2} homeworks sent)",student.FirstName,student.LastName,student.HomeworksSent);
            //}

            //Emails of all onsite students query
            //var onsiteStudentsEmails = students
            //    .Where(student => student.StudentType == "Onsite")
            //    .Select(student => student.Email);

            //foreach (var email in onsiteStudentsEmails)
            //{
            //    Console.WriteLine(email);
            //}

            //Exam results and attendance count of all students with less than 5 attendances query
            //var lowAttendeeResults = students
            //    .Where(student => student.AttendancesCount < 5)
            //    .Select(student => new { student.ExamResult, student.AttendancesCount });

            //foreach (var student in lowAttendeeResults)
            //{
            //    Console.WriteLine("Result: {0}, attendances: {1}", student.ExamResult, student.AttendancesCount);
            //}

            //Aggregate students who have 4 or more bonus query
            //var highBonusStudents = students.Count(student => student.Bonus >= 4);

            //Console.WriteLine(highBonusStudents);

            //Onsite average score query
            //var onsiteStudentsResults = students
            //    .Where(student =>student.StudentType == "Onsite")
            //    .Select(student => student.ExamResult);

            //Console.WriteLine("Onsite average: {0}",onsiteStudentsResults.Average());

            ////Online average score query
            //var onlineStudentsResults = students
            //    .Where(student => student.StudentType == "Online")
            //    .Select(student => student.ExamResult);

            //Console.WriteLine("Online average: {0}", onlineStudentsResults.Average());

            //Number of Students who have max teamwork score query
            //var maxTeamworkScoreStudents = students
            //    .Count(student => student.TeamworkScore == students.Max(score => score.TeamworkScore));

            //Console.WriteLine(maxTeamworkScoreStudents);
            
            //Alphabetical Grouping query
            //var alphabeticalGroups = students
            //    .OrderBy(student => student.FirstName)
            //    .GroupBy(student => student.FirstName.First());

            //foreach (var group in alphabeticalGroups)
            //{
            //    Console.WriteLine(group.Key);
            //    foreach (var student in group)
            //    {
            //        Console.WriteLine(" {0} {1}",student.FirstName,student.LastName);
            //    }
            //}

            //Grouped by type and sorted by exam result in descending order query
            var StudentsGroupedByTypeAndExamResults = students
                .OrderByDescending(student => student.ExamResult)
                .GroupBy(student => student.StudentType);

            foreach (var group in StudentsGroupedByTypeAndExamResults)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("{0} {1} - {2}",student.FirstName,student.LastName,student.ExamResult);
                }
            }
        }
    }
}
