using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class ToDoListDataContext : DbContext
    {
        public ToDoListDataContext(DbContextOptions<ToDoListDataContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        virtual public DbSet<ToDoTask> ToDoTasks { get; set; }


    }
}
