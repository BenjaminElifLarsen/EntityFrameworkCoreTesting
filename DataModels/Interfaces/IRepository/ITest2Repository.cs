using EntityFrameworkCoreTesting.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Interfaces.IRepository
{
    /// <summary>
    /// Interface for all Test2Repositories.
    /// </summary>
    public interface ITest2Repository : IBasicRepository<Test2, string>
    {
    }
}
