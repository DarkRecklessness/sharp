using System;

public class Menu
{
    private EmployeeManager manager;

    public Menu()
    {
        manager = new EmployeeManager();
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Загрузить данные из файла");
            Console.WriteLine("2. Показать сотрудников по уровню опыта");
            Console.WriteLine("3. Показать статистику");
            Console.WriteLine("4. Показать сотрудников с зарплатой в диапазоне 70-80%");
            Console.WriteLine("5. Выйти");
            Console.Write("Введите ваш выбор: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    LoadDataFromUserSpecifiedFile();
                    break;
                case "2":
                    ShowEmployeesByExperience();
                    break;
                case "3":
                    manager.DisplayStatistics();
                    break;
                case "4":
                    ShowEmployeesInSalaryRange();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, попробуйте еще раз.");
                    break;
            }
        }
    }

    private void LoadDataFromUserSpecifiedFile()
    {
        Console.Write("Введите полный путь к файлу: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            manager.LoadEmployeesFromCSV(filename);
        }
        else
        {
            Console.WriteLine("Файл не найден. Пожалуйста, проверьте путь и попробуйте снова.");
        }
    }

    private void ShowEmployeesByExperience()
    {
        if (!manager.Employees.Any())
        {
            Console.WriteLine("Нет данных о сотрудниках. Сначала загрузите данные.");
            return;
        }

        Console.Write("Введите уровень опыта: ");
        string experience = Console.ReadLine();
        var employees = manager.GetEmployeesByExperience(experience);
        
        if (employees.Any())
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Designation: {emp.Designation}, Salary: {emp.Salary}");
            }
        }
        else
        {
            Console.WriteLine($"Нет сотрудников с уровнем опыта '{experience}'.");
        }
    }

    private void ShowEmployeesInSalaryRange()
    {
        if (!manager.Employees.Any())
        {
            Console.WriteLine("Нет данных о сотрудниках. Сначала загрузите данные.");
            return;
        }

        var salaryEmployees = manager.GetEmployeesWithSalaryRange(0.7, 0.8);
        if (salaryEmployees.Any())
        {
            foreach (var emp in salaryEmployees)
            {
                Console.WriteLine($"ID: {emp.Id}, Designation: {emp.Designation}, Salary: {emp.Salary}");
            }
        }
        else
        {
            Console.WriteLine("Нет сотрудников в указанном диапазоне зарплат.");
        }
    }
}
