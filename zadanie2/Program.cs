using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania2
{
    public class Student
    {
        public string FullName { get; set; }
        public string Group { get; set; }
        public double AverageGrade { get; set; }
        public double FamilyIncome { get; set; }
        public int FamilyMembers { get; set; }
        public string Gender { get; set; }
        public string EducationForm { get; set; }

        public override string ToString()
        {
            return $"{FullName} - {Group} - Средняя оценка: {AverageGrade} - Доход: {FamilyIncome} - Члены: {FamilyMembers} - Пол: {Gender} - Форма: {EducationForm}";
        }
    }

    public class HostelManager
    {
        private List<Student> students;

        public HostelManager()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void DisplayPriorityList()
        {
            var priorityList = students
                .OrderBy(s => s.FamilyIncome)
                .ThenByDescending(s => s.AverageGrade)
                .ToList();

            Console.WriteLine("Список приоритетов при размещении общежитий:");
            foreach (var student in priorityList)
            {
                Console.WriteLine(student);
            }
        }

        public void DisplayColorCodedList()
        {
            var colorCodedList = students
                .OrderByDescending(s => s.AverageGrade)
                .ToList();

            Console.WriteLine("Список размещения общежитий с цветовой кодировкой:");
            for (int i = 0; i < colorCodedList.Count; i++)
            {
                if (i < 10)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (i < 20)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(colorCodedList[i]);
            }

            Console.ResetColor();
        }

        public void DisplayIncompleteFamilyList()
        {
            var incompleteFamilyList = students
                .Where(s => s.FamilyMembers < 3)
                .ToList();

            Console.WriteLine("Студенты с неполными семьями:");
            foreach (var student in incompleteFamilyList)
            {
                Console.WriteLine(student);
            }
        }

        public void DisplayTopStudentsWithHighestGrades(int count)
        {
            var topStudents = students
                .OrderByDescending(s => s.AverageGrade)
                .Take(count)
                .ToList();

            Console.WriteLine($"Лучшие ученики ({count}) с наивысшими оценками:");
            foreach (var student in topStudents)
            {
                Console.WriteLine(student);
            }
        }

        public void DisplayTopStudentsWithLowestGrades(int count)
        {
            var lowGradeStudents = students
                .OrderBy(s => s.AverageGrade)
                .Take(count)
                .ToList();

            Console.WriteLine($"Лучшие ученики ({count}) с самыми низкими оценками:");
            foreach (var student in lowGradeStudents)
            {
                Console.WriteLine(student);
            }
        }

        public void DisplayLowestIncomeIncompleteFamilyStudents(int count)
        {
            var selectedStudents = students
                .Where(s => s.FamilyMembers < 3)
                .OrderBy(s => s.FamilyIncome)
                .Take(count)
                .ToList();

            Console.WriteLine($"Лучшие студенты ({count}) с самым низким семейным доходом и неполными семьями:");
            foreach (var student in selectedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }


    class Program
    {
        static void Main()
        {
            HostelManager hostelManager = new HostelManager();

            hostelManager.AddStudent(new Student
            {
                FullName = "Саттар Бекнур Бекжанулы",
                Group = "Группа 1",
                AverageGrade = 4.5,
                FamilyIncome = 15000,
                FamilyMembers = 4,
                Gender = "Мужской",
                EducationForm = "Очная"
            });

            hostelManager.AddStudent(new Student
            {
                FullName = "Есеналиев Арман",
                Group = "Группа 2",
                AverageGrade = 4.2,
                FamilyIncome = 12000,
                FamilyMembers = 3,
                Gender = "Мужской",
                EducationForm = "Заочная"
            });

            hostelManager.AddStudent(new Student
            {
                FullName = "Ахылбек Ахад",
                Group = "Группа 1",
                AverageGrade = 4.3,
                FamilyIncome = 13000,
                FamilyMembers = 2,
                Gender = "Мужской",
                EducationForm = "Заочная"
            });


            hostelManager.DisplayPriorityList();
            Console.WriteLine();
            hostelManager.DisplayColorCodedList();
            Console.WriteLine();
            hostelManager.DisplayIncompleteFamilyList();
            Console.WriteLine();
            hostelManager.DisplayTopStudentsWithHighestGrades(10);
            Console.WriteLine();
            hostelManager.DisplayTopStudentsWithLowestGrades(10);
            Console.WriteLine();
            hostelManager.DisplayLowestIncomeIncompleteFamilyStudents(3);
            Console.ReadKey();
        }
    }

}
