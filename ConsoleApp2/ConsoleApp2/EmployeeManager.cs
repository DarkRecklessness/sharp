public class EmployeeManager
{
    public List<Employee> Data { get; private set; }

    public EmployeeManager(string path)
    {
        Data = CSVManager.ReadData(path);
        if (Data.Count != 0)
        {
            Console.WriteLine("Данные успешно загружены");
        } 
    }
    
}