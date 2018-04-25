using CodeItAirlines.App.Pessoas;
using CodeItAirlines.App.Pessoas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void EmbarcarTipulante(ITripulante tripulante)
        {
            if (tripulante is TripulanteTecnico)
                EmbarcarTripulanteTecnico((TripulanteTecnico)tripulante);

            if (tripulante is TripulanteCabine)
                EmbarcarTripulanteCabine((TripulanteCabine)tripulante);
        }

        private void EmbarcarTripulanteTecnico(TripulanteTecnico tripulante)
        {
            if (_tripulacaoTecnica.Count() == 3)
                throw new Exception("A capacidade máxima da tripulação técnica já foi atingida!");

            _tripulacaoTecnica.Add(tripulante);
        }

        private void EmbarcarTripulanteCabine(TripulanteCabine tripulante)
        {
            if (_tripulacaoCabine.Count() == 3)
                throw new Exception("A capacidade máxima da tripulação de cabine já foi atingida!");

            _tripulacaoCabine.Add(tripulante);
        }
    }
}
