using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Interfaces
{
    interface IDtoHandlingEntity <ModelType>
    {
        public ModelType GenerateEntity { get; }
    }
}
