using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DapperContext 
    {
        private readonly IConfiguration configuration;
        private readonly string connection;

        public DapperContext(IConfiguration configuration, string connection)
        {
            this.configuration = configuration;
            this.connection = connection;
        }

        public IDbConnection CreateConnection() => new SqlConnection(this.connection);
    }
}
