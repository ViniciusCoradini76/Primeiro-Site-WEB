using Jovem_Programador_WEB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Jovem_Programador_WEB.Data.Mapeamento
{
    public class LoginMapeamento : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Login");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Usuario).HasColumnType("varchar(100)");

            builder.Property(t => t.Senha).HasColumnType("varchar(100)");

        }
    }
}
