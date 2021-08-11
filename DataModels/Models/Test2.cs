using EntityFrameworkCoreTesting.DataModels.DTOs;
using EntityFrameworkCoreTesting.DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Models
{
    public class Test2 : IEntityHandlingDto<Test2DTO> //Domain-Driven Design
    {
        /// <summary>
        /// The id.
        /// </summary>
        public string Test2Id { get; private set; } //could make sense to allow updating a string id, but would need to check if it is in use or not. Would only make real sense in case of composite keys
        /// <summary>
        /// The foreignkey id.
        /// </summary>
        public int Test1Id { get; private set; }
        /// <summary>
        /// The foreignkey entity.
        /// </summary>
        public Test1 Test1 { get; private set; }

        /// <summary>
        /// Constructor for the model binding.
        /// </summary>
        private Test2() //ctor for entityframework core
        {

        }

        /// <summary>
        /// Constructor with the foreignkey entity.
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="test1">The foreignkey entity.</param>
        public Test2(string id, Test1 test1)
        { //developer ctor
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
            Test2Id = id;
            Test1Id = test1.Test1Id; 
            Test1 = test1;
        }

        /// <summary>
        /// Constructor with the foreignkey entity's id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="test1Id">The id of the foreignkey entity.</param>
        public Test2(string id, int test1Id)
        { //developer ctor
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
            if (test1Id == 0)
                throw new ArgumentNullException(nameof(test1Id));
            Test2Id = id;
            Test1Id = test1Id;
        }

        /// <summary>
        /// Constructor with no foreignkey entity. This entity should be in a collection with the foreignkey entity it should belong too.
        /// </summary>
        /// <param name="id"></param>
        public Test2(string id)
        { //developer ctor
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
        }

        public Test2DTO GenerateDTO => new Test2DTO 
        {
            Id = Test2Id,
            Test1Id = Test1Id,
        };

        /// <summary>
        /// Update which foreignkey entity this entity points too.
        /// </summary>
        /// <param name="newTest1"></param>
        public void UpdateTest1(Test1 newTest1) { Test1Id = newTest1.Test1Id; Test1 = newTest1; }

        public void UpdateFromDTO(Test2DTO dto)
        {
            Test1Id = dto.Test1Id;
        }
    }
}
