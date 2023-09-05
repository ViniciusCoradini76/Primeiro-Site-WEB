using Jovem_Programador_WEB.Models;

namespace Jovem_Programador_WEB.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();
        void EditarAluno(Aluno aluno);
        void InserirAluno(Aluno aluno);
        void ExcluirAluno(int id);
        Aluno BuscarId(int id);


    }
}
