using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LearningBlazor.Models;

[Table("inscricao", Schema = "dbo")]
public class Inscricao
{
    [Column("id")]
    public int Id { get; set; }

    [Column("numero_insc")]
    public int NumeroInsc { get; set; }

    [Column("data_inscricao")]
    public DateTime DataInscricao { get; set; }

    [Column("nota_conh_gerais")]
    public decimal NotaConhGerais { get; set; }

    [Column("nota_conh_especificos")]
    public decimal NotaConhEspecificos { get; set; }

    [Column("candidato_id")]
    public int CandidatoId { get; set; }

    [Column("cargo_id")]
    public int CargoId { get; set; }

    public Cargo? Cargo { get; set; }
    public Candidato? Candidato { get; set; }
}
