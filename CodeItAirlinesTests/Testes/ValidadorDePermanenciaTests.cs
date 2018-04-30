using CodeItAirlines.App.Pessoas;
using CodeItAirlines.App.Pessoas.Exceptions;
using CodeItAirlines.App.Pessoas.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CodeItAirlinesTests.Testes
{
    [TestFixture]
    public class ValidadorDePermanenciaTests
    {
        public List<IPessoa> _lista;

        [SetUp]
        public void SetUp()
        {
            _lista = new List<IPessoa>();
        }

        [Test]
        public void Deve_lancar_excecao_quando_chefe_de_servico_sozinho_com_oficial()
        {
            _lista.Add(new ChefeDeServico());
            _lista.Add(new Oficial());

            var excecao = Assert.Throws<ValidacaoException>(
                                () => new ValidadorDePermanencia().Validar(_lista));

            excecao.Message.Should().Be("O chefe de serviço não pode ficar sozinho com os oficiais!");
        }

        [Test]
        public void Deve_lancar_excecao_quando_piloto_sozinho_com_comissaria()
        {
            _lista.Add(new Piloto());
            _lista.Add(new Comissaria());

            var excecao = Assert.Throws<ValidacaoException>(
                    () => new ValidadorDePermanencia().Validar(_lista));

            excecao.Message.Should().Be("O piloto não pode ficar sozinho com as comissarias!");
        }

        [Test]
        public void Deve_lancar_excecao_quando_ladrao_sem_policial()
        {
            _lista.Add(new Ladrao());
            _lista.Add(new Comissaria());

            var excecao = Assert.Throws<ValidacaoException>(
                    () => new ValidadorDePermanencia().Validar(_lista));

            excecao.Message.Should().Be("O ladrão não pode ficar sozinho sem o policial!");
        }

    }
}
