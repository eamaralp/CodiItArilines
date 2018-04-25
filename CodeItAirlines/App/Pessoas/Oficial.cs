using CodeItAirlines.App.Pessoas.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
