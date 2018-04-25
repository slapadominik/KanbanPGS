using System;
using Microsoft.EntityFrameworkCore;
using Pgs.Kanban.Domain.Models;

namespace Pgs.Kanban.Domain
{
    public class KanbanContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pgskanban2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Board> Boards { get; set; } 

        public DbSet<List> Lists { get; set; }

        public DbSet<Card> Cards { get; set; }
    }
}