using CodeItAirlines.App.Pessoas;
using CodeItAirlines.App.Pessoas.Exceptions;
using CodeItAirlines.App.Pessoas.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodeItAirlinesTests.Testes
{
    [TestFixture]
    public class ValidadorTripulacaoTests
    {
        public List<IPessoa> _lista;

        [SetUp]
        public void SetUp()
        {
            _lista = new List<IPessoa>();
        }

        [Test]
        public void Deve_lancar_excecao_quando_embarque_mais_de_um_piloto()
        {
            _lista.Add(new Piloto());

            var excecao = Assert.Throws<ValidacaoException>(
                                () => new ValidadorTripulacao(_lista).Validar(new Piloto()));

            excecao.Message.Should().Be("O piloto já embarcou na aeronave!");
        }

        [Test]
        public void Deve_lancar_excecao_quando_embarque_mais_de_dois_oficiais()
        {
            _lista.Add(new Oficial());
            _lista.Add(new Oficial());

            var excecao = Assert.Throws<ValidacaoException>(
                                () => new ValidadorTripulacao(_lista).Validar(new Oficial()));

            excecao.Message.Should().Be("A aeronave possui capacidade máxima para dois Oficiais!");
        }

        [Test]
        public void Deve_lotacao_tripulacao_tecnica_atingida()
        {
            _lista.Add(new Piloto());
            _lista.Add(new Oficial());
            _lista.Add(new Oficial());

            var excecao = Assert.Throws<ValidacaoException>(
                                () => new ValidadorTripulacao(_lista).Validar(new Piloto()));

            excecao.Message.Should().Be("A capacidade máxima da tripulação técnica já foi atingida!");
        }


        [Test]
        public void Deve_lancar_excecao_quando_embarque_mais_de_um_chefe_de_servico()
        {
            _lista.Add(new ChefeDeServico());

            var excecao = Assert.Throws<ValidacaoException>(
                                () => new ValidadorTripulacao(_lista).Validar(new ChefeDeServico()));

            excecao.Message.Should().Be("O chefe de serviço já embarcou na aeronave!");
        }

        [Test]
        public void Deve_lancar_excecao_quando_embarque_mais_de_duas_comissarias()
        {
            _lista.Add(new Comissaria());
            _lista.Add(new Comissaria());

            var excecao = Assert.Throws<ValidacaoException>(
                                () => new ValidadorTripulacao(_lista).Validar(new Comissaria()));

            excecao.Message.Should().Be("A aeronave possui capacidade máxima para duas Comissárias!");
        }

        [Test]
        public void Deve_lotacao_tripulacao_de_cabine_atingida()
        {
            _lista.Add(new ChefeDeServico());
            _lista.Add(new Comissaria());
            _lista.Add(new Comissaria());

            var excecao = Assert.Throws<ValidacaoException>(
                                () => new ValidadorTripulacao(_lista).Validar(new Comissaria()));

            excecao.Message.Should().Be("A capacidade máxima da tripulação técnica já foi atingida!");
        }


    }
}
