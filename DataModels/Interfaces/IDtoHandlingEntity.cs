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
    interface IDtoHandlingEntity <ModelType> //if this was an abstract class, it could be kind of like a factory design, I guess. It would not have the <ModelType>
    { //The superclass contains the abstract method for creating, while the subclasses contain the actually implementation. Each subclass would return a result of their type rather than the superclass. There is a difference between Factory Design and Factory Method Design. Factory method design seems to be more my thing. These factory designs might be useful on a non-api webpage
        /// <summary>
        /// Generates an entity out from the DTO.
        /// </summary>
        [JsonIgnore]
        public ModelType GenerateEntity { get; }
    }
}
