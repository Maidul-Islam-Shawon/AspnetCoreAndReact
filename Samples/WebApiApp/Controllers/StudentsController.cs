using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private AppDbContext _context;
        private ILogger logger;

        public StudentsController(AppDbContext context, ILoggerFactory factory)
        {
            _context = context;
            logger = factory.CreateLogger<StudentsController>();
        }


        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetStudents(int skip=0, int take=10, string orderBy="Name", bool isAssending=true)
        {
            IQueryable<Student> dbStudents = _context.Students.AsQueryable();

            if (orderBy == "Name")
            {
                dbStudents = isAssending ? dbStudents.OrderBy(x => x.Name).AsQueryable() :
                                        dbStudents.OrderByDescending(x => x.Name).AsQueryable();
            }

            if (orderBy == "Phone")
            {
                dbStudents = isAssending ? dbStudents.OrderBy(x => x.Phone).AsQueryable() :
                                        dbStudents.OrderByDescending(x => x.Phone).AsQueryable();
            }

            dbStudents = dbStudents.Skip(skip).Take(take).AsQueryable();
            List<Student> students = dbStudents.ToList();
            //students.Add(new Student() { Id= 1, Name="abc", Phone="123" });
            //students.Add(new Student() { Id = 2, Name = "efg", Phone = "456" });

            return Ok(students);
        }

        [HttpPost]
        [Route("SaveStudent")]
        public IActionResult SaveStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete]
        [Route("DeleteStudnet")]
        public IActionResult DeleteStudnet(int id)
        {
            return Ok(id);
        }

    }
}