using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Models
{
    public class Test3
    {
        private HashSet<Test2> _test2s;
        public string Test3Id { get; private set; }
        public IEnumerable<Test2> Test2s { get => _test2s; private set => _test2s.ToHashSet(); }
        private Test3()
        {

        }
        public Test3(string id, HashSet<Test2> test2s = null)
        {

        }
    }
}
