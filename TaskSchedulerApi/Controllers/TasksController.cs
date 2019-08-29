using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskSchedulerApi.Models;

namespace TaskSchedulerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks()
        {
            var tasks = await _context.Tarefas.ToListAsync();

            return tasks;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> GetTask(long id)
        {
            var task = await _context.Tarefas.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Models.Task>> PostTask(Models.Task task)
        {
            _context.Tarefas.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(long id, Models.Task task)
        {
            if (id != task.Id)
                return BadRequest();

            _context.Entry(task).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Task>> DeleteTask(long id)
        {
            var task = await _context.Tarefas.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        private bool TaskExists(long id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
