using LearningBlazor.Models;

namespace LearningBlazor.Context;

public class ContextDB
{
    public ContextDB()
    {
        Pessoas = new List<Pessoa>();
    }

    public List<Pessoa>? Pessoas { get; set; }
}
