using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace WebApiWithOData.Controllers
{
    [Route("odata/[controller]")]
    public class PersonDtoController : ODataController
    {
        private readonly PersonDbContext personContext;
        private readonly IMapper _mapper;
        public PersonDtoController(PersonDbContext context, IMapper mapper)
        {
            personContext = context;
            _mapper = mapper;
            //List<Department> departmentList = new List<Department>();
            //{
            //    departmentList.Add(new Department() { DepartmentName = "Yönetim" });
            //    departmentList.Add(new Department() { DepartmentName = "İnsan Kaynakları" });
            //    departmentList.Add(new Department() { DepartmentName = "Teknik" });
            //}

            //if (personContext.Departments.Count() == 0)
            //    personContext.AddRange(departmentList);

            //List<Person> list = new List<Person>();
            //{
            //    list.Add(new Person() { DepartmentId = 3, Name = "Hasan", Lastname = "Gündoğdu", Salary = 10000 });
            //    list.Add(new Person() { DepartmentId = 3, Name = "Ali", Lastname = "Yılmaz", Salary = 5000 });
            //    list.Add(new Person() { DepartmentId = 2, Name = "Ahmet", Lastname = "Akşam", Salary = 15000 });
            //    list.Add(new Person() { DepartmentId = 2, Name = "Ayşe", Lastname = "Sabah", Salary = 16000 });
            //    list.Add(new Person() { DepartmentId = 1, Name = "Fatma", Lastname = "Öğlen", Salary = 8000 });
            //    list.Add(new Person() { DepartmentId = 1, Name = "Murat", Lastname = "Güneş", Salary = 7000 });
            //}
            //if (personContext.Persons.Count() == 0)
            //    personContext.AddRange(list);

            //personContext.SaveChanges();


        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            var singlePerson = personContext.Persons.Find(key);

            return Ok(singlePerson);
        }

        //[EnableQuery]
        //public IActionResult Get()
        //{
        //    return Ok(personContext.Persons);
        //}

        //Mapper nasıl genericleştirilebilir.
        [EnableQuery]
        public IActionResult Get()
        {
            // Önce entity üzerinde sorgulama yapılıyor
            var query = personContext.Persons.AsQueryable();

            // Sorgulama tamamlandıktan sonra DTO'ya dönüştürülüyor
            var personDtos = _mapper.ProjectTo<PersonDto>(query);


            return Ok(personDtos);
        }
    }
}
