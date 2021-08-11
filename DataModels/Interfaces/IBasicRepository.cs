using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Interfaces
{
    public interface IBasicRepository <ModelType, ModelId>
    {
        public void Update(ModelType entity);
        public void Add(ModelType entity);
        public void Remove(ModelType entity);
        public IEnumerable<ModelType> All { get; }
        public ModelType GetById(ModelId id); 

    }
}
