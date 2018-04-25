using CodeItAirlines.App.Pessoas;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeItAirlines.App
{
    public class Tripulacao
    {
        private readonly List<TripulanteTecnico> _tripulacaoTecnica;
        private readonly List<TripulanteCabine> _tripulacaoCabine;

        public Tripulacao()
        {
            _tripulacaoTecnica = new List<TripulanteTecnico>();
            _tripulacaoCabine = new List<TripulanteCabine>();
        }

        public void AdicionarTripulanteTecnico(TripulanteTecnico tripulante)
        {
            _tripulacaoTecnica.Add(tripulante);
        }

    }
}
