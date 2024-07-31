public class CandidatoInscrito
{
    public string Nome { get; set; } = "";

    public string Cpf { get; set; } = "";

    public DateTime DataNascimento { get; set; }

    public string NumeroInsc { get; set; }

    public DateTime DataInscricao { get; set; }

    public double NotaConhGerais { get; set; }

    public double NotaConhEspecificos { get; set; }

    public double MediaDeNotas { get; set; }
}
