using CodeItAirlines.App.Pessoas.Interfaces;

namespace CodeItAirlines.App.Pessoas
{
    public class Policial : Pessoa, IMotorista
    {
        public Policial()
        {
            Nome = "Policial";
        }
    }
}
