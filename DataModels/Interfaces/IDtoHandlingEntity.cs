using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Interfaces
{
    /// <summary>
    /// Contains methods for working with entities of <typeparamref name="ModelType"/> via DTOs.
    /// </summary>
    /// <typeparam name="ModelType">The model of the entity.</typeparam>
    interface IDtoHandlingEntity <ModelType>
    {
        /// <summary>
        /// Generates an entity out from the DTO.
        /// </summary>
        [JsonIgnore]
        public ModelType GenerateEntity { get; }
    }
}
