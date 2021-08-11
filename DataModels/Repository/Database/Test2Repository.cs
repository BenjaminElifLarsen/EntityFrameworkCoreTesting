using EntityFrameworkCoreTesting.DataModels.Interfaces.IRepository;
using EntityFrameworkCoreTesting.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Repository.Database
{
    public class Test2Repository : ITest2Repository
    {
        public IEnumerable<Test2> All => throw new NotImplementedException();

        public void Add(Test2 entity)
        {
            throw new NotImplementedException();
        }

        public Test2 GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Test2 entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Test2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
