using EntityFrameworkCoreTesting.DataModels.Interfaces;
using EntityFrameworkCoreTesting.DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.DTOs
{
    /// <summary>
    /// The DTO for Test1
    /// </summary>
    public class Test1DTO : IDtoHandlingEntity<Test1>
    {
        /// <summary>
        /// The id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Other stuff.
        /// </summary>
        public string Other { get; set; }
        /// <summary>
        /// List of foreignkeys pointing to it.
        /// </summary>
        public List<Test2> Test2s { get; set; }

        /// <summary>
        /// Foreignkey class.
        /// </summary>
        public class Test2
        {
            /// <summary>
            /// The id.
            /// </summary>
            public string Id { get; set; }
        }

        [JsonIgnore] //prevents the getter from being called when the object is coverted to JSON
        public Test1 GenerateEntity => new Test1(Id, Name, Other, Test2s.Select(t => new Models.Test2(t.Id, Id)).ToHashSet());
    }
}
