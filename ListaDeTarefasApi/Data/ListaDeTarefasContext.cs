using ListaDeTarefasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefasApi.Data
{
    public class ListaDeTarefasContext : DbContext
    {
        public ListaDeTarefasContext(DbContextOptions<ListaDeTarefasContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
