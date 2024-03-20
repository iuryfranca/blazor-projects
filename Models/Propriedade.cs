using System.ComponentModel.DataAnnotations.Schema;

namespace LearningBlazor.Models;

[Table("propriedade")]
public class Propriedade
{
    [Column("id")]
    public int Id { get; set; }

    [Column("descricao")]
    public string? Descricao { get; set; }

    [Column("valor")]
    public Double? Valor { get; set; }

    [Column("id_pessoa")]
    public DateTime? IdPessoa { get; set; }

    [ForeignKey("IdPessoa")]
    public Pessoa? Pessoa { get; set; }
}
