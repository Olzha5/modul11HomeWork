using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11
{
    interface IEmployee
    {
        string FullName { get; set; }
        DateTime HireDate { get; set; }
        string Position { get; set; }
        decimal Salary { get; set; }
        string Gender { get; set; }

        string ToString();
    }

    class Employee : IEmployee
    {
        public string FullName { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"ФИО: {FullName}, Должность: {Position}, Дата приема на работу: {HireDate.ToShortDateString()}, Зарплата: {Salary}, Пол: {Gender}";
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введи количество сотрудников: ");
            int numberOfEmployees = int.Parse(Console.ReadLine());

            List<IEmployee> employees = new List<IEmployee>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                Console.WriteLine($"Информация о сотруднике {i + 1}:");
                Employee employee = new Employee();

                Console.Write("ФИО: ");
                employee.FullName = Console.ReadLine();

                Console.Write("Дата приема на работу (yyyy-mm-dd): ");
                employee.HireDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Должность: ");
                employee.Position = Console.ReadLine();

                Console.Write("Зарплата: ");
                employee.Salary = decimal.Parse(Console.ReadLine());

                Console.Write("Пол (Мужчина/Женщина): ");
                employee.Gender = Console.ReadLine();

                employees.Add(employee);
            }

            // a.
            Console.WriteLine("\nВсе сотрудники:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            // b.
            Console.Write("\nФильтр должности: ");
            string positionFilter = Console.ReadLine();
            var employeesByPosition = employees.FindAll(e => e.Position.Equals(positionFilter, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nДолжность сотрудника '{positionFilter}':");
            foreach (var employee in employeesByPosition)
            {
                Console.WriteLine(employee);
            }

            // c. 
            decimal clerksAverageSalary = employees
                .Where(e => e.Position.Equals("Клерк", StringComparison.OrdinalIgnoreCase))
                .Average(e => e.Salary);

            var managersAboveClerksAverage = employees
                .Where(e => e.Position.Equals("Мэнеджер", StringComparison.OrdinalIgnoreCase) && e.Salary > clerksAverageSalary)
                .OrderBy(e => e.FullName);

            Console.WriteLine("\nMенеджеры с зарплатой выше средней клерка:");
            foreach (var manager in managersAboveClerksAverage)
            {
                Console.WriteLine(manager);
            }

            // d. 
            Console.Write("\nВведите пороговое значение даты приема на работу (yyyy-mm-dd): ");
            DateTime hireDateThreshold = DateTime.Parse(Console.ReadLine());

            var employeesAfterDate = employees
                .Where(e => e.HireDate > hireDateThreshold)
                .OrderBy(e => e.FullName);

            Console.WriteLine($"\nСотрудники, нанятые после {hireDateThreshold.ToShortDateString()}:");
            foreach (var employee in employeesAfterDate)
            {
                Console.WriteLine(employee);
            }

            // e.
            Console.Write("\nВведите пол для фильтрации (Мужчина/Женщина/Все): ");
            string genderFilter = Console.ReadLine();

            var employeesByGender = genderFilter.Equals("Все", StringComparison.OrdinalIgnoreCase)
                ? employees
                : employees.Where(e => e.Gender.Equals(genderFilter, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nСотрудники с полом '{genderFilter}':");
            foreach (var employee in employeesByGender)
            {
                Console.WriteLine(employee);
            }
            Console.ReadKey();
        }
    }

}