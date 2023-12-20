using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API_Panificadora.Models
{
    public class ToDoContextFactory : IDesignTimeDbContextFactory<AppContexto>
    {
        public AppContexto CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppContexto>();
            builder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=PANIFICADORADB;Integrated Security=True;TrustServerCertificate=True");
            return new AppContexto(builder.Options);
        }
    }
}
