using System.Linq;
using EntityFrameworkCoreTesting.DataModels.DTOs;
using EntityFrameworkCoreTesting.DataModels.Interfaces.IRepository;
using EntityFrameworkCoreTesting.DataModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCoreTesting.Controllers
{
    /// <summary>
    /// The api controller.
    /// </summary>
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
        /// <summary>
        /// Get all Test1 entities.
        /// </summary>
        /// <returns>All Test1 entities.</returns>
        [HttpGet("Test1")]
        public ActionResult GetTest1()
        {
            return Ok(_test1Repository.AllNoTracking.Select(t1 => t1.GenerateDTO));
        }
        /// <summary>
        /// Get a specific Test1 entity out form <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>If found, Ok statuscode with the entity. Else statuscode NotFound.</returns>
        [HttpGet("Test1/{id}")]
        public ActionResult GetTest1(int id)
        {
            Test1 test = _test1Repository.GetByIdNoTracking(id);
            if (test == null)
                return StatusCode(StatusCodes.Status404NotFound);
            return Ok(test.GenerateDTO);
        }
        /// <summary>
        /// Add a new entity to the context out from the information in <paramref name="dto"/>.
        /// </summary>
        /// <param name="dto">The dto with the entity information to add.</param>
        /// <returns>BadRequest if the Id is not 0 or if one or more Test2 ids are in use. Else Ok statuscode.</returns>
        [HttpPost("Test1")]
        public ActionResult AddTest1(Test1DTO dto)
        {
            if (dto.Id != 0)
                return BadRequest("Id is not zero");
            Test1 test1 = dto.GenerateEntity;
            if (_test2Repository.All.Any(t => test1.Test2s.Any(tt => t.Test2Id == tt.Test2Id)))
                return BadRequest("One or more Test2 ids are in use");
            _test1Repository.Add(test1);
            return Ok();
        }
        /// <summary>
        /// Update an entity with the information in <paramref name="dto"/>
        /// </summary>
        /// <param name="dto">The dto with the update information.</param>
        /// <returns>NotFound if the id in dto did not match an entity, else Ok</returns>
        [HttpPut("Test1")]
        public ActionResult PutTest1(Test1DTO dto)
        {
            Test1 test = _test1Repository.GetById(dto.Id);
            if (_test1Repository.GetById(dto.Id) == null)
                return StatusCode(StatusCodes.Status404NotFound);
            test.UpdateFromDTO(dto);
            _test1Repository.Update(test);
            return Ok();
        }
        /// <summary>
        /// Patch an entity with the information in <paramref name="dto"/>
        /// </summary>
        /// <param name="dto">The dto with the patch information.</param>
        /// <returns>NotFound if the id in dto did not match an entity, else Ok</returns>
        [HttpPatch("Test1")]
        public ActionResult PatchTest1(Test1DTO dto) //this is just the same as the update method...
        {
            Test1 test1 = _test1Repository.GetById(dto.Id);
            if (test1 == null)
                return StatusCode(StatusCodes.Status404NotFound);
            test1.UpdateFromDTO(dto);
            _test1Repository.Update(test1);
            return Ok();
        }
        /// <summary>
        /// Deletes an entity with the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the entity to delete.</param>
        /// <returns>Ok statuscode.</returns>
        [HttpDelete("Test1/{id}")]
        public ActionResult DeleteTest1(int id)
        {
            Test1 test = _test1Repository.GetById(id);
            if (test == null)
                return Ok();
            _test1Repository.Remove(test);
            return Ok();
        }
        /// <summary>
        /// Get all Test2 entities.
        /// </summary>
        /// <returns>All Test2 entities.</returns>
        [HttpGet("Test2")]
        public ActionResult GetTest2()
        {
            return Ok(_test2Repository.AllNoTracking.Select(t2 => t2.GenerateDTO));
        }
        /// <summary>
        /// Get a specific Test2 entity out form <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>If found, Ok statuscode with the entity. Else statuscode NotFound.</returns>
        [HttpGet("Test2/{id}")]
        public ActionResult GetTest2(string id)
        {
            Test2 test = _test2Repository.GetByIdNoTracking(id);
            if (test == null)
                return StatusCode(StatusCodes.Status404NotFound);
            return Ok(test.GenerateDTO);
        }
        /// <summary>
        /// Add a new entity to the context out from the information in <paramref name="dto"/>.
        /// </summary>
        /// <param name="dto">The dto with the entity information to add.</param>
        /// <returns>BadRequest if the Id is not 0 or if one or more Test2 ids are in use. Else Ok statuscode.</returns>
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
        /// <summary>
        /// Update an entity with the information in <paramref name="dto"/>
        /// </summary>
        /// <param name="dto">The dto with the update information.</param>
        /// <returns>NotFound if the id in dto did not match an entity, else Ok</returns>
        [HttpPut("Test2")]
        public ActionResult PutTest2(Test2DTO dto)
        {
            Test2 test = _test2Repository.GetById(dto.Id);
            if (test == null)
                return StatusCode(StatusCodes.Status404NotFound);
            test.UpdateFromDTO(dto);
            _test2Repository.Update(test);
            return Ok();
        }
        /// <summary>
        /// Patch an entity with the information in <paramref name="dto"/>
        /// </summary>
        /// <param name="dto">The dto with the patch information.</param>
        /// <returns>NotFound if the id in dto did not match an entity, else Ok</returns>
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
        /// <summary>
        /// Deletes an entity with the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the entity to delete.</param>
        /// <returns>Ok statuscode.</returns>
        [HttpDelete("Test2/{id}")]
        public ActionResult DeleteTest2(string id)
        {
            Test2 test = _test2Repository.GetById(id);
            if (test == null)
                return Ok();
            _test2Repository.Remove(test);
            return Ok();
        }
    }
}
