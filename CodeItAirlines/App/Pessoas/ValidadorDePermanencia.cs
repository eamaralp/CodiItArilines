using CodeItAirlines.App.Pessoas.Exceptions;
using CodeItAirlines.App.Pessoas.Interfaces;
using System.Collections.Generic;

namespace CodeItAirlines.App.Pessoas
{
    public class ValidadorDePermanencia
    {
        private List<IPessoa> _listaDePessoas;

        public void Validar(List<IPessoa> listaDePessoas)
        {
            if (listaDePessoas.Count < 2)
                return;

            _listaDePessoas = listaDePessoas;

            if (listaDePessoas.Exists(x => x.GetType() == typeof(ChefeDeServico)))
                ValidarPermanenciaChefeDeServico();
            if (listaDePessoas.Exists(x => x.GetType() == typeof(Piloto)))
                ValidarPermanenciaPiloto();
            if (listaDePessoas.Exists(x => x.GetType() == typeof(Ladrao)))
                ValidarPermanenciaLadrao();

        }

        private void ValidarPermanenciaChefeDeServico()
        {
            if (_listaDePessoas.Exists(x => x.GetType() == typeof(ChefeDeServico)))
            {
                if (_listaDePessoas.Exists(x => x.GetType() != typeof(Oficial) && x.GetType() != typeof(ChefeDeServico)))
                    return;
                else
                    throw new ValidacaoException("O chefe de serviço não pode ficar sozinho com os oficiais!");
            }
        }

        private void ValidarPermanenciaPiloto()
        {
            if (_listaDePessoas.Exists(x => x.GetType() == typeof(Piloto)))
            {
                if (_listaDePessoas.Exists(x => x.GetType() != typeof(Comissaria) && x.GetType() != typeof(Piloto)))
                    return;
                else
                    throw new ValidacaoException("O piloto não pode ficar sozinho com as comissarias!");
            }
        }

        private void ValidarPermanenciaLadrao()
        {
            if (_listaDePessoas.Exists(x => x.GetType() == typeof(Ladrao)))
            {
                if (_listaDePessoas.Exists(x => x.GetType() == typeof(Policial)))
                    return;
                else
                    throw new ValidacaoException("O ladrão não pode ficar sozinho sem o policial!");
            }
        }
    }
}
