using Microsoft.EntityFrameworkCore;

namespace Maxim_Cazacu_Lab5.Models
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options)
        : base(options)
        {
        }
        public DbSet<Expenses> Expense { get; set; }
        public DbSet<ExpenseDTO> ExpenseDTO { get; set; }

    }
}
