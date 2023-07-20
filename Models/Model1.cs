using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVC_Dropdown.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tbl_user> tbl_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_user>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
