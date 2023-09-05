﻿using Jovem_Programador_WEB.Data.Repositorio.Interfaces;
using Jovem_Programador_WEB.Models;

namespace Jovem_Programador_WEB.Data.Repositorio
{

        public class AlunoRepositorio : IAlunoRepositorio
        {

            private readonly BancoContexto _bancoContexto;

            public AlunoRepositorio (BancoContexto bancoContexto)
            {
                _bancoContexto = bancoContexto;
            }

            public List<Aluno> BuscarAlunos()
            {
                return _bancoContexto.Aluno.ToList();
            }
            public void InserirAluno(Aluno aluno)
            {
                _bancoContexto.Aluno.Add(aluno);
                _bancoContexto.SaveChanges();
             } 
            public void EditarAluno(Aluno aluno)
            {
                _bancoContexto.Aluno.Update(aluno);
                _bancoContexto.SaveChanges();
            }
        public void ExcluirAluno(int id)
        {
            var aluno = _bancoContexto.Aluno.FirstOrDefault(a => a.Id == id);
            if (aluno != null)
            {
                _bancoContexto.Aluno.Remove(aluno);
                _bancoContexto.SaveChanges();
            }
        }
        public Aluno BuscarId(int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(x => x.Id == id);
        }

       
    }

}
