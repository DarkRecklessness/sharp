using System.Collections.Generic;
using System.IO;

public class CSVHandler
{
    public static List<Employee> LoadFromFile(string filename)
    {
        var employees = new List<Employee>();

        try
        {
            using (var reader = new StreamReader(filename))
            {
                reader.ReadLine(); // Пропустить заголовок
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    try
                    {
                        int id = int.Parse(values[0]);
                        int workingYear = int.Parse(values[1]);
                        string designation = values[2];
                        string experience = values[3];
                        string employmentStatus = values[4];
                        double salary = ParseSalary(values[5]);
                        string location = values[6];

                        var employee = new Employee(id, workingYear, designation, experience, employmentStatus, salary, location);
                        employees.Add(employee);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Ошибка при чтении строки: {line}. Ошибка: {ex.Message}");
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
        }

        return employees;
    }

    public static void SaveToFile(string filename, List<Employee> employees)
    {
        try
        {
            using (var writer = new StreamWriter(filename))
            {
                // Заголовок файла
                writer.WriteLine("Id,WorkingYear,Designation,Experience,EmploymentStatus,Salary,Location");

                // Данные о сотрудниках
                foreach (var emp in employees)
                {
                    string line = $"{emp.Id},{emp.WorkingYear},{emp.Designation},{emp.Experience},{emp.EmploymentStatus},{emp.Salary},{emp.Location}";
                    writer.WriteLine(line);
                }
            }
            Console.WriteLine($"Данные сохранены в файл: {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
        }
    }

    private static double ParseSalary(string salaryString)
    {
        // Удаление запятых и кавычек для корректного преобразования в число
        salaryString = salaryString.Replace(",", "").Replace("\"", "").Trim();
        return double.Parse(salaryString);
    }
}
