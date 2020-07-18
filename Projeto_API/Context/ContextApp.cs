using Microsoft.EntityFrameworkCore;
using Projeto_API.Models;

namespace Projeto_API.Context
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente {get; set;}
    }
}