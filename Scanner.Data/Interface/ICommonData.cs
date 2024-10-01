using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.Data.Interface
{
    public interface ICommonData
    {
        string GetTenant();
        int GetTenantId();
        string ConnectionString();
        string AdminConnectionString();
    }
}
