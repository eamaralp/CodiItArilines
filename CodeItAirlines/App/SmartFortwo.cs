using CodeItAirlines.App.Pessoas;
using CodeItAirlines.App.Pessoas.Interfaces;
using System.Collections.Generic;

namespace CodeItAirlines.App
{
    public class SmartForTwo
    {
        public IMotorista motorista { get; set; }
        public IPessoa passageiro { get; set; }

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

        public void TrocarConsutor()
        {
            var aux = this.motorista;
            this.motorista = this.passageiro as IMotorista;
            this.passageiro = aux;
        }

    }
}
