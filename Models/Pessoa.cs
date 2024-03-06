namespace LearningBlazor.Models;

public class Pessoa
{
    public string Nome { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }

    public double CalcularIMC()
    {
        return Peso / (Altura * Altura);
    }

    public string SituacaoIMC()
    {
        var imc = CalcularIMC();
        if (imc < 18.5)
        {
            return "Abaixo do peso";
        }
        else if (imc < 24.9)
        {
            return "Peso normal";
        }
        else if (imc < 29.9)
        {
            return "Sobrepeso";
        }
        else if (imc < 34.9)
        {
            return "Obesidade grau 1";
        }
        else if (imc < 39.9)
        {
            return "Obesidade grau 2";
        }
        else
        {
            return "Obesidade grau 3";
        }
    }
}
