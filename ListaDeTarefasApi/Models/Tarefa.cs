using System;
using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefasApi.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        public bool Finalizada { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
