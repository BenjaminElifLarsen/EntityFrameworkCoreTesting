using EntityFrameworkCoreTesting.DataModels.Interfaces.IRepository;
using EntityFrameworkCoreTesting.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Repository.Database
{
    public class Test1Repository : ITest1Repository
    {
        public IEnumerable<Test1> All => throw new NotImplementedException();

        public void Add(Test1 entity)
        {
            throw new NotImplementedException();
        }

        public Test1 GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Test1 entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Test1 entity)
        {
            throw new NotImplementedException();
        }
    }
}
