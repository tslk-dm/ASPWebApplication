using Lesson3_homework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3_homework.Data.Interface
{
     public interface IPersonRepo
    {
        Person GetById(int id);
        Person GetByName(string name);
        IEnumerable<Person> GetPagination(int skip, int take);
        void Add(Person person);
        void Update(Person person);
        bool Delete(int id);

        int GetNewId();
        int GetIdForUpdate(string firstName, string lastName);
    }
}
