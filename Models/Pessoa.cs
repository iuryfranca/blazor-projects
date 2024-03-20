using System.ComponentModel.DataAnnotations.Schema;

namespace LearningBlazor.Models;

[Table("pessoas")]
public class Pessoa
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string? Nome { get; set; }

    [Column("cpf")]
    public string? Cpf { get; set; }

    [Column("data_nasc")]
    public DateTime? DataNasc { get; set; }

    [Column("telefone")]
    public string? Telefone { get; set; }

    public List<Propriedade>? Propriedades { get; set; }
}
