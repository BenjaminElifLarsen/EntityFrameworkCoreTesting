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
        private Test2() //ctor for entityframework core
        {

        }

        public Test2(string id, Test1 test1)
        { //developer ctor
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
            Test2Id = id;
            Test1Id = test1.Test1Id; 
            Test1 = test1;
        }

        public Test2(string id, int test1Id)
        { //developer ctor
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
            if (test1Id == 0)
                throw new ArgumentNullException(nameof(test1Id));
            Test2Id = id;
            Test1Id = test1Id;
        }

        public Test2(string id)
        { //developer ctor
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
        }

        public string Test2Id { get; private set; } //could make sense to allow updating a string id, but would need to check if it is in use or not. Would only make real sense in case of composite keys
        public int Test1Id { get; private set; }
        public Test1 Test1 { get; private set; }

        public Test2DTO GenerateDTO => new Test2DTO 
        {
            Id = Test2Id,
            Test1Id = Test1Id,
        };

        public void UpdateTest1(Test1 newTest1) { Test1Id = newTest1.Test1Id; Test1 = newTest1; }

        public void UpdateFromDTO(Test2DTO dto)
        {
            Test1Id = dto.Test1Id;
        }
    }
}
