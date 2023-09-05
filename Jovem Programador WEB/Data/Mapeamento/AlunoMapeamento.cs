using Jovem_Programador_WEB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Jovem_Programador_WEB.Data.Mapeamento
{
    public class AlunoMapeamento : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasColumnType("varchar(50)");
            
            builder.Property(t => t.Idade).HasColumnType("int");
           
            builder.Property(t => t.Matricula).HasColumnType("varchar(50)");
            
            builder.Property(t => t.DataNascimento).HasColumnType("Date");



        }
    }
}
