using CodeItAirlines.App.Pessoas.Interfaces;

namespace CodeItAirlines.App.Pessoas
{
    public abstract class Pessoa : IPessoa
    {
        public string Nome { get; set; }
    }
}
