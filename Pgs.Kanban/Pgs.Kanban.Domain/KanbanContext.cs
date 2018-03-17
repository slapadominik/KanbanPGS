using System;
using Microsoft.EntityFrameworkCore;
using Pgs.Kanban.Domain.Models;

namespace Pgs.Kanban.Domain
{
    public class KanbanContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PgsKanban;AttachDbFileName=C:\Users\Michal Walczynski\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\PgsKanban.mdf;Trusted_Connection=True;");
        }

        public DbSet<Board> Boards { get; set; } 

        public DbSet<List> Lists { get; set; }
    }
}