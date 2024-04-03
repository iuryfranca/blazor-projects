using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LearningBlazor.Models;

[Table("Candidato", Schema = "dbo")]
public class Candidato
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string? Nome { get; set; }

    [Column("cpf")]
    public string? Cpf { get; set; }

    [Column("data_nascimento")]
    public DateTime? DataNascimento { get; set; }

    public List<Inscricao>? Inscricoes { get; set; }
}
