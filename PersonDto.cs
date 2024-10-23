using System.ComponentModel.DataAnnotations;

namespace WebApiWithOData
{
    public class PersonDto
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string DepartmentName { get; set; }
        public Department Department { get; set; }

        public PersonDto()
        {
            this.Name = string.Empty;
            this.Lastname = string.Empty;
        }
    }
}
