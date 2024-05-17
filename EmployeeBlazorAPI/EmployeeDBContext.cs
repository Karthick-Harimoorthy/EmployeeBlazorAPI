using Microsoft.EntityFrameworkCore;

namespace EmployeeBlazorAPI
{
    public class EmployeeDBContext :DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EmployeeData> EmployeeDatas { get; set; }
    }
}
