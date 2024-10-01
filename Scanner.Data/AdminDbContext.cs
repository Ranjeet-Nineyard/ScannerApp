using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Scanner.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.Data
{
    public class AdminDbContext : DbContext
    {

        private readonly ICommonData commonData;
        private readonly string connectionString;

        public AdminDbContext(ICommonData commonData): base()
        {
            this.commonData = commonData;
        }
        public AdminDbContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString ?? this.commonData.AdminConnectionString(),
                opts =>
                {
                    opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                    opts.EnableRetryOnFailure(maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                });
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<object> Admin { get; set; }



    }
}
