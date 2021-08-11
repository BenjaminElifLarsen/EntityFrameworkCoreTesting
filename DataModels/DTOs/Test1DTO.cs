using EntityFrameworkCoreTesting.DataModels.Interfaces;
using EntityFrameworkCoreTesting.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.DTOs
{
    public class Test1DTO : IDtoHandlingEntity<Test1>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Other { get; set; }
        public List<Test2> Test2s { get; set; }

        public Test1 GenerateEntity => new Test1(Id, Name, Other, Test2s.Select(t => new Models.Test2(t.Id, Id)).ToHashSet());

        public class Test2
        {
            public string Id { get; set; }
        }
    }
}
