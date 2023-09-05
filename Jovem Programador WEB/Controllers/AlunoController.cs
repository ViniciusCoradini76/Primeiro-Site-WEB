using Jovem_Programador_WEB.Data.Repositorio.Interfaces;
using Jovem_Programador_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Jovem_Programador_WEB.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IConfiguration configuration, IAlunoRepositorio alunoRepositorio)
        {
            _configuration = configuration;
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Index()
        {
            var aluno = _alunoRepositorio.BuscarAlunos();
            return View(aluno);
        }
        public IActionResult adicionar()
        {
            return View();
        }

        public IActionResult InserirAluno (Aluno aluno)
        {
            try
            {
                _alunoRepositorio.InserirAluno(aluno);
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao inserir aluno";
            }
            TempData["MsgSucesso"] = "Aluno adicionado com sucesso";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();

            try
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });
                }
                else
                {
                    ViewData["MsgErro"] = "Erro na busca do endereço!";
                }

            }
            catch (Exception)
            {
                throw;
            }

            return View("Endereco", endereco);
        }
        public IActionResult Editar(int id)
        {
            var aluno = _alunoRepositorio.BuscarId(id);
            return View(aluno);
        }


        public IActionResult EditarAluno(Aluno aluno)
        {
            _alunoRepositorio.EditarAluno(aluno);
            return RedirectToAction("Index");
        }
        public IActionResult ExcluirAluno(int id)
        {
            try
            {
                _alunoRepositorio.ExcluirAluno(id);
                TempData["MsgSucesso"] = "Aluno excluído com sucesso";
            }
            catch (Exception ex)
            {
                TempData["MsgErro"] = "Erro ao excluir aluno";
            }

            return RedirectToAction("Index");
        }


    }
}
