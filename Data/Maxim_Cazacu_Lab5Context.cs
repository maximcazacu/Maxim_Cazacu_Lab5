using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Maxim_Cazacu_Lab5.Models;

namespace Maxim_Cazacu_Lab5.Data
{
    public class Maxim_Cazacu_Lab5Context : DbContext
    {
        public Maxim_Cazacu_Lab5Context (DbContextOptions<Maxim_Cazacu_Lab5Context> options)
            : base(options)
        {
        }

        public DbSet<Maxim_Cazacu_Lab5.Models.Expenses> Expenses { get; set; } = default!;
        public object ExpenseDTO { get; internal set; }
    }
}
