using EntityFrameworkCoreTesting.DataModels.DTOs;
using EntityFrameworkCoreTesting.DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Models
{
    /// <summary>
    /// Test class 1
    /// </summary>
    public class Test1 : IEntityHandlingDto<Test1DTO> //Domain-Driven Design. Looki also into Factory design.
    { //the models, in this project, will have no knowledge of the context or how to interact with it. That is for the repo design to handle. 
        /// <summary>
        /// Contains the foreign key entities.
        /// </summary>
        private HashSet<Test2> _test2s;

        /// <summary>
        /// The id.
        /// </summary>
        public int Test1Id { get; private set; }
        /// <summary>
        /// The name.
        /// </summary>
        public string Test1Name { get; private set; }
        /// <summary>
        /// Other stuff
        /// </summary>
        public string Test1Other { get; private set; }
        /// <summary>
        /// The entities pointing to this entity.
        /// </summary>
        public IEnumerable<Test2> Test2s { get { return _test2s; } private set { _test2s = value.ToHashSet(); } }

        /// <summary>
        /// Constructor for model binding.
        /// </summary>
        private Test1() //private constructor for the context.
        {
        }

        /// <summary>
        /// Constructor for an entity with no foreignkeys pointing to it.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="other">Other stuff.</param>
        public Test1(int id, string name, string other)
        { //public constructor for developers.
            Test1Id = id;
            Test1Name = name;
            Test1Other = other;
            _test2s = new HashSet<Test2>();
        }
        /// <summary>
        /// Constructor for an entity with foreignkeys poiting to it.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="other">Other stuff.</param>
        /// <param name="test2s">The foreignkeys pointing to it.</param>
        public Test1(int id, string name, string other, HashSet<Test2> test2s)
        { //public constructor for developers.
            Test1Id = id;
            Test1Name = name;
            Test1Other = other;
            if (test2s == null)
                throw new ArgumentNullException(nameof(test2s));
            _test2s = test2s;
        }

        public Test1DTO GenerateDTO => new Test1DTO
        {
            Id = Test1Id,
            Other = Test1Other,
            Name = Test1Name,
            Test2s = _test2s.Select(t => new Test1DTO.Test2 { Id = t.Test2Id }).ToList(),
        };

        /// <summary>
        /// Update the name.
        /// </summary>
        /// <param name="newName">The new name.</param>
        public void UpdateName(string newName) { Test1Name = newName; }
        /// <summary>
        /// Update other stuff.
        /// </summary>
        /// <param name="newOther">The new other stuff.</param>
        public void UpdateOther(string newOther) { Test1Other = newOther; }
        /// <summary>
        /// Add a new foreignkey entity.
        /// </summary>
        /// <param name="test2">The foreignkey entity to add.</param>
        public void AddTest2(Test2 test2) { _test2s.Add(test2); }
        /// <summary>
        /// Remove a foreignkey entity.
        /// </summary>
        /// <param name="test2">The foreignkey entity to remove.</param>
        public void RemoveTest2(Test2 test2) { _test2s.Remove(test2); }
        /// <summary>
        /// Get a foreignkey entity via its <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the foreignkey entity.</param>
        /// <returns>The foreignkey entity if found else null.</returns>
        public Test2 GetTest2ViaId(string id) { return _test2s.FirstOrDefault(t => t.Test2Id == id); }

        public void UpdateFromDTO(Test1DTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Name) && dto.Name != Test1Name)
                UpdateName(dto.Name);
            if (!string.IsNullOrWhiteSpace(dto.Other) && dto.Other != Test1Other)
                UpdateOther(dto.Other);
            if (dto.Test2s != null)
                _test2s = dto.Test2s.Select(t => new Test2(t.Id)).ToHashSet();
        }
    }
}
