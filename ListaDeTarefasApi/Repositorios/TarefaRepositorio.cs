using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeTarefasApi.Data;
using ListaDeTarefasApi.Models;
using ListaDeTarefasApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefasApi.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly ListaDeTarefasContext _context;

        public TarefaRepositorio(ListaDeTarefasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefas(string titulo, bool? finalizada)
        {
            var tarefas = _context.Tarefas.AsQueryable();

            if (!string.IsNullOrEmpty(titulo))
            {
                tarefas = tarefas.Where(t => t.Titulo.Contains(titulo));
            }

            if (finalizada.HasValue)
            {
                tarefas = tarefas.Where(t => t.Finalizada == finalizada.Value);
            }

            return await tarefas.ToListAsync();
        }

        public async Task<Tarefa> ObterTarefa(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task<Tarefa> AdicionarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> AtualizarTarefa(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<bool> ExcluirTarefa(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return false;
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
