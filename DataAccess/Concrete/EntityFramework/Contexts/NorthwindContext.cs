using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=coinodb-dev.cjq6i1xxy6zz.eu-central-1.rds.amazonaws.com;Database=pubs;Uid=sa;Password=DtzsCI3HF9n4WIX7O3dj6SSdC43PdpwpMtcaXtDlj8TJy3KDSJ;TrustServerCertificate=True"
);      
                
        }
        public DbSet<Stor> stores { get; set; }
        public DbSet<Authors> authors { get; set; }
        public DbSet<OperationClaims> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOpClaims> UserOperationClaims { get; set; }
    }
}
