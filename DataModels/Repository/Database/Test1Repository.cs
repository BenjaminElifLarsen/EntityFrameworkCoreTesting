using EntityFrameworkCoreTesting.DataModels.Interfaces.IRepository;
using EntityFrameworkCoreTesting.DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Repository.Database
{
    public class Test1Repository : ITest1Repository
    {
        private readonly AppDbContext _appDbContext;
        public Test1Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Test1> All => _appDbContext.Test1s
            .Include(t1 => t1.Test2s);

        public void Add(Test1 entity)
        {
            throw new NotImplementedException();
        }

        public Test1 GetById(int id)
        {
            return _appDbContext.Test1s
                .Include(t => t.Test2s)
                .FirstOrDefault(t => t.Test1Id == id);
        }

        public void Remove(Test1 entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Test1 entity)
        {
            _appDbContext.Test1s.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
