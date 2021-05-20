using Lesson3_homework.Model;
using Lesson3_homework.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3_homework.Domain.Interface
{
    public interface IPersonManager
    {
        Person GetById(int id);
        Person GetByName(string name);
        IEnumerable<Person> GetPagination(int skip, int take);
        int Add(PersonCreateRequest person);
        int Update(PersonUpdateRequest person);
        bool Delete(int id);
    }
}
