using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCounter.Server.Data;
using BlazorCounter.Server.Models;

namespace BlazorCounter.Server.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoSerController : ControllerBase
    {
        private readonly EventManagerDbContext _context;

        public TodoSerController(EventManagerDbContext context)
        {
            _context = context;
        }

        // GET: api/TodoSer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoSer>>> GetTodo()
        {
            return await _context.Todo.ToListAsync();
        }

        // GET: api/TodoSer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoSer>> GetTodoSer(int id)
        {
            var todoSer = await _context.Todo.FindAsync(id);

            if (todoSer == null)
            {
                return NotFound();
            }

            return todoSer;
        }

        // PUT: api/TodoSer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoSer(int id, TodoSer todoSer)
        {
            if (id != todoSer.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoSer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoSerExists(id))
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

        // POST: api/TodoSer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoSer>> PostTodoSer(TodoSer todoSer)
        {
            _context.Todo.Add(todoSer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoSer", new { id = todoSer.Id }, todoSer);
        }

        // DELETE: api/TodoSer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoSer(int id)
        {
            var todoSer = await _context.Todo.FindAsync(id);
            if (todoSer == null)
            {
                return NotFound();
            }

            _context.Todo.Remove(todoSer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoSerExists(int id)
        {
            return _context.Todo.Any(e => e.Id == id);
        }
    }
}
