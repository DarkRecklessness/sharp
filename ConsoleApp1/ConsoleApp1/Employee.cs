public class Employee
{
    public int Id { get; set; }
    public int WorkingYear { get; set; }
    public string Designation { get; set; }
    public string Experience { get; set; }
    public string EmploymentStatus { get; set; }
    public double Salary { get; set; }
    public string Location { get; set; }

    public Employee(int id, int workingYear, string designation, string experience, string employmentStatus, double salary, string location)
    {
        Id = id;
        WorkingYear = workingYear;
        Designation = designation;
        Experience = experience;
        EmploymentStatus = employmentStatus;
        Salary = salary;
        Location = location;
    }
}