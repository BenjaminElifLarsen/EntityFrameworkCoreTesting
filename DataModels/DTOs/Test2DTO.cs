using EntityFrameworkCoreTesting.DataModels.Interfaces;
using EntityFrameworkCoreTesting.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.DTOs
{
    /// <summary>
    /// The DTO for Test2
    /// </summary>
    public class Test2DTO : IDtoHandlingEntity<Test2>
    {
        /// <summary>
        /// The id.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The id of the foreign key entity it points too.
        /// </summary>
        public int Test1Id { get; set; }

        [JsonIgnore]  //prevents the getter from being called when the object is coverted to JSON
        public Test2 GenerateEntity => new Test2(Id,Test1Id);
    }
}
