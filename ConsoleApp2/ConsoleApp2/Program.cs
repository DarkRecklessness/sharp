public class Program
{
    public static void Main()
    {
        //CSVManager.ReadData("D:\\Downloads(chrome)\\Data_Science_Fields_Salary_Categorization.csv");
        string path = "D:\\Downloads(chrome)\\Data_Science_Fields_Salary_Categorization.csv";
        EmployeeManager M = new EmployeeManager(path);
        Console.WriteLine(M.Data.Count);
    }
}