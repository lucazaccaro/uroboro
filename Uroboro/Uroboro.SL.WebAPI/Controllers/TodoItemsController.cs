using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uroboro.Common.Models;
using Uroboro.SL.WebAPI.Models;

namespace Uroboro.SL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : Controller
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var todoItems = await _context.TodoItems.ToListAsync();
            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<TodoItem>> Create([Bind("Id,Name,IsComplete")] TodoItem todoItem)
        {
            if (todoItem == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = todoItem.Id }, todoItem);               
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(long id, [Bind("Id,Name,IsComplete")] TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemExists(todoItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(todoItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = await _context.TodoItems.FindAsync(id);
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return Ok(id);
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
