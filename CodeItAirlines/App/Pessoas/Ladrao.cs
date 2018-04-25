using CodeItAirlines.App.Pessoas.Interfaces;

namespace CodeItAirlines.App.Pessoas
{
    public class Ladrao : Pessoa, IPassageiro
    {
        public Ladrao()
        {
            Nome = "Ladrao";
        }
    }
}
