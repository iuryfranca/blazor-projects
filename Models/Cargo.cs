using System.ComponentModel.DataAnnotations.Schema;

namespace LearningBlazor.Models;

[Table("cargo", Schema = "public")]
public class Cargo
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nome_cargo")]
    public string NomeCargo { get; set; } = "";

    [Column("edital")]
    public string Edital { get; set; } = "";

    [Column("salario_base")]
    public double SalarioBase { get; set; }
}
