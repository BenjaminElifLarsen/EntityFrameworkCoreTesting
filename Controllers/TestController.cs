using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCoreTesting.DataModels.DTOs;
using EntityFrameworkCoreTesting.DataModels.Interfaces.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCoreTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITest1Repository _test1Repository;
        private readonly ITest2Repository _test2Repository;
        public TestController(ITest1Repository test1Repository, ITest2Repository test2Repository)
        {
            _test1Repository = test1Repository;
            _test2Repository = test2Repository;
        }

        [HttpGet("Get")]
        public ActionResult Get()
        {
            return Ok(_test1Repository.All.Select(t1 => t1.GenerateDTO));
        }

        [HttpGet("Get/{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_test1Repository.GetById(id).GenerateDTO);
        }
    }
}
