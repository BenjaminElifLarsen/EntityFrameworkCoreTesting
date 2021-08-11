using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Interfaces
{
    public interface IDtoHandling <DtoType>
    {
        public DtoType GenerateDTO { get; }
        public void UpdateFromDTO(DtoType dto);
    }
}
