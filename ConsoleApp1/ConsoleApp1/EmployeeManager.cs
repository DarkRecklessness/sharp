using System;
using System.Collections.Generic;
using System.Linq;

public class EmployeeManager
{
    public List<Employee> Employees { get; private set; }

    public EmployeeManager()
    {
        Employees = new List<Employee>();
    }

    public void LoadEmployeesFromCSV(string filename)
    {
        Employees = CSVHandler.LoadFromFile(filename);

        if (Employees.Any())
        {
            Console.WriteLine("Данные успешно загружены.");
        }
        else
        {
            Console.WriteLine("Не удалось загрузить данные. Возможно, файл пуст или содержит ошибки.");
        }
    }

    public List<Employee> GetEmployeesByExperience(string experience)
    {
        return Employees.Where(e => e.Experience.Equals(experience, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void SaveEmployeesByExperience(string filename, string experience)
    {
        var employees = GetEmployeesByExperience(experience);
        if (employees.Any())
        {
            CSVHandler.SaveToFile(filename, employees);
        }
        else
        {
            Console.WriteLine("Нет сотрудников с данным уровнем опыта.");
        }
    }

    public void DisplayStatistics()
    {
        if (!Employees.Any())
        {
            Console.WriteLine("Нет данных о сотрудниках.");
            return;
        }

        int totalEmployees = Employees.Count;

        var maxSalaryEmployee = Employees.OrderByDescending(e => e.Salary).FirstOrDefault();
        var minSalaryEmployee = Employees.OrderBy(e => e.Salary).FirstOrDefault();
        var dataEngineersFromUK = Employees.Count(e => e.Designation == "Data Engineer" && e.Location == "GB");

        Console.WriteLine($"Общее количество сотрудников: {totalEmployees}");
        
        if (maxSalaryEmployee != null)
        {
            Console.WriteLine($"Сотрудник с наибольшей зарплатой: {maxSalaryEmployee.Designation} - {maxSalaryEmployee.Salary}");
        }

        if (minSalaryEmployee != null)
        {
            Console.WriteLine($"Сотрудник с наименьшей зарплатой: {minSalaryEmployee.Designation} - {minSalaryEmployee.Salary}");
        }

        Console.WriteLine($"Количество Data Engineers из Великобритании: {dataEngineersFromUK}");
    }

    public List<Employee> GetEmployeesWithSalaryRange(double minPercentage, double maxPercentage)
    {
        if (!Employees.Any())
        {
            Console.WriteLine("Нет данных о сотрудниках.");
            return new List<Employee>();
        }

        double maxSalary = Employees.Max(e => e.Salary);
        double lowerBound = maxSalary * minPercentage;
        double upperBound = maxSalary * maxPercentage;

        return Employees.Where(e => e.Salary >= lowerBound && e.Salary <= upperBound).ToList();
    }
}
