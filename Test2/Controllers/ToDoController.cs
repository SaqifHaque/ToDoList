using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test2.Models;



namespace Test2.Controllers
{
    [EnableCors]
    [Route("api/ToDo")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ToDoListDataContext context;
        public ToDoController(ToDoListDataContext context)
        {
            this.context = context;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var tasks = context.ToDoTasks.ToList();
            var descendingOrder = tasks.OrderByDescending(i => i.Id);
            return Ok(descendingOrder);
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public IActionResult Get(int id)
        {
            var tasks = context.ToDoTasks.Find(id);
            return Ok(tasks);
            
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDoTask task)
        {
            task.Status = false;
            context.ToDoTasks.Add(task);
            context.SaveChanges();
            string url = Url.Link("GetTaskById", new { id = task.Id });
            return Created(url, task);
        }
      

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ToDoTask task)
        {
            context.Entry(task).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            context.ToDoTasks.Remove(context.ToDoTasks.Find(id));
            context.SaveChanges();
            return Ok();

        }

    }
}
