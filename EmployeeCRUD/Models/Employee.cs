namespace EmployeeCRUD.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Department { get; set; }

        public string Project { get; set; }

        public int Age { get; set; }
    }
}
