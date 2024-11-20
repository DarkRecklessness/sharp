public class Employee
{
    public int Id { get; set; }
    public int WorkingYear { get; set; }
    public string Designation { get; set; }
    public string Experience { get; set; }
    public string EmploymentStatus { get; set; }
    public double Salary { get; set; }
    public string Location { get; set; }
    public string Company_Location { get; set; }
    public string Company_Size { get; set; }
    public int Remote_Working_Ratio { get; set; }

    public Employee(int id, int workingYear, string designation, string experience, string employmentStatus,
        double salary, string location, string company_location, string company_size, int remote_working_ratio)
    {
        Id = id;
        WorkingYear = workingYear;
        Designation = designation;
        Experience = experience;
        EmploymentStatus = employmentStatus;
        Salary = salary;
        Location = location;
        Company_Location = company_location;
        Company_Size = company_size;
        Remote_Working_Ratio = remote_working_ratio;
    }
}