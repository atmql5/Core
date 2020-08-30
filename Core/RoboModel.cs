using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    partial class RoboContext : DbContext
    {
        public DbSet<Solution> Solutions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=/db/robodb.db");
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    this.SolutionMapping(modelBuilder);
        //    this.CustomizeSolutionMapping(modelBuilder);
        //}
        //partial void CustomizeSolutionMapping(ModelBuilder modelBuilder);
        //private void SolutionMapping(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Solution>().ToTable(@"Solution");
        //    modelBuilder.Entity<Solution>().Property(x => x.Id).HasColumnName(@"Id").HasColumnType(@"INTEGER").IsRequired().ValueGeneratedOnAdd();
        //}
    }

    class Solution
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Header { get; set; }
        public int Type { get; set; }
        public int? Pid { get; set; }
        public int? Lft { get; set; }
        public int? Rgt { get; set; }
        public string Descriptions { get; set; }
    }
}
