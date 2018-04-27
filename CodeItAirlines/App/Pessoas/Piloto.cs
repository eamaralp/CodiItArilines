using CodeItAirlines.App.Pessoas.Interfaces;

namespace CodeItAirlines.App.Pessoas
{
    public class Piloto : Pessoa, ITripulanteTecnico, IMotorista
    {
        public Piloto()
        {
            Nome = "Piloto";
        }
    }
}
