using CodeItAirlines.App.Pessoas;
using CodeItAirlines.App.Pessoas.Interfaces;
using System.Collections.Generic;

namespace CodeItAirlines.App
{
    public class SmartForTwo
    {
        private IMotorista motorista;
        private IPessoa passageiro;

        public void EmbarcarMotorista(IMotorista motorista)
        {
            this.motorista = motorista;
        }

        public void EmbarcarPassageiro(IPessoa passageiro)
        {
            this.passageiro = passageiro;
        }

        public IMotorista DesembarcarMotorista()
        {
            var motorista = this.motorista;

            this.motorista = null;

            return motorista;
        }

        public IPessoa DesembarcarPassageiro()
        {
            var passageiro = this.passageiro;

            this.passageiro = null;

            return passageiro;
        }

        public void ValidarEmbarqueSmartForTwo()
        {
            var listaDePessoasSmartForTwo = new List<IPessoa>
            {
                this.motorista,
                this.passageiro
            };

            new ValidadorDePermanencia().Validar(listaDePessoasSmartForTwo);
        }
    }
}
