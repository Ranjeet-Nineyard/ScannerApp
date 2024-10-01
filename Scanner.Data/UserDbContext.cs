using Microsoft.EntityFrameworkCore;
using Scanner.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.Data
{
    public class UserDbContext : DbContext
    {
        private readonly ICommonData commonData;
        private readonly string connectionString;

        public UserDbContext(ICommonData commonData) : base()
        {
            this.commonData = commonData;
        }
        public UserDbContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString ?? this.commonData.ConnectionString(),
                opts =>
                {
                    opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                    opts.EnableRetryOnFailure(maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                });
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<object> User { get; set; }
    }
}
