using Microsoft.EntityFrameworkCore;
using REM_POD_App.files;
using System.Collections.Generic;

namespace REM_POD_App.DBcontext
{
    public class REMcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Secret.GetConnectionString);
        }
        public virtual DbSet<Model> Models
        {
            get; set;
        }
    }
}
