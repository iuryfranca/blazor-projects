using System.ComponentModel.DataAnnotations.Schema;

namespace LearningBlazor.Models;

[Table("inscricao", Schema = "public")]
public class Inscricao
{
    [Column("id")]
    public int Id { get; set; }

    [Column("numero_insc")]
    public string NumeroInsc { get; set; }

    [Column("data_inscricao")]
    public DateTime DataInscricao { get; set; }

    [Column("nota_conh_gerais")]
    public double NotaConhGerais { get; set; }

    [Column("nota_conh_especificos")]
    public double NotaConhEspecificos { get; set; }

    [Column("candidato_id")]
    public int CandidatoId { get; set; }

    [Column("cargo_id")]
    public int CargoId { get; set; }

    // public Candidato Candidato { get; set; }

    // public Cargo Cargo { get; set; }
}
