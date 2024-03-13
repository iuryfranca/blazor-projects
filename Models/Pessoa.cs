using System.ComponentModel.DataAnnotations.Schema;

namespace LearningBlazor.Models;

[Table("pessoa", Schema = "public")]
public class Pessoa
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string? Nome { get; set; }

    [Column("cpf")]
    public string? Cpf { get; set; }

    [Column("data_nascimento")]
    public DateTime? DataNascimento { get; set; }

    [Column("telefone")]
    public string? Telefone { get; set; }
}
