using EntityFrameworkCoreTesting.DataModels.Interfaces;
using EntityFrameworkCoreTesting.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.DTOs
{
    public class Test2DTO : IDtoHandlingEntity<Test2>
    {
        public string Id { get; set; }
        public int Test1Id { get; set; }

        [JsonIgnore]  //prevents the getter from being called when the object is coverted to JSON
        public Test2 GenerateEntity => new Test2(Id,Test1Id);
    }
}
