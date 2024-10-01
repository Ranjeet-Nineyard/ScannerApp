using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Xml.Linq;

namespace Scanner.Data
{
    public abstract class BaseDataAccess
    {
       
        private string dbName;
        private string tenant;
        protected IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;

        public BaseDataAccess(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public string TenantId => tenant ?? _httpContextAccessor?.HttpContext?.Request?.Headers["TenantId"].ToString();

        public string GetUserName()
        {
            
            var userString = _httpContextAccessor.HttpContext?.Items["UserName"];
            return userString?.ToString();
        }  

        public string GetConnectionString(bool isAdmin = false)
        {
            if (isAdmin ==true ||  TenantId==null)
            {
                return $"{_configuration["ConnectionStrings:Datavanced"]}".Replace("_DBNAME_", _configuration["ConnectionStrings:AdminDatabase"]);
            }
            else
            {
                if (dbName == null)
                {
                    if (!String.IsNullOrEmpty(TenantId))
                    {
                        dbName = GetTenantById(Convert.ToInt32(TenantId));

                    }
                }
                return $"{_configuration["ConnectionStrings:Datavanced"]}".Replace("_DBNAME_", dbName);
            }  
        }

        public string  GetTenantById(Int32 id)
        {
            String tenant = String.Empty;
            try
            {
                DbDataReader dataReader;
                List<DbParameter> parameterList = new List<DbParameter>();
                parameterList.Add(GetParameter("Id", id));
                using (DbConnection connection = this.GetConnection(true))
                {
                    using (DbCommand cmd = this.GetCommand(connection, "usp_GetTenantById", CommandType.StoredProcedure))
                    {
                        if (parameterList != null && parameterList.Count > 0)
                        {
                            cmd.Parameters.AddRange(parameterList.ToArray());
                        }
                        cmd.CommandTimeout = 0;
                        dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        if (dataReader != null && dataReader.HasRows)
                        {
                            if (dataReader.Read())
                            {
                                tenant = Convert.ToString(dataReader["name"] ?? "");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tenant;
        }


        protected DbConnection GetConnection(Boolean isAdmin = false)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString(isAdmin));
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }
        protected DbCommand GetCommand(DbConnection connection, String commandText, CommandType commandType)
        {
            SqlCommand command = new SqlCommand(commandText, connection as SqlConnection);
            command.CommandType = commandType;
            return command;
        }
        protected DbParameter GetParameter(String parameter, object value)
        {
            SqlParameter parameterObject = new SqlParameter(parameter, value != null ? value : DBNull.Value);
            parameterObject.Direction = ParameterDirection.Input;
            return parameterObject;
        }
    }
}
