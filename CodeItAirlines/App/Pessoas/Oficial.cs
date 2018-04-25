using CodeItAirlines.App.Pessoas.Interfaces;

namespace CodeItAirlines.App.Pessoas
{
    public class Oficial : TripulanteTecnico, IPassageiro
    {
        public Oficial()
        {
            Nome = "Oficial";
        }
    }
}
