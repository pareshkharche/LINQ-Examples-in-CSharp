using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinqPractice
{   
    public class Program
    {    
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student{ Id=1, Name="Alice", Age=20, Subject="Math", Grade=85, City="NYC"},
                new Student { Id = 2, Name = "Bob", Age = 22, Subject = "Science", Grade = 90, City ="LA" },
                new Student { Id = 3, Name = "Charlie", Age = 19, Subject = "Math", Grade = 78, City ="NYC" },
                new Student { Id = 4, Name = "Diana", Age = 21, Subject = "Science", Grade = 92, City= "Chicago" },
                new Student { Id = 5, Name = "Eve", Age = 20, Subject = "Math", Grade = 88, City ="LA" },
                new Student { Id = 6, Name = "Frank", Age = 23, Subject = "History", Grade = 75, City ="NYC" },
                new Student { Id = 7, Name = "Grace", Age = 22, Subject = "Science", Grade = 95, City= "Chicago" },
                new Student { Id = 8, Name = "Henry", Age = 19, Subject = "History", Grade = 65, City ="LA" },
                new Student { Id = 9, Name = "Ivy", Age = 21, Subject = "Math", Grade = 82, City ="Chicago" },
                new Student { Id = 10, Name = "Jack", Age = 20, Subject = "History", Grade = 70, City ="NYC" }
            };


            //LINQ queries here


            //student who score above 80
            Console.WriteLine("Student who score above 80");
            var topStudents = students.Where(s => s.Grade > 80);
            foreach (var student in topStudents)
            {
                Console.WriteLine($"{student.Name}: {student.Grade}");
            }

            Console.WriteLine("====================================");

            //students from NYC
            Console.WriteLine("Students from NYC");
            var nycStudents = students.Where(s => s.City == "NYC");
            foreach (var student in nycStudents)
            {
                Console.WriteLine($"{student.Name}");
            }


            Console.WriteLine("====================================");

            //Multiple conditions (AND)
            Console.WriteLine("Multiple conditions (AND)");
            var mathToppers = students.Where(s => s.Subject == "Math" && s.Grade > 80);
            foreach (var student in mathToppers)
            {
                Console.WriteLine($"{student.Name}: {student.Grade}");
            }

            Console.WriteLine("====================================");

            //Multiple consitions (OR)
            Console.WriteLine("Multiple conditions (OR)");
            var youngOrToppers = students.Where(s => s.Age < 20 || s.Grade > 90);
            foreach (var student in youngOrToppers)
            {
                Console.WriteLine($"{student.Name}= Age: {student.Age} , Grade: {student.Grade}");
            }

            Console.WriteLine("====================================");

            //SELECT - TRANSFORM DATA
            //GET ONLY NAMES

            Console.WriteLine("Select - transfrom data");
            Console.WriteLine("Get Only Names");
            var names = students.Select(s => s.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }


            Console.WriteLine("====================================");
            //get names and grades
            Console.WriteLine("Get Names and Grades");
            var nameGrades = students.Select(s => new { s.Name, s.Grade });
            foreach (var item in nameGrades)
            {
                Console.WriteLine($"{item.Name} : {item.Grade}");
            }


            Console.WriteLine("====================================");
            //Transform to upppercae
            Console.WriteLine("Transform to Uppercase");
            var upperName = students.Select(s => s.Name.ToUpper());
            foreach (var name in upperName)
            {
                Console.WriteLine(name);
            }


            Console.WriteLine("====================================");
            //Create Custome Format
            Console.WriteLine("Create Custom Format");
            var formatted = students.Select(s => $"{s.Name} ({s.Age} years) - {s.Grade}%");
            foreach (var item in formatted)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("====================================");
            //3. WHERE + SELECT Combined
            Console.WriteLine("WHERE + SELECT Combine");
            var topStudentNames = students
                .Where(s => s.Grade > 85)
                .Select(s => new { s.Name, s.Grade });
            foreach (var name in topStudentNames)
            {
                Console.WriteLine($"{name.Name}: {name.Grade}");
            }


            Console.WriteLine("====================================");
            //Math students with formatted output
            Console.WriteLine("Maths Students with formatted output");
            var mathStudents = students
                .Where(s => s.Subject == "Math")
                .Select(s => $"{s.Name}: {s.Grade}%");
            foreach (var student in mathStudents)
            {
                Console.WriteLine(student);
            }


            Console.WriteLine("====================================");
            //OrderBy/OrderByDescending-sort Data
            Console.WriteLine("OrderBy / OrderByDescending - Sort Data");
            Console.WriteLine("SortBy grade (ascending");
            var sortedByGrade = students.OrderBy(s => s.Grade);
            foreach (var student in sortedByGrade)
            {
                Console.WriteLine($"{student.Name} - {student.Grade}");
            }

            Console.WriteLine("====================================");
            //Sort by grade (Descending)
            Console.WriteLine("Sort By Grade {Descending");
            var toToBottom = students.OrderByDescending(s => s.Grade);
            foreach (var student in toToBottom)
            {
                Console.WriteLine($"{student.Name} - {student.Grade}");
            }


            Console.WriteLine("====================================");
            //sort by multiple fields
            Console.WriteLine("Sort By Multiple Fields");
            var sorted = students
                .OrderBy(s => s.Subject)
                .ThenByDescending(s => s.Grade);
            foreach (var student in sorted)
            {
                Console.WriteLine($"{student.Subject} - {student.Name}: {student.Grade}");
            }


            Console.WriteLine("====================================");
            //Sort, Filter and select
            Console.WriteLine("Sort, Filter and Select");
            var topMathStudents = students
                .Where(s => s.Subject == "Math")
                .OrderByDescending(s => s.Grade)
                .Select(s => s.Name);
            foreach (var name in topMathStudents)
            {
                Console.WriteLine(name);
            }


            Console.WriteLine("====================================");
            //GroupBy-Group data
            Console.WriteLine("GroupBy - Groupdata");
            //group by subject
            Console.WriteLine("GroupBy Subject");
            var bySubject = students.GroupBy(s => s.Subject);
            foreach (var group in bySubject)
            {
                Console.WriteLine($"\n{group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($" {student.Name}: {student.Grade}");
                }

            }


            Console.WriteLine("====================================");
            //Count student per subject
            Console.WriteLine("Count students per subject");
            var subjectCount = students.GroupBy(s => s.Subject);
            foreach (var group in subjectCount)
            {
                Console.WriteLine($"{group.Key} : {group.Count()} students");
            }


            Console.WriteLine("====================================");
            //Average grade per subject
            Console.WriteLine("Average grade per subject");
            var averageBySuject = students.GroupBy(s => s.Subject);
            foreach (var group in averageBySuject)
            {
                double avg = group.Average(s => s.Grade);
                Console.WriteLine($"{group.Key}: {avg:F2}");
            }


            Console.WriteLine("====================================");
            //group by city and get top student
            Console.WriteLine("GroupBy city and get top student");
            var topByCity = students
                .GroupBy(s => s.City)
                .Select(g => new
                {
                    City = g.Key,
                    TopStudent = g.OrderByDescending(s => s.Grade).First()
                });
            foreach (var item in topByCity)
            {
                Console.WriteLine($"{item.City}: {item.TopStudent.Name} - {item.TopStudent.Grade}");
            }

            Console.WriteLine("====================================");
            //group by city and get top student
            Console.WriteLine("GroupBy city and get top student -    using tuple");
            var topByCityy = students
                .GroupBy(s => s.City)
                .Select(g =>
                (
                    City: g.Key,
                    TopStudent: g.OrderByDescending(s => s.Grade).First()
                ));
            foreach (var item in topByCityy)
            {
                Console.WriteLine($"{item.City}: {item.TopStudent.Name} - {item.TopStudent.Grade}");
            }



            Console.WriteLine("====================================");
            //First / Firstorderdefault
            Console.WriteLine("FIRST / FIRSTORDERDEFAULT");
            Console.WriteLine("Get the first element");
            Console.WriteLine("First student ");
            var first = students.First();
            Console.WriteLine(first.Name);


            Console.WriteLine("====================================");
            //first with condition
            Console.WriteLine("First with condition");
            var firstScienceStudent = students.First(s => s.Subject == "Science");
            Console.WriteLine(firstScienceStudent.Name);


            Console.WriteLine("====================================");
            //FirstOrDefault (safe - returns null if not found)
            Console.WriteLine("FirstOrDefault (safe - returns null of not found)");
            var student1 = students.FirstOrDefault(s => s.Name == "Zara");
            if (student1 == null)
            {
                Console.WriteLine("Student not found");
            }


            Console.WriteLine("====================================");
            //First after sorting
            Console.WriteLine("First After Sorting");
            var topStudent = students.OrderByDescending(s => s.Grade).First();
            Console.WriteLine($"Top student: {topStudent.Name} - {topStudent.Grade}");

            Console.WriteLine("====================================");
            //Last / LastOrDefault
            //Last student
            Console.WriteLine("Last / LastOrDefault");
            Console.WriteLine("Last student");
            var last = students.Last();
            Console.WriteLine(last.Name);


            Console.WriteLine("====================================");
            //Last with condition
            Console.WriteLine("Last with condition");
            var lastMathStudent = students.Last(s => s.Subject == "Math");
            Console.WriteLine(lastMathStudent.Name);


            Console.WriteLine("====================================");
            //Single / SingleOrDefault
            //Single (when you except exactly one)
            Console.WriteLine("Single/SingleOrDefault");
            Console.WriteLine("Single (when you except exactly one)");
            var grace = students.Single(s => s.Name == "Grace");
            Console.WriteLine(grace.Grade);

            Console.WriteLine("====================================");
            //SingleOrDefault (safe version)
            Console.WriteLine("SingleOrDefault (safe version)");
            var student2 = students.SingleOrDefault(s => s.Name == "Grace");
            if (student2 != null)
            {
                Console.WriteLine(student2.Grade);
            }



            Console.WriteLine("====================================");
            //Any/all
            //any student failed?
            Console.WriteLine("Any / All");
            Console.WriteLine("Any student failed");
            bool anyFailed = students.Any(s => s.Grade < 40);
            Console.WriteLine(anyFailed);

            Console.WriteLine("====================================");
            //any student from LA?
            Console.WriteLine("Any student from LA?");
            bool hasLA = students.Any(s => s.City == "LA");
            Console.WriteLine(hasLA);

            Console.WriteLine("====================================");
            //all student passed?
            Console.WriteLine("All student passed?");
            bool allPassed = students.All(s => s.Grade >= 40);
            Console.WriteLine(allPassed);

            Console.WriteLine("====================================");
            //all students are adults?
            Console.WriteLine("All students are adults");
            bool allAdults = students.All(s => s.Age >= 18);
            Console.WriteLine(allAdults);


            Console.WriteLine("====================================");
            //COUNT / SUM / AVERAGE / MIN / MAX
            //aggregate functions
            //count
            Console.WriteLine("COUNT / SUM /AVERAGE / MIN / MAX");
            Console.WriteLine("COUNT");
            int total = students.Count();
            Console.WriteLine($"Total students: {total}");

            int mathCount = students.Count(s => s.Subject == "Math");
            Console.WriteLine($"Math students: {mathCount}");


            Console.WriteLine("====================================");
            Console.WriteLine("SUM");
            int totalGrades = students.Sum(s => s.Grade);
            Console.WriteLine($"Total grades: {totalGrades}");

            int mathTotalGrades = students.Where(s => s.Subject == "Math").Sum(s => s.Grade);
            Console.WriteLine($"Math total: {mathTotalGrades}");



            Console.WriteLine("====================================");
            Console.WriteLine("Average");
            double avgGrade = students.Average(s => s.Grade);
            Console.WriteLine($"Average grade: {avgGrade:F2}");

            double mathAvg = students.Where(s => s.Subject == "Math").Average(s => s.Grade);
            Console.WriteLine($"Math average: {mathAvg:F2}");


            Console.WriteLine("====================================");
            Console.WriteLine("MIN/MAX");

            int lowestGrade = students.Min(s => s.Grade);
            Console.WriteLine($"Lowest grade: {lowestGrade}");

            int highestGrade = students.Max(s => s.Grade);
            Console.WriteLine($"Highest grade: {highestGrade}");


            Console.WriteLine("====================================");
            //take/skip a number of elements
            //top 3 students
            Console.WriteLine("Take/skip a number of elements");
            Console.WriteLine("Top 3 students");
            var top3 = students.OrderByDescending(s => s.Grade).Take(3);
            foreach (var student in top3)
            {
                Console.WriteLine($"{student.Name}: {student.Grade}");
            }


            Console.WriteLine("====================================");
            //skip first 5 students
            Console.WriteLine("Skip first 5 students");
            var remaining = students.Skip(5);
            foreach (var student in remaining)
            {
                Console.WriteLine(student.Name);
            }


            Console.WriteLine("====================================");
            //Pagination(skip3, take3)
            Console.WriteLine("Pagination (skip3, take3");
            var page2 = students.Skip(3).Take(3);
            foreach (var student in page2)
            {
                Console.WriteLine(student.Name);
            }


            Console.WriteLine("====================================");
            //DISTINCT
            //remove duplicates
            //Distinct subjects
            Console.WriteLine("DISTINCT");
            Console.WriteLine("Remove duplicates");
            Console.WriteLine("Distinct subjects");
            var subjects = students.Select(s => s.Subject).Distinct();
            foreach(var subject in subjects)
            {
                Console.WriteLine(subject);
            }


            Console.WriteLine("====================================");
            Console.WriteLine("DISTINCT");
            Console.WriteLine("Remove duplicates");
            Console.WriteLine("Distinct cities");
            var cities = students.Select(s => s.City).Distinct();
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }



            Console.WriteLine("====================================");
            Console.WriteLine("====================================");
            Console.WriteLine("====================================");


            List<Course> courses = new List<Course>
            {
                 new Course{Subject="Math", Teacher="Dr.Smith"},
                 new Course{Subject="Science", Teacher="Dr.Johnson"},
                 new Course{Subject="History", Teacher="Dr.Brown"}

               
            };

            Console.WriteLine("====================================");
            //JOIN
            //Combine two Collections
            //Add Courses data
            Console.WriteLine("JOIN");
            Console.WriteLine("Combine two Collections");
            Console.WriteLine("Add coursees data");
            var studentCourses = students.Join(
            courses,                          // Second collection
            student => student.Subject,       // Key from students
            course => course.Subject,         // Key from courses
            (student, course) => new          // Result
            {
                student.Name,
                student.Subject,
                course.Teacher
            }
            );

            foreach (var item in studentCourses)
            {
                Console.WriteLine($"{item.Name} studies {item.Subject} with {item.Teacher}");
            }
            // Output: Alice studies Math with Dr. Smith, ..........etc.


            Console.WriteLine("====================================");
            //TOLIST/TOARRAY/TODICTIONARY
            //Convert to different collection types
            //Example 1: ToList
            Console.WriteLine("TOLIST/TOARRAY/TODICTIONARY");
            Console.WriteLine("Convert to differnet collection types");
            Console.WriteLine("Example 1: ToList");
            
            List<Student> topStundets1 = students.Where(s => s.Grade > 85).ToList();
            foreach (var student in topStundets1)
            {
                Console.WriteLine($"{student.Name} - {student.Grade}");
            }

            Console.WriteLine("Example 2: ToArray");

            string[] names1 =students.Select(s=>s.Name).ToArray();
            foreach (var name in names1)
            {
                Console.WriteLine(name);
            }


            Console.WriteLine("Example 3: ToDictionary");

            Dictionary<int, Student> studentDict = students.ToDictionary(s => s.Id);
            Console.WriteLine(studentDict[5].Name);



            Console.WriteLine("========================================");
            Console.WriteLine("EXERCISE 1: FILTER & SORT");
            Console.WriteLine("========================================\n");

            // 1.1: Get all students from Chicago who scored above 80, sorted by grade
            Console.WriteLine("1.1: Chicago students with grade > 80 (sorted by grade):");
            Console.WriteLine("--------------------------------------------------");

            var chicagoTopStudents = students
            .Where(s => s.City == "Chicago" && s.Grade > 80)
            .OrderBy(s => s.Grade);

            foreach (var student in chicagoTopStudents)
            {
                Console.WriteLine($"{student.Name}: {student.Grade} ({student.Subject})");
            }
            // Output: Ivy: 82 (Math), Diana: 92 (Science), Grace: 95 (Science)

            Console.WriteLine();

            // 1.2: Get names of the bottom 3 students
            Console.WriteLine("1.2: Bottom 3 students by grade:");
            Console.WriteLine("--------------------------------------------------");

            var bottom3 = students
                .OrderBy(s => s.Grade)
                .Take(3)
                .Select(s => s.Name);

            foreach (var name in bottom3)
            {
                Console.WriteLine(name);
            }
            // Output: Henry, Jack, Frank





            Console.WriteLine("\n========================================");
            Console.WriteLine("EXERCISE 2: GROUPING");
            Console.WriteLine("========================================\n");

            // 2.1: Group by Age and show count for each age
            Console.WriteLine("2.1: Student count by Age:");
            Console.WriteLine("--------------------------------------------------");

            var countByAge = students
                .GroupBy(s => s.Age)
                .OrderBy(g => g.Key);

            foreach (var group in countByAge)
            {
                Console.WriteLine($"Age {group.Key}: {group.Count()} students");
                foreach (var student in group)
                {
                    Console.WriteLine($"  - {student.Name}");
                }
            }
            // Output:
            // Age 19: 2 students (Charlie, Henry)
            // Age 20: 3 students (Alice, Eve, Jack)
            // Age 21: 2 students (Diana, Ivy)
            // Age 22: 2 students (Bob, Grace)
            // Age 23: 1 student (Frank)

            Console.WriteLine();

            // 2.2: Group by City and calculate average grade per city
            Console.WriteLine("2.2: Average grade by City:");
            Console.WriteLine("--------------------------------------------------");

            var avgGradeByCity = students
                .GroupBy(s => s.City)
                .Select(g => new
                {
                    City = g.Key,
                    AverageGrade = g.Average(s => s.Grade),
                    StudentCount = g.Count()
                })
                .OrderByDescending(x => x.AverageGrade);

            foreach (var item in avgGradeByCity)
            {
                Console.WriteLine($"{item.City}: {item.AverageGrade:F2} (from {item.StudentCount} students)");
            }
            // Output:
            // Chicago: 89.67 (from 3 students)
            // LA: 81.00 (from 3 students)
            // NYC: 77.00 (from 4 students)

            Console.WriteLine("\n========================================");
            Console.WriteLine("EXERCISE 3: COMPLEX QUERIES");
            Console.WriteLine("========================================\n");

            // 3.1: Find the subject with the highest average grade
            Console.WriteLine("3.1: Subject with highest average grade:");
            Console.WriteLine("--------------------------------------------------");

            var topSubject = students
                .GroupBy(s => s.Subject)
                .Select(g => new
                {
                    Subject = g.Key,
                    AverageGrade = g.Average(s => s.Grade),
                    StudentCount = g.Count()
                })
                .OrderByDescending(x => x.AverageGrade)
                .First();

            Console.WriteLine($"{topSubject.Subject}: {topSubject.AverageGrade:F2} average");
            Console.WriteLine($"(from {topSubject.StudentCount} students)");
            // Output: Science: 92.33 average

            Console.WriteLine();

            // 3.2: Get the youngest student from each city
            Console.WriteLine("3.2: Youngest student from each city:");
            Console.WriteLine("--------------------------------------------------");

            var youngestByCity = students
                .GroupBy(s => s.City)
                .Select(g => new
                {
                    City = g.Key,
                    YoungestStudent = g.OrderBy(s => s.Age).First()
                });

            foreach (var item in youngestByCity)
            {
                Console.WriteLine($"{item.City}: {item.YoungestStudent.Name} (Age {item.YoungestStudent.Age})");
            }
            // Output:
            // NYC: Charlie (Age 19)
            // LA: Henry (Age 19)
            // Chicago: Diana (Age 21)

            Console.WriteLine();

            // 3.3: Find students whose grade is above the overall average
            Console.WriteLine("3.3: Students with grade above overall average:");
            Console.WriteLine("--------------------------------------------------");

            double overallAverage = students.Average(s => s.Grade);
            Console.WriteLine($"Overall average grade: {overallAverage:F2}\n");

            var aboveAverage = students
                .Where(s => s.Grade > overallAverage)
                .OrderByDescending(s => s.Grade);

            foreach (var student in aboveAverage)
            {
                Console.WriteLine($"{student.Name}: {student.Grade} ({student.Subject})");
            }
            // Output: Grace: 95, Diana: 92, Bob: 90, Eve: 88, Alice: 85

            Console.WriteLine("\n========================================");
            Console.WriteLine("EXERCISE 4: AGGREGATES");
            Console.WriteLine("========================================\n");

            // 4.1: Calculate total grades for each subject
            Console.WriteLine("4.1: Total grades for each subject:");
            Console.WriteLine("--------------------------------------------------");

            var totalGradesBySubject = students
                .GroupBy(s => s.Subject)
                .Select(g => new
                {
                    Subject = g.Key,
                    TotalGrades = g.Sum(s => s.Grade),
                    StudentCount = g.Count(),
                    AverageGrade = g.Average(s => s.Grade)
                })
                .OrderByDescending(x => x.TotalGrades);

            foreach (var item in totalGradesBySubject)
            {
                Console.WriteLine($"{item.Subject}:");
                Console.WriteLine($"  Total: {item.TotalGrades}");
                Console.WriteLine($"  Students: {item.StudentCount}");
                Console.WriteLine($"  Average: {item.AverageGrade:F2}");
                Console.WriteLine();
            }
            // Output:
            // Math: Total 333, Students 4, Average 83.25
            // Science: Total 277, Students 3, Average 92.33
            // History: Total 210, Students 3, Average 70.00

            // 4.2: Find the age range (max - min) of students
            Console.WriteLine("4.2: Age range of students:");
            Console.WriteLine("--------------------------------------------------");

            int minAge = students.Min(s => s.Age);
            int maxAge = students.Max(s => s.Age);
            int ageRange = maxAge - minAge;

            Console.WriteLine($"Minimum Age: {minAge}");
            Console.WriteLine($"Maximum Age: {maxAge}");
            Console.WriteLine($"Age Range: {ageRange} years");
            // Output: Min 19, Max 23, Range 4 years

            Console.WriteLine();

            // 4.3: Count how many students are in each grade range (0-60, 61-80, 81-100)
            Console.WriteLine("4.3: Students count by grade range:");
            Console.WriteLine("--------------------------------------------------");

            var gradeRanges = new[]
            {
            new { Range = "0-60 (Fail)", Count = students.Count(s => s.Grade >= 0 && s.Grade <= 60) },
            new { Range = "61-80 (Pass)", Count = students.Count(s => s.Grade >= 61 && s.Grade <= 80) },
            new { Range = "81-100 (Distinction)", Count = students.Count(s => s.Grade >= 81 && s.Grade <= 100) }
        };

            foreach (var range in gradeRanges)
            {
                Console.WriteLine($"{range.Range}: {range.Count} students");
            }
            // Output:
            // 0-60 (Fail): 0 students
            // 61-80 (Pass): 4 students
            // 81-100 (Distinction): 6 students

            Console.WriteLine();

            // BONUS: Detailed breakdown by grade range
            Console.WriteLine("Detailed breakdown:");
            Console.WriteLine("--------------------------------------------------");

            var failStudents = students.Where(s => s.Grade <= 60).Select(s => s.Name);
            var passStudents = students.Where(s => s.Grade > 60 && s.Grade <= 80).Select(s => s.Name);
            var distinctionStudents = students.Where(s => s.Grade > 80).Select(s => s.Name);

            Console.WriteLine($"Fail (0-60): {string.Join(", ", failStudents) ?? "None"}");
            Console.WriteLine($"Pass (61-80): {string.Join(", ", passStudents)}");
            Console.WriteLine($"Distinction (81-100): {string.Join(", ", distinctionStudents)}");
            // Output:
            // Fail: None
            // Pass: Henry, Jack, Frank, Charlie
            // Distinction: Alice, Bob, Diana, Eve, Grace, Ivy

            Console.WriteLine("\n========================================");
            Console.WriteLine("BONUS: ADVANCED QUERIES");
            Console.WriteLine("========================================\n");

            // BONUS 1: Find top student in each subject
            Console.WriteLine("BONUS 1: Top student in each subject:");
            Console.WriteLine("--------------------------------------------------");

            var topBySubject = students
                .GroupBy(s => s.Subject)
                .Select(g => g.OrderByDescending(s => s.Grade).First());

            foreach (var student in topBySubject)
            {
                Console.WriteLine($"{student.Subject}: {student.Name} ({student.Grade})");
            }
            // Output: Math: Eve (88), Science: Grace (95), History: Frank (75)

            Console.WriteLine();

            // BONUS 2: Students with grades in top 50%
            Console.WriteLine("BONUS 2: Students in top 50% by grade:");
            Console.WriteLine("--------------------------------------------------");

            var medianGrade = students.OrderBy(s => s.Grade).Skip(students.Count / 2).First().Grade;
            var topHalf = students.Where(s => s.Grade >= medianGrade).OrderByDescending(s => s.Grade);

            Console.WriteLine($"Median grade: {medianGrade}");
            foreach (var student in topHalf)
            {
                Console.WriteLine($"{student.Name}: {student.Grade}");
            }

            Console.WriteLine();

            // BONUS 3: Subject diversity by city
            Console.WriteLine("BONUS 3: Subject diversity by city:");
            Console.WriteLine("--------------------------------------------------");

            var subjectsByCity = students
                .GroupBy(s => s.City)
                .Select(g => new
                {
                    City = g.Key,
                    Subjects = g.Select(s => s.Subject).Distinct().Count(),
                    SubjectList = string.Join(", ", g.Select(s => s.Subject).Distinct())
                });

            foreach (var item in subjectsByCity)
            {
                Console.WriteLine($"{item.City}: {item.Subjects} subjects ({item.SubjectList})");
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine("ALL EXERCISES COMPLETED! 🎉");
            Console.WriteLine("========================================");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();


        }  
    }
}
