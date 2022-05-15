using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Data
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
               
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
