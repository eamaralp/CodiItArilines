using CodeItAirlines.App.Pessoas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeItAirlines.App.Pessoas
{
    public class ChefeDeServico : TripulanteCabine, IMotorista
    {
        public ChefeDeServico()
        {
            Nome = "Chefe de Serciço";
        }
    }
}
