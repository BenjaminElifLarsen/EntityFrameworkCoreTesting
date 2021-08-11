using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreTesting.DataModels.Models
{
    public class Test1 //Domain-Driven Design. Lookin also into Factory design.
    { //the models, in this project, will have no knowledge of the context or how to interact with it. That is for the repo design to handle. 
        private Test1() //private constructor for the context.
        {
            //_test2s = new HashSet<Test2>(); //not sure if this one is needed or not, test it
        }

        public Test1(int id, string name, string other)
        { //public constructor for developers.
            Test1Id = id;
            Test1Name = name;
            Test1Other = other;
            _test2s = new HashSet<Test2>();
        }
        private HashSet<Test2> _test2s;
        public int Test1Id { get; private set; }
        public string Test1Name { get; private set; }
        public string Test1Other { get; private set; }
        public IEnumerable<Test2> Test2s { get { return _test2s; } private set { _test2s = value.ToHashSet(); } }
        
        public void UpdateName(string newName) { Test1Name = newName; }
        public void UpdateOther(string newOther) { Test1Other = newOther; }
        public void AddTest2(Test2 test2) { _test2s.Add(test2); }
        public void RemoveTest2(Test2 test2) { _test2s.Remove(test2); }
        public Test2 GetTest2ViaId(string id) { return _test2s.FirstOrDefault(t => t.Test2Id == id); }
    }
}
