using Lesson3_homework.Domain.Interface;
using Lesson3_homework.Model;
using Lesson3_homework.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3_homework.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _personManager.GetById(id);
            return Ok(result);
        }

        [HttpGet("search/{name}")]
        public IActionResult GetByName([FromRoute] string name)
        {
            var result = _personManager.GetByName(name);
            return Ok(result);
        }

        [HttpGet("skip/{skip}/take/{take}")]
        public IActionResult GetPagination([FromRoute] int skip, [FromRoute] int take)
        {
            var result = _personManager.GetPagination(skip, take);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PersonCreateRequest personDto)
        {
            var id = _personManager.Add(personDto);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Update( [FromBody] PersonUpdateRequest personDto)
        {
            var id = _personManager.Update(personDto);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var isDelete = _personManager.Delete(id);
            return Ok(isDelete);
        }
    }
}


//GET / persons /{ id} — получение человека по идентификатору
//GET /persons/search?searchTerm={term} — поиск человека по имени
//GET /persons/?skip={5}&take ={ 10} — получение списка людей с пагинацией
//POST /persons — добавление новой персоны в коллекцию
//PUT /persons — обновление существующей персоны в коллекции
//DELETE /persons/{id} — удаление персоны из коллекции

