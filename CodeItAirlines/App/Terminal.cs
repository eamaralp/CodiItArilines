using CodeItAirlines.App.Pessoas;
using System;
using System.Collections.Generic;

namespace CodeItAirlines.App
{
    public class Terminal
    {
        private readonly List<Pessoa> _passageiros;

        public Terminal()
        {
            _passageiros = new List<Pessoa>();
        }

        public void AdicionarPassageiro(Pessoa passageiro)
        {
            _passageiros.Add(passageiro);
        }

        public void RemoverPassageiro(Pessoa passageiro)
        {

        }
    }
}
