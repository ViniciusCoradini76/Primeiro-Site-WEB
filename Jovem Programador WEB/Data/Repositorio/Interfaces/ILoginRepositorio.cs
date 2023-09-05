using Jovem_Programador_WEB.Models;

namespace Jovem_Programador_WEB.Data.Repositorio.Interfaces
{
    public interface ILoginRepositorio
    {
        Login ValidarLogin(Login login);
    }
}
