using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using RequestModel;
using Service;
using ViewModel;

namespace LmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly LmsDbContext _db;

        public CourseController(LmsDbContext db)
        {
            this._db = db;
        }

        [Route("GetCourse")]
        public async Task<IActionResult> GetCourses(CourseRequestModel request)
        {
            BaseRepository<Course> repository = new BaseRepository<Course>(_db);
            CourseService service = new CourseService(repository);
            var courses = await service.SearchAsync(request);
            return Ok();
        }
    }
}