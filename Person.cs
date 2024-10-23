namespace WebApiWithOData
{
    public class Person: BaseEntity
    {
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Salary { get; set; }
    }
}
