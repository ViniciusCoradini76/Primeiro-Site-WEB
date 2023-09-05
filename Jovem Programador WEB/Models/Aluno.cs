using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Jovem_Programador_WEB.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Matricula { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Cep { get; set; }
    }
}
