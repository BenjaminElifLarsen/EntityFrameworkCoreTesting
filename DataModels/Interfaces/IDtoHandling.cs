﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Interfaces
{
    public interface IDtoHandling <DtoType>
    {
        /// <summary>
        /// Generates a DTO out from the entity.
        /// </summary>
        public DtoType GenerateDTO { get; }
        /// <summary>
        /// Updates the entity out from the information in <paramref name="dto"/>. 
        /// This does not update the entity in the context.
        /// </summary>
        /// <param name="dto">The data transfer object with the update information.</param>
        public void UpdateFromDTO(DtoType dto);
    }
}
