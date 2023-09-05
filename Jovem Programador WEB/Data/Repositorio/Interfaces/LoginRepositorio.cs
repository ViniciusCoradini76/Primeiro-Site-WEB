using Jovem_Programador_WEB.Models;

namespace Jovem_Programador_WEB.Data.Repositorio.Interfaces
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public LoginRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }
        public Login ValidarLogin(Login login)
        {
            return _bancoContexto.Login.FirstOrDefault(x => x.Usuario == login.Usuario && x.Senha == login.Senha);
        }
    }
}
