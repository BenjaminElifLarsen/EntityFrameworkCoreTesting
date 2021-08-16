using EntityFrameworkCoreTesting.DataModels.Interfaces.IRepository;
using EntityFrameworkCoreTesting.DataModels.Models;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Test2> AllNoTracking => _appDbContext.Test2s.AsNoTracking();

        public void Add(Test2 entity)
        {
            _appDbContext.Test2s.Add(entity);
            _appDbContext.SaveChanges();
        }

        public Test2 GetById(string id)
        {
            return _appDbContext.Test2s.Include(t => t.Test1).FirstOrDefault(t => t.Test2Id == id);
        }

        public Test2 GetByIdNoTracking(string id)
        {
            return _appDbContext.Test2s.Include(t => t.Test1).AsNoTracking().FirstOrDefault(t => t.Test2Id == id);
        }

        public void Remove(Test2 entity)
        {
            _appDbContext.Test2s.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void Update(Test2 entity)
        {
            _appDbContext.Update(entity);
            _appDbContext.SaveChanges();
        }
    }
}
