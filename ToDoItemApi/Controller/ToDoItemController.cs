using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoItem_Console;

namespace ToDoItemApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private IRepository _repository;
        public ToDoItemController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ToDoItem>>> QueryAsync(
            long id, bool? done)
        {
            var list = await _repository.QueryAsync(id, done);
            
            if (list.Count == 0)
            {
                return NotFound(new Dictionary<string, string>() { { "message", $"Can't find {id}" } });
            }
            return Ok(list);
        }
        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> QueryAllAsync()
        {
            var list = await _repository.QueryAllAsync();
            return Ok(list);
        }
        [HttpPost()]

        public async Task<ActionResult<ToDoItem>> CreateAsync([FromBody] ToDoItem toDoItem)
        {
            var model = await _repository.GetAsync(toDoItem.Id);
            if (model != null)
                return BadRequest(new Dictionary<string, string>() { { "message", "ToDoItem already exists." } });
            return Ok(toDoItem);
        }
    }
}
