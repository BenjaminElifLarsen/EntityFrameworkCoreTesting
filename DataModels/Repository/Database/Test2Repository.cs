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
        private readonly AppDbContext _appDbContext;
        public Test2Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Test2> All => _appDbContext.Test2s;

        public void Add(Test2 entity)
        {
            throw new NotImplementedException();
        }

        public Test2 GetById(string id)
        {
            return _appDbContext.Test2s.FirstOrDefault(t => t.Test2Id == id);
        }

        public void Remove(Test2 entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Test2 entity)
        {
            _appDbContext.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
