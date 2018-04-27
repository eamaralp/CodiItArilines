using CodeItAirlines.App.Pessoas.Interfaces;

namespace CodeItAirlines.App.Pessoas
{
    public class ChefeDeServico : Pessoa, ITripulanteCabine, IMotorista
    {
        public ChefeDeServico()
        {
            Nome = "Chefe de Serciço";
        }
    }
}
