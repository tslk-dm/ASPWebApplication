using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson3_homework.Data.Interface;
using Lesson3_homework.Domain.Interface;
using Lesson3_homework.Model;
using Lesson3_homework.Model.Dto;

namespace Lesson3_homework.Domain.Implamentation
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepo _personRepo;

        public PersonManager(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
            
        }

        public int Add(PersonCreateRequest personDto)
        {
            var person = new Person()
            {
                Id = _personRepo.GetNewId(),
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                Email = personDto.Email,
                Company = personDto.Company,
                Age = personDto.Age
            
            };
            _personRepo.Add(person);

            return person.Id;
        }

        public bool Delete(int id)
        {
            return _personRepo.Delete(id);
        }

        public Person GetById( int id)
        {
            return _personRepo.GetById(id);
        }

        public Person GetByName(string name)
        {
            return _personRepo.GetByName(name);
        }

        public IEnumerable<Person> GetPagination(int skip, int take)
        {
            return _personRepo.GetPagination(skip, take);
        }

        public int Update(PersonUpdateRequest personDto)
        {
            var id = _personRepo.GetIdForUpdate(personDto.FirstName, personDto.LastName);

            var person = new Person()
            {
                Id = id,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                Email = personDto.Email,
                Company = personDto.Company,
                Age = personDto.Age

            };

            _personRepo.Update(person);

            return person.Id;
        }
    }
}
