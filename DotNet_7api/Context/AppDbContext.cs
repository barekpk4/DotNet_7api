using Dapper.ORM;
using System.Configuration;

namespace DotNet_7api.Context
{
    public class AppDbContext : DapperContext
    {
        public AppDbContext(IConfiguration configuration) : base(configuration.GetConnectionString("DotNet7"))
        {

        }



    }
}
