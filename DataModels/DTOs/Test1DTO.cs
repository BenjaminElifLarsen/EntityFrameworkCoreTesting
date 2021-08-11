using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.DTOs
{
    public class Test1DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Other { get; set; }
        public List<Test2> Test2s { get; set; }

        public class Test2
        {
            public string Id { get; set; }
        }
    }
}
