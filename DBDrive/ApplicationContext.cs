using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBDrive
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // гарантируем, что БД создана
        }
 //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 //     {
 //         optionsBuilder.UseSqlite("Data Source=F:\\sqlite\\helloapp.db");
 //     }
    }
}
