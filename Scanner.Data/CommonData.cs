using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Scanner.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.Data
{
    public class CommonData : BaseDataAccess, ICommonData
    {

        public CommonData(IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(configuration, httpContextAccessor)
        {
        }

        private string tName;

        public string ConnectionString() => GetConnectionString();
        public string AdminConnectionString() => GetConnectionString(true);
        public string GetTenant()
        {
            throw new NotImplementedException();
        }

        public int GetTenantId()
        {
            throw new NotImplementedException();
        }
    }
}
