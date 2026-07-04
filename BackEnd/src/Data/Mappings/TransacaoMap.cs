using BackEnd.src.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.src.Data.Mappings;

/// <summary>
/// Configuração de mapeamento da entidade Transacao.
/// </summary>
public class TransacaoMap : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Descricao)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(t => t.Valor)
            .HasPrecision(10, 2);

        builder.HasOne(t => t.Pessoa)
            .WithMany(p => p.Transacoes)
            .HasForeignKey(t => t.PessoaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}