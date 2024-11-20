using System.Text;

public class CSVManager
{
    public static List<Employee> ReadData(string path)
    {
        List<Employee> z = new();
        
        if (!File.Exists(path))
        {
            Console.WriteLine("Файла не существует, попробуйте снова");
            return z;
        }
        
        string[] s = File.ReadAllLines(path, Encoding.UTF8);
        int n = s.GetLength(0);
        HelperSalary(ref s);
        for (int i = 1; i < n; ++i)
        {
            string[] k = s[i].Split(",");
            
            if (k.GetLength(0) != 10)
            {
                continue;
            }
            
            try
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!заифать пустые поля для интов
                int id = int.Parse(k[0]);
                int workingYear = int.Parse(k[1]);
                string designation = k[2];
                string experience = k[3];
                string employmentStatus = k[4];
                double salary = double.Parse(ParseSalary(k[5]));
                string location = k[6];
                string company_location = k[7];
                string company_size = k[8];
                int remote = int.Parse(k[9]);

                var employee = new Employee(id, workingYear, designation, experience, employmentStatus, salary, location,
                    company_location, company_size, remote);
                z.Add(employee);
            }
            catch (FormatException ex)
            {
                //Console.WriteLine($"Ошибка при чтении строки: {i}. Ошибка: {ex.Message}");
            }
        }

        if (z.Count == 0)
        {
            Console.WriteLine("Корректных данных в файле нет");
        }
        return z;
    }

    private static void HelperSalary(ref string[] k)
    {
        int n = k.GetLength(0);
        string[] res = new string[n];
        for (int i = 0; i < n; ++i)
        {
            string tmp = "";
            int m = k[i].Length;
            for (int j = 0; j < m; ++j)
            {
                tmp += k[i][j];
                if (k[i][j] == '"')
                {
                    while (k[i][++j] != '"')
                    {
                        if (k[i][j] == ',') tmp += " ";
                        else tmp += k[i][j];
                    }
                    tmp += k[i][j];
                }
            }
            res[i] = tmp;
        }
        k = res;
    }
    
    private static string ParseSalary(string salaryString)
    {
        salaryString = salaryString.Replace(" ", "").Replace("\"", "").Replace(".", ","); // !!!!!!!!!!!!!!!!!! подумать с точкой и запятой
        return salaryString;
    }
}