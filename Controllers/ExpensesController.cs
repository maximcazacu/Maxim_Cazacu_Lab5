using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Maxim_Cazacu_Lab5.Data;
using Maxim_Cazacu_Lab5.Models;

namespace Maxim_Cazacu_Lab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly Maxim_Cazacu_Lab5Context _context;

        public ExpensesController(Maxim_Cazacu_Lab5Context context)
        {
            _context = context;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetExpenses()
        {
            return await _context.ExpenseDTO.ToListAsync();
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDTO>> GetExpenses(int id)
        {
            var expenses = await _context.ExpenseDTO.FindAsync(id);

            if (expenses == null)
            {
                return NotFound();
            }

            return expenses;
        }

        // PUT: api/Expenses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenses(int id, Expenses expenses)
        {
            if (id != expenses.Id)
            {
                return BadRequest();
            }

            _context.Entry(expenses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpensesExists(id))
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

        // POST: api/Expenses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Expenses>> PostExpenses(Expenses expenses)
        {
            _context.Expenses.Add(expenses);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpenses), new { id = expenses.Id }, expenses);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenses(int id)
        {
            var expenses = await _context.Expenses.FindAsync(id);
            if (expenses == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expenses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpensesExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
