using CodeItAirlines.App.Pessoas;
using CodeItAirlines.App.Pessoas.Interfaces;
using System.Collections.Generic;

namespace CodeItAirlines.App
{
    public class SmartForTwo
    {
        private IMotorista motorista;
        private IPassageiro passageiro;

        public bool Embarcar(IMotorista motorista, IPassageiro passageiro)
        {
            ValidarEmbarqueSmartForTwo(motorista, passageiro);
            this.motorista = motorista;
            this.passageiro = passageiro;

            return true;
        }

        private void ValidarEmbarqueSmartForTwo(IMotorista motorista, IPassageiro passageiro)
        {
            var listaDePessoasSmartForTwo = new List<IPessoa>
            {
                motorista,
                passageiro
            };

            new ValidadorDePermanencia().Validar(listaDePessoasSmartForTwo);
        }
    }
}
