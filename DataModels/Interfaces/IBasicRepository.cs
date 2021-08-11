using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Interfaces
{
    /// <summary>
    /// Contains the basic context interactions a non-joining table repository will need.
    /// </summary>
    /// <typeparam name="ModelType">The model.</typeparam>
    /// <typeparam name="ModelId">The id of the model.</typeparam>
    public interface IBasicRepository <ModelType, ModelId>
    {
        /// <summary>
        /// Update an entity in the context.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException">The entity is not tracked beforehand.</exception>
        public void Update(ModelType entity);
        /// <summary>
        /// Add an entity to the context.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException"></exception>
        public void Add(ModelType entity);
        /// <summary>
        /// Remove an entity from the context.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException"></exception>
        public void Remove(ModelType entity);
        /// <summary>
        /// Get all entities in the context.
        /// </summary>
        public IEnumerable<ModelType> All { get; }
        /// <summary>
        /// Get all entities in the context with no tracking.
        /// </summary>
        public IEnumerable<ModelType> AllNoTracking { get; }
        /// <summary>
        /// Get a specific entity via <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the entity to get.</param>
        /// <returns>The entity if found else null.</returns>
        public ModelType GetById(ModelId id);
        /// <summary>
        /// Get a specific entity via <paramref name="id"/> with no tracking.
        /// </summary>
        /// <param name="id">The id of the entity to get.</param>
        /// <returns>The entity if found else null.</returns>
        public ModelType GetByIdNoTracking(ModelId id);
    }
}
