using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCoreTesting.DataModels.DTOs;
using EntityFrameworkCoreTesting.DataModels.Interfaces.IRepository;
using EntityFrameworkCoreTesting.DataModels.Models;
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

        [HttpGet("Test1")]
        public ActionResult GetTest1()
        {
            return Ok(_test1Repository.All.Select(t1 => t1.GenerateDTO));
        }

        [HttpGet("Test1/{id}")]
        public ActionResult GetTest1(int id)
        {
            return Ok(_test1Repository.GetById(id).GenerateDTO);
        }

        [HttpPost("Test1")]
        public ActionResult AddTest1(Test1DTO dto)
        {
            if (dto.Id != 0)
                return BadRequest("Id is set");
            Test1 test1 = dto.GenerateEntity;
            _test1Repository.Add(test1);
            return Ok();
        }

        [HttpPatch("Test1")]
        public ActionResult PatchTest1(Test1DTO dto)
        {
            Test1 test1 = _test1Repository.GetById(dto.Id);
            if (test1 == null)
                return StatusCode(StatusCodes.Status404NotFound);
            test1.UpdateFromDTO(dto);
            _test1Repository.Update(test1);
            return Ok();
        }

        [HttpGet("Test2")]
        public ActionResult GetTest2()
        {
            return Ok(_test2Repository.All.Select(t2 => t2.GenerateDTO));
        }

        [HttpGet("Test2/{id}")]
        public ActionResult GetTest2(string id)
        {
            return Ok(_test2Repository.GetById(id).GenerateDTO);
        }

        [HttpPost("Test2")]
        public ActionResult AddTest2(Test2DTO dto)
        {
            if (string.IsNullOrEmpty(dto.Id))
                return BadRequest("Id needs to be set");
            if (_test2Repository.All.Any(t => t.Test2Id == dto.Id))
                return BadRequest("Id is already in use");
            Test2 test2 = dto.GenerateEntity;
            _test2Repository.Add(test2);
            return Ok();
        }

        [HttpPatch("Test2")]
        public ActionResult PatchTest2(Test2DTO dto)
        {
            Test2 test2 = _test2Repository.GetById(dto.Id);
            if (test2 == null)
                return StatusCode(StatusCodes.Status404NotFound);
            test2.UpdateFromDTO(dto);
            _test2Repository.Update(test2);
            return Ok();
        }
    }
}
