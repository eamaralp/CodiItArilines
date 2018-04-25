using CodeItAirlines.App.Pessoas;
using CodeItAirlines.App.Pessoas.Interfaces;
using System;
using System.Collections.Generic;

namespace CodeItAirlines.App
{
    public class SmartForTwo
    {
        private IMotorista motorista;
        private Pessoa passageiro;

        public void Embarcar(IMotorista motorista, Pessoa passageiro)
        {
            ValidarEmbarque(motorista, passageiro);
            this.motorista = motorista;
            this.passageiro = passageiro;
        }

        private void ValidarEmbarque(IMotorista motorista, Pessoa passageiro)
        {
            if (passageiro is Ladrao && !(motorista is Policial))
            {
                throw new Exception("O Ladrão só pode ser transportado pelo policial!");
            }                
        }
    }
}
