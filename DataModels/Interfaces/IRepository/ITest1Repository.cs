using EntityFrameworkCoreTesting.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Interfaces.IRepository
{
    public interface ITest1Repository : IBasicRepository<Test1,int>
    {
    }
}
