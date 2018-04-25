using CodeItAirlines.App.Pessoas.Interfaces;

namespace CodeItAirlines.App.Pessoas
{
    public class Comissaria : TripulanteCabine, IPassageiro
    {
        public Comissaria()
        {
            Nome = "Comissaria";
        }
    }
}
