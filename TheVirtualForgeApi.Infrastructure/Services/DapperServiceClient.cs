using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace TheVirtualForgeApi.Infrastructure.Services
{
    public class DapperServiceClient
    {
        private readonly string configurationString;

        public DapperServiceClient(IConfiguration configuration)
        {
            this.configurationString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<T>> ExecuteAsync<T>(string strquery, DynamicParameters parameters) where T:class
        {
            return await Task.Run(async () => {
                using (var conn=new SqlConnection(configurationString))
                {
                    conn.Open();
                    var response = await conn.QueryAsync<T>(strquery, parameters,commandTimeout:20000);
                    return response.ToList();
                }
            });
        }
        public async Task<int> ExecuteSingleAsync(string strquery, DynamicParameters parameters) 
        {
            return await Task.Run(async () => {
                using (var conn = new SqlConnection(configurationString))
                {
                    var response = await conn.ExecuteAsync(strquery, parameters);
                    return response ;
                }
            });
        }
    }
}
