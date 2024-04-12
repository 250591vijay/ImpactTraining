using ImpactTraining.Models.Exceldo_Model;
using Microsoft.EntityFrameworkCore;

namespace ImpactTraining.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Customer>Customers { get; set; }
    }
}
