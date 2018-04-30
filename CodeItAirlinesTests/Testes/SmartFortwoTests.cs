using CodeItAirlines.App;
using CodeItAirlines.App.Pessoas;
using FluentAssertions;
using NUnit.Framework;

namespace CodeItAirlines.Testes
{
    [TestFixture]
    public class SmartForTwoTests
    {
        private SmartForTwo smartForTwo;

        [SetUp]
        public void SetUp()
        {
            smartForTwo = new SmartForTwo();
        }

        [Test]
        public void Deve_embarcar_motorista_no_smartForTwo()
        {
            smartForTwo.EmbarcarMotorista(new Piloto());

            (smartForTwo.DesembarcarMotorista() is Piloto).Should().BeTrue();
            smartForTwo.DesembarcarPassageiro().Should().BeNull();
        }

        [Test]
        public void Deve_embarcar_motorista_e_passageiro_no_smartForTwo()
        {
            smartForTwo.EmbarcarMotorista(new Piloto());
            smartForTwo.EmbarcarPassageiro(new Oficial());

            (smartForTwo.DesembarcarMotorista() is Piloto).Should().BeTrue();
            (smartForTwo.DesembarcarPassageiro() is Oficial).Should().BeTrue();
        }

        [Test]
        public void Deve_embarcar_passageiro_no_smartForTwo()
        {
            smartForTwo.EmbarcarPassageiro(new Oficial());

            smartForTwo.DesembarcarMotorista().Should().BeNull();
            (smartForTwo.DesembarcarPassageiro() is Oficial).Should().BeTrue();
        }

    }
}
