﻿using CodeItAirlines.App.Pessoas.Exceptions;
using CodeItAirlines.App.Pessoas.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CodeItAirlines.App.Pessoas
{
    public class ValidadorTripulacao
    {
        private List<IPessoa> _pessoas;

        public ValidadorTripulacao(List<IPessoa> pessoas)
        {
            _pessoas = pessoas;
        }

        public void Validar(IPessoa pessoa)
        {
            if(pessoa is ITripulanteTecnico)
                ValidarTripulacaoTecnica(pessoa);
            if (pessoa is ITripulanteCabine)
                ValidarTripulacaoDeCabine(pessoa);
        }


        private void ValidarTripulacaoTecnica(IPessoa pessoa)
        {
            if (!_pessoas.Any())
                return;

            var tripulacaoTecnica = _pessoas.Where(x => x is ITripulanteTecnico).ToList();

            if (tripulacaoTecnica.Count() == 3)
                throw new ValidacaoException("A capacidade máxima da tripulação técnica já foi atingida!");

            if(tripulacaoTecnica.Exists(x => x.GetType() == typeof(Piloto)) && pessoa is Piloto)
                throw new ValidacaoException("O piloto já embarcou na aeronave!");

            if (tripulacaoTecnica.Where(x => (x.GetType() == typeof(Oficial))).Count() ==  2 && pessoa is Oficial)
                throw new ValidacaoException("A aeronave possui capacidade máxima para dois Oficiais!");
        }

        private void ValidarTripulacaoDeCabine(IPessoa pessoa)
        {
            if (!_pessoas.Any())
                return;

            var tripulacaoCabine = _pessoas.Where(x => x is ITripulanteCabine).ToList();

            if (tripulacaoCabine.Count() == 3)
                throw new ValidacaoException("A capacidade máxima da tripulação técnica já foi atingida!");

            if (tripulacaoCabine.Exists(x => x.GetType() == typeof(ChefeDeServico)) && pessoa is ChefeDeServico)
                throw new ValidacaoException("O chefe de serviço já embarcou na aeronave!");

            if (tripulacaoCabine.Where(x => (x.GetType() == typeof(Comissaria))).Count() == 2 && pessoa is Comissaria)
                throw new ValidacaoException("A aeronave possui capacidade máxima para duas Comissárias!");
        }

    }
}
